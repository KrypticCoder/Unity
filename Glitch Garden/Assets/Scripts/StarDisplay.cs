using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	
	private Text starText;
	private int stars = 100;
	
	public enum Status {
		SUCCESS, FAILURE
	};
	
	public void Start(){
		starText = GetComponent<Text>();
		UpdateDisplay ();
	}
		
	public void AddStars(int amount){
		stars += amount;
		UpdateDisplay ();
	}
	
	public Status UseStars(int amount){
		if(stars >= amount){
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		} 
		
		return Status.FAILURE;
		

	}
	
	public void UpdateDisplay(){
		starText.text = stars.ToString();
	}
}
