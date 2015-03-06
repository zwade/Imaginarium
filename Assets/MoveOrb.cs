using UnityEngine;
using System.Collections;

public class MoveOrb : MonoBehaviour {
	public float realLocation = 0;
	public float imagLocation = 0;

	private Complex location;
	// Use this for initialization
	void Start () {
		location = new Complex(realLocation, imagLocation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = location.toVector3 + 2*Vector3.up;
	}

	public void Rotate () {
		location = location * Complex.cI();
	}


}
