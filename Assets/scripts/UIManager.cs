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

		foreach (GameObject button in BallBtns) {
			foreach (Image img in button.GetComponentsInChildren<Image> ()) {
				img.enabled = false;
			}
		}


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
			if(button.GetComponentInChildren<Text> () != null)
			{
				button.GetComponentInChildren<Text> ().enabled = state;
			}

//			foreach(Image img in button.GetComponentsInChildren<Image> ()){
//					img.enabled = state;
//			}
			//button.GetComponentInChildren<GameObject> ().SetActive(state);
		}
		GameObject Scoreboard = GameObject.Find ("ScorebardBackground");
		Scoreboard.GetComponent<Image> ().enabled = state;
		Scoreboard.GetComponentsInChildren<Text> () [0].enabled = state;
	}

	public void deactivatePreviousBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
		//curBallButton.transform.localScale = new Vector3 (.8f,.8f,.8f);
		curBallButton.GetComponent<Image> ().sprite = InactiveSprite;
	}

	public void activateCurrentBall(){
		string curBallName = RulesManager.getCurBallName();
		string curBallButtonColor = GameObject.Find (curBallName).GetComponent<Ball> ().color;
		GameObject curBallButton = GameObject.Find (curBallButtonColor + "Button");
		//curBallButton.transform.localScale = new Vector3 (1.33f, 1.33f, 1.33f);
		curBallButton.GetComponent<Image> ().sprite = ActiveSprite;
	}

	public void setDeadness(){
		bool[,] deadness = RulesManager.getDeadness ();

		for(int i = 0;i<4;i++){			
			for (int j = 0; j < 4; j++) {
				if(i!=j){
				if(deadness[i,j]==true){
					//Debug.Log ("Deadness: "+ i + "," + j);
					string colorPlayed = RulesManager.ballColors [i];
					string colorHit = RulesManager.ballColors [j];
					GameObject ballInPlayButton = GameObject.Find (colorPlayed+"Button");
					GameObject hitBallButton = ballInPlayButton.transform.FindChild (colorHit + "Button_Deadness").gameObject;
					hitBallButton.GetComponent<Image> ().enabled = true;
				}
				else{
					string colorPlayed = RulesManager.ballColors [i];
					string colorHit = RulesManager.ballColors [j];
					GameObject ballInPlayButton = GameObject.Find (colorPlayed+"Button");
					Debug.Log ("colorPlayed: " + colorPlayed);
					Debug.Log("colorHit: " + colorHit);
					GameObject hitBallButton = ballInPlayButton.transform.FindChild (colorHit + "Button_Deadness").gameObject;
					hitBallButton.GetComponent<Image> ().enabled = false;

					//if(ballInPlayButton.transform.has
//					if (GameObject hitBallButton = ballInPlayButton.transform.FindChild (colorHit + "Button_Deadness").gameObject != null) {
//						hitBallButton.GetComponent<Image> ().enabled = false;
//
//					}
				}
				//Debug.Log ("Nums: "+ i + "," + j);
				//Debug.Log (deadness [i, j]);
				}
			}
		}
	}
}
