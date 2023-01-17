using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
		Debug.Log("Play Game");
		DataPersistenceManager.SetNewGame(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BackButton()
	{
		Debug.Log("Back Button");
		DataPersistenceManager.instance.SaveGame();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

	public void QuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}

	public void LoadGame()
	{
		Debug.Log("Load Game");
		DataPersistenceManager.SetNewGame(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}


}
