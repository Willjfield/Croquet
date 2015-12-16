using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public float boundary_W, boundary_E, boundary_S, boundary_N;
	// Use this for initialization
	void Start () {
		boundary_W = -254.2f;
		boundary_E = -226.355f;
		boundary_S = .2481f;
		boundary_N = -34.65f;
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
