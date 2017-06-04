using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexCell : MonoBehaviour 
{
	public HexCoordinates coordinates;
	public Color color;
	public int resources;
	public TextMesh textMesh;

	[SerializeField]
	HexCell[] neighbors;

	void Awake()
	{
		textMesh = GetComponent<TextMesh> ();
		textMesh.transform.Rotate (new Vector3(90f, 0f ,0f));
		textMesh.text = resources.ToString ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		textMesh.text = resources.ToString ();
		if (resources <= 0) {
			color = Color.black;
		}
	}

	public HexCell[] GetNeighbors()
	{
		return neighbors;
	}

	public void SetNeighbor (HexCell[] _neighbors)
	{
		neighbors = _neighbors;
	}
}
