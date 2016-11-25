using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	int selectedItem; 
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void toggleVisibility(){
		selectedItem = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
		switch (selectedItem) {
		case 0:
			transform.FindChild ("CurrentGameStatus").gameObject.SetActive (false);
			break;
		case 1:
			transform.FindChild ("CurrentGameStatus").gameObject.SetActive (true);
			break;
		case 2:
			Application.LoadLevel("Main_Scene");
			break;
		case 3:
			transform.FindChild ("CurrentGameStatus").gameObject.SetActive (false);
			break;
		case 4:
			transform.FindChild ("CurrentGameStatus").gameObject.SetActive (false);
			break;
		case 5:
			Application.Quit();
			break;
		}
	}
}
