using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SlidingImage : MonoBehaviour {
	public float t = 0f;
	private List<GameObject> backgrounds;
	private int count;
	private int prev;
	private int index;
	void Awake () {
		count = 0;
		index = 1;
		prev = 1;
		backgrounds = new List<GameObject>();
		foreach (Transform child in transform) {
			if (count > 0) {
				child.GetComponent<Animator>().StopPlayback();
			}
			backgrounds.Add(child.gameObject);
			count++;
		}
	}
	void Update () {
		t += Time.deltaTime;
		if (Mathf.FloorToInt(t) % 4 == 0 && Mathf.FloorToInt(t) > prev) {
			prev = Mathf.FloorToInt(t);
			index++;
			if (index > count) {
				index = 1;
			}
			backgrounds[index - 1].GetComponent<Animator>().enabled = true;
			backgrounds[index - 1].GetComponent<Animator>().Play("Fade", -1, 0);
			Debug.Log("Firing");
		}
	}
}