using UnityEngine;
using System.Collections;

public class ActivateAimer : MonoBehaviour {

	GameObject Balls;
	// Use this for initialization
	void Start () {
		Balls = GameObject.Find ("Balls");
	}
	
	// Update is called once per frame
	void Update () {
		bool nearBall = false;
		foreach (Transform ball in Balls.transform)
		{
			if(Vector3.Distance(ball.position,this.transform.position)<.1f){
				nearBall = true;
			}
		}
		GetComponent<Renderer>().enabled=nearBall;
	}
}
