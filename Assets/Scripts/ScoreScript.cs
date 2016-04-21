using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	private Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = gameObject.GetComponent<Text> ();
		scoreText.text = "Score: " + LevelManager.score;
	}
}
