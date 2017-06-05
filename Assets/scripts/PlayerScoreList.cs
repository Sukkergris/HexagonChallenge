using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerScoreList : MonoBehaviour
{
	public GameObject playerEntryPrefab;

	ScoreBoard scoreboard;

	List<GoPlayerTuple> playerScores;
	List<Player> players;

	void Awake()
	{
		scoreboard = GameObject.FindObjectOfType<ScoreBoard>();
	}

	void Update()
	{
		if (scoreboard == null) 
		{
			Debug.Log ("No scoreboard found attached to any gameobject");
			return;
		}

		if (players != scoreboard.GetPlayerSorted()) {
			while (this.transform.childCount > 0) 
			{
				GameObject c = this.transform.GetChild (0).gameObject;
				c.transform.SetParent (null); //Become Batman
				Destroy (c);
			}

			SetUp ();
		}

		UpdateScoreBoard ();

	}

	private void UpdateScoreBoard ()
	{
		foreach (GoPlayerTuple go in playerScores) 
		{
			Player player = go.Player;
			go.Go.transform.Find ("Resources").GetComponent<Text> ().text = scoreboard.GetScore (player).ToString ();
		}
	}

	public void SetUp()
	{
		playerScores = new List<GoPlayerTuple>();
		players = scoreboard.GetPlayerSorted ();

		foreach (Player player in players) 
		{
			GameObject go = (GameObject)Instantiate (playerEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("Name").GetComponent<Text> ().text = player.ToString ();
			go.transform.Find ("Resources").GetComponent<Text> ().text = scoreboard.GetScore (player).ToString();
			go.transform.GetComponent<Image> ().color = player.color;
			playerScores.Add (new GoPlayerTuple(go, player));
		}
	}

	public class GoPlayerTuple
	{
		public GameObject Go { get; private set; }
		public Player Player { get; private set; }

		public GoPlayerTuple (GameObject go, Player player)
		{
			Go = go;
			Player = player;
		}
	}
}
