using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalAI : MonoBehaviour {

	Rigidbody2D rb;
	public float speed = 3;
	bool left;
	int range = 1;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void NotUpdate () {
		if (!left) {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.left, range);
			if (hit.collider != null) {
				if (hit.collider.gameObject != this.gameObject) {
					Debug.LogError (hit.collider.name);
					Debug.Log ("needs to flip");
					flip ();
				}
			}
		} else {
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.right, range);
			if (hit.collider != null && hit.collider.gameObject != this.gameObject) { 
				if (hit.collider.gameObject != this.gameObject) {
					Debug.LogError (hit.collider.name);
					Debug.Log ("needs to flip");
					flip ();
				}
			}
		}
	}


	void Update () {
		Vector3 local = this.transform.position;
		local.x += GetComponent<CircleCollider2D> ().offset.x;
		if (Physics2D.OverlapCircle (local, .075f) != null) {
			flip ();
		}

		if (!left ) {
			Debug.Log ("left");
			rb.AddForce (Vector2.left * speed);
		} else if (left){
			Debug.Log ("right");
			rb.AddForce (Vector2.right * speed);
		}
	}

	void flip () {
		Debug.Log ("Flipping");
		Vector3 temp = this.gameObject.transform.localScale;
		temp.x *= -1;
		this.gameObject.transform.localScale = temp;
		left = !left;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.gray;
		Vector3 local = this.transform.position;
		local.x += GetComponent<CircleCollider2D> ().offset.x;
		Gizmos.DrawWireSphere (local, .075f);
	}
}