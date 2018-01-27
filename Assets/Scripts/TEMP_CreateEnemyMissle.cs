using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_CreateEnemyMissle : MonoBehaviour {

	public GameObject Missile;
	public GameObject Grenade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			var mousePositionInWorld = Camera. main. ScreenToWorldPoint(Input. mousePosition);
			Instantiate(Missile,new Vector3(mousePositionInWorld. x,mousePositionInWorld. y, 0),Quaternion. identity);
		}


		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			var mousePositionInWorld = Camera. main. ScreenToWorldPoint(Input. mousePosition);
			Instantiate(Grenade,new Vector3(mousePositionInWorld. x,mousePositionInWorld. y, 0),Quaternion. identity);
		}
	}
}
