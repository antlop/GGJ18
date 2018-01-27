using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePotentialHorde : MonoBehaviour {

	public int Rows = 10;
	public int Colomns = 10;

	public GameObject HordeMemberPrefab;

	// Use this for initialization
	void Start () {
		if (HordeMemberPrefab != null) {
			int halfRows = Rows / 2;
			int halfCol = Colomns / 2;
			for (int x = -halfRows; x < halfRows; ++x) {
				for (int y = -halfCol; y < halfCol; ++y) {

					Instantiate (HordeMemberPrefab, new Vector3 (x, y, 0), Quaternion.identity);
				}
			}
		}
	}
}
