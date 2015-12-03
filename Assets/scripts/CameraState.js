#pragma strict

var cam1 : Camera; 
var cam2 : Camera;
var cam3 : Camera;
var cam4 : Camera;

private var camCount : int;

function Start() { 
	camCount = 1;
	}

function Update() {

 if (Input.GetKeyDown(KeyCode.Space)) {
 	camCount++;
 	if(camCount>4){
 		camCount = 1;
 	}
 	
 	switch(camCount) {
	    case 1:
	        cam1.enabled = true;
	        cam2.enabled = false;
	        cam3.enabled = false;
	        cam4.enabled = false;
	        break;
	    case 2:
	        cam2.enabled = true;
	        cam1.enabled = false;
	        cam3.enabled = false;
	        cam4.enabled = false;
	        break;
	    case 3:
	        cam3.enabled = true;
	        cam1.enabled = false;
	        cam2.enabled = false;
	        cam4.enabled = false;
	        break;
	    case 4:
	        cam4.enabled = true;
	        cam1.enabled = false;
	        cam2.enabled = false;
	        cam3.enabled = false;
	        break;
     }
     
 	}
 
}