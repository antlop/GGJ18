using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceCheck : MonoBehaviour {
	private GameObject player;
	public float distanceThreshhold = 7.0f;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (GetComponent<HordeMemeber> ()) {
			//if( GetComponent<HordeMemeber>().
		}

		if (player == null) {
			Destroy (gameObject);
		}

		else if (transform.position.x < player.transform.position.x && Vector3.Distance (transform.position, player.transform.position) > distanceThreshhold) {
			Destroy (gameObject);
		}
	}
}
