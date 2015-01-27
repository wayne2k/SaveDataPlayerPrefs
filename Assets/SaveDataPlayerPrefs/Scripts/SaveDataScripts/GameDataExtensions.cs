using UnityEngine;
using System.Collections;

public static class GameDataExtensions 
{
	public static bool MergeGameData (this GameData currentData, GameData newData)
	{
		bool modified = false;

		if (newData == null)
				return modified;

		if (newData.name != currentData.name) {
			currentData.name = newData.name;
			modified = true;
		}
		if (newData.score > currentData.score) {
			currentData.score = newData.score;
			modified = true;
		}
		if (newData.highscore > currentData.highscore) {
			currentData.highscore = newData.highscore;
			modified = true;
		}
		return modified;
	}
}
