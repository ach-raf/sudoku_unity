using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
	/*
	WebGL: Application.persistentDataPath points to /idbfs/<md5 hash of data path> where the data path is the URL stripped of 
	everything including and after the last '/' before any '?' components.

	Linux: Application.persistentDataPath points to $XDG_CONFIG_HOME/unity3d or $HOME/.config/unity3d.

	iOS: Application.persistentDataPath points to /var/mobile/Containers/Data/Application/<guid>/Documents.

	tvOS: Application.persistentDataPath is not supported and returns an empty string.

	Android: Application.persistentDataPath points to /storage/emulated/0/Android/data/<packagename>/files on most devices 
	(some older phones might point to location on SD card if present), the path is resolved using android.content.Context.getExternalFilesDir.
	*/

	string saveDataPath;
	string configPath;

	public SaveSystem()
	{
		saveDataPath = Application.dataPath + "/save/save.json";
		configPath = Application.dataPath + "/save/config.json";

	}

	public void SaveConfig(GridData gridData)
	{
		if (File.Exists(configPath))
		{
			File.Delete(configPath);
		}
		List<string> lines = new List<string>();
		lines.Add(JsonUtility.ToJson(gridData.Width.ToString()));
		lines.Add(JsonUtility.ToJson(gridData.Height.ToString()));

		File.AppendAllLines(configPath, lines);

	}




	public void Serialize(GridData gridData)
	{
		SaveConfig(gridData);
		if (File.Exists(saveDataPath))
		{
			File.Delete(saveDataPath);
		}
		CellData cellData;
		List<string> lines = new List<string>();
		foreach (KeyValuePair<int, GameObject> pair in gridData.CellDictionary)
		{
			cellData = pair.Value.GetComponent<CellComponenet>().GetCellData();
			lines.Add(cellData.ToString());
		}

		File.AppendAllLines(saveDataPath, lines);
		Debug.Log("Saved");

	}

	public void Deserialize(out int width, out int height, out string[] lines)
	{
		if (File.Exists(saveDataPath))
		{
			if (File.Exists(configPath))
			{
				string[] config_lines = File.ReadAllLines(configPath);
				width = JsonUtility.FromJson<int>(config_lines[0]);
				height = JsonUtility.FromJson<int>(config_lines[1]);
				GridData gridData = new GridData(width, height);
				lines = File.ReadAllLines(saveDataPath);
			}

		}
		width = 0;
		height = 0;
		lines = null;
	}
}
