using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 1.0f;
	public int scorePerKill = 10;
	public float speedMultiplier;
	public Color blue;

	private Transform playerT;
	private float speed;
	private GameObject gm;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find ("GvrMain");
		playerT = player.transform;
		gm = GameObject.Find("GameManager");
		speed = gm.GetComponent<GameManager> ().waves * speedMultiplier;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 relativePos = (playerT.position + new Vector3(0, 1.2f, 0)) - transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos);

		Quaternion current = transform.localRotation;

		transform.rotation = Quaternion.Slerp(current, rotation, Time.deltaTime);
		transform.Translate(0, 0, 3 * (Time.deltaTime * speed));

		if (gm.GetComponent<GameManager> ().isGameOver) {
			Destroy (this.gameObject);
		}

	}

	void FixedUpdate() {
		
	}
		
	public void Damage(int gunDamage) {
		health -= gunDamage;

		if (health <= 0.0f) {
			gm.GetComponent<GameManager> ().IncrementScore (scorePerKill);
			Destroy (this.gameObject);	
		} else if (health == 1.0f) {
			gameObject.GetComponent<MeshRenderer> ().material.SetColor("_Color", blue);
		}

	}
}
