using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidCheck : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector2 temp = transform.position;
			temp.x = target.position.x;
			transform.position = temp;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Destroy (other.gameObject);

	}
}
