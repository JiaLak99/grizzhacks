using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateLevel : MonoBehaviour {
	
	public GenerateData gd;

	public double averageHeight;

	public double Kdiff; //difficulty increase per level
	public double Kn;
	public double Ksl;   //difficulty increase per change in standard deviation of length
	public double Ksh;   //difficulty increase per change in standard deviation of height
	public double maxAllocation = .67; //largest percent of remaining difficulty that can be allocated to a given value (0-100)

	public int level;  //level number

	public double[] lengths;
	public double[] heights;

	public int unitsInScreen = 96;

	double difficulty;
	int n = -1;              //number of blocks
	double sl = -1;				//standard deviation of the lengths
	double sh = -1;             //standard deviation of the heights

	// Use this for initialization
	void Start () {
		
		System.Random rand = new System.Random ();
		
		difficulty = level * Kdiff;
		//Debug.Log (difficulty);
		double allocation;
		do {
			allocation = UnityEngine.Random.value * difficulty; //amount of the remaining difficulty to be allocated to Ksl*s
		} while (allocation/difficulty > maxAllocation);
		//Debug.Log (allocation);
		int selection = rand.Next() % 3; //	choose which to allocate first

		switch (selection){
		case 0:
			n = (int)(allocation / Kn);
			break;
		case 1:
			sl = 1 /(allocation * Ksl);
			break;
		case 2:
			sh = 1 /(allocation * Ksh);
			break;
			}

		difficulty -= allocation;
		//Debug.Log (n);
		//Debug.Log (difficulty);
		do {
			allocation = UnityEngine.Random.value * difficulty; //amount of the remaining difficulty to be allocated to Ksl*s
		} while (allocation/difficulty > maxAllocation);

		selection = rand.Next () % 2;

		if (selection == 0) {
			if (n != -1) {
				sl = 1 /(allocation * Ksl);
				difficulty -= allocation;
				sh = 1 /(difficulty * Ksh);
			}
			if (n == -1) {
				n = (int)(allocation / Kn);
				difficulty -= allocation;

				if (sl != -1) {
					sh = 1 /(difficulty * Ksh);
				} else {
					sl = 1 /(difficulty * Ksl);
				}
			}
		} else {
			if (sh != -1) {
				sl = 1 /(allocation * Ksl);
				difficulty -= allocation;
				n = (int)(difficulty / Kn);
			}
			if (sh == -1) {
				sh = 1 /(allocation * Ksh);
				difficulty -= allocation;

				if (sl != -1) {
					n = (int)(difficulty / Kn);
				} else {
					sl = 1 /(difficulty * Ksl);
				}
			}
		}
		if (n == 0)
			n = 2;
		print (n);

		lengths = gd.generateData(n, sl, unitsInScreen/n);

		foreach(double i in lengths) {
			print ("length is: " + i);
		}

		heights = gd.generateData (n + 1, sh, averageHeight);

		foreach (double x in heights) {
			print ("heights is: " + x);
		}

		for (int iii = 0; iii < heights.Length; iii++){
			print ("height1: " + Convert.ToString(heights[iii])); //temp
			heights[iii] = heights[iii];
			print ("height2: " + Convert.ToString(heights[iii])); //temp
		}

		double sum = 0;

		foreach (double l in lengths) {
			sum += l;
		}

		for (int iii = 0; iii < lengths.Length; iii++){
			lengths[iii] = lengths[iii] * unitsInScreen/sum;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
