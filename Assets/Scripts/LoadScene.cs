using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public GameObject Lock1;
	public GameObject Lock2;

	void Start(){
		Lock1.SetActive (true);
		Lock2.SetActive (true);
	}

	void Update()
	{
		if (PlayerPrefs.GetInt ("42") == 1 || PlayerPrefs.GetInt ("GameMode") == 1)
			Lock2.SetActive (false);
		if (PlayerPrefs.GetInt ("Elephant") == 1 || PlayerPrefs.GetInt ("GameMode") == 1)
			Lock1.SetActive (false);	
	}

	public void FourtyTwoAvailable(){
		if (PlayerPrefs.GetInt ("42") == 1)
			SelectLevel (4);
		else if (PlayerPrefs.GetInt ("GameMode") == 1)
			SelectLevel (4);
	}

	public void ElephantAvailable(){
		if (PlayerPrefs.GetInt ("Elephant") == 1)
			SelectLevel (3);
		else if (PlayerPrefs.GetInt ("GameMode") == 1)
			SelectLevel (3);
	}

	public void SelectLevel(int Level_Select){
		movement.winStatus = false;
		SceneManager.LoadScene(Level_Select);
	}
}
