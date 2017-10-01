using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateData : MonoBehaviour {

	public double[] generateData(int n, double sigma, double mu){

		sigma = 100; //temp

		double[] data = new double[n];

		//print ("n is: " + Convert.ToString(n));
		print ("sigma is: " + Convert.ToString(sigma));
		print ("mu is: " + Convert.ToString(mu));

		while (n > 0) {
			//System.Random rand = new System.Random(); //reuse this if you are generating many
			System.Random rand = new System.Random(Guid.NewGuid().GetHashCode());
			double u1 = 1.0-rand.NextDouble(); //uniform(0,1] random doubles
			double u2 = 1.0-rand.NextDouble();
			double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
				Math.Cos(2.0 * Math.PI * u2); //random normal(0,1)
			double randNormal =
				mu + sigma * randStdNormal; //random normal(mean,stdDev^2)
			if (randNormal < 0) {
				randNormal *= -1;
			}
			data[n - 1] = randNormal;
			//print ("randstdnormal is: " + Convert.ToString (randStdNormal));
			//print ("randnormal is: " + Convert.ToString(randNormal));
			//print ("u1 is: " + Convert.ToString(u1));
			//print ("u2 is: " + Convert.ToString(u2));
			print ("array data is: " + Convert.ToString(data[n - 1]));
			n = n - 1;
		}

		foreach (double i in data) {
			Debug.Log (i);
		}
		return data;
	}
}