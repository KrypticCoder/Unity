using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name){
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
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
}
