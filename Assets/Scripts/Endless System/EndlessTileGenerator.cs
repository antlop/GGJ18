using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTileGenerator : MonoBehaviour {

	public GameObject tile;
	float lastTileXPosition = 30;

	// TODO: Get a not-hard-coded value for this
	public float tileWidth;

	public int numPreloadedTiles = 4;

	// Use this for initialization
	public void Start () {
		for (int i = 0; i < numPreloadedTiles; i++) {
			PlaceNextTile ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void PlaceNextTile() {
		Debug.Log("Next tile!");
		float newTileXPosition = lastTileXPosition + tileWidth;

		GameObject newTile = Instantiate (tile);

		// Pass in self GameObject so that tile can tell us when player reaches end of it
		newTile.GetComponent<EndlessTile> ().Init (gameObject);
		newTile.transform.position = new Vector3 (newTileXPosition, 0, 0);


		lastTileXPosition = newTileXPosition;
	}

	public void PlayerReachedEndOfOldestTileCallback() {
		PlaceNextTile ();
		// TODO: Get rid of oldest tile.
	}
}
