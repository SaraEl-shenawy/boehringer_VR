using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actions : MonoBehaviour {

	public void startGame(){
		SceneManager.LoadScene ("GAME");
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void backToMainMenu(){
		SceneManager.LoadScene ("MENU");
	}
}
