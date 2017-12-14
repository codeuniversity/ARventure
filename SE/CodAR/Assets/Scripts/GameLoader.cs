using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour {

	public MeshRenderer mesh;
	public ARCamera cam;

	private Vector3 centralPos;

	// Use this for initialization
	void Start() {
		centralPos = mesh.bounds.center;
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && cam.isInFrame (centralPos)) {
			//Checks if Screen is pressed and if obj is in frame

			GameController.SwitchToGame ();
		}
		
	}
}
