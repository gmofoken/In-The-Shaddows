using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Save : MonoBehaviour {
	public void TeaPotComplete(){
		PlayerPrefs.SetInt ("Elephant", 1);
	}

	public void ElephantComplete(){
		PlayerPrefs.SetInt ("42", 1);
	}

	public void FourtyTwoComplete(){
		PlayerPrefs.SetInt ("42", 1);
	}
}
