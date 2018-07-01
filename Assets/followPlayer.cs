using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 temp = transform.position;
		temp.x = target.position.x;
		transform.position = temp;

		Debug.Log (transform.position);
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (other.gameObject);
	}
}
