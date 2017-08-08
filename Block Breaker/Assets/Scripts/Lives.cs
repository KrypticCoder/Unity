using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public Sprite[] LivesSprites;
	
	public static int numLives = 3;
	
	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().sprite = LivesSprites[numLives - 1];
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<SpriteRenderer>().sprite = LivesSprites[numLives - 1];
	}
}
