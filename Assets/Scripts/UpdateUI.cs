using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {
	public GameObject textObject;
	private Text textField;
	private MovePlayer mp;
	private Rotate rt;

	private Complex location; 
	// Use this for initialization
	void Start () {
		textField = textObject.GetComponent<Text>();
		mp = GetComponent<MovePlayer>();
		rt = transform.parent.gameObject.GetComponent<Rotate>();
	}

	public Complex getLocation() {
		return location;
	}
	
	// Update is called once per frame 
	void Update () {
		location = Complex.FromPolar(mp.distance/10,-Mathf.PI*rt.angle/180f);
		textField.text = location.ToString();
	}
}
