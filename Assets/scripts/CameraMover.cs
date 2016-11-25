using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	public float walkingSpeed;
	private JointLimits limits;
	GameObject MalletShaft;
	// Use this for initialization
	void Start () {
		walkingSpeed = 0.1f;
		MalletShaft = GameObject.Find ("MalletShaft");
		limits = MalletShaft.GetComponent<HingeJoint>().limits;
	}
	public void adjustWalkingSpeed(float theSpeed){
		walkingSpeed = theSpeed;
	}
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		//Move around
		if(Camera.current != null)
		{
			//Look around
			float inputRot = Input.GetAxis("Horizontal");
			this.transform.Rotate(Vector3.up*inputRot);

			//Move around
			if (Input.GetKey (KeyCode.W))
			    {
				this.transform.Translate(new Vector3(-0.1f*walkingSpeed, 0.0f, 0.0f));

			}
			if (Input.GetKey (KeyCode.A))
			{
				this.transform.Translate(new Vector3(0.0f, 0.0f,-0.1f*walkingSpeed));
			}      
			if (Input.GetKey (KeyCode.S))
			{      
				this.transform.Translate(new Vector3(0.1f*walkingSpeed, 0.0f, 0.0f));
				; 
			}
			
			if (Input.GetKey (KeyCode.D))
			{     
				this.transform.Translate(new Vector3(0.0f, 0.0f,0.1f*walkingSpeed));
				  
			}
		}
		#endif
	}

	void LateUpdate() {
		#if (UNITY_ANDROID || UNITY_IOS)
			float pinchAmount = 0;
			Quaternion desiredRotation = transform.rotation;

			DetectTouchMovement.Calculate();

//			if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0) { // zoom
//				pinchAmount = DetectTouchMovement.pinchDistanceDelta*.01f;
//			}

			if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0) { // rotate
				Vector3 rotationDeg = Vector3.zero;
				rotationDeg.y = -DetectTouchMovement.turnAngleDelta;
				desiredRotation *= Quaternion.Euler(rotationDeg);
			}

			if(DetectTouchMovement.panDistance.magnitude > 0 || Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0){
				limits.min = 0;
				limits.bounciness = 0;
				limits.max = 0;
				MalletShaft.GetComponent<HingeJoint>().limits = limits;
			}
			
			// not so sure those will work:
			transform.rotation = desiredRotation;
			transform.localPosition += Vector3.forward * DetectTouchMovement.panDistance.y;
			transform.localPosition += Vector3.right * DetectTouchMovement.panDistance.x;
		#endif
	}

	public void moveToBall(GameObject ball){
		{
			Vector3 Pos3D = ball.transform.position;
			
			int targetWicketNum = ball.GetComponent<Ball>().getWicket();
			string targetWicketName = "Wicket_"+targetWicketNum;
			GameObject targetWicket = GameObject.Find(targetWicketName);
			
			Vector3 wicketDirection = Pos3D-targetWicket.transform.position;
			float wicketDistance = wicketDirection.magnitude*2f;
			Vector3 normalWicketDirection = wicketDirection/wicketDistance;
			Vector3 newPosition = Pos3D+normalWicketDirection;
			
			Vector3 temp = transform.position;
			temp.x = newPosition.x;
			temp.z = newPosition.z;
			
			Vector3 LookTarget = targetWicket.transform.position;
			LookTarget.y = transform.position.y;
			
			transform.position=temp;
			transform.LookAt(LookTarget);
			transform.Rotate(0,90,0);
		} 
	}
}
