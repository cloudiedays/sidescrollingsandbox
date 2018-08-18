using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveSystem {

	public static void SavePlayer (playerStats player) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav" ,FileMode.Create);

		PlayerDataSave data = new PlayerDataSave (player);
		bf.Serialize (stream, data);
		stream.Close ();
	}


	public static int[] LoadPlayer () {
		if (File.Exists (Application.persistentDataPath + "/player.sav")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.sav", FileMode.Open);

			PlayerDataSave data = bf.Deserialize (stream) as PlayerDataSave;

			stream.Close ();
			return data.stats;
		} else {
			Debug.LogError ("No file found!");
			return new int[4];
		}
	}
}



[Serializable]
public class PlayerDataSave {
	public int[] stats;

	public PlayerDataSave(playerStats player) {
		stats = new int[3];
		stats [0] = Mathf.RoundToInt(player.speed);
		stats [1] = Mathf.RoundToInt(player.health);
		stats [2] = Mathf.RoundToInt(player.hunger);
	}
}

[Serializable]
public class TileDataSave {
	public int locationx;
	public int locationy;
	public int health;
	public int tileType;

	public TileDataSave(TileData tile) {
		locationx = Mathf.RoundToInt(tile.gameObject.transform.position.x);
		locationy = Mathf.RoundToInt(tile.gameObject.transform.position.y);
		tileType = tile.tileType.tileType;
	}
}