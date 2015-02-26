#pragma strict

var speed = 5;

function Start () {

}

function Update () {
	var dir:int = 0;
	if (Input.GetKey("left")) {
		dir -= 1;
	}
	if (Input.GetKey("right")) {
		dir += 1;
	}
	transform.localPosition = transform.localPosition + Vector3(dir*speed*Time.deltaTime,0,0);
}