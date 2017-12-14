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

	// Holds a value which pads the object 
	public float extentsionPadding;


	public GameController gameController;
	public Camera cam;

	// Holds the coin objects, 9:1 normal:red
	// So one in 10 coins should be red.
	public GameObject[] coins;

	private MeshRenderer mesh;
	private Rigidbody rb;

	// This is the difference between the rigidbody objects position and the mesh's position
	// I figured it out through hard debugging, there should also be a mathematical way to get there, to make
	// it more dynamic, but I elected to do it this way because of time constraints
	private float differenceMeshRigidbody = 1.2f;

	// Holds the data needed to spawn coins. ACTUALLY NOT A POSITIONAL V3!!!
	private Vector3 coinSpawn;

	// This is going to hold the extention between the center of the mesh + padding as a viewport value
	private float viewpointExtention;



	private int coinCounter = 0;

	void Start () {


		GetMyComponents ();

		Vector3 meshSize = mesh.bounds.extents;


		// The following line shows a problem with Unity
		// WorldToViewportPoint needs a V3 position, but I am only interested in the x value,
		// So I have to feed it with on the spot created V3, to get the difference of origin to
		// obj extention + padding in viewpoint values.
		viewpointExtention = 
			(WorldToView(Vector3.zero).x - (WorldToView(Vector3.one * (meshSize.x + extentsionPadding)).x));


		// X and Y are used for a random range for the actual spawn-X, Z is used for spawn-Y, spawn-Z will always be 0   
		coinSpawn = new Vector3 (
			ViewToWorld(Vector3.zero).x,
			ViewToWorld(Vector3.one).x,
			ViewToWorld(Vector3.one * 1.2f).y);

		// This is basically using threading. I can't fully explain it, read the Unity Documentation if you're interested
		StartCoroutine (coinSpawner());

	}

	void GetMyComponents() {
		//Grabs components needed

		rb = GetComponent<Rigidbody> ();

		mesh = GetComponentInChildren<MeshRenderer> ();
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

		string title = "Game Completed!";
		string message = "You gained " + coinCounter.ToString() + " coins!";

		// Transitional PopUp switches back to world after it is dealt with by the user
		Popup.TransitionalPopUp(title, message);

	}
		


	void spawnCoin() {
		GameObject coin = coins[Random.Range(0, coins.Length)]; //Grabs random coin, 1 in 10 chance of it being red

		Instantiate (
			coin, 

			new Vector3 (
				Random.Range (coinSpawn.x, coinSpawn.y), //Any point on the actual rendered screen can spawn a coin
				coinSpawn.z,
				0), // Z coordinate is always zero, since we're semi 2D in this scene
			
			Quaternion.identity //Basically means: no rotation
		);
	}


	//FixedUpdate runs once every physics operation, so before every frame
	//and thus before every Update()
	void FixedUpdate () {
		
		Vector3 acceleration = Input.acceleration; //Grabs the accelerometer data


		Vector3 movement = new Vector3(acceleration.x, 0.0f, 0.0f); //takes only the x value from the data above, not interested in y-axis


		rb.velocity = movement * speed; //sets the velocity of the game object to the above data * external speed multiplier



//		float currentPosMesh = mesh.bounds.center.x;

		Vector3 currentPos = new Vector3 (rb.position.x - differenceMeshRigidbody, rb.position.y, rb.position.z);

		// corrects obj position to be within the frame, always being at least padding away from the edge.
		rb.position = new Vector3 (
			ViewToWorld( // There is probably a smarter solution for this, but I had to hack it together
				new Vector3 ( 
					Mathf.Clamp (
						WorldToView(currentPos).x , 0 - viewpointExtention, 1 + viewpointExtention), //viewpointExt is a negative value
					0.0f,
					0.0f)).x + differenceMeshRigidbody, //since we calculate the position for the Mesh, we need to translate it for rb
			rb.position.y, 
			rb.position.z
		);
	

		
	}

	void OnTriggerEnter(Collider e) {
		//Gets called when coin enters trigger

		int valueGain = e.GetComponent<Coin> ().worth;
		gameController.UpdateMoney (valueGain);
		coinCounter += valueGain;
		Destroy (e.gameObject);
	}

	private Vector3 WorldToView(Vector3 pos) {
		// Calling this function of Camera a lot, so I made it a private function so it is more readable
		return cam.WorldToViewportPoint (pos);
	}

	private Vector3 ViewToWorld(Vector3 pos) {
		// Calling this function of Camera a lot, so I made it a private function so it is more readable
		return cam.ViewportToWorldPoint (pos);
	}
}

