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
	}

	private void OnEnable()
	{
		EventManager.gridDataChanged += OnGridDataChanged;
	}

	private void OnDisable()
	{
		EventManager.gridDataChanged -= OnGridDataChanged;
	}



	public void OnGridDataChanged(GridData gridData)
	{
		this.gridData = gridData;
	}

	private void Start()
	{

		CellData startingCell = gridData.GetCellDataFromGameObject(gridData.CellDictionary[3]);

		Debug.Log("startingCell: " + startingCell.GetValue());
		bool northLogic = sudokuLogic.NorthLogic(startingCell, 4);
		Debug.Log("northLogic: " + northLogic);

		bool southLogic = sudokuLogic.SouthLogic(startingCell, 76);
		Debug.Log("southLogic: " + southLogic);

		bool eastLogic = sudokuLogic.EastLogic(startingCell, 4);
		Debug.Log("eastLogic: " + eastLogic);

		bool westLogic = sudokuLogic.WestLogic(startingCell, 4);
		Debug.Log("westLogic: " + westLogic);

		bool localArrayLogic = sudokuLogic.LocalArrayLogic(startingCell, 4);
		Debug.Log("localArrayLogic: " + localArrayLogic);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{

		}
	}
}
