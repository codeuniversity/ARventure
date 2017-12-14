using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

	public Camera cam;
	public MeshRenderer mesh;

	public string title;
	public string message;

	private Vector3 centralPos;

	void Start() {
		centralPos = mesh.bounds.center;
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1") && isInFrame(centralPos)) {
			MNPopup popup = new MNPopup (title, message);
			popup.AddAction ("Continue", () => {Debug.Log("Ok action callback");});
			popup.AddDismissListener (() => {Debug.Log("dismiss listener");});
			popup.Show ();
		}
	}

	private bool isInFrame(Vector3 pos) {

		if ((cam.WorldToViewportPoint (pos).z < 1)) {
			return false;
		} else if ((cam.WorldToViewportPoint (pos).x < 0.0f || cam.WorldToViewportPoint (pos).x > 1.0f)) {
			return false;
		} else if ((cam.WorldToViewportPoint (pos).y < 0.0f && cam.WorldToViewportPoint (pos).y > 1.0f)) {
			return false;
		} else {
			return true;
		}



	}
}
