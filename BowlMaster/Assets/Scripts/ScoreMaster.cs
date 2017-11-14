﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	// Returns a list of cumulative scores like a normal score card
	public static List<int> ScoreCumulative(List<int> roles){
		List<int> cumulativeScores = new List<int>();

		int runningTotal;

		foreach(int frameScore in ScoreFrames(roles)){
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	// Returns a list of individual frame scores, NOT cumulative
	public static List<int> ScoreFrames(List<int> roles){
		List<int> frameList = new List<int>();

		return frameList;
	}

}
