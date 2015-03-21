using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = camera.transform.rotation;
	}
}
