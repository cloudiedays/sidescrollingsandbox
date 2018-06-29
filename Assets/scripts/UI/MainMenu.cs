using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

	public GameObject titleEffectPrefab;
	public GameObject titleGO;
	public Transform[] spawnpoint;

	public TextMeshProUGUI quitText;

	public void TitleEffect () {
		Instantiate (titleEffectPrefab, spawnpoint[Random.Range(0, spawnpoint.Length)].position , Quaternion.identity);
	}

	public void LoadLevel (string level) {
		SceneManager.LoadScene (level);
	}

	public void Quit () {
		quitText.text = "Really? (Y/N)";
		if (Input.GetKeyDown (KeyCode.Y)) {
			Debug.Log ("Quiting Now...");
			Application.Quit ();
		} 
		if (Input.GetKeyDown (KeyCode.N)) {
			quitText.text = "Quit";
		}
	}
}
