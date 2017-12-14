using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCamera : MonoBehaviour {


	private Camera arCam;
	// Use this for initialization
	void Start () {
		arCam = GetComponent<Camera> ();
	}

	public bool isInFrame(Vector3 pos) {
		if ((arCam.WorldToViewportPoint (pos).z < 1)) { //Checks if position is in front of camera
			return false;
		} else if ((arCam.WorldToViewportPoint (pos).x < 0.0f || arCam.WorldToViewportPoint (pos).x > 1.0f)) {
			//checks if position is in frame on the x axis
			return false;
		} else if ((arCam.WorldToViewportPoint (pos).y < 0.0f && arCam.WorldToViewportPoint (pos).y > 1.0f)) {
			//checks if position is in frame on y axis
			return false;
		} else {
			return true;
		}
	}

	// Overloading for ease of use

	public bool isInFrame(Transform trans) {
		return isInFrame (trans.position);
	}

	public bool isInFrame(GameObject obj) {
		return isInFrame (obj.transform.position);
	}

}
