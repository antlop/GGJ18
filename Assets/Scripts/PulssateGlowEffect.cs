using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulssateGlowEffect : MonoBehaviour {

	public bool shouldPulse = false;
	public bool pulseGood = true;
	public PulssatingController myController;

	private bool didEnd = false;

	public Color goodFlashColor;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (myController && myController.shouldPulse) {

			didEnd = true;

			float pulsingScale = myController.getScaler ();
			if (pulseGood) {
				if (goodFlashColor.r > 0.1f) {
					GetComponent<SpriteRenderer> ().color = new Color (pulsingScale, pulsingScale, 0);
				} else {
					GetComponent<SpriteRenderer> ().color = new Color (0, pulsingScale, 0);
				}
			} else {
				GetComponent<SpriteRenderer> ().color = new Color (1.0f, pulsingScale, 1.0f);
			}
			//DynamicGI.SetEmissive (GetComponent<Renderer> (), new Color (204, 115, 51) * pulsingScale);
		
		} else if (didEnd) {
			didEnd = false;

			GetComponent<SpriteRenderer> ().color = new Color (1.0f, 1.0f, 1.0f);
		}
	}
}
