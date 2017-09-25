using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider, difficultySlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;
	
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel("01a Start");
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;	
	}
}
