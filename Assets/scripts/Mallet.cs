using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
		private float swingStrength = .5f;
		private GameObject MalletShaft;
		private JointLimits limits;
		private GameObject BallMarkers;

		public void adjustswingStrength(float theStrength){
			swingStrength = theStrength;
		}

		void Start(){
			//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = false;
			MalletShaft = GameObject.Find("MalletShaft");
			limits = MalletShaft.GetComponent<HingeJoint>().limits;

			BallMarkers = GameObject.Find ("BallMarkers");
			BallMarkers.SetActive(true);
		}

		void LateUpdate ()
		{
		#if UNITY_EDITOR || UNITY_STANDALONE
				// Swing Keyboard
				float backswing = Input.GetAxisRaw ("Vertical");
				GetComponent<Rigidbody>().AddForce (transform.forward * 50 * backswing * swingStrength);
			if (Input.GetKey ("space")) {
					//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = true;
				} else {
					//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = false;
				}
		#endif

		#if UNITY_ANDROID || UNITY_IOS
			float rollAmount = 0f;
			if (Input.touchCount == 1 
				&& Input.GetTouch (0).phase == TouchPhase.Moved 
				&& DetectTouchMovement.panDistance.magnitude == 0 
				&& Mathf.Abs(DetectTouchMovement.turnAngleDelta) == 0
				&& DragTransform.dragBall == false
			) {
					// Get movement of the finger since last frame
					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
					GetComponent<Rigidbody> ().AddForce (transform.forward * Mathf.Pow(touchDeltaPosition.y*.25f,2) * Mathf.Sign(touchDeltaPosition.y));
			}

			if (Input.touchCount == 0){
				BallMarkers.SetActive(true);
			}else{
				BallMarkers.SetActive(false);
			}
//		if (DetectTouchMovement.panDistance.magnitude > 0 || Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0){
//				Debug.Log("not swinging");
//				limits.min = 0;
//				limits.bounciness = 0;
//				limits.max = 0;
//				MalletShaft.GetComponent<HingeJoint>().limits = limits;
//				MalletShaft.transform.rotation = new Quaternion();
//		}else{
//			limits.min = -120;
//			limits.bounciness = 0;
//			limits.max = 170;
//			MalletShaft.GetComponent<HingeJoint>().limits = limits;
//		}
		#endif
		}


}
