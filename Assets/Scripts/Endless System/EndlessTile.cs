using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTile : MonoBehaviour {

	public GameObject endOfTileDetector;

	GameObject tileGenerator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	public void Init(GameObject tileGen) {
		Debug.Log ("Placed new tile!");
		tileGenerator = tileGen;
		endOfTileDetector.GetComponent<EndOfTileDetector>().Init(tileGen);
	}

	//PlayerReachedEndOfOldestTileCallback()
	// TODO: On collision with end of tile, call the PlayerReachedEndOfOldestTileCallback()

	void OnTriggerEnter2D(Collider2D other) {
	}

}
