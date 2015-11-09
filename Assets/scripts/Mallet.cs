using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
		float mousePos = 0.0f;
		float mousePos2 = 0.0f;

		void Update ()
		{
				//Swing Mouse
				/*
				mousePos = Input.mousePosition.y;
				if (Input.GetMouseButton (0)) {						
						float backswingMouse = mousePos - mousePos2;
						GetComponent<Rigidbody>().AddForce (transform.forward * backswingMouse * 1.5f);
						GetComponent<Rigidbody>().useGravity = true;
				} else {
						mousePos2 = mousePos;
				}
				*/
				// Swing Keyboard
				float backswing = Input.GetAxisRaw ("Vertical");
				GetComponent<Rigidbody>().AddForce (transform.forward * 20 * backswing);
				GetComponent<Rigidbody>().useGravity = true;	
				mousePos2 = mousePos;

		}
}
