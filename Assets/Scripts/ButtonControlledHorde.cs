using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlledHorde : MonoBehaviour {

    public List<float> PercentLaneArray;
    public int currentLaneIndex = 0;

	// Use this for initialization
	void Start () {
        currentLaneIndex = PercentLaneArray.Count / 2;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height * PercentLaneArray[currentLaneIndex];

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
	
    public void MoveUp()
    {
        currentLaneIndex -= 1;
        if( currentLaneIndex < 0 )
        {
            currentLaneIndex = 0;
        }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height * PercentLaneArray[currentLaneIndex];

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }

    public void MoveDown()
    {
        currentLaneIndex += 1;
        if (currentLaneIndex >= PercentLaneArray.Count)
        {
            currentLaneIndex = PercentLaneArray.Count-1;
        }

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        screenPos.y = Screen.height * PercentLaneArray[currentLaneIndex];

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
}
