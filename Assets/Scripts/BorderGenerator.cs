using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderGenerator : MonoBehaviour {

	public List<GameObject> TopTiles;
	public List<GameObject> BottomTiles;

	public float widthOfTubeSection = 50.0f;

	// Use this for initialization
	void Start () {
		if (TopTiles != null) {
			TopTiles = new List<GameObject> ();
		}
		if (BottomTiles != null) {
			BottomTiles = new List<GameObject> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateTiles() {
		int halfwidth = (int)(widthOfTubeSection / 2);
		float topStartingX = transform.GetChild (1).transform.position.x + 1.5f;

		for (int i = 0; i < widthOfTubeSection; ++i) {
			if (TopTiles.Count > 0) {
				GameObject obj = Instantiate (TopTiles [Random.Range (0, TopTiles.Count)], new Vector3(i*3.0f + topStartingX, 9, 0), Quaternion.identity) as GameObject;
				obj.transform.parent = transform;
			}
			if (BottomTiles.Count > 0) {
				GameObject obj = Instantiate (BottomTiles [Random.Range (0, BottomTiles.Count)], new Vector3 (i * 3.0f + topStartingX, -9, 0), Quaternion.identity) as GameObject;
				obj.transform.parent = transform;
			}
		}
	}
}
