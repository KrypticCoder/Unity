using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		Ball.hasStarted = false;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit");
		Application.Quit ();
	}
	
	public void BackToStart(string name){
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Ball.hasStarted = false;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		// if all breakable bricks are destroyed, 
		// load next level
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
