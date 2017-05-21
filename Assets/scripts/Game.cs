using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Game : MonoBehaviour {

	HexGrid grid;
	HexCell[] cells;

	Player[] players;
	List<Color> colors;

	void Awake()
	{
		grid = GetComponentInChildren<HexGrid> ();
		players = new Player[3] { new MyStrat2 (), new MyStrat2 (), new MyStrat2 () };
		colors = new List<Color> { Color.blue, Color.green, Color.red, Color.magenta };
	}

	// Use this for initialization
	void Start () 
	{
		cells = grid.cells;
		foreach (var player in players) 
		{
			int rndColor = Random.Range (0, colors.Count);
			player.color = colors [rndColor];
			colors.Remove (player.color);

			int rndStartPos = Random.Range (0, cells.Length);
			cells [rndStartPos].color = player.color;
		}

		InvokeRepeating ("ExecuteStrategies", 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
//		foreach (var cell in cells) 
//		{
//			cell.color = players [Random.Range(0, players.Length)].color;
//		}
	}

	public void ExecuteStrategies()
	{
		AddResourcesToPlayers ();
		foreach (var player in players) 
		{
			player.Strategy (FindPlayerCells(player));
		}
		grid.DrawUpdatedCells ();
	}

	private HexCell[] FindPlayerCells(Player player)
	{
		List<HexCell> tmp = new List<HexCell> ();
		foreach (var cell in cells) 
		{
			if (cell.color == player.color) 
			{
				tmp.Add (cell);
			}
		}
		return tmp.ToArray ();
	}

	void AddResourcesToPlayers()
	{
		foreach (var cell in cells) 
		{
			if (cell.color != Color.black && cell.resources < 100) 
			{
				cell.resources++;
			}
		}
	}
}
