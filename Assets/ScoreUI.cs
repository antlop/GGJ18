using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	public GameObject hordeLeader;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = hordeLeader.GetComponent<HordeLeader> ().CalculateScore () + "!";
		
	}
}
