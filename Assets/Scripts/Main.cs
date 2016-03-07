using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour {

	// Load prefab
	public GameObject spotlightprefab;

	void Start() {
		// Create new object from prefab
		for (int i = 0; i < 10; i++) {
			Instantiate (spotlightprefab);
		}
	}
}





