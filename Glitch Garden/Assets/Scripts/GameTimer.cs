using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	
	private Slider slider;
	private AudioSource audioSource;
	private bool levelDone = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = FindObjectOfType<LevelManager>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create You Win object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad/levelSeconds;
		
		if(Time.timeSinceLevelLoad >= levelSeconds && !levelDone){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects();
		
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		levelDone = true;
	}
	
	void DestroyAllTaggedObjects(){
		
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("destroyOnWin")){
			Destroy (obj);
		}
	}
	
	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}
