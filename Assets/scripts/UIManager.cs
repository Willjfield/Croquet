using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	int selectedItem; 
	Transform StatusMenu;
	public List<Image> ColorButtons;
	public List<Text> BallText;
	// Use this for initialization
	void Start () {
		StatusMenu = transform.FindChild ("CurrentGameStatus");
		foreach (Transform child in StatusMenu.transform)
		{
			ColorButtons.Add (child.GetComponent<Image> ());
			Transform[] grandchildren = child.GetComponentsInChildren<Transform> ();
			BallText.Add (grandchildren[1].GetComponent<Text>());
		}

		toggleGameStatusComponents (false);
	}

	// Update is called once per frame
	void Update () {

	}

	public void toggleVisibility(){
		selectedItem = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
		switch (selectedItem) {
		case 0:
			toggleGameStatusComponents(false);
			break;
		case 1:
			toggleGameStatusComponents(true);

			break;
		case 2:
			Application.LoadLevel("Main_Scene");
			break;
		case 3:
			toggleGameStatusComponents(false);
			break;
		case 4:
			toggleGameStatusComponents(false);
			break;
		case 5:
			Application.Quit();
			break;
		}
	}

	private void toggleGameStatusComponents(bool state){
		foreach (Image img in ColorButtons)
		{
			img.enabled = state;
		}
		foreach (Text txt in BallText)
		{
			txt.enabled = state;
		}
	}
}
