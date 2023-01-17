using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridData
{
	private int width;
	private int height;
	private HashSet<int> indexSet;
	private Dictionary<int, GameObject> cellDictionary;

	#region Properties

	public Dictionary<int, GameObject> CellDictionary
	{
		get
		{
			return cellDictionary;
		}
		set
		{
			cellDictionary = value;
			EventManager.OngridDataChanged(this);
		}
	}

	public void AddPair(int index, GameObject cell)
	{
		cellDictionary.Add(index, cell);
		EventManager.OngridDataChanged(this);
	}

	public void RemovePair(int index)
	{
		cellDictionary.Remove(index);
		EventManager.OngridDataChanged(this);
	}

	public GameObject GetCell(int index)
	{
		return cellDictionary[index];
	}
	public HashSet<int> IndexSet
	{
		get
		{
			return indexSet;
		}
		set
		{
			indexSet = value;
			EventManager.OngridDataChanged(this);
		}
	}

	public void AddIndex(int index)
	{
		if (indexSet.Contains(index))
		{
			return;
		}
		indexSet.Add(index);
		EventManager.OngridDataChanged(this);
	}


	public int Width
	{
		get
		{
			return width;
		}
		set
		{
			width = value;
			EventManager.OngridDataChanged(this);
		}
	}


	public int Height
	{
		get
		{
			return height;
		}
		set
		{
			height = value;
			EventManager.OngridDataChanged(this);
		}
	}


	#endregion

	public GridData(int width = 9, int height = 9)
	{
		this.width = width;
		this.height = height;
		indexSet = new HashSet<int>();
		cellDictionary = new Dictionary<int, GameObject>();
		EventManager.OngridDataChanged(this);
	}
	public CellData GetCellDataFromGameObject(GameObject _gameObject)
	{
		CellComponenet cellComponenet = _gameObject.GetComponent<CellComponenet>();
		return cellComponenet.GetCellData();
	}
	public CellComponenet GetCellComponent(int cellIndex)
	{
		if (indexSet.Contains(cellIndex))
		{
			GameObject cell = cellDictionary[cellIndex];
			CellComponenet cellComponenet = cell.GetComponent<CellComponenet>();
			return cellComponenet;
		}
		return null;

	}

	public CellComponenet GetCellComponent(int x, int y)
	{
		int cellIndex = y * 10 + x;
		return GetCellComponent(cellIndex);
	}


	public CellData NorthNeighbor(CellData currentCell)
	{
		int cellIndex = currentCell.cellIndex - 10;
		if (indexSet.Contains(cellIndex))
		{
			return GetCellComponent(cellIndex).GetCellData();
		}
		return null;
	}

	public CellData SouthNeighbor(CellData currentCell)
	{
		int cellIndex = currentCell.cellIndex + 10;
		if (indexSet.Contains(cellIndex))
		{
			return GetCellComponent(cellIndex).GetCellData();
		}
		return null;

	}

	public CellData EastNeighbor(CellData currentCell)
	{
		int cellIndex = currentCell.cellIndex + 1;
		if (indexSet.Contains(cellIndex))
		{
			return GetCellComponent(cellIndex).GetCellData();
		}
		return null;
	}

	public CellData WestNeighbor(CellData currentCell)
	{
		int cellIndex = currentCell.cellIndex - 1;
		if (indexSet.Contains(cellIndex))
		{
			return GetCellComponent(cellIndex).GetCellData();
		}
		return null;
	}

	public CellComponenet FindEmptyCell()
	{
		foreach (int index in indexSet)
		{
			CellComponenet cellComponenet = GetCellComponent(index);
			if (cellComponenet && cellComponenet.GetCellData().value == 0 && cellComponenet.GetCellData().modifiable)
			{
				return cellComponenet;
			}
		}
		return null;
	}



}
