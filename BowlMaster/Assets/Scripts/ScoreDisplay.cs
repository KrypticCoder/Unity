using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRolls(List<int>rolls){
		string scoresString = FormatRolls(rolls);

		for(int i = 0; i < scoresString.Length; i++){
			rollTexts[i].text = scoresString[i].ToString();
		}
	}

	public void FillFrames(List<int>rolls){
		for(int i = 0; i < rolls.Count; i++){
			frameTexts[i].text = rolls[i].ToString();
		}
	}

	public static string FormatRolls(List<int>rolls){
		string result = "";
		for(int i = 0; i < rolls.Count; i++){

			int box = result.Length + 1;

			if( (box % 2 == 0 || box == 21)  && rolls[i] + rolls[i-1] == 10){
				result += "/";
			} else if(box >= 19 && rolls[i] == 10){
				result += "X";
			} else if(rolls[i] == 10){
				result += "X ";
			} else if(rolls[i] == 0){
				result += "-";
			} else { 
				result += rolls[i].ToString();
			}

		}



		return result;
	}
}
