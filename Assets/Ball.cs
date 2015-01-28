using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 temp = transform.position; // copy to an auxiliary variable...
		Vector3 stopMo = new Vector3 (0, 0, 0);
		
		if (transform.position.x > -226.8) {
			temp.x = -227.0f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			rigidbody.velocity = stopMo;
			rigidbody.angularVelocity = stopMo;
		}
		if (transform.position.x < -252) {

			temp.x = -251.8f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
			rigidbody.velocity = stopMo;
			rigidbody.angularVelocity = stopMo;

		}
		if (transform.position.z > 0) {
			temp.z = -0.2f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			rigidbody.velocity = stopMo;
			rigidbody.angularVelocity = stopMo;
		}
		if (transform.position.z < -31.5) {
			temp.z = -31.3f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value
			rigidbody.velocity = stopMo;
			rigidbody.angularVelocity = stopMo;
		}
		
	}
}
