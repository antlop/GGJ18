using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTileDetector : MonoBehaviour {

	public GameObject tileGenerator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init(GameObject tileGen) {
		tileGenerator = tileGen;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Other thing entered tile trigger!");
		if (other.tag == "Player") {
			Debug.Log ("Player entered tile trigger!");
			tileGenerator.GetComponent<EndlessTileGenerator> ().PlayerReachedEndOfOldestTileCallback ();
		}
	}
}
