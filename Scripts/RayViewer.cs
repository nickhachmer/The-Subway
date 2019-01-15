using UnityEngine;
using System.Collections;

public class RayViewer : MonoBehaviour {

	public float weponRange = 50.0f;
	private Camera fpsCam;

	// Use this for initialization
	void Start () {
		fpsCam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lineOrigin = fpsCam.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, 0.0f));
	
		Debug.DrawRay (lineOrigin, fpsCam.transform.forward * weponRange, Color.green);
	}

}
