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
		if (Input.GetMouseButton(0)) {
			PlaceNextTile();
		}
	}

	void PlaceNextTile() {
		Debug.Log("Next tile!");
		float newTileXPosition = lastTileXPosition + tileWidth;

		GameObject newTile = Instantiate (tile);
		newTile.GetComponent<EndlessTile> ().Init ();
		newTile.transform.position = new Vector3 (newTileXPosition, 0, 0);


		lastTileXPosition = newTileXPosition;
	}

	void PlayerReachedEndOfOldestTileCallback() {
		PlaceNextTile ();

		// TODO: Get rid of oldest tile.
	}
}
