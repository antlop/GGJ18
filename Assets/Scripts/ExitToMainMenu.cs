using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitToMainMenu : MonoBehaviour {

	public void Exit() {
		SceneManager.LoadScene ("MainMenu");
	}
}
