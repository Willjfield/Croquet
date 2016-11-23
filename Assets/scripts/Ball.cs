using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float boundary_W, boundary_E, boundary_S, boundary_N;
	private int nextWicket;
	private string color;

	private bool ballInHand;
	
	private int strokesLeft;
	// Use this for initialization
	void Start () {

		boundary_W = -254.2f;
		boundary_E = -226.355f;
		boundary_S = .2481f;
		boundary_N = -34.65f;
		nextWicket = 1;
		string name = this.name;
		color = name.Substring(0,name.Length-4);

		if (color == "Blue") {
			strokesLeft = 1;		
		} else {
			strokesLeft = 0;		
		}

		ballInHand = true;
	}

	public void setStrokes(int strokeNum){
		strokesLeft = strokeNum;
		Debug.Log (this.gameObject.name+" has "+strokesLeft+" strokes left");
	}

	public int getStrokes(){
		return strokesLeft;
	}

	public void setBallInHand(bool _ballInHand){
		ballInHand = _ballInHand;
	}

	public void setWicket(int wicketNum){
		nextWicket = wicketNum;
	}

	public int getWicket(){
		return nextWicket;
	}

	public void moveToNextWicket(){
		nextWicket++;
		strokesLeft++;

		GameObject ballUI = GameObject.Find(color+"Button");
		ballUI.GetComponentInChildren<UnityEngine.UI.Text>().text = "for wicket #"+nextWicket.ToString();
		Debug.Log (this.gameObject.name+" is going for wicket " + nextWicket);
		Debug.Log (this.gameObject.name+" has "+strokesLeft+" strokes left");
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = transform.position; // copy to an auxiliary variable...
		Vector3 stopMo = new Vector3 (0, 0, 0);
		
		if (transform.position.x > boundary_E) {
			temp.x = boundary_E-.35f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			GetComponent<Rigidbody>().velocity = stopMo;
			GetComponent<Rigidbody>().angularVelocity = stopMo;
		}
		if (transform.position.x < boundary_W) {

			temp.x = boundary_W+.35f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			GetComponent<Rigidbody>().velocity = stopMo;
			GetComponent<Rigidbody>().angularVelocity = stopMo;

		}
		if (transform.position.z < boundary_N) {
			temp.z = boundary_N+.35f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			GetComponent<Rigidbody>().velocity = stopMo;
			GetComponent<Rigidbody>().angularVelocity = stopMo;
		}
		if (transform.position.z > boundary_S) {
			temp.z = boundary_S+.35f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			GetComponent<Rigidbody>().velocity = stopMo;
			GetComponent<Rigidbody>().angularVelocity = stopMo;
		}
		
	}

	void OnTriggerEnter(Collider collider){
		if (collider.name == "MalletHead") {

			ballInHand = false;

			if(strokesLeft>0 && RulesManager.getCurBallName()==this.name){
				strokesLeft--;
				Debug.Log (this.gameObject.name+" hit the mallet and has "+strokesLeft+" strokes left");
			}

			if(RulesManager.getCurBallName()!=this.name){
				Debug.Log (this.gameObject.name+" played out of turn");
			}
			//Change this to happen when ball stops, not onTriggerEnter
			if(strokesLeft == 0 && RulesManager.getCurBallName()==this.name){
				Debug.Log (this.gameObject.name+" is done its turn unless it gets extra shots...");
				RulesManager.nextBall();
			}
		}

		if (collider.name.Contains("Ball") && (RulesManager.getLastBallName()==this.name||(strokesLeft==1 && RulesManager.getCurBallName()==this.name))  && !ballInHand) {
				RulesManager.setBallsInHand();
				if(RulesManager.getLastBallName()==this.name){
					RulesManager.lastBall();
				}
				GameObject currentBall = GameObject.Find (RulesManager.getCurBallName());
				currentBall.GetComponent<Ball> ().setStrokes (2);
				//strokesLeft = 2;
				Debug.Log (this.gameObject.name+" hit "+collider.name+" and has "+strokesLeft+" strokes left");
				
		}
	}
}
