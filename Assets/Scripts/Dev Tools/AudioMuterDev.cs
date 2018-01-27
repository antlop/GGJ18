using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Any Scene that has a GameObject with this script attached will have all audio muted
public class AudioMuterDev : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioListener.volume = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
