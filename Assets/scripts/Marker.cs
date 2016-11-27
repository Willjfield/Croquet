using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	public GameObject parentBall;
	private GameObject camera;
	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = parentBall.transform.position;
		float distFromCamera = Vector3.Distance (camera.transform.position, transform.position)*.025f;
		transform.localScale = new Vector3 (distFromCamera,distFromCamera,distFromCamera);
		transform.Translate (0, (Mathf.Sin(Time.fixedTime)/(1f/distFromCamera))+(4f*distFromCamera), 0);
		transform.Rotate (0, 1f, 0);
	}
}
