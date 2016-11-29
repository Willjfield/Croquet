using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

	float doubleClickStart = 0;
	GameObject camController;
	CameraMover mover;
	void Start(){
		camController = GameObject.Find("CameraController");
		mover = camController.GetComponent<CameraMover> ();
		Debug.Log (mover);
	}

	void OnMouseUp()
	{
		if ((Time.time - doubleClickStart) < 0.3f)
		{
			this.OnDoubleClick();
			doubleClickStart = -1;
		}
		else
		{
			doubleClickStart = Time.time;
		}
	}

	void OnDoubleClick()
	{
		Debug.Log("Double Clicked!");
		mover.moveToBall (this.gameObject);
	}

}