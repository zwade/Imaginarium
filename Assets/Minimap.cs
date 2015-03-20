using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Minimap : MonoBehaviour {


	public GameObject player;
	public GameObject playerBlip;

	public GameObject[] orbs;
	public GameObject orbBlip;
	public GameObject receptorBlip;

	public Color colors;

	private RectTransform PBI;
	private UpdateUI playerLoc;

	private RectTransform[] orbInst;
	private OrbControl[] orbLocs;
	private Receptor[] receptors;
	// Use this for initialization
	void Start () {
		GameObject playerBlipInst = Instantiate(playerBlip);
		playerBlipInst.transform.parent = this.transform;
		playerBlipInst.transform.localPosition = new Vector3(0,0,0);
		PBI = playerBlipInst.GetComponent<RectTransform>();
		PBI.anchoredPosition = new Vector3(0,0,0);
		PBI.localScale = new Vector3(1,1,1);

		playerLoc = player.GetComponent<UpdateUI>();

		orbInst = new RectTransform[orbs.Length];
		orbLocs = new OrbControl[orbs.Length];
		receptors = new Receptor[orbs.Length];

		for (int i = 0; i < orbs.Length; i++) {
			GameObject lInst = Instantiate(orbBlip);
			lInst.transform.parent = this.transform;
			lInst.transform.localPosition = new Vector3(0,0,0);

			GameObject rInst = Instantiate (receptorBlip);
			rInst.transform.parent = this.transform;
			rInst.transform.localPosition = new Vector3(0,0,0);


			orbInst[i] = lInst.GetComponent<RectTransform>();
			orbInst[i].anchoredPosition = new Vector3(0,0,0);
			orbInst[i].localScale = new Vector3(1,1,1);
			orbLocs[i] = orbs[i].GetComponent<OrbControl>();

			receptors[i] = orbLocs[i].receptor.GetComponent<Receptor>();

			RectTransform rT = rInst.GetComponent<RectTransform>();
			rT.localScale = new Vector3(1,1,1);
			rT.anchoredPosition = 150/70*receptors[i].location.toVector2;

			lInst.GetComponent<Image>().color = orbLocs[i].color;

			rInst.GetComponent<Image>().color = orbLocs[i].color;
		}
	}
	
	// Update is called once per frame
	void Update () {
		PBI.anchoredPosition = 150/70*playerLoc.getLocation().toVector2;
		for (int i = 0; i < orbs.Length; i++) {
			orbInst[i].anchoredPosition = 150/70*orbLocs[i].getLocation().toVector2;
		}
	}
}
