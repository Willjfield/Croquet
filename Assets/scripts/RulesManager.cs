using UnityEngine;
using System.Collections;

public class RulesManager : MonoBehaviour {
	public static string[] balls;
	private static int curBallNum;
	private static GameObject currentBall;
	// Use this for initialization
	void Start () {
		curBallNum = 0;
		balls = new string[]{"BlueBall","RedBall","BlackBall","YellowBall"};
		currentBall = GameObject.Find (balls [curBallNum]);
	}

	public static void nextBall(){
		curBallNum++;
		if (curBallNum > 3) {
			curBallNum = 0;		
		}
		currentBall = GameObject.Find (balls [curBallNum]);
		currentBall.GetComponent<Ball> ().setStrokes (1);
	}
	
	public static void lastBall(){
		curBallNum--;
		if (curBallNum > 3) {
			curBallNum = 0;		
		}
		if (curBallNum < 0) {
			curBallNum = 3;		
		}
//		currentBall = GameObject.Find (balls [curBallNum]);
//		currentBall.GetComponent<Ball> ().setStrokes (1);
	}

	public static void setBallsInHand(){
		foreach (string b in balls) {
			Ball ball = GameObject.Find (b).GetComponent<Ball>();
			ball.setBallInHand(true);
		}
	}

	public static string getCurBallName(){
		return balls[curBallNum];
	}

	public static string getLastBallName(){
		int lastBallIndex = curBallNum - 1;

		if (lastBallIndex > 3) {
			lastBallIndex = 0;		
		}

		if (lastBallIndex < 0) {
			lastBallIndex = 3;		
		}
		return balls[lastBallIndex];
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (getCurBallName ());
	}
}
