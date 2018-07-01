using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour {

	public Tile tileType;
	public float health;
	public Color color;

	void Start () {
		health = tileType.strength/6;
	}
}
