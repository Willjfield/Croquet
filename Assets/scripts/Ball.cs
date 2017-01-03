using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float boundary_W, boundary_E, boundary_S, boundary_N;
	private GameObject mallet;
	private int nextWicket;
	public string color;
	public bool overlapping;

	private bool ballInHand;
	
	private int strokesLeft;

	private UIManager UIManagerScript;
	// Use this for initialization
	void Start () {
		overlapping = false;
		boundary_W = -254.2f;
		boundary_E = -226.355f;
		boundary_S = .2481f;
		boundary_N = -34.65f;
		mallet = GameObject.Find ("MalletShaft");
		UIManagerScript = GameObject.Find ("UI").GetComponent<UIManager> ();
		//UIManagerScript.activateCurrentBall ();



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
		UIManagerScript.deactivatePreviousBall ();
		if (strokesLeft == 0) {
			RulesManager.lastBall ();
		}
		UIManagerScript.activateCurrentBall ();

		nextWicket++;
		strokesLeft++;
		GameObject ballUI = GameObject.Find(color+"Button");
		ballUI.GetComponentInChildren<UnityEngine.UI.Text>().text = (nextWicket-1).ToString();

		RulesManager.clearDeadness (this.gameObject.name);
		Debug.Log (this.gameObject.name+" is going for wicket " + nextWicket);
		Debug.Log (this.gameObject.name+" has "+strokesLeft+" strokes left");

	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = transform.position; // copy to an auxiliary variable...
		Vector3 stopMo = Vector3.zero;
		
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

	float speed;
	bool shouldUpdate = true;
	void Update(){
		speed = GetComponent<Rigidbody>().velocity.magnitude;
		if (speed < 0.005 && shouldUpdate) {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//Or
			//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			RulesManager.updateBallPositions ();
			shouldUpdate = false;
		} else if(speed > 0.005){
			shouldUpdate = true;
		}
	}

	void OnTriggerExit(Collider collider){
		overlapping = false;
		//GetComponent<Ball> ().transform.GetChild (0).localScale = new Vector3 (4, 4, 4);
		//GetComponent<Ball> ().transform.GetChild (0).gameObject.SetActive (true);
		//collider.transform.parent.GetComponent<Ball> ().transform.GetChild (0).localScale = new Vector3 (4, 4, 4);

	}

	void OnTriggerEnter(Collider collider){
		if (collider.isTrigger) {
			overlapping = true;
			//GetComponent<Ball> ().transform.GetChild (0).gameObject.SetActive (false);
			//collider.transform.parent.GetComponent<Ball> ().transform.GetChild (0).localScale = new Vector3(0,0,0);

		}
		if (collider.name == "MalletHead" && mallet.GetComponent<Rigidbody>().velocity.magnitude>.005f) {

			ballInHand = false;

			if(strokesLeft>0 && RulesManager.getCurBallName()==this.name){
				strokesLeft--;
				Debug.Log (this.gameObject.name+" hit the mallet and has "+strokesLeft+" strokes left");
			}

			if(RulesManager.getCurBallName()!=this.name){
				Debug.Log (this.gameObject.name+" played out of turn");
				return;
			}
			//Change this to happen when ball stops, not onTriggerEnter
			if(strokesLeft == 0 && RulesManager.getCurBallName()==this.name){
				Debug.Log (this.gameObject.name+" is done its turn unless it gets extra shots...");
				UIManagerScript.deactivatePreviousBall ();
				RulesManager.nextBall();
				UIManagerScript.activateCurrentBall ();
			}
		}

		if (collider.name.Contains("Ball") && nextWicket>1 && (RulesManager.getLastBallName()==this.name||(strokesLeft==1 && RulesManager.getCurBallName()==this.name))  && !ballInHand) {
			//CAN'T HIT PREVIOUS PLAYED BALL
				RulesManager.setBallsInHand();
				if(RulesManager.getLastBallName()==this.name){
					UIManagerScript.deactivatePreviousBall ();
					RulesManager.lastBall();
					UIManagerScript.activateCurrentBall ();
				}
				GameObject currentBall = GameObject.Find (RulesManager.getCurBallName());
				currentBall.GetComponent<Ball> ().setStrokes (2);
				//strokesLeft = 2;
				Debug.Log (this.gameObject.name+" hit "+collider.name+" and has "+strokesLeft+" strokes left");
				RulesManager.updateDeadness (this.gameObject.name,collider.name);
	
		}
	}
}
