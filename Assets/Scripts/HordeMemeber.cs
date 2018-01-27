using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeMemeber : MonoBehaviour {

	public GameObject[] Followers;
	public GameObject Leader;
	public int ID; 

	public int AddedIndex;

	Vector2 goalPos = Vector2.zero;
	float speed = 3.0f;

	void Start() {
		Followers = new GameObject[3];
		Followers [0] = new GameObject();
		Followers [1] = new GameObject();
		Followers [2] = new GameObject();

		Followers [0].tag = "Unused";
		Followers [1].tag = "Unused";
		Followers [2].tag = "Unused";

	}


	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Collide");
		if (other.gameObject.tag == "NotInfected") {
			GameObject.FindGameObjectWithTag ("HordeLeader").GetComponent<HordeLeader> ().newInfected (other.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "SingleEnemyDestroyer") {
			GameObject.FindGameObjectWithTag ("HordeLeader").GetComponent<HordeLeader> ().RemoveFromBFS ();
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "MultipleEnemyDestroyer") {
			GameObject.FindGameObjectWithTag ("HordeLeader").GetComponent<HordeLeader> ().RemoveFromBFS ();
			Destroy (other.gameObject);
		}
	}

	void Update() {
		if (Leader == null) {
			GameObject.FindGameObjectWithTag ("HordeLeader").GetComponent<HordeLeader> ().newInfected (gameObject);
		}
		Debug.DrawRay (transform.position, transform.forward, Color.white);
	}

	void flock() {
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Leader.transform.position - transform.position), speed * Time.deltaTime);
		//transform.position += transform.forward * Time.deltaTime * speed;
		float dist = Vector3.Distance (transform.position, Leader.transform.position);
		if ( dist > 5.0f) {
			if( ID < 4 ) {
			}
		} else if (dist > 0.015f) {
			transform.position = Vector2.MoveTowards (transform.position, Leader.transform.position, speed * Time.deltaTime * dist);
		} 

	}

	void FixedUpdate () {
		flock ();
		if (Leader == null) {
			goalPos = GameObject.FindGameObjectWithTag ("HordeLeader").transform.position;
		} else {
			goalPos = Leader.transform.position;
		}

	}
}
