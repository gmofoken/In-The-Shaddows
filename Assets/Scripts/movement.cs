using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
	public GameObject win;
	public float horizontalSpeed = 5.0F;
	public float verticalSpeed = 5.0F;
	public static bool winStatus = false;
	public GameObject obj;
	public Save save;
	public GameObject levelSelect;
	bool four;
	bool two;

	// Use this for initialization
	void Start () {
		four = false;
		two = false;
		obj = GameObject.Find(this.obj.name);
		win.SetActive (false);
		levelSelect.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		checkPosition ();
		if (winStatus == false)
			rotateObject ();
		else {
			win.SetActive (true);
			levelSelect.SetActive (true);
		}
	}

	void rotateObject(){
		switch (obj.name){
		case "elephant":
			if (Input.GetMouseButton (0)) {
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				transform.eulerAngles += new Vector3 (x, y, 0);
			}
			break;
		case "tea_pot" : 
			if (Input.GetMouseButton (0)) {
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				transform.eulerAngles += new Vector3 (0, y, 0);
			}
			break;
		case "logo-4":
		case "logo-2": 
			if (Input.GetMouseButton (0)) {
				obj = GameObject.Find("logo-4");
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				obj.transform.eulerAngles += new Vector3 (x, y, 0);
				if (Input.GetKey(KeyCode.LeftShift)) {
					x = 0.03F * Input.GetAxis ("Mouse X");
					obj.transform.position += new Vector3 (0, 0, x);
				}
			} else if (Input.GetMouseButton (1)) {
				obj = GameObject.Find("logo-2");
				float x = horizontalSpeed * Input.GetAxis ("Mouse X");
				float y = verticalSpeed * Input.GetAxis ("Mouse Y");
				obj.transform.eulerAngles += new Vector3 (x, y, 0);
				if (Input.GetKey(KeyCode.LeftShift)) {
					x = 0.03F * Input.GetAxis ("Mouse X");
					obj.transform.position += new Vector3 (0, 0, x);
				}
			}
			break;
		}
	}
	void checkPosition(){

		switch (obj.name) {
		case "elephant": 
			if ((transform.eulerAngles.x >= 80 && transform.eulerAngles.x <= 100)
				&& (transform.eulerAngles.y >= 95 && transform.eulerAngles.y <= 100)) {
				winStatus = true;
				if (PlayerPrefs.GetInt ("GameMode") != 1)
					save.ElephantComplete ();
			}
			break;
		case "tea_pot": 
			if (transform.eulerAngles.y >= 80 && transform.eulerAngles.y <= 90) {
				winStatus = true;
				if (PlayerPrefs.GetInt ("GameMode") != 1)
					save.TeaPotComplete ();
			}
			break;
		case "logo-4":
		case "logo-2": 
			if (obj.name == "logo-2" && (obj.transform.eulerAngles.x >= -10 && obj.transform.eulerAngles.x <= 5)
				&& (obj.transform.eulerAngles.y >= 90 && obj.transform.eulerAngles.y <= 110)) {
				two = true;
				Debug.Log ("two staus = " + two);
			} 

			if (obj.name == "logo-4" && (obj.transform.eulerAngles.x > -5 && obj.transform.eulerAngles.x < 5)
				&& (obj.transform.eulerAngles.y > 90 && obj.transform.eulerAngles.y < 100)) {
				four = true;
				Debug.Log ("four staus = " + four);
			}

			if (four == true && two == true) {
				winStatus = true;
				if (PlayerPrefs.GetInt ("GameMode") != 1)
					save.FourtyTwoComplete ();
			} 
			break;
		}
	}
}