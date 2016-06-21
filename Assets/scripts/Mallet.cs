﻿using UnityEngine;
using System.Collections;

public class Mallet : MonoBehaviour
{
		float mousePos = 0.0f;
		float mousePos2 = 0.0f;
		private float swingStrength = .5f;

		public void adjustswingStrength(float theStrength){
			swingStrength = theStrength;
		}
		void Update ()
		{
				//Swing Mouse
				/*
				mousePos = Input.mousePosition.y;
				if (Input.GetMouseButton (0) && Input.GetKey (KeyCode.LeftControl)) {						
						float backswingMouse = mousePos - mousePos2;
						GetComponent<Rigidbody>().AddForce (transform.forward * backswingMouse * 1.5f);
						GetComponent<Rigidbody>().useGravity = false;
				} else {
						mousePos2 = mousePos;
				}
				*/
				// Swing Keyboard
				float backswing = Input.GetAxisRaw ("Vertical");
				GetComponent<Rigidbody>().AddForce (transform.forward * 50 * backswing * swingStrength);
				//GetComponent<Rigidbody>().useGravity = true;	
				//mousePos2 = mousePos;

			if (Input.GetKey ("space")) {
					GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = true;
				} else {
					GameObject.Find ("ShootLine").GetComponent<MeshRenderer> ().enabled = false;
				}
		}


}
