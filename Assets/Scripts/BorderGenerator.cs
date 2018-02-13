using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderGenerator : MonoBehaviour
{

    public List<GameObject> TopTiles;
    public List<GameObject> BottomTiles;
    public GameObject FillTile;
    public float widthOfTubeSection = 50.0f;
    [Range(0, 100)]
    public int percentForWallObsticle = 5;
    [Range(1, 5)]
    public int maxTileHeight = 2;
    public int maxTileWidth = 4;

    private float _topStartingX;

    void Start()
    {
        _topStartingX = transform.GetChild(1).transform.position.x - 3f;
        GenerateTiles();
    }

    public void GenerateTiles()
    {
        for (int i = 0; i < widthOfTubeSection; ++i)
        {
            GenerateTileColumn(i, TopTiles[Random.Range(0, TopTiles.Count)], 9);
            GenerateTileColumn(i, BottomTiles[Random.Range(0, BottomTiles.Count)], -9);
        }
    }

    private void GenerateTileColumn(int xPosition, GameObject tileGraphic, float firstTileYOffset)
    {

        var tile = Instantiate(tileGraphic, new Vector3(xPosition * 3.0f + _topStartingX, firstTileYOffset, 0), Quaternion.identity);
        tile.transform.parent = transform;

        for (int j = 0; j < 2; ++j)
        {
            var stackedTileOffset = firstTileYOffset < 0 ? -12 - j * 3 : 12 + j * 3;
            var extraRowTile = Instantiate(FillTile, new Vector3(xPosition * 3.0f + _topStartingX, stackedTileOffset, 0), Quaternion.identity);
            extraRowTile.transform.parent = transform;
        }
    }
}
