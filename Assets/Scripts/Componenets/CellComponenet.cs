using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CellComponenet : MonoBehaviour, IClickable
{

	// get text componenet from children
	private TextMeshPro text;
	private int cellNumber = 1;
	private void Awake()
	{
		text = GetComponentInChildren<TextMeshPro>();
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
		Debug.Log("Clicked");
		RandomColor();
		if (cellNumber > 9)
		{
			cellNumber = 1;
		}
		SetCellNumber(cellNumber);
		cellNumber++;

	}

	public void RandomColor()
	{
		GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
	}

	public void SetCellNumber(int number)
	{
		cellNumber = number;
		text.text = cellNumber.ToString();
	}
}
