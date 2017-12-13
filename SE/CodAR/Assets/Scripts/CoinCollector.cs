using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollector : MonoBehaviour {

	public float speed;
	public float waitTime;
	public float gameTime;

	public Vector3 spawnPosition;
	public float extentsionPadding;
	public Text text;

	public GameController gameController;
	public Camera camera;
	public GameObject[] coins;
	public Camera arCam;

	private MeshRenderer mesh;
	private Rigidbody rb;
	private float differenceMeshRigidbody = 1.2f;

	private Vector3 coinSpawn;
	private float viewpointExtention;
	private int coinCounter = 0;

	void Start () {
		arCam.transform.SetPositionAndRotation (Vector3.one * 10, Quaternion.identity);
		rb = GetComponent<Rigidbody> ();

		mesh = GetComponentInChildren<MeshRenderer> ();

		Debug.Log (mesh.bounds);
		viewpointExtention = (camera.WorldToViewportPoint(Vector3.zero).x - (camera.WorldToViewportPoint(Vector3.one * (0.8f + extentsionPadding)).x));

		text.text = gameController.money.ToString ();

		coinSpawn = new Vector3 (
			camera.ViewportToWorldPoint(Vector3.zero).x,
			camera.ViewportToWorldPoint(Vector3.one).x,
			camera.ViewportToWorldPoint (Vector3.one * 1.2f).y);

		StartCoroutine (coinSpawner());

	}
	
	IEnumerator coinSpawner() {
		yield return new WaitForSeconds (waitTime);
		float startTime = Time.time;
		while (Time.time - startTime < gameTime) {
			spawnCoin ();
			yield return new WaitForSeconds (0.2f);
		}
		yield return new WaitForSeconds (waitTime);
		gameController.SaveMoney ();
		PopUp ();

	}
		
	void PopUp() {
		MNPopup popup = new MNPopup ("Game Ended!", "You collected " + coinCounter.ToString() + " coins");
		popup.AddAction ("Continue", () => {SceneManager.LoadScene("01_World");});
		popup.AddDismissListener (() => {SceneManager.LoadScene("01_World");});
		popup.Show ();
	}

	void spawnCoin() {
		GameObject coin = coins[Random.Range(0, coins.Length)];
		Instantiate (coin, new Vector3 (
			Random.Range (coinSpawn.x, coinSpawn.y), coinSpawn.z, 0), Quaternion.identity);
	}

	void FixedUpdate () {
		Vector3 acceleration = Input.acceleration;



		Vector3 movement = new Vector3(acceleration.x, 0.0f, 0.0f);

		rb.velocity = movement * speed;

		float currentPosMesh = mesh.bounds.center.x;
		Vector3 currentPos = new Vector3 (rb.position.x - differenceMeshRigidbody, rb.position.y, rb.position.z);


		rb.position = new Vector3 (
			camera.ViewportToWorldPoint (
				new Vector3 ( 
					Mathf.Clamp (
						camera.WorldToViewportPoint (currentPos).x , 0 - viewpointExtention, 1 + viewpointExtention),
						0.0f,
						0.0f)).x + differenceMeshRigidbody,
			rb.position.y, 
			rb.position.z
		);
	

		
	}

	void OnTriggerEnter(Collider e) {

		gameController.money += e.GetComponent<Coin> ().worth;
		coinCounter += e.GetComponent<Coin> ().worth;
		Destroy (e.gameObject);
		text.text = gameController.money.ToString ();
	}
}

