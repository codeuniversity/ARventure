using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needs UI to interact with Text
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	//public bool items;
	//public bool progression;

	public int money; // local variable to display


	private static int staticMoney; // keeps it's value between scenes, but not between executions
	// This is merely a workaround! In a proper project I'd probably use a way to permanently save money!



	public Text moneyText;




	void Start() {
		if (staticMoney == null) {
			money = 0;
		} else {
			money = staticMoney;
		};
		moneyText.text = money.ToString();

		/* Out of scope!
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
	public void UpdateMoney(int value) {
		money += value;
		moneyText.text = money.ToString ();
	}

	public void SaveMoney() {
		staticMoney = money;
	}


	public static void SwitchToGame() {
		SceneManager.LoadScene ("03_Coin_Game");
	}

	public static void SwitchToWorld() {
		SceneManager.LoadScene ("01_World");
	}



}
