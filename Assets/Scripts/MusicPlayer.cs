﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake() {
		Debug.Log ("MusicPlayer Awake " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music palyer self-destruction!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("MusicPlayer Start " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
