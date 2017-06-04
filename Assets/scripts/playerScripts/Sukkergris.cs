using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sukkergris : Player {

	public Sukkergris() : base()
	{
	}

	public override Tuple Strategy (HexCell[] MyCells)
	{
		HexCell[] neighbors;
		HexCell WeakestEnemy = null;
		HexCell transferFrom = null;

		foreach (var cell in MyCells) 
		{
			neighbors = cell.GetNeighbors ();

			foreach (var neighbor in neighbors) 
			{
				if (neighbor.color == Color.black) 
				{
					return new Tuple (cell, neighbor.resources+1, neighbor);
				}
				if (WeakestEnemy == null && neighbor.color != cell.color) 
				{
					transferFrom = cell;
					WeakestEnemy = neighbor;
				}
				else if (neighbor.color != cell.color) 
				{
					if (WeakestEnemy.resources > neighbor.resources) 
					{
						transferFrom = cell;
						WeakestEnemy = neighbor;
					}
				}
			}
		}

		return new Tuple (transferFrom, WeakestEnemy.resources + 1, WeakestEnemy);
	}
}
