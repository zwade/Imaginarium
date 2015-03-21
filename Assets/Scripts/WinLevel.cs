using UnityEngine;
using System.Collections;

public class WinLevel : MonoBehaviour {

	public GameObject[] orbs;
	public float delay = 2;

	public float timeStart = -1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeStart > 0 && (Time.time-timeStart) > delay) {
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
}
