#pragma strict

var text		: GameObject;
var delay 		: float = .2f;
var sustainDur 	: float = 5f;
var fadeSpeed	: float = .05f;

private var tm		: TextMesh;
var time		: float;

function Awake () {
	tm = text.GetComponent(TextMesh);
	tm.color.a = 0;
}

function Update () {
	
	time += Time.deltaTime;
	
	if(time > delay){
		if(time < sustainDur - delay){
			tm.color.a += fadeSpeed;
		}
		else{
			tm.color.a -= fadeSpeed;
		}
	}
	
	if(time > delay && tm.color.a <= 0){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
}