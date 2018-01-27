using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeLeader : MonoBehaviour {

	public GameObject Horde;
	public GameObject[] Followers;
	public GameObject lastAdded;
	public int FollowerCount = 0;

	// Use this for initialization
	void Start () {
		Followers = new GameObject[3];
		Followers [0] = new GameObject();
		Followers [1] = new GameObject();
		Followers [2] = new GameObject();

		Followers [0].tag = "Unused";
		Followers [1].tag = "Unused";
		Followers [2].tag = "Unused";
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

		}
		BFS (obj);
		obj.GetComponent<HordeMemeber> ().AddedIndex = ++FollowerCount;
	}

	void BFS(GameObject obj) {

		if (noneOfMyFollowersAreUnused(obj)) {
			Queue<GameObject> q = new Queue<GameObject> ();
			q.Enqueue (Followers[0]);
			q.Enqueue (Followers[1]);
			q.Enqueue (Followers[2]);

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
		}
	}

	bool noneOfMyFollowersAreUnused(GameObject obj) {
		if (Followers [0].tag == "Unused") {
			Followers[0] = obj;
			Followers[0].GetComponent<HordeMemeber> ().Leader = gameObject;
			Followers[0].GetComponent<HordeMemeber> ().ID = 4;
			return false;
		} else if( Followers [1].tag == "Unused") {
			Followers[1] = obj;
			Followers[1].GetComponent<HordeMemeber> ().Leader = gameObject;
			Followers[1].GetComponent<HordeMemeber> ().ID = 4;
			return false;
		} else if( Followers [2].tag == "Unused") {
			Followers[2] = obj;
			Followers[2].GetComponent<HordeMemeber> ().Leader = gameObject;
			Followers[2].GetComponent<HordeMemeber> ().ID = 4;
			return false;
		}
		return true;
	}

	public void RemoveFromBFS() {
		checkForLastAdded ();
		Debug.Log ("Remove");
		if (lastAdded != null) {
			Debug.Log ("not null");
			lastAdded.GetComponent<HordeMemeber> ().Leader.GetComponent<HordeMemeber> ().Followers [lastAdded.GetComponent<HordeMemeber> ().ID] = new GameObject ();
			lastAdded.GetComponent<HordeMemeber> ().Leader.GetComponent<HordeMemeber> ().Followers [lastAdded.GetComponent<HordeMemeber> ().ID].tag = "Unused";
			Destroy (lastAdded);
			FollowerCount -= 1;
		}
	}

	void checkForLastAdded() {
		if (Followers [0].GetComponent<HordeMemeber> ().AddedIndex >= FollowerCount) {
			Debug.Log ("GAme Over!");
		} else if (Followers [1].GetComponent<HordeMemeber> ().AddedIndex >= FollowerCount) {
			Destroy (Followers [1]);
			Followers [1] = new GameObject ();
			Followers [1].tag = "Unused";
			FollowerCount -= 1;
		} else if (Followers [2].GetComponent<HordeMemeber> ().AddedIndex >= FollowerCount) {
			Destroy (Followers[2]);
			Followers [2] = new GameObject ();
			Followers [2].tag = "Unused";
			FollowerCount -= 1;
		} else {

			Queue<GameObject> q = new Queue<GameObject> ();
			q.Enqueue (Followers [0]);
			q.Enqueue (Followers [1]);
			q.Enqueue (Followers [2]);

			while (q.Count > 0) {
				GameObject node = q.Dequeue ();

				for (int i = 0; i < 3; ++i) {
					if (node.GetComponent<HordeMemeber> ().Followers [i].GetComponent<HordeMemeber> ().AddedIndex >= FollowerCount) {
						lastAdded = node.GetComponent<HordeMemeber> ().Followers [i];
						return;
					} else {
						q.Enqueue (node.GetComponent<HordeMemeber> ().Followers [i]);
					}
				}
			}
		}
	}
}
