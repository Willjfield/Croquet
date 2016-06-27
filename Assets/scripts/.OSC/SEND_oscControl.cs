//
//	  UnityOSC - Example of usage for OSC receiver
//
//	  Copyright (c) 2012 Jorge Garcia Martin
//
// 	  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// 	  documentation files (the "Software"), to deal in the Software without restriction, including without limitation
// 	  the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
// 	  and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// 	  The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// 	  of the Software.
//
// 	  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// 	  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// 	  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// 	  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// 	  IN THE SOFTWARE.
//

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class SEND_oscControl : MonoBehaviour {
	
	private Dictionary<string, ServerLog> servers;
	private Dictionary<string, ClientLog> clients;

	public Vector2 obPos;
	public Vector3 eulerOri;
	public Quaternion qOri;

	public float season;

	// Script initialization
	void Start() {	
		SEND_OSCHandler.Instance.Init(); //init OSC
		servers = new Dictionary<string, ServerLog>();
		clients = new Dictionary<string,ClientLog> ();
		Input.gyro.enabled = true;
		Debug.Log ("osc Running");
		Screen.orientation = ScreenOrientation.Portrait;
		Input.gyro.updateInterval = 0.083334F;
	}

	// NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
	void Update() {

	
		SEND_OSCHandler.Instance.UpdateLogs();
		servers = SEND_OSCHandler.Instance.Servers;
		clients = SEND_OSCHandler.Instance.Clients;

		Input.gyro.enabled = true;

		if (Input.touchCount > 0) {
			obPos = Input.GetTouch (0).position;
		} else {
			obPos = Input.mousePosition;
		}

		eulerOri = new Vector3(Input.gyro.attitude.eulerAngles.x,Input.gyro.attitude.eulerAngles.y,Input.gyro.attitude.eulerAngles.z);
		qOri = new Quaternion (Input.gyro.attitude [0],Input.gyro.attitude [1], Input.gyro.attitude [2], Input.gyro.attitude [3]);
		string sendOriArray = qOri.ToString("F4");

		//SEND_OSCHandler.Instance.SendMessageToClient ("TouchOSC Bridge", "/touch", "start");
		SEND_OSCHandler.Instance.SendMessageToClient ("TouchOSC Bridge", "/ori", sendOriArray);


		//Receive Messages:
	    /*foreach( KeyValuePair<string, ServerLog> item in servers )
		{
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if(item.Value.log.Count > 0) 
			{
				int lastPacketIndex = item.Value.packets.Count - 1;

				String messageAddress = item.Value.packets[lastPacketIndex].Address.ToString();

				if(messageAddress == "/touch"){
					float valueX = float.Parse (item.Value.packets[lastPacketIndex].Data[0].ToString());
					float valueY = float.Parse (item.Value.packets[lastPacketIndex].Data[1].ToString());
					UnityEngine.Debug.Log("touch event: "+valueX+","+valueY);
					obPos.Set((valueX/100)-5,0,-(valueY/100)-9);
					transform.position=obPos;
					obPos.Set(0,0,0);
				}

				if(messageAddress == "/ori"){
					float valueY = float.Parse (item.Value.packets[lastPacketIndex].Data[0].ToString());
					float valueX = -1*float.Parse (item.Value.packets[lastPacketIndex].Data[1].ToString());
					float valueZ = -1*float.Parse (item.Value.packets[lastPacketIndex].Data[2].ToString());
					UnityEngine.Debug.Log("ori event: "+valueX+","+valueY);
					obPos.Set(valueX,valueY,valueZ);
					transform.eulerAngles = obPos;
					obPos.Set(0,0,0);
				}

				//Log all OSC data received:
				/*UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}", 
				                                    item.Key, // Server name
				                                    item.Value.packets[lastPacketIndex].Address, // OSC address
				                                    item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value
				                                    */


		//	}
	    //}
		
	}
}