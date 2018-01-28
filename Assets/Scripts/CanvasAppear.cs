using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasAppear : MonoBehaviour {

	float alpha = 0.0f;
	public int Score = 0;
	bool initialize = true;

	// Update is called once per frame
	void Update () {
		if (initialize) {
			Debug.Log ("ADDING SCORE");
			transform.GetChild (1).GetComponent<Text> ().text = "Score: " + Score;
			initialize = false;
		}

		alpha += Time.deltaTime;

		if (alpha > 1.0f) {
			alpha = 1.0f;
		}

		transform.GetComponent<CanvasGroup> ().alpha = alpha;
	}
}
