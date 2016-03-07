using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class controlLight : MonoBehaviour {

	// Random rotation
	float xrot;
	float yrot;
	//float zrot;
	// Random starting position
	float xpos;
	float ypos;
	float zpos;
	// Change color intensity
	float colorintensity;
	// Control when color changes
	float colortimer;
	float colorspeed;

	// List of colors to change the lights
	List<Color> colorlist = new List<Color>( new Color[] {Color.red, Color.green, Color.blue, Color.cyan, Color.magenta, Color.yellow});
	
	// Run on start only
	void Start() {
		// Control when color changes
		colortimer = 0f;
		colorspeed = 1f; // Seconds

		// Random rotation
		xrot = Random.Range (-200, 200);
		yrot = Random.Range (-200, 200);
		//zrot = Random.Range (-200, 200);
		
		// Random starting position
		xpos = Random.Range (-5, 5);
		ypos = Random.Range (2, 8);
		zpos = Random.Range (-5, -2);
		this.transform.position = new Vector3 (xpos, ypos, zpos);

		// Change light intensity
		colorintensity = Random.Range (2,8);
		this.GetComponent<Light> ().intensity = colorintensity;
	}


	// Update is called once per frame
	void Update () {

		// Change the color every 1 second
		colortimer += Time.deltaTime;
		if (colortimer >= colorspeed) {
			colortimer = 0;
			this.GetComponent<Light> ().color = colorlist [Random.Range (0, 5)];
		}
		this.transform.Rotate (new Vector3 (xrot, yrot, 0) * Time.deltaTime);
	}
}
