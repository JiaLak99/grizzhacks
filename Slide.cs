using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

	public float speed = 0;

	public bool horizontal = true;

	Vector3 translation;
	Transform tr;

	// Use this for initialization
	void Start () {

		if (horizontal) {
			translation = new Vector3 (speed, 0, 0);
		} else {
			translation = new Vector3 (0, speed, 0);
		}
		tr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		tr.Translate (translation * Time.deltaTime);
	}
}
