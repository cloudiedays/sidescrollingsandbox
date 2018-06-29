using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingController : MonoBehaviour {

	public GameObject[] objects;

	GameObject selectedObject;
	Vector2 mousePos;
	bool inBuildingMode = false;
	int i;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.B)) {
			inBuildingMode = true;
		}

		if (inBuildingMode) {

			if(Input.GetKeyDown(KeyCode.Q)) {
				i--;
				i = Mathf.Max (0, i);
				selectedObject = objects[i];
				Debug.Log (selectedObject);
			}
			if(Input.GetKeyDown(KeyCode.E)) {
				i++;
				i = Mathf.Min (objects.Length, i);
				selectedObject = objects[i];
				Debug.Log (selectedObject);
			}

			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			transform.position = new Vector2 (Mathf.Round (mousePos.x), Mathf.Round (mousePos.y));

			if (Input.GetMouseButtonDown (0)) {
//				Vector2 mouseRay = Camera.main.ScreenToWorldPoint(transform.position);
				RaycastHit2D rayHit = Physics2D.Raycast (mousePos, Vector2.zero, Mathf.Infinity);

				if (rayHit.collider == null) {
					Instantiate (selectedObject, transform.position, Quaternion.identity);
				}
			}
		}
	}
}
