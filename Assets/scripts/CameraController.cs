using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	[Range(0, 5)]
	public float cameraSpeed;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null)
		transform.position = Vector3.Lerp (transform.position, target.position - offset, cameraSpeed * Time.deltaTime);
	}

	public void FindNewTarget (GameObject newTarget) {
		target = newTarget.transform;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
	}
}
