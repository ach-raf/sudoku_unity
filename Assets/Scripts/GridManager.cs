using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public GameObject cellPrefab;
	public GameObject parent;
	public int width = 9;
	public int height = 9;
	public Vector2 startingPosition = new Vector2(-4.5f, 7.5f);
	private GameObject[,] cellList;
	// Start is called before the first frame update
	void Start()
	{
		CreateGrid();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void CreateGrid()
	{
		cellList = new GameObject[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				GameObject cell = Instantiate(cellPrefab, new Vector3(startingPosition.x + x, startingPosition.y - y, 0), Quaternion.identity);
				cell.transform.SetParent(parent.transform);
				cell.name = "Cell_" + x + "_" + y;
				cellList[x, y] = cell;
			}
		}

	}
}
