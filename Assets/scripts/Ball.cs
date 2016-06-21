using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float boundary_W, boundary_E, boundary_S, boundary_N;
	private int nextWicket;
	// Use this for initialization
	void Start () {
		boundary_W = -254.2f;
		boundary_E = -226.355f;
		boundary_S = .2481f;
		boundary_N = -34.65f;
		nextWicket = 1;
	}

	public void setWicket(int wicketNum){
		nextWicket = wicketNum;
	}

	public int getWicket(){
		return nextWicket;
	}

	public void moveToNextWicket(){
		nextWicket++;

		Debug.Log (this.gameObject.name+" is going for wicket " + nextWicket);
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
}
