﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomStrat1 : Player {

	public RandomStrat1() : base()
	{
	}

	public override Tuple Strategy (HexCell[] MyCells)
	{
		HexCell[] neighbors;
		List<Tuple> possibleMoves = new List<Tuple> ();

		foreach (HexCell cell in MyCells) 
		{
			neighbors = cell.GetNeighbors ();

			foreach (HexCell neighbor in neighbors) 
			{
				if (neighbor.color != cell.color && cell.resources > neighbor.resources) 
				{
					possibleMoves.Add (new Tuple (cell, neighbor.resources + 1, neighbor));
				} 
				else 
				{
//					possibleMoves.Add (new Tuple (cell, cell.resources - 1, neighbor));
				}
			}
		}
//		if (possibleMoves.Count > 0) 
//		{
		return possibleMoves [Random.Range (0, possibleMoves.Count)];	
//		}
	}
}