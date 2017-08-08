 using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip sound;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
		}
		timesHits = 0;
		this.levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionExit2D(Collision2D collision){
		if(isBreakable){
			HandleHits ();
		} else {
			AudioSource.PlayClipAtPoint(sound, this.transform.position, 0.3f);
		}
	}
	
	void HandleHits(){
		timesHits++;
		int maxHits = hitSprites.Length + 1;
		if(timesHits >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			AudioSource.PlayClipAtPoint(sound, this.transform.position, 0.5f);
			PuffSmoke ();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHits - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
	
}
