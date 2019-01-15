using UnityEngine;
using System.Collections;

public class CanvasRotation : MonoBehaviour {

	public Transform head;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = head.rotation;
	}
}
