using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour {

	public int width;
	public float heightMultiplier;
	public float smoothness;
	[HideInInspector] public float seed;
	[HideInInspector] public float caveSeed;
	public int heightAddition;

	[Space] [Header("Blocks")]
	public GameObject grassTile;
	public GameObject dirtTile;
	public GameObject stoneTile;
	public GameObject coalTile;
	public GameObject ironTile;
	public GameObject diamondTile;
	public GameObject treeGO;

	[Space] [Header("Chances")]
	public float coalChance;
	public float ironChance;
	public float diamondChance;
	public float treeChance;
	public float caveChance;

	public void Start () {
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
		// caves
		foreach (GameObject t in GameObject.FindGameObjectsWithTag("Stone")) {
			if (t.transform.parent == this.gameObject.transform && t.transform.position.y <= Random.Range(85, 95)) {
				float value = (Mathf.PerlinNoise(t.transform.position.x / 32.0f,t.transform.position.y / 32.0f) * caveSeed);
				if (value < caveChance ) { //cave opening
					Destroy (t);
				} else { //not cave opening 
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


		// ores
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Grass")) {
			if (g.transform.parent == this.gameObject.transform) {
				float r = Random.Range (0f, 100f);
				if (r < treeChance) {
					GameObject newTree = Instantiate (treeGO, new Vector2(g.transform.position.x, g.transform.position.y + .425f), Quaternion.identity);
					newTree.transform.parent = this.transform;
				}
			}
		}
	}
}