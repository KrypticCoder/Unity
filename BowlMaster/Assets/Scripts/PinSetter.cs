using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public float distanceToRaise = 40f;

	private float lastChangeTime;
	private bool ballEnteredBox = false;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();

		if(ballEnteredBox){
			CheckStanding();
		}
	}

	public void RaisePins(){
		// Raise standing pins by distanceToRaise
		Debug.Log("raising pins");

		foreach(Pin pin in FindObjectsOfType<Pin>()){
			if(pin.IsStanding()){
				pin.GetComponent<Rigidbody>().useGravity = false;
				pin.gameObject.transform.Translate(new Vector3(0, distanceToRaise, 0));
			}
		} 
	}

	public void LowerPins(){
		// Lower raised pins
		Debug.Log("lowering pins");
	}

	public void RenewPins(){
		// Renew pins
		Debug.Log("renewing pins");
	}

	void CheckStanding(){
		// update the lastStandingCount


		int currentStanding = CountStanding();

		if(currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;	// how long to wait to consider pins have settled


		if(Time.time - lastChangeTime > settleTime){
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		ball.Reset();
		lastStandingCount = -1;		// pins have settled and ball not back in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding(){
		int standing = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if(pin.IsStanding()){
				standing++;
			}
		}
		return standing;
	}

	void OnTriggerEnter(Collider collider){
		GameObject thingHit = collider.gameObject;
		if(thingHit.GetComponent<Ball>()){
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider collider){
		GameObject thingLeft = collider.gameObject;

		if(thingLeft.GetComponentInParent<Pin>()){
			Destroy(thingLeft);
		}
	}


}
