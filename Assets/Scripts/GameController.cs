using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject GameOverCanvas;
    [HideInInspector]
    public static float ElapsedTime;
    [HideInInspector]
    public int[] PlayerScores;

    private int _activePlayers;

    void Start()
    {
        ElapsedTime = 0f;
        _activePlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        PlayerScores = new int[_activePlayers];
    }

    void Update()
    {
        ElapsedTime += Time.deltaTime;
    }

    public void PlayerDied(GameObject hordeLeader)
    {
        if (_activePlayers == 0)
        {
            return;
        }
        _activePlayers -= 1;

        if (_activePlayers == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        var canvasAppear = GameOverCanvas.GetComponent<CanvasAppear>();
        if (canvasAppear == null)
        {
            GameOverCanvas.gameObject.SetActive(true);
            GameOverCanvas.gameObject.AddComponent<CanvasAppear>();
            canvasAppear.Score = PlayerScores[0];
            Cursor.visible = true;
        }
    }
}
