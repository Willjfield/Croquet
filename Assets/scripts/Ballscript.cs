using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position; // copy to an auxiliary variable...

		if (transform.position.x < 0) {
			temp.x = 0.0f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
				}
	}
}
