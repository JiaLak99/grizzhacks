using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDone : MonoBehaviour {

	BoxCollider2D red1;
	BoxCollider2D red2;

	public MenuControl mc;

	// Use this for initialization
	void Start () {
		red1 = gameObject.transform.GetChild (0).GetComponent<BoxCollider2D>();
		red2 = gameObject.transform.GetChild (1).GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(red1.bounds.min.y <= red2.bounds.max.y){
			Debug.Log ("Kill me now!");
			mc.LoadScene ("LoseGame");
		}
	}
}
