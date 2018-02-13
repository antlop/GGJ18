using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DistanceCheck : MonoBehaviour
{
    public float DistanceThreshhold = 50f;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0)
        {
            Destroy(gameObject);
        }
        else if (players.All(player => 
            player.transform.position.x >= transform.position.x &&
            Vector2.Distance(transform.position, player.transform.position) > DistanceThreshhold))
        {
            // If all players are to the right of the game object
            // And all players are past the distance threshhold
            Destroy(gameObject);
        }
    }
}
