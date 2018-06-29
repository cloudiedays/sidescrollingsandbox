using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

	[Header("Spawning")]
	public Vector2 spawnPoint;
	public GameObject playerPrefab;
	[Header("Speed")]
	public float speed = 5;
	public float jumpSpeed;
	[Header("Health")]
	public float maxHealth = 15;
	public float health;
	public float starveDecrease = 2;
	public Image healthBar;
	[Header("Hunger")]
	public float maxHunger = 15;
	public float hunger;
	public float hungerDecrease = 1;
	public Image hungerBar;


	void Awake () {
		health = maxHealth;
		hunger = maxHunger;
	}
	void Update () {
		if (gameObject.GetComponent<playerMotor> ().isPaused == false) {
			hunger -= Time.deltaTime * hungerDecrease;

			if (hunger <= 0) { // if starving then do this
				hunger = 0;
				health -= Time.deltaTime * starveDecrease;
			} else if (hunger > maxHunger) {
				hunger = maxHunger;
			}

			if (health < 0) {
				Die ();
			} else if (health > maxHealth) {
				health = maxHealth;
			}
		}

		hungerBar.fillAmount = hunger/maxHunger;
		healthBar.fillAmount = health/maxHealth;

	}

	void Die () {
		Debug.Log ("Oops, you died");
		GameObject newTarget = Instantiate (playerPrefab, spawnPoint, Quaternion.identity);
		Camera.main.GetComponent<CameraController> ().FindNewTarget(newTarget);



		//needs to be last
		Destroy (this.gameObject);
	}
}
