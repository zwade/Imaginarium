using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Receptor : MonoBehaviour {
	public float real = -2;
	public float imag = 0;
	public GameObject text;

	public Complex location;
	// Use this for initialization
	void Start () {
		location = new Complex(real, imag);
		Debug.Log (">"+location.toVector2);
		transform.position = location.toVector3 + transform.position.y * Vector3.up ;
		text.GetComponent<Text>().text = location.ToString ();
		transform.eulerAngles = new Vector3(0,location.Phase*-180/Mathf.PI,0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
