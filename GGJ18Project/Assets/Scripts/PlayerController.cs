using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector3 velocity;
	public float movementSpeed;
	public float maxSpeed;
	public float drag;
	// public Vector2 acceleration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateVelocity ();
		ApplyDrag ();
		UpdatePosition ();
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
