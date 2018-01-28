using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulssatingController : MonoBehaviour {

	public bool shouldPulse = false;
	public float pulseDuration = 1.5f;
	float pulsingScale = 0.1f;
	bool increasing = true;

	// Use this for initialization
	void Start () {

		pulsingScale = Random.Range (0.1f, 0.9f);
	}
	
	// Update is called once per frame
	void Update () {

		if (shouldPulse) {
			pulseDuration -= Time.deltaTime;
			if (pulseDuration <= 0.0f) {
				pulseDuration = 1.5f;
				shouldPulse = false;

				GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
			}

			if (increasing) {
				pulsingScale += Time.deltaTime * 5.0f;
				if (pulsingScale >= 1.5f) {
					pulsingScale = 1.5f;
					increasing = false;
				}
			} else {
				pulsingScale -= Time.deltaTime * 7.5f;
				if (pulsingScale <= 0.1f) {
					pulsingScale = 0.1f;
					increasing = true;
				}
			}
		}
	}

	public float getScaler() {
		return pulsingScale;
	}
}
