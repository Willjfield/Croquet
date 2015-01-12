using UnityEngine;
using System.Collections;

public class ball_script : MonoBehaviour {

	void OnMouseDown(){
		rigidbody.AddForce (-transform.right * 1000);
		rigidbody.useGravity = true;
	}
}
