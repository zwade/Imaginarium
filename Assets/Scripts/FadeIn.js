#pragma strict
var working 		: boolean = true;
var seconds			: float = .3f;
var blackout		: Texture;
var fade_length		: float = 10f;
var fade_speed		: float = 0.01f;
private var alpha	: float;


function Awake () {
	Time.timeScale = 1;
	Time.fixedDeltaTime = .02;
	alpha = 1;
}

function OnGUI () {
	if(alpha > 0) {
		GUI.color.a = alpha;
		GUI.contentColor.a = alpha;
		GUI.backgroundColor.a = alpha;
		GUI.Box(Rect(-Screen.width, -5, Screen.width * 3, Screen.height * 3), blackout);
	}
}

function Update () {
	if(working){
		if(seconds >= 0) {
			seconds -= Time.deltaTime;
		} else if( fade_length > 0) {
			fade_length -= Time.deltaTime;
			alpha -= fade_speed;
		}
	}
}