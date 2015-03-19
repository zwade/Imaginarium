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

		if (position != destination) {
			float angDist = destination.Phase - position.Phase;
			float radDist = destination.Mag - position.Mag;
			float scale = 0;
			if (Mathf.Abs (angDist) <= 0.02) {
				scale = 1f*Mathf.Sign(radDist);
			} else if (Mathf.Abs (radDist) <= 0.02) {
				scale = .33f*Mathf.Sign (angDist);
			} else {
				scale = radDist/angDist;
			}
			position = (position | (speed * scale * Time.deltaTime)) & (speed * Time.deltaTime);
			Debug.Log (scale);
			Debug.Log (4*Mathf.Sqrt (Mathf.Pow ((scale),2)+1)*Mathf.Abs (scale)*Time.deltaTime);
			Debug.Log ("------------");
			if ((position-destination).Mag < 2*Mathf.Sqrt (Mathf.Pow ((scale),2)+1)*Mathf.Abs(scale)*Time.deltaTime) {
				position = destination;
			}

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
	}
}
