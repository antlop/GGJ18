using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HordeLeader : MonoBehaviour {

	public GameObject Horde;
	public GameObject[] Followers;
	public GameObject lastAdded;
	public int FollowerCount = 0;
	private int maxFollowerCount = 0;
	public Canvas GameOverCanvas;

	private int limitingFollowerCount = 75;
	public bool USELIMITER = true;


	public Sprite infected;
	public Sprite notInfected;

	public AudioClip pickupAudioClip;
	public AudioClip borderHitClip;
	public AudioClip hordeMemberDeathClip;


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
		if (Input.GetKeyDown (KeyCode.T)) {
			Destroy(GameObject.Find ("New Game Object"));
		}
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

			GetComponentInChildren<AudioSource> ().PlayOneShot (pickupAudioClip);
		} else if (other.gameObject.tag == "SingleEnemyDestroyer") {
			Debug.Log ("Hit Litte Enemy");
			RemoveFromBFS ();
		} else if (other.gameObject.tag == "MultipleEnemyDestroyer") {
			Debug.Log ("Hit Big Enemy");
			RemoveFromBFS ();
		} else if (other.gameObject.layer == 11) {
			GetComponentInChildren<AudioSource> ().PlayOneShot (borderHitClip, 0.1f);
		}
    }

    public void newInfected(GameObject obj) {

		if (USELIMITER && FollowerCount >= limitingFollowerCount)
			return;

		obj.tag = "Infected";

		if (obj.GetComponent<HordeMemeber>() == null) {
			obj.AddComponent<HordeMemeber> ();
			obj.layer = 9;
		}
		BFS (obj);
		obj.GetComponent<HordeMemeber> ().AddedIndex = ++FollowerCount;

		if (FollowerCount > maxFollowerCount) {
			maxFollowerCount = FollowerCount;
		}

		obj.GetComponent<SpriteRenderer> ().sprite = infected;
		obj.GetComponent<Floating> ().enabled = false;

		Destroy(GameObject.Find ("New Game Object"));
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
					if (node.GetComponent<HordeMemeber> ().Followers [i] == null) {
						node.GetComponent<HordeMemeber> ().Followers [i] = obj;
						obj.GetComponent<HordeMemeber> ().ID = i;
						obj.GetComponent<HordeMemeber> ().Leader = node;
						return;
					} else if (node.GetComponent<HordeMemeber> ().Followers [i].tag == "Unused") {
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

		for (int i = 0; i < 3; ++i) {
			if (Followers [i] == null) {
				Followers [i] = new GameObject ();
				Followers [i].tag = "Unused";
			}
		}


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
		if ( lastAdded != null) {
			Debug.Log ("not null");
			lastAdded.GetComponent<HordeMemeber> ().Leader.GetComponent<HordeMemeber> ().Followers [lastAdded.GetComponent<HordeMemeber> ().ID] = new GameObject ();
			lastAdded.GetComponent<HordeMemeber> ().Leader.GetComponent<HordeMemeber> ().Followers [lastAdded.GetComponent<HordeMemeber> ().ID].tag = "Unused";
			lastAdded.GetComponent<SpriteRenderer> ().sprite = notInfected;
			lastAdded.GetComponent<Floating> ().enabled = false;
			Destroy (lastAdded);
			FollowerCount -= 1;
			GetComponentInChildren<AudioSource> ().PlayOneShot (hordeMemberDeathClip);
		}
	}

	public int CalculateScore() {
		return maxFollowerCount * 300;
	}

	void checkForLastAdded() {
		if (FollowerCount <= 1) {
			Debug.Log ("GAme Over!");
			if (GameOverCanvas.GetComponent<CanvasAppear> () == null) {
				GameOverCanvas.gameObject.SetActive (true);
				GameOverCanvas.gameObject.AddComponent<CanvasAppear> ();
				GameOverCanvas.GetComponent<CanvasAppear> ().Score = CalculateScore ();
				Destroy (GetComponent<PlayerController> ());
			}
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
