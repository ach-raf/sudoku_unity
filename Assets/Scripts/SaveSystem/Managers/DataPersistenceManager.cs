using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
	[Header("File Storage Config")]
	[SerializeField] private string fileName;
	[SerializeField] private bool useEncryption;
	public static DataPersistenceManager instance { get; private set; }
	private FileDataHandler dataHandler;

	private GameData gameData;

	public static bool newGame;

	private List<IDataPersistence> dataPersistenceList = new List<IDataPersistence>();

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("There should only be one instance of DataPersistenceManager");
		}
		instance = this;

	}

	private void Start()
	{
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
		dataPersistenceList = FindAllDataPersistenceObjects();
		LoadGame();
	}


	public void NewGame()
	{
		gameData = new GameData();
	}

	public void LoadGame()
	{
		Debug.Log("newGame: " + newGame + "");
		if (newGame)
		{
			NewGame();
		}
		else if (!newGame)
		{
			// load save data from file
			gameData = dataHandler.Load();
		}

		foreach (IDataPersistence dataPersistence in dataPersistenceList)
		{
			dataPersistence.LoadData(gameData);
		}
	}

	public void SaveGame()
	{
		foreach (IDataPersistence dataPersistence in dataPersistenceList)
		{
			dataPersistence.SaveData(gameData);
		}

		dataHandler.Save(gameData);
	}

	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataPersistence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
		return dataPersistenceObjects.ToList();
	}

	public static void SetNewGame(bool _newGame)
	{
		newGame = _newGame;
	}


}
