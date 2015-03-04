using UnityEngine;
using System.Collections;

public class PhaseOut : MonoBehaviour {
	public GameObject camera;
	public GameObject player;
	public float animSpeed = .5f;
	public float dist = 1f;

	private int turning = 0;
	private float time = 0;
	private float mag = 0;
	private float angle = 0; 
	private int dir = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) {
			turning = 1;
			if (dir == 0 || dir == 2) {
				mag = (player.transform.position.x);
			} else {
				mag = (player.transform.position.z);
			}
			mag = dir <= 1 ? mag : -mag;
			angle = dir * Mathf.PI/2.0f;
			dir++;
			time = Time.time;
			if (dir > 3) {
				dir = 0;
			}
		} else if (Input.GetKeyDown ("down")) {
			turning = -1;
			if (dir == 0 || dir == 2) {
				mag = (player.transform.position.x);
			} else {
				mag = (player.transform.position.z);
			}
			mag = dir <= 1 ? mag : -mag;
			angle = dir * Mathf.PI/2.0f;
			dir--;
			time = Time.time;
			if (dir < 0) {
				dir = 3;
			}
		}

		int lr = (Input.GetKey ("left") ? -1 : 0) + (Input.GetKey ("right") ? 1 : 0);
		if (lr != 0) {
			float nx = player.transform.position.x;
			float nz = player.transform.position.z;
			switch(dir) {
			case 0:
				nx -= lr*dist*Time.deltaTime;
				break;
			case 1:
				nz -= lr*dist*Time.deltaTime;
				break;
			case 2:
				nx += lr*dist*Time.deltaTime;
				break;
			case 3:
				nz += lr*dist*Time.deltaTime;
				break;
			}
			player.transform.position = new Vector3(nx,1,nz);
		}

		if (turning != 0) {
			float t = Time.time;
			if (t-time >= animSpeed) {
				player.transform.position = new Vector3(dir % 2 == 0 ? mag * (dir <= 1 ? 1 : -1) : 0, 1, dir % 2 == 1 ? mag * (dir <= 1 ? 1 : -1): 0);
				camera.transform.position = new Vector3(10*Mathf.Cos (Mathf.PI/2.0f*(dir+1)),1,10*Mathf.Sin (Mathf.PI/2.0f*(dir+1)));
				camera.transform.rotation = Quaternion.Euler (0,-90-(Mathf.PI/2.0f*(dir+1))*180/Mathf.PI,0);
				turning = 0;
				return;
			}
			float a = angle+turning*Mathf.PI/2.0f*(t-time)/animSpeed;
			float r = mag*Mathf.Cos (a);
			float i = mag*Mathf.Sin (a);
			float x = 10*Mathf.Cos (Mathf.PI/2.0f+a);
			float z = 10*Mathf.Sin (Mathf.PI/2.0f+a);
			//Debug.Log (r);
			player.transform.position = new Vector3(r,1,i);
			camera.transform.position = new Vector3(x,1,z);
			camera.transform.rotation = Quaternion.Euler (0,180-a*180/Mathf.PI,0);
		}
	}
}
