using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
	public Color color;

	public abstract Tuple Strategy(HexCell[] MyCells);
}

