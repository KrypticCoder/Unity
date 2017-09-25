using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {


	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if(musicManager){
			musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
			Debug.Log ("music manager loaded " + musicManager);
		} else {
			Debug.LogWarning ("No music manager found in start scene, can't set volume");
		}
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
