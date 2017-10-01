using UnityEngine;
using System.Collections;

public class StopGame : MonoBehaviour {


	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnMouseDown(){
		levelManager.LoadLevel("01a Start");
	}
	
	
}
