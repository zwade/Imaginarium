#pragma strict
// Script for cutscenes 
// goes through images one by one
// goes through text lines one by one
// stays on last image until all text complete

// loads next level when done

var delay		: int;
var blackout	: Texture;
var skin		: GUISkin;
var script		: TextAsset;
var imgs		: Sprite[];


private var text	: String;
private var scripts	: String[];
private var time	: int = 0;
private var iter	: int = -1;
private var alpha	: float = 1;
private var fading	: int = 0;
private var sp		: SpriteRenderer;

function Start () {
	scripts = script.text.Replace("\r", "").Split("\n"[0]);
	// RemoveRegisterChars(scripts);
	fading = 1;
	Time.timeScale = 1;
	sp = GetComponent(SpriteRenderer);
	if(scripts[0] == "") {
		sp.sprite = imgs[0];
		iter = 0;
	}
}

function OnGUI () {
	if (fading != 0) {
		GUI.color.a = alpha;
		GUI.contentColor.a = alpha;
		GUI.backgroundColor.a = alpha;
		GUI.Box(Rect(-5, -5, Screen.width + 10, Screen.height * 2), blackout);
	}
	GUI.skin = skin;
	GUI.skin.button.fontSize = Mathf.Min(Screen.height, Screen.width) / 25;
	GUI.color.a = Mathf.Max(0, 1-2*alpha);
	GUI.contentColor.a = Mathf.Max(0, 1-2*alpha);
	GUI.backgroundColor.a = Mathf.Max(0, 1-2*alpha);
	GUI.skin.button.fontSize = Screen.width / 37;
	if (GUI.Button(Rect(25,Screen.height-100, Screen.width - 50, 75), text))
		time = 0;
	GUI.skin.button.fontSize = Mathf.Min(Screen.width, Screen.height) / 25;
	if (GUI.Button(Rect(9*Screen.width/10 - 10, 10, Screen.width/10, Screen.height/10), "Skip"))
		fading = -1;
	GUI.backgroundColor.a = 0;
	if(GUI.Button(new Rect(0, 0, Screen.width, Screen.height), ""))
		time = 0;
}

function Update () {
	if (fading == 1) {
		alpha -= .01;
		if ( alpha < 0 ) {
			fading = 0;
			alpha = 0;
		}
	} else if (fading == -1) {
		alpha += .01;
		if(alpha > 1) {
			Application.LoadLevel(Application.loadedLevel + 1);
			return;
		}
	} else if (time <= 0) {
			iter++;
			if (iter >= scripts.Length) {
				fading = -1;
				return;
			}
			text = scripts[iter];
			if(iter < imgs.length){
				sp.sprite = imgs[iter];
			}
			if(text == "") {
				text = scripts[++iter];
			}
			time = delay;
	} else if(Input.GetKeyDown(KeyCode.Space))
		time = 0;
	else
		time -= Time.deltaTime*1000;
}