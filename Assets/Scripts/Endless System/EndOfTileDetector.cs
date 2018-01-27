using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfTileDetector : MonoBehaviour {

	public GameObject tileGenerator;
	bool playerEnteredBefore = false;

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
		if (other.tag == "Player" && !playerEnteredBefore) {
			playerEnteredBefore = true;
			tileGenerator.GetComponent<EndlessTileGenerator> ().PlayerReachedEndOfOldestTileCallback ();
		}
	}
}
