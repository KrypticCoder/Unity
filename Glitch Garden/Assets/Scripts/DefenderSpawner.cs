using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	// Use this for initialization
	void Start () {
	
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		defenderParent = GameObject.Find("Defenders");
		
		if(!defenderParent)
			defenderParent = new GameObject("Defenders");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
	
		if(Button.selectedDefender){
			int defenderCost = Button.selectedDefender.GetComponent<Defender>().starCost;
			if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
				Vector2 onPosition = SnapToGrid (Camera.main.ScreenToWorldPoint (Input.mousePosition));
				SpawnDefender (onPosition);
			} else {
				Debug.Log ("Insufficient stars");
			}
		} else {
				Debug.Log ("No Defender selected");
		}
	}

	void SpawnDefender(Vector2 mouseClick)
	{
		GameObject defender = Instantiate (Button.selectedDefender, mouseClick, Quaternion.identity) as GameObject;
		defender.transform.parent = defenderParent.transform;
	}	
	
	Vector2 SnapToGrid(Vector2 pos){
		return new Vector2(Mathf.Round(pos.x), Mathf.Round (pos.y));
	}
	
}
