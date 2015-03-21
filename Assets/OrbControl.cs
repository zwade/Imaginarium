using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrbControl : MonoBehaviour {

	public GameObject UI;
	public GameObject Player;
	public GameObject textData;

	public float threshold = 2;
	public float speed = 3.14f;

	public float real;
	public float complex;

	public GameObject receptor;
	public GameObject camera;
	public GameObject holder;
	public GameObject particleSystem;


	public Color color;

	private ParticleSystem particles;
	private Receptor recepScript;
	private Text textScript;

	private Complex position;

	private Complex destination;

	private UpdateUI locManager;
	// Use this for initialization
	void Start () {
		position = new Complex(real,complex);
		destination = position;
		locManager = Player.GetComponent<UpdateUI>();
		UI.SetActive(false);
		textScript = textData.GetComponent<Text>();
		recepScript = receptor.GetComponent<Receptor>();
		particles = particleSystem.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Mathf.Abs(destination.Phase-position.Phase) < 0.1) {
			position.Phase = destination.Phase;
		} else {
			position = position & (speed * Time.deltaTime);
		}

		if (Mathf.Abs(destination.Mag-position.Mag) < 0.05) {
			position.Mag = destination.Mag;
		} else {
			position = position | (speed * .33f * Time.deltaTime * Mathf.Sign (destination.Mag - position.Mag));
		}
		/*
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
*/
		transform.position = position.toVector3 + transform.position.y*Vector3.up;
		transform.eulerAngles = new Vector3(0,position.Phase*-180/Mathf.PI,0);
		if ((position-locManager.getLocation()).Mag < threshold) {
			UI.SetActive(true);
		} else {
			UI.SetActive(false);
		}
		holder.transform.rotation = camera.transform.rotation;

		textScript.text = destination.ToString();

		if (Mathf.Abs ((destination-recepScript.location).Mag) < 0.1) {
			particles.enableEmission = true;
		} else {
			particles.enableEmission = false;
		}


	}
	public Complex getLocation() {
		return position;
	}
	public void timesNegativeOne() {
		destination = destination * (Complex.c1() * -1f);
	}

	public void timesImaginaryUnit() {
		destination = destination * Complex.cI();
	}

	public void addOne() {
		destination.Mag += 1;
	}

	public void subtractOne() {
		destination.Mag -= 1;
	}

	public void square() {
		destination = destination ^ 2f ;
	}
	public void squareRoot() {
		destination = destination ^ 1/2f;
	}

}
