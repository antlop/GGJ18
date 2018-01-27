using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTileGenerator : MonoBehaviour {

	public GameObject tile;
	float lastTileXPosition = 0;

	LinkedList<GameObject> currentTiles;

	// TODO: Get a not-hard-coded value for this
	public int startingXPosition = 0;
	public float tileWidth = 30;


	public int numPreloadedTilesAhead = 4;
	public int numPreloadedTilesBehind = 5;

	// Use this for initialization
	public void Start () {
		currentTiles = new LinkedList<GameObject> ();


		int numTotalStartingPreloadedTiles = numPreloadedTilesAhead + numPreloadedTilesBehind + 1;
		lastTileXPosition = startingXPosition - tileWidth * numPreloadedTilesBehind;
		for (int i = 0; i < numTotalStartingPreloadedTiles ; i++) {
			PlaceNextTile ();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LoadInitialTiles() {
		

	}

	void PlaceTileAt(float xPosition) {
		

	}

	void PlaceNextTile() {
		Debug.Log("Next tile!");
		float newTileXPosition = lastTileXPosition + tileWidth;

		GameObject newTile = Instantiate (tile);
		// Pass in self GameObject so that tile can tell us when player reaches end of it
		newTile.GetComponent<EndlessTile> ().Init (gameObject);
		newTile.transform.position = new Vector3 (newTileXPosition, 0, 0);

		lastTileXPosition = newTileXPosition;
		currentTiles.AddLast(newTile);
	}

	void RemoveOldestTile() {
		GameObject oldestTile = currentTiles.First.Value;
		currentTiles.RemoveFirst ();

		Debug.Log ("Remove oldest tile!");
		Destroy (oldestTile);
	}

	public void PlayerReachedEndOfOldestTileCallback() {
		PlaceNextTile ();
		// TODO: Get rid of oldest tile.
		RemoveOldestTile();
	}
}
