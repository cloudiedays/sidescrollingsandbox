using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMotor : MonoBehaviour {

	public Rigidbody2D rb;
	playerStats ps;

	private bool facingRight = false;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRaduis;
	public LayerMask groundLayer;
	public GameObject particles;

	public bool isPaused;
	public GameObject pauseMenu;

	public Tile dirtItem;

	// Use this for initialization
	void Start () {
		ps = GetComponent<playerStats> ();
		facingRight = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!isPaused) {
			isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRaduis, groundLayer);

			float moveInput = Input.GetAxisRaw ("Horizontal");
			rb.velocity = new Vector2 (moveInput * ps.speed, rb.velocity.y);
			if (facingRight == false && moveInput > 0) {
				Flip ();
			} else if (facingRight == true && moveInput < 0) {
				Flip ();
			}
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				rb.velocity = Vector2.up * ps.jumpSpeed;
			}
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}
		if (isPaused) {
			pauseMenu.SetActive (true);
		}


		if (!isPaused) {
			if (Input.GetMouseButton (0)) {
				DigBlock ();
			}
		}
	}

	void Flip () {
		facingRight = !facingRight;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler;
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.gray;
		Gizmos.DrawWireSphere (groundCheck.transform.position, checkRaduis);
	}

	void DigBlock () {
		Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);
		if (hit.collider.gameObject.GetComponent<TileData> () != null && Vector2.Distance (hit.transform.position, this.gameObject.transform.position) < 4) {
		
			hit.collider.gameObject.GetComponent<TileData> ().health -= Time.deltaTime;

			if (hit.collider.gameObject.GetComponent<TileData> ().health <= 0) {

				if (hit.collider.gameObject.GetComponent<TileData> ().tileType.grass == true) {
					// if the tile is grass
					hit.collider.GetComponent<SpriteRenderer>().color = Color.Lerp (Color.white, Color.clear, .5f);
					Destroy (hit.collider.gameObject);
					GetComponent<inventory> ().AddItem (dirtItem, 1);
				} else if (hit.collider.gameObject.GetComponent<TileData> ().tileType.multiDrop == true) {
					//if the tile drops multiple of the item
					hit.collider.GetComponent<SpriteRenderer>().color = Color.Lerp (Color.white, Color.clear, .5f);
					Destroy (hit.collider.gameObject);
					GetComponent<inventory> ().AddItem (hit.collider.gameObject.GetComponent<TileData> ().tileType, Random.Range (1, 4));
				} else {
					//if the tile has no wierdness happening, just a normal basic tile
					hit.collider.GetComponent<SpriteRenderer>().color = Color.Lerp (Color.white, Color.clear, .5f);
					Destroy (hit.collider.gameObject);
					GetComponent<inventory> ().AddItem (hit.collider.gameObject.GetComponent<TileData> ().tileType, 1);
				}
			}
		}
	}
}