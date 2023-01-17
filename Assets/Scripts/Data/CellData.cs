using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellData
{
	public Vector2 position;
	public int value;
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


	public override string ToString()
	{
		return JsonUtility.ToJson(this);
	}
}

