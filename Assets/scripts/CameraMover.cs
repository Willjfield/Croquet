using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	public float walkingSpeed;
	// Use this for initialization
	void Start () {
		walkingSpeed = 0.1f;
	}
	public void adjustWalkingSpeed(float theSpeed){
		walkingSpeed = theSpeed;
	}
	// Update is called once per frame
	void Update () {
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
