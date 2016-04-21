using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public AudioClip crack;
	public static int breakableCount = 0;
	private int timesHit;
	public Sprite[] hitSprites;
	private bool isBreakable;
	private LevelManager levelManager;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;

		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
			//print(breakableCount);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;

		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			//print(breakableCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke() {
		GameObject smokePuff = Instantiate(smoke, 
		                                   gameObject.transform.position, 
		                                   Quaternion.AngleAxis(180,Vector3.up)) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

		Destroy (smokePuff, 2f);
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
}
