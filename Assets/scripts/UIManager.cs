using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	int selectedItem; 
	Transform StatusMenu;
	public List<Image> ColorButtons;
	private GameObject[] BallBtns;

	public Sprite ActiveSprite;
	public Sprite InactiveSprite;

	// Use this for initialization
	void Start () {
		StatusMenu = transform.FindChild ("CurrentGameStatus");
		if (BallBtns == null)
			BallBtns = GameObject.FindGameObjectsWithTag("BallButton");
		toggleGameStatusComponents (false);
		activateCurrentBall ();

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
			RulesManager.Save ();
			break;
		case 6:
			RulesManager.Load ();
			break;
		case 7:
			Application.Quit();
			break;
		}
	}

	private void toggleGameStatusComponents(bool state){
		foreach (GameObject button in BallBtns) {
			button.GetComponent<Image> ().enabled = state;
			button.GetComponentInChildren<Text> ().enabled = state;
		}
		GameObject Scoreboard = GameObject.Find ("ScorebardBackground");
		Scoreboard.GetComponent<Image> ().enabled = state;
		Scoreboard.GetComponentsInChildren<Text> () [0].enabled = state;
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
