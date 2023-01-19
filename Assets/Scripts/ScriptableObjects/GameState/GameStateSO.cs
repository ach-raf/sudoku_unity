using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState", order = 1)]
public class GameStateSO : ScriptableObject
{
	public bool newGame = true;
	public bool saveFileExists = false;

	public bool showContinueButton = false;
}
