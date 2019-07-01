using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
	public GameObject MainCanvas;
	public GameObject OptionsCanvas;

	void Start(){
		MainCanvas.SetActive (true);
		OptionsCanvas.SetActive (false);
	}

	public void StartButton_OnClick(){
		SceneManager.LoadScene (1);
	}

	public void QuitButton_OnClick(){
		Application.Quit();
	}

	public void ResetGame(){
		PlayerPrefs.SetInt ("Elephant", 0);
		PlayerPrefs.SetInt ("42", 0);
	}

	public void Options(){
		MainCanvas.SetActive (false);
		OptionsCanvas.SetActive (true);
	}

	public void Main(){
		MainCanvas.SetActive (true);
		OptionsCanvas.SetActive (false);
	}

	public void GameMode(int mode){
		PlayerPrefs.SetInt ("GameMode", mode);
		MainCanvas.SetActive (true);
		OptionsCanvas.SetActive (false);
	}

	public void TestMode(){
		PlayerPrefs.SetInt ("ElephantTest", 1);
		PlayerPrefs.SetInt ("42Test", 1);
	}
}
