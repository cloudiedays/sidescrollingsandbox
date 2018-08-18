using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventory : MonoBehaviour {


	public TextMeshProUGUI inventoryText, selectionText;
	int[] counts = new int[9];
	int selectedTile;
	public GameObject[] tiles;
	public GameObject worldParent;

	public void AddItem (Tile item, int amount) {
		counts [item.tileType] += amount;
		Debug.Log ("Added " + amount + " unit of " + item.name + " to the players inventory.");
	}

	void Update () {
		//Debug.Log(counts[8] + " food");

		inventoryText.text = "Food: " + counts [8] + "\nDirt: " + counts [0] + "\nWood: " + counts [5] + "\nStone: " + counts [1] + "\nCoal: " + counts [2] + "\nIron: " + counts [3] + "\nDiamonds: " + counts [4];


		if (Input.GetKeyDown (KeyCode.UpArrow) && selectedTile != counts.Length - 1) {
			selectedTile++;
			Debug.Log (selectedTile);
			selectionText.text = "Selected Tile: " + tiles[selectedTile].GetComponent<TileData>().tileType.name;
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && selectedTile != 0) {
			selectedTile--;
			Debug.Log (selectedTile);
			selectionText.text = "Selected Tile: " + tiles[selectedTile].GetComponent<TileData>().tileType.name;
		}

		if (Input.GetMouseButton (1)) {
			placeBlock ();
		}
	}

	void placeBlock () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 placePos = new Vector3 (Mathf.RoundToInt (mousePos.x), Mathf.RoundToInt (mousePos.y), 0f);

		if (Physics2D.OverlapCircleAll (placePos, .25f).Length == 0 && counts[selectedTile] > 0) {
			GameObject newTile = Instantiate (tiles [selectedTile], placePos, Quaternion.identity);
			counts [selectedTile]--;
			newTile.transform.parent = worldParent.transform;
		}
	}
}