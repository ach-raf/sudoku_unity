using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]

public class CellComponenet : MonoBehaviour, IClickable
{

	private TextMeshPro text;
	private CellData cellData;

	private SudokuLogic sudokuLogic;
	private void Awake()
	{
		text = GetComponentInChildren<TextMeshPro>();
	}

	private void OnEnable()
	{
		EventManager.sudokuLogicChanged += OnSudokuLogicChanged;
	}

	private void OnDisable()
	{
		EventManager.sudokuLogicChanged -= OnSudokuLogicChanged;
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void click()
	{
		Debug.Log("Debug: Clicked");
		if (cellData != null)
		{
			RandomColor();
			IncrementCell();
		}

		if (sudokuLogic != null)
		{
			RandomColor();
			IncrementCell();
			sudokuLogic.LocalArrayLogic(cellData, 4);
		}

	}

	public void RandomColor()
	{
		cellData.color = new Color(Random.value, Random.value, Random.value);
		OnCellDataChanged();
	}

	public void OnCellDataChanged()
	{
		text.text = cellData.value.ToString();
		GetComponent<SpriteRenderer>().color = cellData.color;
	}

	public void SetCellData(CellData cellData)
	{
		this.cellData = cellData;
		OnCellDataChanged();
	}
	public CellData GetCellData()
	{
		return cellData;
	}

	public void IncrementCell()
	{
		cellData.value += 1;
		if (cellData.value > 9)
		{
			cellData.value = 1;
		}
		cellData.modifiable = false;
		OnCellDataChanged();
	}

	public void SetColor(Color color)
	{
		GetComponent<SpriteRenderer>().color = color;
	}

	public void OnSudokuLogicChanged(SudokuLogic sudokuLogic)
	{
		this.sudokuLogic = sudokuLogic;
	}


}
