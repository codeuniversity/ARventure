using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour {

	public string requiredItem;

	public GameController gameController;


	private bool itemPresent;


	void Update() {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			CheckForKey ();
		}
	}

	void CheckForKey() {
		if (gameController.CheckItem (requiredItem)) {
			Debug.Log ("Success");
		} else {
			Debug.Log ("Failure");
		}
	}

}
