using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	public MeshRenderer coinbody;
	public Vector3 rotationAxis = Vector3.up; //Sometimes I needed to set a different rotation axis, thus public.

	private Vector3 coinposition;

	// Use this for initialization
	void Start () {
		coinposition = coinbody.bounds.center;
	}
	
	// Update is called once per frame
	void Update () {

		// Without the following line, the obj would rotate around it's out-of-bound center, yielding a funny
		// effect, this normalises it.
		transform.RotateAround (coinposition, rotationAxis, 300 * Time.deltaTime);
	}
}
