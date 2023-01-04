using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellComponenet : MonoBehaviour, IClickable
{

	private TextMeshPro text;
	private CellData cellData;
	private void Awake()
	{
		text = GetComponentInChildren<TextMeshPro>();
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{

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
		if (cellData.modifiable)
		{
			RandomColor();
			IncrementCell();
		}


	}

	public void RandomColor()
	{
		GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
	}

	public void OnCellDataChanged()
	{
		text.text = cellData.GetValue().ToString();
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
		if (cellData.GetValue() > 9)
		{
			cellData.SetValue(1);
		}
		cellData.SetValue(cellData.GetValue() + 1);
	}

	public void SetColor(Color color)
	{
		GetComponent<SpriteRenderer>().color = color;
	}


}
