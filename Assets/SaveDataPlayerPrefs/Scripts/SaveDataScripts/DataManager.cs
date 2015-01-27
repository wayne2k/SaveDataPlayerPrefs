using UnityEngine;
using System.Collections;

namespace RollRoti.SaveDataPlayerPrefs
{
	public class DataManager : MonoBehaviour 
	{
		public static DataManager Instance { get; private set; }

		public string saveFileName = "GameSave_001";
		public GameData gameData;

		void Awake ()
		{
			if (Instance == null) {
				DontDestroyOnLoad (gameObject);
				Instance = this;
			}
			else if (Instance != this)
			{
				Destroy (gameObject);
			}
		}
		
//		void Start ()
//		{
//			LoadGameData ();
//		}
		
		void LoadFromDisk ()
		{
			Debug.Log ("Retrieving Data from disk.");
			string temp = PlayerPrefs.GetString (saveFileName);

			System.Object _dataObject = temp.GetSystemObject ();

			if (_dataObject != null) 
			{
				try 
				{
					Debug.Log ("Converting Retrieved data to GameData.");
					GameData _data = (GameData)_dataObject;
					if (_data == null)
						Debug.Log ("Converted data is null");

					Debug.Log ("Merging data");
					if (gameData.MergeGameData (_data))
					{
						Debug.Log ("Data Merged: There was changes.");
					}
					else
					{
						Debug.Log ("Data Merged: There was NO changes.");
					}
				}
				catch (UnityException error)
				{
					Debug.LogError ("UnityException: An error has occured.");
					Debug.LogException (error);
				}
				catch (System.Exception error)
				{
					Debug.LogError ("System.Exception: An error has occured.");
					Debug.LogException (error);
				}
			}
			else
			{
				Debug.Log ("Retrieved Data was Empty.");
			}
		}

		void SaveToDisk ()
		{
			string temp = gameData.GetSerializedString ();
			
			PlayerPrefs.SetString (saveFileName, temp);
		}
		
		public void LoadGameData ()
		{
			LoadFromDisk ();
		}
		
		public void SaveGameData ()
		{
			SaveToDisk ();
		}
		
		public void DeleteGameData ()
		{
			PlayerPrefs.DeleteKey (saveFileName);
		}
	}
}
