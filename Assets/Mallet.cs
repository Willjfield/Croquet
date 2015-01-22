using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
	//public JointLimits limits = hingeJoint.limits;

	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
		//MalletDown ();
		}
		// Swing
		float backswing = Input.GetAxisRaw("Vertical");					
		rigidbody.AddForce (transform.forward* 20 * backswing);
		rigidbody.useGravity = true;	
		
	}
	//void MalletDown(){		/// Put mallet down
//			limits.min = 0;
//			limits.minBounce = 0;
//			limits.max = 90;
//			limits.maxBounce = 0;
//			hingeJoint.limits = limits;
	//}
}
