using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class RulesManager : MonoBehaviour {
	public static string[] balls;
	private static int curBallNum;
	private static GameObject currentBall;

	public static Vector3[] ballPositions;
	public static bool[,] deadness;

	// Use this for initialization
	void Awake () {
		curBallNum = 0;
		balls = new string[]{"BlueBall","RedBall","BlackBall","YellowBall"};
		currentBall = GameObject.Find (balls [curBallNum]);
		ballPositions = new Vector3[4];
		deadness = new bool[4,3];
		for(int i = 0;i<4;i++){
			//int index = i;
			for(int j = 0;j<3;j++){
				deadness[i,j] = false;
			}
		}
	}

//	void OnGUI(){
//		if(GUI.Button(new Rect(10,460,300,90), "Save")){
//			Save();
//		}
//
//		if(GUI.Button(new Rect(10,560,300,90), "Load")){
//			Load();
//		}
//	}

	public static void updateBallPositions(){
		for (int b =0;b<4;b++) {
			Ball ball = GameObject.Find (balls[b]).GetComponent<Ball>();
			ballPositions [b] = ball.transform.position;
			//Debug.Log (ballPositions[b]);
		}
	}

	private static void setBallPositions(){
		for (int b =0;b<4;b++) {
			Ball ball = GameObject.Find (balls[b]).GetComponent<Ball>();
			ball.transform.position = ballPositions [b];
			//Debug.Log (ballPositions[b]);
		}
	}

	private static int getBallIndex(string ball){
		int ballIndex = 4;
		switch (ball) {
		case "BlueBall":
			ballIndex = 0;
				break;
		case "RedBall":
			ballIndex = 1;
				break;
		case "BlackBall":
			ballIndex = 2;
				break;
		case "YellowBall":
			ballIndex = 3;
				break;
		}
		return ballIndex;
	}

	public static void updateDeadness(string ballPlayed, string ballCollided){
		int ballPlayedIndex = getBallIndex(ballPlayed);
		int ballCollidedIndex = getBallIndex(ballCollided);

		deadness [ballPlayedIndex, ballCollidedIndex] = true;
		//Debug.Log (ballPlayedIndex+" dead on "+ballCollidedIndex);
		//Debug.Log (deadness[ballPlayedIndex,ballCollidedIndex]);
		//Debug.Log (deadness[2,1]);
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

	public static void Save(string gameName){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/"+gameName+".dat");

		PlayerData data = new PlayerData ();
		data.curBallNum = curBallNum;

		RulesManager.updateBallPositions ();

		data.ballPositions = new SerializableVector3[4];

		for (int b =0;b<4;b++) {
			SerializableVector3 pos = new SerializableVector3(ballPositions[b].x,ballPositions[b].y,ballPositions[b].z);
			data.ballPositions [b] = pos;
		}
		data.deadness = deadness;

		currentBall = GameObject.Find (balls [curBallNum]);
		data.strokesLeft = currentBall.GetComponent<Ball> ().getStrokes ();

		data.nextWicket = new int[4];
		for (int b =0;b<4;b++) {
			Ball ball = GameObject.Find (balls[b]).GetComponent<Ball>();
			data.nextWicket[b] = ball.getWicket();
		}

		bf.Serialize (file, data);
		file.Close ();
	}

	public static void Load(string gameName){
		if (File.Exists (Application.persistentDataPath+"/"+gameName+".dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGame.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			curBallNum = data.curBallNum;
			for (int b =0;b<4;b++) {
				ballPositions[b] = new Vector3(data.ballPositions[b].x,data.ballPositions[b].y,data.ballPositions[b].z);
			}
			deadness = data.deadness;

			for (int b =0;b<4;b++) {
				Ball ball = GameObject.Find (balls[b]).GetComponent<Ball>();
				ball.setWicket(data.nextWicket[b]);
			}

			setBallPositions ();

			currentBall = GameObject.Find (balls [curBallNum]);
			currentBall.GetComponent<Ball> ().setStrokes (data.strokesLeft);
			GameObject cam = GameObject.Find ("CameraController");
			cam.GetComponent<CameraMover>().moveToBall(currentBall);
		}
	}
}

[Serializable]
class PlayerData{
	public int curBallNum;
	public SerializableVector3[] ballPositions;
	public bool[,] deadness;
	public int strokesLeft;
	public int[] nextWicket;
}

[Serializable]
public struct SerializableVector3
{
	/// <summary>
	/// x component
	/// </summary>
	public float x;

	/// <summary>
	/// y component
	/// </summary>
	public float y;

	/// <summary>
	/// z component
	/// </summary>
	public float z;

	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="rX"></param>
	/// <param name="rY"></param>
	/// <param name="rZ"></param>
	public SerializableVector3(float rX, float rY, float rZ)
	{
		x = rX;
		y = rY;
		z = rZ;
	}

	/// <summary>
	/// Returns a string representation of the object
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return String.Format("[{0}, {1}, {2}]", x, y, z);
	}

	/// <summary>
	/// Automatic conversion from SerializableVector3 to Vector3
	/// </summary>
	/// <param name="rValue"></param>
	/// <returns></returns>
	public static implicit operator Vector3(SerializableVector3 rValue)
	{
		return new Vector3(rValue.x, rValue.y, rValue.z);
	}

	/// <summary>
	/// Automatic conversion from Vector3 to SerializableVector3
	/// </summary>
	/// <param name="rValue"></param>
	/// <returns></returns>
	public static implicit operator SerializableVector3(Vector3 rValue)
	{
		return new SerializableVector3(rValue.x, rValue.y, rValue.z);
	}
}