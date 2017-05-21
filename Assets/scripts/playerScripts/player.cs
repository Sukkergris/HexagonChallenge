using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
	public Color color;

	public Player()
	{
	}

	public abstract void Strategy(HexCell[] MyCells);

}

