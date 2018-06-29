using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public TextMeshProUGUI quitText;
	public TextMeshProUGUI btmText;
	public GameObject thisMenu;

	public enum stateEnum { quit, btm }
	public stateEnum state;

	public void BackToGame () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		player.GetComponent<playerMotor> ().isPaused = false;
		thisMenu.SetActive (false);
	}

	public void BackToMenu () { // btm = back to menu
		quitText.text = "Quit?";
		btmText.text = "Really? (Y/N)";
		state = stateEnum.btm;
	}

	public void Quit () {
		btmText.text = "Back To Menu?";
		quitText.text = "Really? (Y/N)";
		state = stateEnum.quit;
	}

	public void Update () {
		if (state == stateEnum.btm) {
			if (Input.GetKeyDown (KeyCode.Y)) {
				SceneManager.LoadScene ("MainMenu");
			} 
			if (Input.GetKeyDown (KeyCode.N)) {
				btmText.text = "Back To Menu?";
			}
		} else if (state == stateEnum.quit) {
			if (Input.GetKeyDown (KeyCode.Y)) {
				Debug.Log ("Quiting Now...");
				Application.Quit ();
			} 
			if (Input.GetKeyDown (KeyCode.N)) {
				quitText.text = "Quit?";
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			player.GetComponent<playerMotor> ().isPaused = false;
			thisMenu.SetActive (false);
		}
	}
}
