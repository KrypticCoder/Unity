﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void MoveStart(float amount){
        if(ball.inPlay == false){
            ball.gameObject.transform.Translate(new Vector3(amount, 0, 0));
        }
    }

    public void DragStart(){
        // Capture time and position of drag start
		if(ball.inPlay == false){
        	dragStart = Input.mousePosition;
        	startTime = Time.time;
        }
    }

    public void DragEnd(){

		if(ball.inPlay == false){
	        // Capture time and position of drag end
	        dragEnd = Input.mousePosition;
	        endTime = Time.time;

	        float dragDuration = endTime - startTime;
	        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration / 5;
	        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

	        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

	        ball.Launch(launchVelocity);
	    }
    }
}