using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
	public int width;
	public int height;

	public HashSet<int> indexSet;

	public List<CellData> cellDataList;

	public bool NewGame;


	// the values defined in this constructor will be the default values
	// the game starts with when there's no data to load
	public GameData()
	{
		width = 9;
		height = 9;
		indexSet = new HashSet<int>();
		cellDataList = new List<CellData>();
		NewGame = true;
	}
}