using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Game : MonoBehaviour {

	HexGrid grid;
	HexCell[] cells;

	List<Player> players;
	List<Player> playersToBeRemoved;
	List<Color> colors;

	void Awake()
	{
		grid = GetComponentInChildren<HexGrid> ();
		players = new List<Player>() { new Sukkergris (), new RandomStrat (), new RandomStrat (), new Sukkergris() };
		playersToBeRemoved = new List<Player> ();
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

		InvokeRepeating ("ExecuteStrategies", 0f, 0.01f);
	}
	
	// Update is called once per frame
	void Update () 
	{

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

	void AddResourcesToPlayer(Player player)
	{
		foreach (var cell in cells) 
		{
			if (cell.color == player.color && cell.resources < 100) 
			{
				cell.resources++;
			}
		}
	}

	public void ExecuteStrategies()
	{
		foreach (var player in playersToBeRemoved) 
		{
			players.Remove (player);
		}
		foreach (var player in players) 
		{
			AddResourcesToPlayer (player);
			HexCell[] playerCells = FindPlayerCells(player);
			if (playerCells.Length > 0) 
			{
				TransferResources (player.Strategy (playerCells));	
			} 
			else 
			{
				playersToBeRemoved.Add (player);
			}
		}
		grid.DrawUpdatedCells ();
	}

	public void TransferResources(Tuple moveInfo)
	{
		HexCell _from = moveInfo.TranserFrom;
		int a = moveInfo.Amount;
		HexCell _to = moveInfo.TranserTo;
		if (TransferCellsAreNeighbors(_from, _to)) 
		{
			if (_from.color != _to.color) 
			{
				if (a > _to.resources && _from.resources - a > 0) 
				{
					_to.color = _from.color;
					_to.resources = a;
					_from.resources -= a;
				}
			} 
			else 
			{
				if (_from.resources - a > 0) 
				{
					if (_to.resources + a > 100) 
					{
						int maxTransfer = 100 - _to.resources;
						_to.resources += maxTransfer;
						_from.resources -= maxTransfer;
					}
				}
			}
		}
	}

	public bool TransferCellsAreNeighbors(HexCell _from, HexCell _to)
	{
		HexCell[] fromNeighbours = _from.GetNeighbors ();
		HexCell[] toNeighbours = _to.GetNeighbors ();
		bool _To = false;
		bool _From = false;

		foreach (var cell in fromNeighbours) 
		{
			if (cell == _to) 
			{
				_From = true;
			}
		}

		foreach (var cell in toNeighbours) 
		{
			if (cell == _from) 
			{
				_To = true;
			}
		}

		return _To && _From;
	}
}
