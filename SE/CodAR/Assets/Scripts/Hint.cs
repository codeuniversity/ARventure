using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {


	public MeshRenderer mesh;
	public ARCamera cam;

	public string hintMessage;

	private Vector3 centralPos;

	// Use this for initialization
	void Start() {
		centralPos = mesh.bounds.center;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && cam.isInFrame (centralPos)) {
			//Checks if Screen is pressed and if obj is in frame

			Popup.InfoBox ("Hint!", hintMessage);
		}
		
	}
}
