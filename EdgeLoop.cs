using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeLoop : MonoBehaviour {

	bool cloned;

	BoxCollider2D bc;
	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D> ();
		cloned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (bc.bounds.max.x > Camera.main.ViewportToWorldPoint(new Vector3(1,0, Camera.main.transform.position.z)).x && !cloned){
			GameObject block = Instantiate (gameObject, gameObject.transform.position + new Vector3(-2*Camera.main.orthographicSize* Screen.width/Screen.height,0,0), Quaternion.identity);
			block.transform.parent = gameObject.transform.parent;
			cloned = true;
		}



	}


}