#pragma strict

var speed       : float = 0.5;
var destination : float = 0;
var angle       : float = 0;
var quad        : int   = 0;

function Start() { }

function Update() {
	if (angle != destination && Mathf.Abs(angle-destination) < (90/speed*Time.deltaTime)) {  //may cause issues if time.deltaTime is not constant enough
		angle = destination;
		transform.rotation.eulerAngles = Vector3.up * destination;
	}
	if (destination != angle) {
		var dir = destination > angle ? 1 : -1;
		angle += dir * 90 / speed * Time.deltaTime;
		transform.Rotate(Vector3.up * dir * 90 / speed * Time.deltaTime);
	}
	// Represents a phase shift of 90 degrees by rotating the world
	if (Input.GetKeyUp("up")) {
		destination += 90;
		quad += 1;
		quad = quad % 4;
	} else if (Input.GetKeyDown("down")) {
		destination -= 90;
		quad -= 1;
		if (quad < 0) {
			quad += 4;
		}
		quad = quad % 4;
	}
}