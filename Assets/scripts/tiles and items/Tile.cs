using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile", menuName = "Inventory/Tile", order = 1)]
public class Tile : ScriptableObject {

	public string tileName;
	public Sprite icon;
	public float strength;
	public bool multiDrop = false;
	public bool grass = false;
}
