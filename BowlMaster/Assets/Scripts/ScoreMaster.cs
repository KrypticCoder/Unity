using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	// Returns a list of cumulative scores like a normal score card
	public static List<int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int>();

		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	// Returns a list of individual frame scores, NOT cumulative
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int>();

		for(int i = 1; i < rolls.Count; i+=2){

			if(frames.Count == 10) { break; }

			if(rolls[i-1] + rolls[i] < 10){
				frames.Add(rolls[i - 1] + rolls[i]);
			}

			if(rolls.Count - i <= 1) { break; }

			if(rolls[i-1] == 10){
				i--;
				frames.Add(10 + rolls[i+1] + rolls[i+2]);
			} else if(rolls[i-1] + rolls[i] == 10){
				frames.Add(10 + rolls[i+1]);
			}
		}

		return frames;
	}

//	// Returns a list of individual frame scores, NOT cumulative
//	public static List<int> ScoreFrames(List<int> rolls){
//		List<int> frameList = new List<int>();
//		int count = 0;
//
//		for(int i = 0; i < rolls.Count; i++){
//
//			// check if strike
//			if(rolls[i] == 10){
//	
//
//				if(i + 2 < rolls.Count && frameList.Count < 10){
//					frameList.Add(10 + rolls[i + 1] + rolls[i + 2]);
//				}
//				count += 1;
//			}
//
//			else if((i + 1) - count == 2 && frameList.Count < 10){
//				int score = rolls[i] + rolls[i - 1];
//
//				// check if spare
//				if(score == 10 && i + 1 < rolls.Count){
//					score += rolls[i + 1];
//					frameList.Add(score);
//
//				// add if not in last frame, otherwise spare in last frame
//				} else if(score != 10){
//					frameList.Add(score);
//				}
//				count += 2;
//			} 
//		}
//	
//		return frameList;
//	}

}
