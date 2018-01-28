using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject GameOverCanvas;

	int player1Score;
	int player2Score;

	int playerNum = 1;

	int numAlivePlayers;

	// Use this for initialization
	void Start () {
		numAlivePlayers = GameObject.FindGameObjectsWithTag ("Player").Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayerDied(GameObject hordeLeader) {
		if (numAlivePlayers == 0) {
			return;
		}
		numAlivePlayers -= 1;

		int playerScore = hordeLeader.GetComponent<HordeLeader>().CalculateScore();

		Debug.Log("Player " + playerNum + " has died. " + numAlivePlayers + " players left.");

		if (playerNum == 1) {
			player1Score = playerScore;
		} else if (playerNum == 2) {
			player2Score = playerScore;
		} else {
			Debug.LogError ("Not a valid player number!");
		}
			
		if (numAlivePlayers == 0) {
			GameOver ();
		}

		playerNum++;
	}

	void GameOver() {
		Debug.Log ("Game Over!");
		if (GameOverCanvas.GetComponent<CanvasAppear> () == null) {
			GameOverCanvas.gameObject.SetActive (true);
			GameOverCanvas.gameObject.AddComponent<CanvasAppear> ();
			GameOverCanvas.GetComponent<CanvasAppear> ().Score = player1Score;
			Cursor.visible = true;
		}
	}
}
