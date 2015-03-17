using UnityEngine;
using System.Collections;

public class OrbControl : MonoBehaviour {

	public GameObject UI;
	public GameObject Player;

	public float threshold = 2;
	public float speed = 3.14f;

	public float real;
	public float complex;
	private Complex position;

	private Complex destination;

	private UpdateUI locManager;
	// Use this for initialization
	void Start () {
		position = new Complex(real,complex);
		destination = position;
		locManager = Player.GetComponent<UpdateUI>();
		UI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if ((position-destination).Mag < 0.1) {
			position = destination;
		}

		if (position != destination) {
			float angDist = destination.Phase - position.Phase;
			float radDist = destination.Mag - position.Mag;
			float scale = 0;
			if (angDist == 0) {
				scale = 1f;
			} else if (radDist == 0) {
				scale = .33f;
			} else {
				scale = radDist/angDist;
			}
			Debug.Log (position | (speed * scale * Time.deltaTime));
			position = (position | (speed * scale * Time.deltaTime)) & (speed * Time.deltaTime);

		} 
		transform.position = position.toVector3 + 2.25f*Vector3.up;
		transform.eulerAngles = new Vector3(0,position.Phase*-180/Mathf.PI,0);

		if ((position-locManager.getLocation()).Mag < threshold) {
			UI.SetActive(true);
		} else {
			UI.SetActive(false);
		}
	}

	public void timesNegativeOne() {
		destination = destination * (Complex.c1() * -1f);
	}

	public void timesImaginaryUnit() {
		destination = destination * Complex.cI();
	}

	public void addOne() {
		destination = destination + Complex.c1();
		Debug.Log (destination);
	}
}
