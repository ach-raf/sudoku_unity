using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

	public GameObject cellPrefab;
	public GameObject parent;

	public int width = 9;
	public int height = 9;

	private GridData gridData;

	public Vector2 startingPosition = new Vector2(-4.5f, 7.5f);

	private void Awake()
	{
		gridData = new GridData(width, height);
	}
	void Start()
	{
		CreateGrid();
	}

	void CreateGrid()
	{

		int cellIndex = 0;
		CellData cellData;
		Vector2 position;
		GameObject cell;
		CellComponenet cellComponenet;
		for (int y = 0; y < width; y++)
		{
			for (int x = 0; x < height; x++)
			{
				position = new Vector2(startingPosition.x + x, startingPosition.y - y);
				cellIndex = y * 10 + x;
				cellData = new CellData(position, 0, true, Color.white, cellIndex);
				cellData.x = x;
				cellData.y = y;
				cellData.color = SelectColor(cellData);
				cell = Instantiate(cellPrefab, cellData.position, Quaternion.identity);
				cellComponenet = cell.GetComponent<CellComponenet>();
				cellComponenet.SetCellData(cellData);
				cell.transform.SetParent(parent.transform);
				cell.name = "Cell_" + x + "_" + y;
				gridData.AddIndex(cellIndex);
				gridData.AddPair(cellIndex, cell);
			}
		}
		EventManager.OngridDataChanged(gridData);

	}

	public Color SelectColor(CellData _startingCell)
	{
		int y = _startingCell.y;
		int x = _startingCell.x;
		//ColorUtility.TryParseHtmlString("#bde0fe", out Color mainColor);
		//ColorUtility.TryParseHtmlString("#a2d2ff", out Color secondaryColor);
		Color mainColor = Color.red;
		Color secondaryColor = Color.black;
		Color color = Color.white;
		switch (y)
		{
			case < 3:
				switch (x)
				{
					case < 3:
						//array 0
						color = mainColor;
						break;
					case < 6:
						//array 1
						color = secondaryColor;
						break;
					default:
						//array 2
						color = mainColor;
						break;
				}
				break;
			case < 6:

				switch (x)
				{
					case < 3:
						//array 0
						color = secondaryColor;
						break;
					case < 6:
						//array 1
						color = mainColor;
						break;
					default:
						//array 2
						color = secondaryColor;
						break;
				}
				break;
			case < 9:

				switch (x)
				{
					case < 3:
						//array 0
						color = mainColor;
						break;
					case < 6:
						//array 1
						color = secondaryColor;
						break;
					default:
						//array 2
						color = mainColor;
						break;
				}
				break;
		}
		return color;
	}
}
