using UnityEngine;
using System.Collections;

public class cameraInOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * Input.GetAxis ("Mouse ScrollWheel"));
		/*
		if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 5f) {
			transform.Translate (Vector3.forward * DetectTouchMovement.pinchDistanceDelta * .01f);
		}

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
