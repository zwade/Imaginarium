using UnityEngine;
using System.Collections;

public class Bob : MonoBehaviour {

	public float baseY = 1.5f;
	public float amplitude = .5f;
	public float frequency = 1f;
	// Use this for initialization
	void Start () {
		//transform.position = new Vector3(transform.position.x,baseY,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,(float)(baseY+amplitude*Mathf.Cos (frequency*Time.time)),transform.position.z);
	}
}
