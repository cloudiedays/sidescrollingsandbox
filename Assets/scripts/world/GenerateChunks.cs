using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour {

	public GameObject chunkPrefab;
	int chunkWidth;
	public int numberOfChunks;
	float seed;
	float caveSeed;

	void Start () {
		chunkWidth = chunkPrefab.GetComponent<GenerateChunk> ().width;
		seed = Random.Range (-100000f, 100000f);
		caveSeed = Random.Range (.25f, 1f);
		Generate ();
	}

	public void Generate () {
		int lastX = -chunkWidth;
		for (int i = 0; i < numberOfChunks; i++) {
			GameObject newChunk = Instantiate (chunkPrefab, new Vector3 (lastX + chunkWidth, 0f), Quaternion.identity) as GameObject;
			newChunk.GetComponent<GenerateChunk> ().seed = seed;
			newChunk.GetComponent<GenerateChunk> ().caveSeed = caveSeed;
			newChunk.transform.parent = this.transform;
			lastX += chunkWidth;
		}
	}
}
