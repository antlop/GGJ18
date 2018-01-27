using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeMemeber : MonoBehaviour {

	public GameObject[] Followers;
	public GameObject Leader;
	public int ID; 

	Vector2 goalPos = Vector2.zero;
	float speed = 5.0f;

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
		if( other.gameObject.tag == "NotInfected" ) {
			GameObject.FindGameObjectWithTag("HordeLeader").GetComponent<HordeLeader>().newInfected (other.gameObject);
		}
	}

	void flock() {
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Leader.transform.position - transform.position), speed * Time.deltaTime);
		//transform.position += transform.forward * Time.deltaTime * speed;
		if (Vector3.Distance (transform.position, Leader.transform.position) > 5.0f) {
			if( ID < 4 ) {
				//Leader.GetComponent<HordeMemeber> ().Followers [ID].tag = "Unused";

			}
		} else if (Vector3.Distance (transform.position, Leader.transform.position) > 0.25f) {
			transform.position = Vector2.MoveTowards (transform.position, Leader.transform.position, speed * Time.deltaTime);
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
	/*
	void DisconnectFollowers() {
		
		Queue<GameObject> q = new Queue<GameObject> ();
		q.Enqueue (Follower);

		while (q.Count > 0) {
			GameObject node = q.Dequeue ();

			for (int i = 0; i < 3; ++i) {
				if (node.GetComponent<HordeMemeber> ().Followers [i].tag != "Unused") {
					node.GetComponent<HordeMemeber> ().Followers [i] = obj;
					obj.GetComponent<HordeMemeber> ().ID = i;
					obj.GetComponent<HordeMemeber> ().Leader = node;
					return;
				} else {
					q.Enqueue (node.GetComponent<HordeMemeber> ().Followers [i]);
				}
			}
		}
	}*/
}
