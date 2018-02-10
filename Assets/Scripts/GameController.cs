using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject GameOverCanvas;
    public Camera2DFollow cameraFollower;
    [HideInInspector]
    public static float ElapsedTime;

    int playerScore = 500;
    int playerNum = 1;
    int numAlivePlayers;

    void Start()
    {
        numAlivePlayers = GameObject.FindGameObjectsWithTag("Player").Length;
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;
    }

    public void PlayerDied(GameObject hordeLeader)
    {
        if (numAlivePlayers == 0)
        {
            return;
        }
        numAlivePlayers -= 1;

        cameraFollower.LookForTargets();


        if (numAlivePlayers == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        if (GameOverCanvas.GetComponent<CanvasAppear>() == null)
        {
            GameOverCanvas.gameObject.SetActive(true);
            GameOverCanvas.gameObject.AddComponent<CanvasAppear>();
            GameOverCanvas.GetComponent<CanvasAppear>().Score = playerScore;
            Cursor.visible = true;
        }
    }
}
