using UnityEngine;
using System.Collections;

public class GUIContinue : MonoBehaviour {

	public GameObject player;
	public GameObject playerEntity;
	public bool isLevel1 = false;
	// Use this for initialization
	void Start () {
		player.GetComponent<Rotate>().enabled = false;
		playerEntity.GetComponent<MovePlayer>().enabled = false;
		//player.GetComponent<Rotate>().setEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OK() {
		if (!isLevel1) {
			player.GetComponent<Rotate>().enabled = true;
		}
		playerEntity.GetComponent<MovePlayer>().enabled = true;
		this.transform.gameObject.SetActive(false);
	}
}
