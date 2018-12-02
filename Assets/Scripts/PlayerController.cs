using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Vector2 inputThrust;

	public float waterFlowVelocity;
	public float waterViscosity;

	// To be able to get inputs in Update() and apply them 
	// in FixedUpdate() to get rid of jittering on collision
	bool pressingUp;
	bool pressingDown;
	bool pressingLeft;
	bool pressingRight;

	// Variables for multiplayer
	public int playerNum;
	string upKey;
	string downKey;
	string rightKey;
	string leftKey;

	// Use this for initialization
	void Start () {
		InitPlayer (playerNum);
		
	}
	
	// Update is called once per frame
	void Update () {
		RecordInputs ();
	}

	void FixedUpdate() {
		AddForceFromRecordedInputs ();
		ApplyFluidDrag ();
	}

	void InitPlayer(int playerNum) {
		if (playerNum == 1) {
			upKey = "up";
			downKey = "down";
			rightKey = "right";
			leftKey = "left";
		} else if (playerNum == 2) {
			upKey = "w";
			downKey = "s";
			rightKey = "d";
			leftKey = "a";
		} else {
			Debug.LogError ("Not a valid player number: " + playerNum);
		}
	}

	void RecordInputs() {
		pressingUp = false;
		pressingDown = false;
		pressingLeft = false;
		pressingRight = false;
        
		if (CrossPlatformInputManager.GetAxis("Horizontal") > 0.1f) {
            inputThrust.x = Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal"));
			pressingRight = true;
		}
		if (CrossPlatformInputManager.GetAxis("Horizontal") < -0.1f)
        {
            inputThrust.x = Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal"));
            pressingLeft = true;
		}
		if (CrossPlatformInputManager.GetAxis("Vertical") > 0.1f)
        {
            inputThrust.y = Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical"));
            pressingUp = true;
		}
		if (CrossPlatformInputManager.GetAxis("Vertical") < -0.1f)
        {
			pressingDown = true;
            inputThrust.y = Mathf.Abs(CrossPlatformInputManager.GetAxis("Vertical"));
        }   
        inputThrust *= 5f;
	}

	void AddForceFromRecordedInputs() {
		Vector2 directionVector;

		if (pressingUp) {
			directionVector = Vector2.up;
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingDown) {
			directionVector = Vector2.down;
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingLeft) {
			directionVector = Vector2.left;
			transform.GetComponent<Rigidbody2D> ().AddForce(directionVector * inputThrust);
		}
		if (pressingRight) {
			directionVector = Vector2.right;
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
