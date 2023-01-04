using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class EventManager
{
	public static event Action<GameObject[]> cellGridChanged;
	public static void OnCellGridChanged(GameObject[] cellGrid) => cellGridChanged?.Invoke(cellGrid);

	public static event Action<GridData> gridDataChanged;
	public static void OngridDataChanged(GridData gridData) => gridDataChanged?.Invoke(gridData);

	public static event Action<SudokuLogic> sudokuLogicChanged;
	public static void OnSudokuLogicChanged(SudokuLogic sudokuLogic) => sudokuLogicChanged?.Invoke(sudokuLogic);

	public static event Action solve;
	public static void OnSolve() => solve?.Invoke();


}
