using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private Ball ball;
	public float minX, maxX;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
		print (ball);
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
	}

	void MoveWithMouse() {
		float mousePositionInBlocks = Input.mousePosition.x / Screen.width * 16;
		Vector3 paddlePosition = new Vector3 (
			Mathf.Clamp (mousePositionInBlocks, minX, maxX), 
			this.transform.position.y, 
			0f);
		this.transform.position = paddlePosition;
	}

	void AutoPlay() {
		Vector3 paddlePosition = new Vector3 (
			Mathf.Clamp (ball.transform.position.x, minX, maxX), 
			this.transform.position.y, 
			0f);
		this.transform.position = paddlePosition;
	}
}
