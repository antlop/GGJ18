using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float inputThrust;
	public float maxSpeed;
	public float drag;
	// public Vector2 acceleration;

	public float waterFlowVelocity;
	public float waterViscosity;

	// To be able to get inputs in Update() and apply them 
	// in FixedUpdate() to get rid of jittering on collision
	bool pressingUp;
	bool pressingDown;
	bool pressingLeft;
	bool pressingRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RecordInputs ();
		// UpdateVelocity ();
		// ApplyDrag ();
		// UpdatePosition ();
	}

	void FixedUpdate() {
		// UpdateVelocityWithRecordedInput ();

		AddForceFromRecordedInputs ();
		ApplyFluidDrag ();

		//ApplyDrag ();
		//transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
	}

	void RecordInputs() {
		pressingUp = false;
		pressingDown = false;
		pressingLeft = false;
		pressingRight = false;
		if (Input.GetKey ("up") || Input.GetKey("w")) {
			Debug.Log ("Pressing up!");
			pressingUp = true;
		}
		if (Input.GetKey ("down") || Input.GetKey("s")) {
			pressingDown = true;
		}
		if (Input.GetKey ("left") || Input.GetKey("a")) {
			pressingLeft = true;
		}
		if (Input.GetKey ("right") || Input.GetKey("d")) {
			pressingRight = true;
		}
	}

	void AddForceFromRecordedInputs() {
		Vector2 directionVector;

		if (pressingUp) {
			directionVector = Vector2.up;
			Debug.Log ("Direction vector is: " + directionVector);
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingDown) {
			directionVector = Vector2.down;
			Debug.Log ("Direction vector is: " + directionVector);
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingLeft) {
			directionVector = Vector2.left;
			Debug.Log ("Direction vector is: " + directionVector);
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingRight) {
			directionVector = Vector2.right;
			Debug.Log ("Direction vector is: " + directionVector);
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
	}



	void ApplyFluidDrag() {
		float playerVelocity = transform.GetComponent<Rigidbody2D> ().velocity.x;
		float relativeVelocity = waterFlowVelocity - playerVelocity;
		float force = waterViscosity * Mathf.Pow (relativeVelocity, 2);
		if (relativeVelocity < 0) {
			force = -force;
		}
		transform.GetComponent<Rigidbody2D> ().AddForce (force * Vector2.right);
	}
}
