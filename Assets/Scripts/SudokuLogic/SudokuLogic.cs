using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuLogic
{
	private List<int> optionList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	private System.Random random = new System.Random();

	private GridData gridData;


	public SudokuLogic()
	{
		EventManager.gridDataChanged += OnGridDataChanged;
	}

	public void OnGridDataChanged(GridData gridData)
	{
		this.gridData = gridData;
	}

	public bool NorthLogic(CellData _startingCell, int _value)
	{
		// return true if you can post the value false if not
		CellData _currentCell = _startingCell;
		CellData _nextCell;
		CellData neighbor;
		if (gridData.NorthNeighbor(_currentCell) != null)
		{
			neighbor = gridData.NorthNeighbor(_currentCell);
		}
		else
		{
			return true;
		}

		int index = neighbor.cellIndex;
		_nextCell = neighbor;
		while (_nextCell != null)
		{
			if (_nextCell.GetValue() != _value)
			{
				_currentCell = _nextCell;
				neighbor = gridData.NorthNeighbor(_currentCell);
				if (neighbor != null)
				{
					_nextCell = neighbor;
				}
				else
				{
					_nextCell = null;
				}

			}
			else
			{
				return false;
			}

		}
		return true;
	}

	public bool SouthLogic(CellData _startingCell, int _value)
	{
		// return true if you can post the value false if not
		CellData _currentCell = _startingCell;
		CellData _nextCell;
		CellData neighbor;
		if (gridData.SouthNeighbor(_currentCell) != null)
		{
			neighbor = gridData.SouthNeighbor(_currentCell);
		}
		else
		{
			return true;
		}

		int index = neighbor.cellIndex;
		_nextCell = neighbor;
		while (_nextCell != null)
		{
			if (_nextCell.GetValue() != _value)
			{
				_currentCell = _nextCell;
				neighbor = gridData.SouthNeighbor(_currentCell);
				if (neighbor != null)
				{
					_nextCell = neighbor;
				}
				else
				{
					_nextCell = null;
				}

			}
			else
			{
				return false;
			}

		}
		return true;
	}

	public bool EastLogic(CellData _startingCell, int _value)
	{
		// return true if you can post the value false if not
		CellData _currentCell = _startingCell;
		CellData _nextCell;
		CellData neighbor;
		if (gridData.EastNeighbor(_currentCell) != null)
		{
			neighbor = gridData.EastNeighbor(_currentCell);
		}
		else
		{
			return true;
		}

		int index = neighbor.cellIndex;
		_nextCell = neighbor;
		while (_nextCell != null)
		{
			if (_nextCell.GetValue() != _value)
			{
				_currentCell = _nextCell;
				neighbor = gridData.EastNeighbor(_currentCell);
				if (neighbor != null)
				{
					_nextCell = neighbor;
				}
				else
				{
					_nextCell = null;
				}

			}
			else
			{
				return false;
			}

		}
		return true;
	}

	public bool WestLogic(CellData _startingCell, int _value)
	{
		// return true if you can post the value false if not
		CellData _currentCell = _startingCell;
		CellData _nextCell;
		CellData neighbor;
		if (gridData.WestNeighbor(_currentCell) != null)
		{
			neighbor = gridData.WestNeighbor(_currentCell);
		}
		else
		{
			return true;
		}

		int index = neighbor.cellIndex;
		_nextCell = neighbor;
		while (_nextCell != null)
		{
			if (_nextCell.GetValue() != _value)
			{
				_currentCell = _nextCell;
				neighbor = gridData.WestNeighbor(_currentCell);
				if (neighbor != null)
				{
					_nextCell = neighbor;
				}
				else
				{
					_nextCell = null;
				}

			}
			else
			{
				return false;
			}

		}
		return true;
	}

	public bool LocalArrayLogic(CellData _startingCell, int _value)
	{
		int y = _startingCell.y;
		int x = _startingCell.x;
		int yLoopStart = 0;
		int yLoopEnd = 0;
		int xLoopStart = 0;
		int xLoopEnd = 0;


		switch (y)
		{
			case < 3:
				yLoopStart = 0;
				yLoopEnd = 3;
				switch (x)
				{
					case < 3:
						//array 0
						xLoopStart = 0;
						xLoopEnd = 3;
						break;
					case < 6:
						//array 1
						xLoopStart = 3;
						xLoopEnd = 6;
						break;
					default:
						//array 2
						xLoopStart = 6;
						xLoopEnd = 9;
						break;
				}
				break;
			case < 6:
				yLoopStart = 3;
				yLoopEnd = 6;
				switch (x)
				{
					case < 3:
						//array 0
						xLoopStart = 0;
						xLoopEnd = 3;
						break;
					case < 6:
						//array 1
						xLoopStart = 3;
						xLoopEnd = 6;
						break;
					default:
						//array 2
						xLoopStart = 6;
						xLoopEnd = 9;
						break;
				}
				break;
			case < 9:
				yLoopStart = 6;
				yLoopEnd = 9;
				switch (x)
				{
					case < 3:
						//array 0
						xLoopStart = 0;
						xLoopEnd = 3;
						break;
					case < 6:
						//array 1
						xLoopStart = 3;
						xLoopEnd = 6;
						break;
					default:
						//array 2
						xLoopStart = 6;
						xLoopEnd = 9;
						break;
				}
				break;
		}
		GameObject cellGameObject;
		CellComponenet cellComponent;
		CellData cellData;

		for (int _y = yLoopStart; _y < yLoopEnd; _y++)
		{
			for (int _x = xLoopStart; _x < xLoopEnd; _x++)
			{
				int index = _y * 10 + _x;
				cellGameObject = gridData.CellDictionary[index];
				cellComponent = cellGameObject.GetComponent<CellComponenet>();
				cellData = cellComponent.GetCellData();
				if (cellData.GetValue() != _value)
				{
					//cellComponent.SetColor(Color.red);
					continue;
				}
				else
				{
					return false;
				}
			}
		}
		return true;

	}
	public bool IsValidMove(CellData cellClicked, int value)
	{
		bool northLogic = NorthLogic(cellClicked, value);
		bool southLogic = SouthLogic(cellClicked, value);
		bool eastLogic = EastLogic(cellClicked, value);
		bool westLogic = WestLogic(cellClicked, value);
		bool localArrayLogic = LocalArrayLogic(cellClicked, value);

		if (localArrayLogic && northLogic && southLogic && eastLogic && westLogic)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public bool Solve()
	{
		/*
        '''Solves the Sudoku board via the backtracking algorithm'''
        */
		List<int> _choises = new List<int>(optionList);
		CellComponenet cellComponenet = gridData.FindEmptyCell();

		if (cellComponenet == null)
		{
			return true;
		}
		CellData cellData = cellComponenet.GetCellData();

		while (_choises.Count != 0)
		{
			int _index = random.Next(_choises.Count);
			int _value = _choises[_index];
			if (IsValidMove(cellData, _value))
			{
				cellData.SetValue(_value);
				_choises.Remove(_value);
				cellComponenet.SetCellData(cellData);
				cellComponenet.SetColor(Color.white);
				//backtracking here, leave the cell emptyGridObject empty for now if solve is false. 
				if (Solve())
				{
					return true;
				}
				cellData.SetValue(0);
				cellComponenet.SetCellData(cellData);
				cellComponenet.SetColor(Color.white);

			}
			_choises.Remove(_value);
		}
		return false;
	}
}
