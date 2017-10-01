using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTime : MonoBehaviour {
	public float tsi;
	private float it;

	// Use this for initialization
	void Start () {
		it = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		tsi = Time.timeSinceLevelLoad - it;
	}
}
