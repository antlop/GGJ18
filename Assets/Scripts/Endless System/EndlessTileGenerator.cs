using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTileGenerator : MonoBehaviour {

	public GameObject tile;
	float lastTileXPosition = 0;

	LinkedList<GameObject> currentTiles;

	// TODO: Get a not-hard-coded value for this
	public float tileWidth = 30;

	public int numPreloadedTiles = 4;

	// Use this for initialization
	public void Start () {
		currentTiles = new LinkedList<GameObject> ();
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
