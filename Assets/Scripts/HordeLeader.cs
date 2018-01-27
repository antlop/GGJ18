using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeLeader : MonoBehaviour {

	public GameObject Horde;
	public GameObject Follower;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Collide");
		other.transform.parent = Horde.transform;
		Horde.GetComponent<Horde> ().AddMember (other.gameObject);
		other.gameObject.AddComponent<HordeMemberMovement> ();
	}*/

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Collide");
		if (other.gameObject.tag == "NotInfected") {
			newInfected (other.gameObject);
		}

	}

	public void newInfected(GameObject obj) {

		obj.tag = "Infected";

		if (obj.GetComponent<HordeMemeber>() == null) {
			obj.AddComponent<HordeMemeber> ();

			BFS (obj);
		}
	}

	void BFS(GameObject obj) {

		if (Follower != null) {
			Queue<GameObject> q = new Queue<GameObject> ();
			q.Enqueue (Follower);

			while (q.Count > 0) {
				GameObject node = q.Dequeue ();

				for (int i = 0; i < 3; ++i) {
					if (node.GetComponent<HordeMemeber> ().Followers [i].tag == "Unused") {
						node.GetComponent<HordeMemeber> ().Followers [i] = obj;
						obj.GetComponent<HordeMemeber> ().ID = i;
						obj.GetComponent<HordeMemeber> ().Leader = node;
						return;
					} else {
						q.Enqueue (node.GetComponent<HordeMemeber> ().Followers [i]);
					}
				}
			}
		} else {
			Follower = obj;
			Follower.GetComponent<HordeMemeber> ().Leader = gameObject;
			Follower.GetComponent<HordeMemeber> ().ID = 4;
		}

	}
}
