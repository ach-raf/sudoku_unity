using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
	public Vector2 position;
	private int value;
	public bool modifiable;
	public Color color;

	public int cellIndex;

	public int cellSize;
	public int x;
	public int y;


	public CellData(Vector2 position, int value, bool modifiable, Color color, int cellIndex, int cellSize = 1)
	{
		this.position = position;
		this.value = value;
		this.modifiable = modifiable;
		this.color = color;
		this.cellIndex = cellIndex;
		this.cellSize = cellSize;
	}

	public void SetValue(int value)
	{
		this.value = value;
	}

	public int GetValue()
	{
		return value;
	}
}

