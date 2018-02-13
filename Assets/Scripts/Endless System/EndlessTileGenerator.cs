using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTileGenerator : MonoBehaviour
{
    public GameObject TilePrefab;
    public float StartingXPosition = 0;
    public float TileWidth = 30;
    public int TilesAhead = 1;
    public int TilesBehind = 1;

    private float _lastTileXPosition;
    private LinkedList<GameObject> _currentTiles;

    public void Start()
    {
        _currentTiles = new LinkedList<GameObject>();

        TileWidth = TilePrefab.transform.Find("Background").GetComponent<SpriteRenderer>().bounds.size.x;

        int numTotalStartingPreloadedTiles = TilesAhead + TilesBehind + 1;
        _lastTileXPosition = StartingXPosition - TileWidth * TilesBehind;

        for (int i = 0; i < numTotalStartingPreloadedTiles; i++)
        {
            PlaceNextTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlaceNextTile()
    {
        float newTileXPosition = _lastTileXPosition + TileWidth;

        GameObject newTile = Instantiate(TilePrefab);
        // Pass in self GameObject so that tile can tell us when player reaches end of it
        newTile.GetComponent<EndlessTile>().Init(gameObject);
        newTile.transform.position = new Vector3(newTileXPosition, 0, 0);

        _lastTileXPosition = newTileXPosition;
        _currentTiles.AddLast(newTile);
    }

    void RemoveOldestTile()
    {
        GameObject oldestTile = _currentTiles.First.Value;
        _currentTiles.RemoveFirst();
        Destroy(oldestTile);
    }

    public void PlayerReachedEndOfOldestTileCallback()
    {
        PlaceNextTile();
        RemoveOldestTile();
    }
}
