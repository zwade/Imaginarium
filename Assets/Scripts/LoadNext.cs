﻿using UnityEngine;
using System.Collections;

public class LoadNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel+1);
	}
}
