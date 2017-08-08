using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		Lives.numLives--;
		print ("lives = " + Lives.numLives);
		if(Lives.numLives > 0){
			Ball.hasStarted = false;
		} else {
			Lives.numLives = 3;
			Ball.hasStarted = false;
			levelManager.LoadLevel("Lose Screen");
		}
	}
}
