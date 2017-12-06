using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public bool items;
	public bool progression;


	void Start() {
		if (!PlayerPrefs.HasKey ("firstrun")) {
			
			PlayerPrefs.SetInt ("firstrun", 1);

			PlayerPrefs.SetInt ("items", 0);
			items = false;

			PlayerPrefs.SetInt ("progression", 0);
			progression = false;

			PlayerPrefs.SetInt ("lastscene", 0);


		} else {
			
			items = GetValue ("items");

			progression = GetValue ("progression");

		}
	}





	bool GetValue(string key) {
		return (PlayerPrefs.GetInt (key) != 0);
	}

	public bool CheckItem(string name) {
		if (name == "screwdriver" && items) {
			return true;
		} else {
			return false;
		}
	}



}
