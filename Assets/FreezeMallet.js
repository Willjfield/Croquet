#pragma strict

function Start () {

}

function Update () {
// Make hinge limit for a door.
	var limits = hingeJoint.limits;
	if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
	limits.min = 0;
	limits.minBounce = 0;
	limits.max = 0;
	limits.maxBounce = 0;
	hingeJoint.limits = limits;
}else{
	limits.min = -120;
	limits.minBounce = 0;
	limits.max = 170;
	limits.maxBounce = 0;
	hingeJoint.limits = limits;
}
}