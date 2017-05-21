using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates 
{
	[SerializeField]
	private int x, y, z;

	public HexCoordinates (int inx, int inz)
	{
		this.x = inx;
		this.y = - inx - inz;
		this.z = inz;
	}

	public int X { get { return x; } }
	public int Y { get { return y; } }
	public int Z { get { return z; } }

	public static HexCoordinates FromOffSetCoordinates (int x, int z)
	{
		return new HexCoordinates (x - z / 2, z);
	}

	public override string ToString ()
	{
		return "(" + X.ToString () + ", " + Y.ToString () + ", " + Z.ToString () + ")";
	}

	public string ToStringOnSeparateLines()
	{
		return X.ToString () + "\n" + Y.ToString () + "\n" + Z.ToString ();
	}
}
