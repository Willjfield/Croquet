using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	int selectedItem; 
	Transform StatusMenu;
	public List<Image> ColorButtons;
	public List<GameObject> BallText;

	public Sprite ActiveSprite;
	public Sprite InactiveSprite;
	// Use this for initialization
	void Start () {
		StatusMenu = transform.FindChild ("CurrentGameStatus");
//		foreach (Transform child in StatusMenu.transform)
//		{
//			ColorButtons.Add (child.GetComponent<Image> ());
//			GameObject[] grandchildren = child.GetComponentsInChildren<Transform> ();
//			BallText.Add (grandchildren[1]);
//		}
		foreach (Transform child in StatusMenu.transform){
			child.gameObject.SetActive (false);
		}
		toggleGameStatusComponents (true);

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
		foreach (Transform child in StatusMenu.transform){
			child.gameObject.SetActive (state);
		}
//		foreach (Image img in ColorButtons)
//		{
//			img.enabled = state;
//		}
//		foreach (GameObject txt in BallText)
//		{
//			txt.SetActive(state);
//		}
	}

	public void deactivatePreviousBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
		curBallButton.transform.localScale = new Vector3 (1f,1f,1f);
		curBallButton.GetComponent<Image> ().sprite = InactiveSprite;
	}

	public void activateCurrentBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
		curBallButton.transform.localScale = new Vector3 (1.2f, 1.2f, 1.2f);
		curBallButton.GetComponent<Image> ().sprite = ActiveSprite;
	}
}
