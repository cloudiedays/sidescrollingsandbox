using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeController : MonoBehaviour {

	public bool isDay = true;
	public float dayLengthMin;

	[Header("Day")]
	public Color daySky;
	public Color dayLight;
	[Header("Night")]
	public Color nightSky;
	public Color nightLight;

	void Start () {
		StartCoroutine (TimeRotation());
	}

	void Update () {
		if (isDay) {
			Camera.main.backgroundColor = daySky;
			RenderSettings.ambientLight = dayLight;
		} else {
			Camera.main.backgroundColor = nightSky;
			RenderSettings.ambientLight = nightLight;
		}
	}

	IEnumerator TimeRotation () {
		while (true) {
			yield return new WaitForSecondsRealtime (dayLengthMin*60);
			isDay = !isDay;
		}
	}
}
