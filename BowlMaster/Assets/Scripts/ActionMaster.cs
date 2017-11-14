using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {
	public enum Action {Tidy, Reset, EndTurn, EndGame, Undefined};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction (List<int> pinFalls){
		Action currentAction = new Action();
		ActionMaster actionMaster = new ActionMaster();

		foreach(int pinFall in pinFalls){
			currentAction = actionMaster.Bowl(pinFall);
		}

		return currentAction;
	}
	
//	public static Action NextAction (List<int> rolls) {
//		Action nextAction = Action.Undefined;
//
//		for (int i = 0; i < rolls.Count; i++) { // Step through rolls
//			
//			if (i == 20) {
//				nextAction = Action.EndGame;
//			} else if ( i >= 18 && rolls[i] == 10 ){ // Handle last-frame special cases
//				nextAction = Action.Reset;
//			} else if ( i == 19 ) {
//				if (rolls[18]==10 && rolls[19]==0) {
//					nextAction = Action.Tidy;
//				} else if (rolls[18] + rolls[19] == 10) {
//					nextAction = Action.Reset;
//				} else if (rolls [18] + rolls[19] >= 10) {  // Roll 21 awarded
//					nextAction = Action.Tidy;
//				} else {
//					nextAction = Action.EndGame;
//				}
//			} else if (i % 2 == 0) { // First bowl of frame
//				if (rolls[i] == 10) {
//					rolls.Insert (i, 0); // Insert virtual 0 after strike
//					nextAction = Action.EndTurn;
//				} else {
//					nextAction = Action.Tidy;
//				}
//			} else { // Second bowl of frame
//				nextAction = Action.EndTurn;
//			}
//		}
//
//		return nextAction;
//	}

	public Action Bowl(int pins){

		if(pins < 0 || pins > 10){ throw new UnityException("Invalid pins"); }

		bowls[bowl - 1] = pins; 

		if(bowl == 21){
			return Action.EndGame;
		}

		// Handles last-frame special cases
		if(bowl >= 19 && pins == 10){
			bowl++;
			return Action.Reset;
		} else if(bowl == 20){
			bowl++;
			if(Bowl21Awarded()){
				return Action.Tidy;
			} else if(Bowl19or20is10or20()){
				if(pins == 0){
					return Action.Tidy;
				} else {
					return Action.Reset;
				}
			} else {
				return Action.EndGame;
			}
		}

		// first bowl of frame
		if(bowl % 2 != 0){	
			if(pins == 10){
				bowl += 2;
				return Action.EndTurn;
			} else {
				bowl++;
				return Action.Tidy;
			}

		// end of frame
		} else { 
			bowl++;
			return Action.EndTurn;
		}	

	} 

	public bool Bowl21Awarded(){
		return (bowls[18] + bowls[19] > 10);
	}

	public bool Bowl19or20is10or20(){
		return (bowls[18] + bowls[19]) % 10 == 0;
	}
}