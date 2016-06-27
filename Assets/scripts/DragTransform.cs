using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Vector3 screenPoint;

	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
	}

	void OnMouseDrag(){
		Vector3 currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 currentPos = Camera.main.ScreenToWorldPoint (currentScreenPoint);
		transform.position = currentPos;
		if (transform.position.y < -0.08268002f) {
			float X = transform.position.x; 
			float Z = transform.position.z;
			transform.position = new Vector3(X, -0.08268002f, Z);		
		}
		ballFreeze ();
	}
	
	void ballFreeze(){
		foreach (Transform ball in transform.parent)
		{
			if(ball != this.transform){
				ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
			}
		}
	}

	void OnMouseUp(){
		foreach (Transform ball in transform.parent)
		{
			ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
	}
}