using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
	//public JointLimits limits = hingeJoint.limits;

	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
		}
		//Swing Mouse
		if (Input.GetMouseButton (0)) {
						float backswingMouse = Input.mousePosition.y - (Screen.height / 2);
						rigidbody.AddForce (transform.forward * backswingMouse * 0.05f);
						rigidbody.useGravity = true;
				}
		// Swing Keyboard
		float backswing = Input.GetAxisRaw("Vertical");
		rigidbody.AddForce (transform.forward* 20 * backswing);
		rigidbody.useGravity = true;	


	}
}
