using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Vector3 screenPoint;
	public static bool dragBall;

	void Start(){
		dragBall = false;
	}

	void onDown(){
		dragBall = true;
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
	}

	void onDrag(){
		
		Vector3 currentScreenPoint;

		currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

		Vector3 currentPos = Camera.main.ScreenToWorldPoint (currentScreenPoint);

		transform.position = currentPos;
		if (transform.position.y < -0.08268002f) {
			float X = transform.position.x; 
			float Z = transform.position.z;
			transform.position = new Vector3 (X, -0.08268002f, Z);		
		}
		ballFreeze ();
		
	}

	void onUp(){
		dragBall = false;
		foreach (Transform ball in transform.parent)
		{
			if (ball.GetComponent<Rigidbody> ()) {
				ball.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			}
		}
	}

	void ballFreeze(){
		foreach (Transform ball in transform.parent)
		{
			if(ball != this.transform && ball.GetComponent<Rigidbody>()){
				ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
			}
		}
	}

	void OnMouseDown(){
		onDown ();
	}

	void OnMouseDrag(){
		onDrag ();
	}

	void OnMouseUp(){
		onUp ();
	}

	void Update(){
		//if (ClickManager.DoubleClick ()) {
		//Debug.Log (ClickManager.DoubleClick ());
		//}
	}
}