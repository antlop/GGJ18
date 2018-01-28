using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class HighScores : MonoBehaviour {

	public struct RecScore {
		public int Score;
		public string Name;
	}

	public TextAsset Scores;
	public List<RecScore> ScoresList;
	public int maxScores = 15;

	// Use this for initialization
	void Start () {
		ScoresList = new List<RecScore> ();
		ReadString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool checkAgainstHighScores(int score) {
		if (ScoresList.Count < maxScores) {
			return true;
		} else {
			for (int i = 0; i < ScoresList.Count; ++i) {
				if (score > ScoresList [i].Score) {
					return true;
				}
			}
		}
		return false;
	}

	public void addScoreToList(int score, string name) {
		if (ScoresList.Count < maxScores) {
			RecScore newScore = new RecScore ();
			newScore.Name = name;
			newScore.Score = score;
			ScoresList.Add (newScore);
		} else {
			int insertIndex = 0;
			for (int i = 0; i < ScoresList.Count; ++i) {
				if (score > ScoresList [i].Score) {
					RecScore newScore = new RecScore ();
					newScore.Name = name;
					newScore.Score = score;
					ScoresList.Insert (i, newScore);
					ScoresList.RemoveAt (ScoresList.Count - 1);
					break;
				}
			}
		}
	}

	public void WriteScores() {
		string path = "Assets/Resources/HighScores.txt";

		StreamWriter writer = new StreamWriter (path, true);

		for (int i = 0; i < ScoresList.Count; ++i) {
			writer.WriteLine (ScoresList [i].Name + " " + ScoresList [i].Score);
		}
		writer.Close ();

		AssetDatabase.ImportAsset (path);
	}

	public void ReadString() {
		string path = "Assets/Resources/HighScores.txt";

		StreamReader reader = new StreamReader (path);
		while (!reader.EndOfStream) {
			string scoreLine = reader.ReadLine ();
			char[] pars = new char[1];
			pars [0] = ' ';
			string[] sz = scoreLine.Split(pars);

			RecScore newScore = new RecScore();
			newScore.Name = sz[0];
			int.TryParse (sz [1], out newScore.Score);
			ScoresList.Add (newScore);
		}

		reader.Close ();
	}
}
