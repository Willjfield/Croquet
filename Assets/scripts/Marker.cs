using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	public GameObject parentBall;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = parentBall.transform.position;
		transform.Translate (0, (Mathf.Sin(Time.fixedTime)/8f)+.5f, 0);
		transform.Rotate (0, 1f, 0);
	}
}
