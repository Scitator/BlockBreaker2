using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public static int score = 0;

	public BoardManager boardScript;

	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		switch (name) {
			case "Level":
				Brick.breakableCount = 0;
				Application.LoadLevel (name);
				break;
			case "LoseScreen":
				Application.LoadLevel ("LoseScreen");
				break;
			case "StartMenu":
				score = 0;
				Application.LoadLevel ("StartMenu");
				break;
			}

	}

	public void Quit() {
		Application.Quit ();
	}

	public void BrickDestroyed() {
		score++;
		if (Brick.breakableCount <= 0) {
			LoadLevel("Level");
		}
	}
}
