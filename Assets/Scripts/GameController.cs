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

    private int _activePlayers = 1;

    void Start()
    {
        ElapsedTime = 0f;
        //_activePlayers = GameObject.FindGameObjectsWithTag("Player").Length;
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
            PlayerScores[0] = (int)ElapsedTime * 100;
            GameOver();
        }
    }

    void GameOver()
    {
        var canvasAppear = GameOverCanvas.GetComponent<CanvasAppear>();
        if (canvasAppear == null)
        {
            canvasAppear = GameOverCanvas.gameObject.AddComponent<CanvasAppear>();
            
            Cursor.visible = true;
        }

        canvasAppear.Score = (int)ElapsedTime * 100;// PlayerScores[0];
        canvasAppear.initialize = true;
        GameOverCanvas.gameObject.SetActive(true);
    }
}
