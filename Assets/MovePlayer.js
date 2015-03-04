#pragma strict

var speed = 5;

function Start() { }

function Update() {
	// Calculate direction of travel (left or right)
	var dir : int = Input.GetKey("left") ? -1 : Input.GetKey("right") ? 1 : 0;
	// Update position by adding <v dt, 0, 0>, where v = dir * |v|
	// Character only moves on the x-axis
	transform.localPosition += Vector3(dir * speed * Time.deltaTime, 0, 0);
}