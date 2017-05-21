using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HexGrid : MonoBehaviour 
{
	private int radius;

	public Color defaultColor = Color.black;

	public HexCell cellPrefab;
	public Text cellLabelPrefab;

	public HexCell[] cells { get; private set; }
	Canvas gridCanvas;
	HexMesh hexMesh;

	// Use this for initialization
	void Awake () {
		radius = 15;
		hexMesh = GetComponentInChildren<HexMesh> ();
		gridCanvas = GetComponentInChildren<Canvas> ();
		cells = new HexCell[CalculateGridSize(radius)];
		int i = 0;
		int rowCount = radius * 2 - 1;
		int colCount = radius;
		int subtractVal = 0;
		bool passedMid = false;

		for (int z = 0; z < rowCount; z++) 
		{
			if (passedMid) {
				subtractVal += z % 2 == 0 ? -1 : 0;	
			} else {
				subtractVal += z % 2 == 0 ? 0 : 1;	
			}

			for (int x = 0; x < colCount; x++) 
			{
				CreateCell (x - subtractVal, z, i++, colCount);
			}

			if (colCount == rowCount) 
			{
				passedMid = true;
			}

			if (passedMid) 
			{
				colCount--;	
			} 
			else 
			{
				colCount++;	
			}
		}

		foreach (var cell in cells) 
		{
			cell.SetNeighbor (neighbors(cell));
		}
	}

	void Start()
	{
//		InvokeRepeating ("DrawUpdatedCells", 0f, 0.5f);
	}

	public void DrawUpdatedCells()
	{
		hexMesh.Triangulate (cells);
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	void CreateCell(int x, int z, int i, int colCount)
	{
		Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);

		HexCell cell = cells [i] = Instantiate<HexCell> (cellPrefab);
		cell.transform.SetParent (transform, false);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffSetCoordinates (x, z);
		cell.color = defaultColor;
		cell.resources = 1;

//		Text label = Instantiate<Text> (cellLabelPrefab);
//		label.rectTransform.SetParent (gridCanvas.transform, false);
//		label.rectTransform.anchoredPosition = new Vector2 (position.x, position.z);
//		label.text = cell.resources.ToString ();
//		label.color = Color.white;
	}
		
	HexCell[] neighbors(HexCell cell)
	{
		List<HexCell> tmp = new List<HexCell> ();
		foreach (var c in cells) 
		{
			if (Math.Abs(cell.coordinates.X - c.coordinates.X) == 1 && 
				Math.Abs(cell.coordinates.Y - c.coordinates.Y) == 1 && 
				Math.Abs(cell.coordinates.Z - c.coordinates.Z) == 0) 
			{
				tmp.Add (c);
			}

			if (Math.Abs(cell.coordinates.X - c.coordinates.X) == 1 && 
				Math.Abs(cell.coordinates.Z - c.coordinates.Z) == 1 && 
				Math.Abs(cell.coordinates.Y - c.coordinates.Y) == 0) 
			{
				tmp.Add (c);
			}

			if (Math.Abs(cell.coordinates.Z - c.coordinates.Z) == 1 && 
				Math.Abs(cell.coordinates.Y - c.coordinates.Y) == 1 && 
				Math.Abs(cell.coordinates.X - c.coordinates.X) == 0) 
			{
				tmp.Add (c);
			}
		}

		HexCell[] retVal = tmp.ToArray ();
		return retVal;
	}

	int CalculateGridSize(int radius)
	{
		int sum = 0;
		for (int i = 0; i < radius; i++) 
		{
			sum += radius + i;
		}

		for (int i = 0; i < radius - 1; i++) 
		{
			sum += radius + i;
		}
		return sum;
	}
}
