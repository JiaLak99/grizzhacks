using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstantiateBottom : MonoBehaviour {

	public GameObject go;
	GenerateLevel gl;

	public GameObject block1;
	public GameObject block2;
	public GameObject block4;
	public GameObject block8;
	public GameObject block16;
	public GameObject block32;
	public GameObject block64;

	GameObject childBlock;
	public float marginOfError;

	public float levelSpeed = 10;
	public int unitsInScreen = 96;

	public float collisionPoint0;
	public float speedOfFallingStuff;
	public float topOffset = 0;
	public Vector3 reference;

	string[] binaries;

	// Use this for initialization
	void Start () {

		reference = new Vector3 (Camera.main.ScreenToWorldPoint(new Vector2(0,0)).x ,Camera.main.ScreenToWorldPoint(new Vector2(0,-250)).y, 0);
		//Debug.Log (reference);

		gl = go.GetComponent<GenerateLevel> ();

		foreach (double x in gl.heights) {
			Debug.Log (x);
		}

		binaries = new string[gl.heights.Length];

		for (int iii = 0; iii < gl.lengths.Length; iii++){
			binaries[iii] = Convert.ToString((int)gl.lengths[iii],2);
		}

		int intSum = 0;
		foreach (double l in gl.lengths){
			Debug.Log ("length " + l);
			intSum += (int)l;
		}

		binaries[gl.lengths.Length] = Convert.ToString (unitsInScreen - intSum, 2);

		foreach (string l in binaries){
			Debug.Log ("length " + l);
		}

		for (int jjj = 0; jjj < binaries.Length;jjj++){
			
			char[] whichBlocks = binaries[jjj].ToCharArray ();
			//Debug.Log (whichBlocks);

			for (int iii = 0; iii < whichBlocks.Length; iii++) {
				if (whichBlocks [iii].Equals ('1')) {
					switch (whichBlocks.Length - iii -1){
					case 0:
						childBlock = Instantiate (block1, reference + new Vector3 (0.1f, (float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (0.2f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 1:
						childBlock = Instantiate (block2, reference + new Vector3 (0.2f, (float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (0.4f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 2:
						childBlock = Instantiate (block4, reference + new Vector3 (0.4f, (float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (0.8f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 3:
						childBlock = Instantiate (block8, reference + new Vector3 (0.8f,(float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (1.6f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 4:
						childBlock = Instantiate (block16, reference + new Vector3 (1.6f, (float)gl.heights[jjj]/100f, 0), Quaternion.identity);
						reference += new Vector3 (3.2f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 5:
						childBlock = Instantiate (block32, reference + new Vector3 (3.2f, (float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (6.4f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					case 6:
						childBlock = Instantiate (block64, reference + new Vector3 (6.4f,(float)(gl.heights[jjj]/100f), 0), Quaternion.identity);
						reference += new Vector3 (12.8f, 0, 0);
						childBlock.transform.parent = gameObject.transform;
						break;
					}
				}
			}
		}

		System.Random rand = new System.Random();

		float topHorizontalOffset = (float)rand.NextDouble() * Camera.main.orthographicSize * Screen.width / Screen.height * 2;

		GameObject top = Instantiate(new GameObject("Top"), GetComponent<Transform>().position + new Vector3(topHorizontalOffset, 0, 0), Quaternion.identity);
		top.transform.transform.parent = gameObject.transform.parent;

		top.AddComponent<Slide> ();
		top.GetComponent<Slide> ().speed = levelSpeed;
		top.GetComponent<Slide> ().horizontal = true;

		top.AddComponent<MouseClick> ();
		top.GetComponent<MouseClick> ().collisionPoint = collisionPoint0;
		top.GetComponent<MouseClick> ().speed = speedOfFallingStuff;
		top.GetComponent<MouseClick> ().levelThing = go;
		top.GetComponent<MouseClick> ().tho = topHorizontalOffset;
		top.GetComponent<MouseClick> ().margin = marginOfError;
		top.GetComponent<MouseClick> ().speed = levelSpeed;

		for (int iii = 0; iii < gameObject.transform.childCount; iii++){
			GameObject child = Instantiate (gameObject.transform.GetChild (iii).gameObject, gameObject.transform.GetChild (iii).position + new Vector3(0,9,0), Quaternion.identity);
			child.transform.parent = top.transform;
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
