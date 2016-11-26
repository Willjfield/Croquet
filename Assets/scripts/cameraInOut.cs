using UnityEngine;
using System.Collections;

public class cameraInOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		transform.Translate (Vector3.forward * Input.GetAxis ("Mouse ScrollWheel"));
		transform.Translate (Vector3.forward * DetectTouchMovement.pinchDistanceDelta);
		/*
		if (transform.position.z > 5f) {
			temp.z = 5f;
			transform.position=temp;
		}

		if (transform.position.z > 0f) {
			temp.y = 0f;
			transform.position=temp;
		}
			*/
	}
}
