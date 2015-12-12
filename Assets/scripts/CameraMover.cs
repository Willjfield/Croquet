using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {
	private float walkingSpeed;
	// Use this for initialization
	void Start () {
		walkingSpeed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {

		//Adjust walking speed
		if (Input.GetKey (KeyCode.LeftShift)) {
						walkingSpeed = 0.5f;
				} 
		else if (Input.GetKey (KeyCode.RightShift)) {
			walkingSpeed = 0.025f;
		}
		else {
			walkingSpeed = 0.05f;
				}
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
}
