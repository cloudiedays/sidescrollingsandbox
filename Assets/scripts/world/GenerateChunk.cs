using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour {

	public int width;
	public float heightMultiplier;
	public float smoothness;
	[HideInInspector] public float seed;
	public int heightAddition;

	[Space] [Header("Tiles")]
	public GameObject grassTile;
	public GameObject dirtTile;
	public GameObject stoneTile;
	public GameObject coalTile;
	public GameObject ironTile;
	public GameObject diamondTile;

	[Space] [Header("Tile Chances")]
	public float coalChance;
	public float ironChance;
	public float diamondChance;

	public void Start () {
		seed = Random.Range (-10000f, 10000f);
		Generate ();
	}

	public void Generate () {
		for (int i = 0; i < width; i++) {
			int h = Mathf.RoundToInt (Mathf.PerlinNoise (seed, (i + transform.position.x) / smoothness) * heightMultiplier) + heightAddition;
			for (int j = 0; j < h; j++) {
				GameObject selectedTile;
				if (j < h - 4) {
					selectedTile = stoneTile;
				} else if (j < h - 1) {
					selectedTile = dirtTile;
				} else {
					selectedTile = grassTile;
				}
				GameObject newTile = Instantiate (selectedTile, Vector3.zero, Quaternion.identity);
				newTile.transform.parent = this.transform;
				newTile.transform.localPosition = new Vector3 (i, j, 0);
			}
		}
		Populate ();
	}

	public void Populate () {
		foreach (GameObject t in GameObject.FindGameObjectsWithTag("Stone")) {
			float r = Random.Range (0f, 100f);
			GameObject selectedTile = null;
			if (r < diamondChance) {
				selectedTile = diamondTile;
			} else if (r < ironChance) {
				selectedTile = ironTile;
			} else if (r < coalChance) {
				selectedTile = coalTile;
			}
		
			if (selectedTile != null) {
				GameObject newResourceTile = Instantiate (selectedTile, t.transform.position, Quaternion.identity);
				newResourceTile.transform.parent = this.transform;
				Destroy (t);
			}
		}
	}
}