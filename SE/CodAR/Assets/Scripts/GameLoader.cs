using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour {

	public string sceneName;
	public MeshRenderer mesh;
	public Camera cam;

	private Vector3 centralPos;

	// Use this for initialization
	void Start() {
		centralPos = mesh.bounds.center;
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
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && isInFrame (centralPos)) {
			cam.transform.position = Vector3.zero;

			SceneManager.LoadScene (sceneName);
		}
		
		}
}
