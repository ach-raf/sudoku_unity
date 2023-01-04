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
		int _x = _startingCell.x;
		int _z = _startingCell.y;
		int xLoopStart = 0;
		int xLoopEnd = 0;
		int zLoopStart = 0;
		int zLoopEnd = 0;

		switch (_x)
		{
			case < 3:
				xLoopStart = 0;
				xLoopEnd = 3;
				switch (_z)
				{
					case < 3:
						//array 0
						zLoopStart = 0;
						zLoopEnd = 3;
						break;
					case < 6:
						//array 1
						zLoopStart = 3;
						zLoopEnd = 6;
						break;
					default:
						//array 2
						zLoopStart = 6;
						zLoopEnd = 9;
						break;
				}
				break;
			case < 6:
				xLoopStart = 3;
				xLoopEnd = 6;
				switch (_z)
				{
					case < 3:
						//array 4
						zLoopStart = 0;
						zLoopEnd = 3;
						break;
					case < 6:
						//array 5
						zLoopStart = 3;
						zLoopEnd = 6;
						break;
					default:
						//array 6
						zLoopStart = 6;
						zLoopEnd = 9;
						break;
				}
				break;
			default:
				xLoopStart = 6;
				xLoopEnd = 9;
				switch (_z)
				{
					case < 3:
						//array 7
						zLoopStart = 0;
						zLoopEnd = 3;
						break;
					case < 6:
						//array 8
						zLoopStart = 3;
						zLoopEnd = 6;
						break;
					default:
						//array 9
						zLoopStart = 6;
						zLoopEnd = 9;
						break;
				}
				break;
		}
		GameObject cellGameObject;
		CellComponenet cellComponent;
		CellData cellData;

		for (int i = xLoopStart; i < xLoopEnd; i++)
		{
			for (int j = zLoopStart; j < zLoopEnd; j++)
			{
				cellGameObject = gridData.CellDictionary[i * 10 + j];
				cellComponent = cellGameObject.GetComponent<CellComponenet>();
				cellData = cellComponent.GetCellData();
				if (cellData.GetValue() != _value)
				{
					cellComponent.SetColor(Color.red);
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

		/*
		List<int> _choises = new List<int>(optionList);


		
		GridObjectSO emptyGridObject = FindEmpty();
		if (emptyGridObject == null)
		{
			return true;
		}

		while (_choises.Count != 0)
		{
			int _index = random.Next(_choises.Count);
			int _value = _choises[_index];
			if (IsValidMove(emptyGridObject, _value))
			{
				emptyGridObject.cellValue = _value;
				_choises.Remove(_value);
				SetTextField(emptyGridObject, _value, Color.white);
				//backtracking here, leave the cell emptyGridObject empty for now if solve is false. 
				if (Solve())
				{
					return true;
				}

				emptyGridObject.cellValue = 0;
				SetTextField(emptyGridObject, 0, Color.white);
			}
			_choises.Remove(_value);
		}
		return false;
		*/
		return true;
	}
}
