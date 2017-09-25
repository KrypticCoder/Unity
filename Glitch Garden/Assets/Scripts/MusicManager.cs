using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
		audioSource = GetComponent<AudioSource>();
		Debug.Log ("Don't destroy on load: " + gameObject);
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnLevelWasLoaded(int level){
		Debug.Log ("Playing clip: " + levelMusicChangeArray[level]);
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		audioSource.clip = thisLevelMusic;
		audioSource.loop = true;
		audioSource.Play();
	}
	
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
