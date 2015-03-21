#pragma strict
var topText		: String;
var bottomText	: String;
var skin	: GUISkin;

private var time	: float;
private var start	: float;
private var end		: float;
private var location: float;

private final var duration	: float = 3;
private final var delay		: float = .5;

function Awake () {

	Debug.Log(Application.loadedLevelName);
	
	time = -1;
	start = -Screen.width / 2;
	end = Screen.width;
}

function OnGUI () {
	GUI.skin = skin;
	GUI.backgroundColor.a = 0;
	if(time < duration && time > 0) {
		GUI.skin.box.fontSize = Mathf.Min(Screen.height / 5, Screen.width / 4) / 3;
		location = start + (end - start) * (
			2.326146076*Mathf.Pow(time/duration, 3) - 4.136072261*Mathf.Pow(time/duration, 2) + 2.80468143*time/duration - .01713286713);
		GUI.Box(Rect(location, Screen.height * 5/7, Screen.width * 2, Screen.height / 7), topText);
		GUI.skin.box.fontSize = Mathf.Min(Screen.height / 5, Screen.width / 4) / 2;
		location = end + (start - end) * (
			6.837400643*Mathf.Pow(time/duration, 3) - 11.15182205*Mathf.Pow(time/duration, 2) + 6.323486317*time/duration - 1.004941346);
		GUI.Box(Rect(location, Screen.height * 6/7, Screen.width / 2, Screen.height / 7), bottomText);
	}
}

function Update () {
	time += Time.deltaTime;
}

