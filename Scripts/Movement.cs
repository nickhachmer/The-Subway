using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public float health;
	public float healthLoss;

	// Use this for initialization
	void Start () {
		health = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {

		float z = Input.GetAxis ("Horizontal");
		float x = Input.GetAxis ("Vertical");

		if (x > 0) {
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
		} else if (x < 0) {
			transform.position = transform.position + Camera.main.transform.forward * -speed * Time.deltaTime;
		}

		if (z > 0) {
			transform.position = transform.position + Camera.main.transform.right * speed * Time.deltaTime;
		} else if (z < 0) {
			transform.position = transform.position + Camera.main.transform.right * -speed * Time.deltaTime;
		}
	}
	void OnTriggerEnter(Collider enemy) {
		health -= healthLoss;
	}
}
