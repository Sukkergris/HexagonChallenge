using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStrat2 : Player {

	public MyStrat2() : base()
	{
	}

	public override void Strategy (HexCell[] MyCells)
	{
		HexCell[] neighbors;

		foreach (var cell in MyCells) 
		{
			neighbors = cell.GetNeighbors ();

			foreach (var neighbor in neighbors) 
			{
				if (neighbor.color != cell.color) 
				{
					cell.TranserResources (cell.resources - 1, neighbor);
				}
			}
		}
	}
}
