using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {


    public float standingThreshold = 7f;

	// Use this for initialization
	void Start () {
		print(name + ": " + transform.rotation.eulerAngles);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public bool IsStanding(){
    	
       	Vector3 rotationInEuler = transform.rotation.eulerAngles;
       	float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
       	float tiltInZ = Mathf.Abs(rotationInEuler.z);

       	if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
       		return true;
       	else
       		return false;

    }
}
