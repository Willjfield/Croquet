using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
	private Vector3 screenPoint;
	private bool dragBall;

	void Start(){
		dragBall = true;
	}

	void onDown(){
		screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
	}

	void onDrag(){
		Vector3 currentScreenPoint;
		//#if UNITY_EDITOR
		currentScreenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//#endif

//		#if UNITY_ANDROID
//		currentScreenPoint = new Vector3 (Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, screenPoint.z);
//		#endif

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
		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began && dragBall) {
			onDown ();
		}

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved && dragBall) {
			onDrag ();
		}

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Ended && dragBall) {
			onUp ();
		}
	}
}