using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RollRoti.SaveDataPlayerPrefs;

public class SaveDataApp : MonoBehaviour 
{
	public bool loadDataOnStart = false;
	public Text name;
	public Text score;
	public Text highscore;

	void Start ()
	{
		if (loadDataOnStart)
			LoadData ();
	}

	void DisplayGameData ()
	{
		name.text = DataManager.Instance.gameData.name;
		score.text = DataManager.Instance.gameData.score.ToString ();
		highscore.text = DataManager.Instance.gameData.highscore.ToString ();
	}
		 

	public void LoadData ()
	{
		DataManager.Instance.LoadGameData ();
		DisplayGameData ();
	}

	public void SaveData ()
	{
		DataManager.Instance.SaveGameData ();
	}

	public void DeleteData ()
	{
		DataManager.Instance.DeleteGameData ();
	}
}
