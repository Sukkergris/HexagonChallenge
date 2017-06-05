using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreBoard : MonoBehaviour
{
	Dictionary<Player, int> scoreboard;

	public void InitializeScoreboard(List<Player> players)
	{
		scoreboard = new Dictionary<Player, int> ();
		foreach (var player in players) 
		{
			scoreboard [player] = 1;
		}
	}

	public int GetScore(Player player)
	{
		if (!scoreboard.ContainsKey(player)) 
		{
			return 0;
		}
		return scoreboard [player];
	}

	public void SetScore(Player player, int score)
	{
		scoreboard [player] = score;
	}

	public void ChangeScore(Player player, int amount)
	{
		scoreboard [player] += amount;
	}

	public List<Player> GetPlayers()
	{
		return scoreboard.Keys.ToList ();
	}

	public List<Player> GetPlayerSorted()
	{
		var myList = scoreboard.ToList ();

		myList.Sort ((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

		List<Player> ordered = new List<Player> ();

		foreach (var item in myList) {
			ordered.Add (item.Key);
		}

		return ordered;
	}
}
