﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;

		if(thingLeft.GetComponentInParent<Pin>()){
			Destroy(thingLeft);
		}
	}
}