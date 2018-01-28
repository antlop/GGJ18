using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeMemeber : MonoBehaviour {

	public GameObject[] Followers;
	public GameObject Leader;

	public HordeLeader hordeLeader;
	public int ID; 

	public int AddedIndex;
    public AudioClip pickupAudioClip;

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
		if (other.gameObject.tag == "NotInfected")
		{
		    if (hordeLeader != null)
            {
                hordeLeader.newInfected(other.gameObject);
                hordeLeader.GetComponentInChildren<AudioSource>().PlayOneShot(hordeLeader.pickupAudioClip);
            }

        }
        else if (other.gameObject.tag == "SingleEnemyDestroyer")
	    {
			hordeLeader.RemoveFromBFS();

	    }
	    else if (other.gameObject.tag == "MultipleEnemyDestroyer")
	    {
			hordeLeader.RemoveFromBFS();
	    }
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "SingleEnemyDestroyer") {
			hordeLeader.RemoveFromBFS ();
		} else if (other.gameObject.tag == "MultipleEnemyDestroyer") {
			hordeLeader.RemoveFromBFS ();
		}
	}

	void Update() {
		if (Leader == null) {
			hordeLeader.newInfected (gameObject);
		}
		Debug.DrawRay (transform.position, transform.forward, Color.white);
	}

	void flock() {
		//transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Leader.transform.position - transform.position), speed * Time.deltaTime);
		//transform.position += transform.forward * Time.deltaTime * speed;
		float dist = Vector3.Distance (transform.position, Leader.transform.position);
		if ( dist > 7.0f) {
			// need to figure out how to destroy individual
		} else if (dist > 0.015f) {
			transform.position = Vector2.MoveTowards (transform.position, Leader.transform.position, speed * Time.deltaTime * dist);
		} 

	}

	void FixedUpdate () {
		flock ();
	}
}
