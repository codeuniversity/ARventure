using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {

	public static void InfoBox(string title, string message) {
		MNPopup popup = new MNPopup (title, message);
		popup.AddAction ("Continue", () => {Debug.Log("Ok action callback");});
		popup.AddDismissListener (() => {Debug.Log("dismiss listener");});
		popup.Show ();
	}

	public static void TransitionalPopUp(string title, string message) {
		// Always transitions to world!
		MNPopup popup = new MNPopup (title, message);
		popup.AddAction ("Continue", () => {GameController.SwitchToWorld();});
		popup.AddDismissListener (() => {GameController.SwitchToWorld();});
		popup.Show ();
	}

}
