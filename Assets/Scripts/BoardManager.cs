using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {

	public int rowsOffset = 5;
	public int columsOffset = 2;
	public int columns = 2;
	public int rows = 2;

	public GameObject[] brickTiles;
	private Transform boardHolder;

	void Start() {
		SetupScene ();
	}

	void SetupScene()
	{
		boardHolder = new GameObject ("Board").transform;
		for (int x = 0; x < columns; x++) {
			for (int y = 0; y < rows; y++) {
				GameObject toInstatiate = brickTiles[Random.Range(0, brickTiles.Length - 1)];
				GameObject instance = Instantiate(toInstatiate, 
				                                  new Vector3(x + columsOffset + 0.5f,y + rowsOffset,0f),
				                                  Quaternion.identity) as GameObject;
				
				instance.transform.SetParent(boardHolder);
				//print(x.ToString() + " " + y.ToString() + " " + instance);
			}
		}
	}
}
