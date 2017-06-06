using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreBoard : MonoBehaviour
{
	Dictionary<Player, int> Scoreboard;
	Dictionary<Player, int> Bugs;
	Dictionary<Player, int> Hexagons;

	public void InitializeScoreboard(List<Player> players)
	{
		Scoreboard = new Dictionary<Player, int> ();
		Bugs = new Dictionary<Player, int> ();
		Hexagons = new Dictionary<Player, int> ();
		foreach (var player in players) 
		{
			Scoreboard [player] = 1;
			Hexagons [player] = 1;
			Bugs [player] = 0;
		}
	}

	public int GetScore(Player player)
	{
		if (!Scoreboard.ContainsKey(player)) 
		{
			return 0;
		}
		return Scoreboard [player];
	}

	public int GetHexagons(Player player)
	{
		if (!Scoreboard.ContainsKey(player)) 
		{
			return 0;
		}
		return Hexagons [player];
	}

	public int GetBugs(Player player)
	{
		if (!Scoreboard.ContainsKey(player)) 
		{
			return 0;
		}
		return Bugs [player];
	}

	public void SetScore(Player player, int score)
	{
		Scoreboard [player] = score;
	}

	public void SetHexagons(Player player, int hexagons)
	{
		Hexagons [player] = hexagons;
	}

	public void SetBugs(Player player, int bugs)
	{
		Bugs [player] = bugs;
	}

	public void ChangeScore(Player player, int amount)
	{
		Scoreboard [player] += amount;
	}

	public void ChangeHexagons(Player player, int amount)
	{
		Hexagons [player] += amount;
	}

	public void ChangeBugs(Player player, int amount)
	{
		Bugs [player] += amount;
	}

	public List<Player> GetPlayers()
	{
		return Scoreboard.Keys.ToList ();
	}

	public List<Player> GetPlayerSorted()
	{
		var myList = Scoreboard.ToList ();

		myList.Sort ((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

		List<Player> ordered = new List<Player> ();

		foreach (var item in myList) {
			ordered.Add (item.Key);
		}

		return ordered;
	}
}
