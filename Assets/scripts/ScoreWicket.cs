using UnityEngine;
using System.Collections;

public class ScoreWicket : MonoBehaviour {

	private int[] zDirections = {0,-1,-1,1,1,-1,-1,1,1,-1,-1,1,-1};
	private int zDirection;
	private int whichWicket;
	// Use this for initialization
	void Start () {
		string wicket = this.gameObject.name;
		whichWicket = int.Parse(wicket[wicket.Length - 1].ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){

	}

	void OnTriggerExit(Collider collider){
		if (collider.GetComponent<Ball>()) {
			float bV = collider.GetComponent<Rigidbody>().velocity.z;
			int curBallTarget = collider.GetComponent<Ball> ().getWicket();
			if(zDirections[curBallTarget]<0 && bV<0 && whichWicket == curBallTarget){
				collider.GetComponent<Ball> ().moveToNextWicket ();
			}else if(zDirections[curBallTarget]>0 && bV>0 && whichWicket == curBallTarget){
				collider.GetComponent<Ball> ().moveToNextWicket ();
			}
		}
		//Debug.Log (collidingBall.nextWicket);
	}
}
