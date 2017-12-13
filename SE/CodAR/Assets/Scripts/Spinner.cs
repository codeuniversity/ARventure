using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	public MeshRenderer coinbody;
	public Vector3 rotationAxis = Vector3.up;

	private Vector3 coinposition;

	// Use this for initialization
	void Start () {
		coinposition = coinbody.bounds.center;
	}
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (coinposition, rotationAxis, 300 * Time.deltaTime);
	}
}
