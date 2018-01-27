using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 velocity;
	public float movementSpeed;
	public float maxSpeed;
	public float drag;
	// public Vector2 acceleration;

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
		//ApplyDrag ();
		//UpdatePosition ();
	}

	void FixedUpdate() {
		UpdateVelocityWithRecordedInput ();
		ApplyDrag ();
		transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x, velocity.y);
	}

	void RecordInputs() {
		pressingUp = false;
		pressingDown = false;
		pressingLeft = false;
		pressingRight = false;
		if (Input.GetKey ("up") || Input.GetKey("w")) {
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

	void UpdateVelocityWithRecordedInput() {

		if (pressingUp) {
			velocity += movementSpeed * Vector3.up;
		}
		if (pressingDown) {
			velocity += movementSpeed * Vector3.down;
		}
		if (pressingLeft) {
			velocity += movementSpeed * Vector3.left;
		}
		if (pressingRight) {
			velocity += movementSpeed * Vector3.right;
		}

		// Cap at max speed (in any direction)
		if (velocity.x > maxSpeed) {velocity.x = maxSpeed;}
		if (velocity.x < -maxSpeed) {velocity.x = -maxSpeed;}
		if (velocity.y > maxSpeed) {velocity.y = maxSpeed;}
		if (velocity.y < -maxSpeed) {velocity.y = -maxSpeed;}
	}

	void UpdatePosition() {
		transform.position += velocity * Time.deltaTime;
	}

	void UpdateVelocity() {
		
		if (Input.GetKey ("up") || Input.GetKey("w")) {
			velocity += movementSpeed * Vector3.up;
		}
		if (Input.GetKey ("down") || Input.GetKey("s")) {
			velocity += movementSpeed * Vector3.down;
		}
		if (Input.GetKey ("left") || Input.GetKey("a")) {
			velocity += movementSpeed * Vector3.left;
		}
		if (Input.GetKey ("right") || Input.GetKey("d")) {
			velocity += movementSpeed * Vector3.right;
		}

		// Cap at max speed (in any direction)
		if (velocity.x > maxSpeed) {velocity.x = maxSpeed;}
		if (velocity.x < -maxSpeed) {velocity.x = -maxSpeed;}
		if (velocity.y > maxSpeed) {velocity.y = maxSpeed;}
		if (velocity.y < -maxSpeed) {velocity.y = -maxSpeed;}
	}

	void ApplyDrag() {
		velocity -= drag * Time.deltaTime * velocity;
	}
}
