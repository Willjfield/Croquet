using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
		float mousePos = 0.0f;
		float mousePos2 = 0.0f;
		private float swingStrength = .5f;
		float oldTheta = 0f;
		float initialTheta = 0f;
		private GameObject MalletShaft;

		public void adjustswingStrength(float theStrength){
			swingStrength = theStrength;
		}

		void start(){
			//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = false;
			MalletShaft = GameObject.Find ("MalletShaft");
		}

		void Update ()
		{
		#if (UNITY_EDITOR || UNITY_STANDALONE)
				// Swing Keyboard
				float backswing = Input.GetAxisRaw ("Vertical");
				GetComponent<Rigidbody>().AddForce (transform.forward * 50 * backswing * swingStrength);

			if (Input.GetKey ("space")) {
					//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = true;
				} else {
					//GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = false;
				}
		#endif

//		#if (UNITY_ANDROID || UNITY_IOS)
//			float rollAmount = 0f;
//			
			if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				// Get movement of the finger since last frame
				Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
				Vector3 malletRotation = (transform.forward * touchDeltaPosition.y);
				//MalletShaft.transform.Rotate (malletRotation);
				GetComponent<Rigidbody> ().AddForce (transform.forward * Mathf.Pow(touchDeltaPosition.y,2) * Mathf.Sign(touchDeltaPosition.y));
			}
//				// Move object across XY plane
//				//transform.Translate(-touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);
//			}else if (Input.touchCount == 2){
//				float theta = Vector2.Angle(Input.GetTouch(0).position,Input.GetTouch(1).position);
//				Vector3 cross = Vector3.Cross(Input.GetTouch(0).position, Input.GetTouch(1).position);
//
//				if (cross.z > 0){
//					theta = 360 - theta;
//				}
//
//				if(Input.GetTouch(1).phase == TouchPhase.Began){
//					Debug.Log("touch start");
//					initialTheta  = theta;
//				}
//				
//				if(Input.GetTouch(1).phase == TouchPhase.Ended){
//					Debug.Log("touch end");
//					oldTheta  = theta;
//				}
//
//				theta+=oldTheta-initialTheta;
//				Debug.Log("theta "+theta);
//				Debug.Log("old "+oldTheta);
//				Debug.Log("init "+initialTheta);
//
//				GameObject.Find("CameraController").transform.eulerAngles = new Vector3(0f,theta,0f);
//			}
//		#endif
		}


}
