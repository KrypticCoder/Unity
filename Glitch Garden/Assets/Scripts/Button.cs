using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private static Button[] buttons;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttons = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		
		if(!costText) Debug.LogWarning (name + " has no cost text");
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown(){
			
		foreach(Button thisButton in buttons){
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
			
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		
		Debug.Log ("selected defender: " + selectedDefender);
	}
	
	
}
