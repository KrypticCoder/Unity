using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;


	private Animator animator;
	private PinCounter pinCounter;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pinCounter = FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RaisePins(){
		// Raise standing pins by distanceToRaise
		foreach(Pin pin in FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
		} 
	}

	public void LowerPins(){
		// Lower raised pins
		foreach(Pin pin in FindObjectsOfType<Pin>()){
			pin.Lower();
		} 
	}

	public void RenewPins(){
		// Renew pins
		Instantiate(pinSet, new Vector3(0, Pin.distanceToRaise, 1829), Quaternion.identity);
	}

	public void performAction(ActionMaster.Action action){
		switch(action){
			case ActionMaster.Action.Tidy:
				animator.SetTrigger("tidyTrigger");
				break;
			case ActionMaster.Action.EndTurn:
			case ActionMaster.Action.Reset:
				animator.SetTrigger("resetTrigger");
				pinCounter.Reset();
				break;
			case ActionMaster.Action.EndGame:
				throw new UnityException("Don't know how to handle EndGame");
		}
	}

}
