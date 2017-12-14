using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public bool items;
	public bool progression;
	public int money;


	public static int staticMoney;

	public Text text;



	void Start() {
		if (staticMoney == null) {
			money = 0;
		} else {
			money = staticMoney;
		};
		text.text = money.ToString();

		/*
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

			money = PlayerPrefs.GetInt ("money");

		}
		text.text = money.ToString();
	*/

	}



	/*


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

	*/
	public void SaveMoney() {
		staticMoney = money;
	}

	



}
