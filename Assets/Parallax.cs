using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	public float scale = 2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(-transform.parent.transform.parent.transform.localPosition.x/scale,transform.localPosition.y,transform.localPosition.z);
	}
}
