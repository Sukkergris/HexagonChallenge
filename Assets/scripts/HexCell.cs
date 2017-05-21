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

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		textMesh.text = resources.ToString ();
	}

	public HexCell[] GetNeighbors()
	{
		return neighbors;
	}

	public void SetNeighbor (HexCell[] _neighbors)
	{
		neighbors = _neighbors;
	}

	public void TranserResources(int _amount, HexCell toThis)
	{
		if (color != toThis.color && toThis.resources < resources) 
		{
			resources -= _amount;
			toThis.resources = _amount;
			toThis.color = color;
		}
	}
}
