using UnityEngine;
using System.Collections;

public class controlMenuItem : MonoBehaviour {
	// These are all for the text mesh child
	public GameObject menuItemTextMesh;
	public Renderer menuItemRenderer;
	public Transform menuItemTransform;
	
	// Lerp stuff
	public Vector3 menuItemStartPosition;
	public Vector3 menuItemOriginalStartPosition;
	public Vector3 menuItemEndPosition;
	public Vector3 menuItemFinalEndPosition;
	public Vector3 middlePosition;
	private float startTime;
	private float journeyLength;
	private float speed = 5.0f;
	private float lerpDistance = -0.5f;

	void Start() {
		// Get child text mesh object
		menuItemTextMesh = this.gameObject.transform.GetChild(0).gameObject;
		
		// Get components for text mesh object for changing color and position
		menuItemRenderer = menuItemTextMesh.GetComponent<Renderer> ();
		menuItemTransform = menuItemTextMesh.GetComponent<Transform> ();

		// Set starting color of text mesh
		menuItemRenderer.material.color = Color.white;

		// Save original location of menuItem and camera position
		menuItemOriginalStartPosition = new Vector3(menuItemTransform.position.x, menuItemTransform.position.y, menuItemTransform.position.z);
		menuItemFinalEndPosition = new Vector3 (Camera.main.gameObject.transform.position.x, Camera.main.gameObject.transform.position.y, Camera.main.gameObject.transform.position.z);

		// Position between menuItem and Main camera
		middlePosition = (menuItemOriginalStartPosition + (lerpDistance * Vector3.Normalize (menuItemOriginalStartPosition - menuItemFinalEndPosition)));
		menuItemFinalEndPosition = middlePosition;

		// Set starting values
		menuItemStartPosition = menuItemOriginalStartPosition;
		menuItemEndPosition = menuItemOriginalStartPosition;
		startTime = Time.time;
		journeyLength = Vector3.Distance (menuItemStartPosition, menuItemEndPosition);
	}

	void OnMouseEnter() {
		menuItemRenderer.material.color = Color.red;

		// Set start and end positions for lerp
		menuItemStartPosition = menuItemTransform.position;
		menuItemEndPosition = menuItemFinalEndPosition;
		
		// Set time and distance for lerp
		startTime = Time.time;
		journeyLength = Vector3.Distance (menuItemStartPosition, menuItemEndPosition);


	}

	void OnMouseExit() {
		menuItemRenderer.material.color = Color.white;

		// Set start and end positions for lerp
		menuItemStartPosition = menuItemTransform.position;
		menuItemEndPosition = menuItemOriginalStartPosition;
		
		// Set time and distance for lerp
		startTime = Time.time;
		journeyLength = Vector3.Distance (menuItemStartPosition, menuItemEndPosition);


	}

	void OnMouseDown() {
		// Control what happens when you click stuff
		if (menuItemTextMesh.GetComponent<TextMesh>().text == "New") {
			print (menuItemTextMesh.GetComponent<TextMesh> ().text);
		}
		else if (menuItemTextMesh.GetComponent<TextMesh>().text == "Show") {
			print (menuItemTextMesh.GetComponent<TextMesh> ().text);
		}
		else if (menuItemTextMesh.GetComponent<TextMesh>().text == "Delete") {
			print (menuItemTextMesh.GetComponent<TextMesh> ().text);
		}
		else if (menuItemTextMesh.GetComponent<TextMesh>().text == "Options") {
			print (menuItemTextMesh.GetComponent<TextMesh> ().text);
		}
		else if (menuItemTextMesh.GetComponent<TextMesh>().text == "Exit") {
			print ("EXITING");
			Application.Quit();
		}
	}

	void Update() {
		// Lerp stuff
		if (journeyLength > 0 ) {
			float distanceCovered = (Time.time - startTime) * speed;
			float fracJourney = distanceCovered / journeyLength;
			menuItemTransform.position = Vector3.Lerp (menuItemStartPosition, menuItemEndPosition, fracJourney);
		}
	}

}
