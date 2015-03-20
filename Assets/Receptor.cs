using UnityEngine;
using System.Collections;

public class Receptor : MonoBehaviour {
	public float real = -2;
	public float imag = 0;

	public Complex location;
	// Use this for initialization
	void Start () {
		location = new Complex(real, imag);
		transform.position = location.toVector3 + transform.position.y * Vector3.up ;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
