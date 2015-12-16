using UnityEngine;
using System.Collections;

public class rotateCamera : MonoBehaviour {
	float tempRoty;
	float tempRotx;
	// Use this for initialization
	void Start () {
		tempRoty = 0.0f;
		tempRotx = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//tempRot.Set(0,0,Input.mousePosition.y);
		if(Input.GetKey (KeyCode.LeftControl)){
			tempRoty = Input.mousePosition.y.Map (Screen.height, 0,-45, 45);
			tempRotx = Input.mousePosition.x.Map (Screen.width, 0,-45, 45);
			transform.localRotation = Quaternion.Euler (tempRoty, tempRotx,0);
		}
	}
}

public static class ExtensionMethods
{
	public static float Map (this float value, float fromSource, float toSource, float fromTarget, float toTarget)
	{
		return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
	}
}