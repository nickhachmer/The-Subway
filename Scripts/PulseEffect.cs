using UnityEngine;
using System.Collections;

public class PulseEffect : MonoBehaviour {

	public Material wall;

	private Color start = new Color(0.7f, 0.4f, 1f, 0.05f);
	private Color end = new Color (0.7f, 0.4f, 1f, 0.3f);

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		float time = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
		wall.color = Color.Lerp (start, end, time);

	}

}
