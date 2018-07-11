using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

	public GameObject titleEffectPrefab;
	public GameObject titleGO;
	public Transform[] spawnpoint;

	bool quiting;

	public TextMeshProUGUI quitText;

	public GameObject controls;

	public void TitleEffect () {
		//Instantiate (titleEffectPrefab, spawnpoint[Random.Range(0, spawnpoint.Length)].position , Quaternion.identity);
	}

	public void LoadLevel (string level) {
		SceneManager.LoadScene (level);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Y) && quiting) {
			Debug.Log ("Quiting Now...");
			Application.Quit ();
		} 
		if (Input.GetKeyDown (KeyCode.N) && quiting) {
			quitText.text = "Quit";
			quiting = false;
		}
	}

	public void Quit () {
		quitText.text = "Really? (Y/N)";
		quiting = true;
	}

	public void Control () {
		controls.SetActive (true);
		quitText.text = "Quit";
		quiting = false;
	}

	public void GoBack () {
		controls.SetActive (false);
	}
}
