using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PepesDisciples : Player {

	public PepesDisciples() : base()
	{
	}

	public override Tuple Strategy (HexCell[] MyCells)
	{
		HexCell[] neighbors;
		List<Tuple> possibleMoves = new List<Tuple> ();

		foreach (var cell in MyCells) 
		{
			neighbors = cell.GetNeighbors ();

			foreach (var neighbor in neighbors) 
			{
				if (neighbor.color != cell.color && cell.resources > neighbor.resources) 
				{
					possibleMoves.Add (new Tuple (cell, neighbor.resources + 1, neighbor));
				} 
				else if (neighbor.color == cell.color && neighbor.resources < 100) 
				{
//					possibleMoves.Add (new Tuple (cell, cell.resources - 1, neighbor));	
				}
			}
		}

		List<Tuple> blacks = KeepBlacks (possibleMoves);

		if (blacks.Count > 0) 
		{
			return blacks [Random.Range (0, possibleMoves.Count)];
		}

		return possibleMoves [Random.Range (0, possibleMoves.Count)];
	}

	public List<Tuple> KeepBlacks(List<Tuple> lst)
	{
		List<Tuple> blacks = new List<Tuple> ();

		foreach (Tuple item in lst) 
		{
			if (item.TranserTo.color == Color.black) 
			{
				blacks.Add (item);
			}
		}

		return blacks;
	}

}
