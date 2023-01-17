using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private SudokuLogic sudokuLogic;
	private GridData gridData;


	private void Awake()
	{
		sudokuLogic = new SudokuLogic();
		EventManager.OnSudokuLogicChanged(sudokuLogic);
	}

	private void OnEnable()
	{
		EventManager.gridDataChanged += OnGridDataChanged;
		EventManager.solve += Solve;
	}

	private void OnDisable()
	{
		EventManager.gridDataChanged -= OnGridDataChanged;
		EventManager.solve -= Solve;
	}



	public void OnGridDataChanged(GridData gridData)
	{
		this.gridData = gridData;
	}

	private void Start()
	{

	}

	private void Update()
	{

	}

	public void DebugLogic()
	{
		CellData startingCell = gridData.GetCellDataFromGameObject(gridData.CellDictionary[88]);

		Debug.Log("startingCell: " + startingCell.value);
		bool northLogic = sudokuLogic.NorthLogic(startingCell, 4);
		Debug.Log("northLogic: " + northLogic);

		bool southLogic = sudokuLogic.SouthLogic(startingCell, 76);
		Debug.Log("southLogic: " + southLogic);

		bool eastLogic = sudokuLogic.EastLogic(startingCell, 4);
		Debug.Log("eastLogic: " + eastLogic);

		bool westLogic = sudokuLogic.WestLogic(startingCell, 4);
		Debug.Log("westLogic: " + westLogic);

		bool localArrayLogic = sudokuLogic.LocalArrayLogic(startingCell, 99);
		Debug.Log("localArrayLogic: " + localArrayLogic);
	}

	public void Solve()
	{
		sudokuLogic.Solve();
	}
}
