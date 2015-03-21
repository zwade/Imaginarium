using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

	public GameObject[] orbs;
	public float delay = 2;
	public bool isFinal = false;

	public GameObject lightShow;
	public GameObject book;
	public GameObject player;
	public GameObject fade;

	public float timeStart = -1f;

	public float fadeTime = -1f;
	public float fadeSpeed = 2f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (timeStart > 0 && (Time.time-timeStart) > delay) {
			if (isFinal) {
				finale();
				return;
			}
			Application.LoadLevel(Application.loadedLevel+1);
		} 
		if (timeStart < 0) {
			foreach (GameObject o in orbs) {
				if (!o.GetComponent<OrbControl>().isSafe){
					return;
				}
			}
			timeStart = Time.time;
		}
	}
	void finale() {
		lightShow.GetComponent<ParticleSystem>().enableEmission = true;
		Debug.Log (fadeTime+" : "+Time.time);
		if (fadeTime > 0) {
			if (((Time.time-fadeTime)/fadeSpeed) > 1.5) {
				Application.LoadLevel(Application.loadedLevel+1);
			}
			float a = (Time.time-fadeTime)/fadeSpeed;
			Color c = fade.GetComponent<SpriteRenderer>().color;
			fade.GetComponent<SpriteRenderer>().color = new Color(c.r,c.g,c.b,a);

		} else if (player.transform.position.x < -65) {
			fadeTime = Time.time;
		}
	}
}

