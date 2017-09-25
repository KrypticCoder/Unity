using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] private float currentSpeed;
	private GameObject currentTarget;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
	}
	
	// Called from animator at time of attack
	void StrikeCurrentTarget(float damage){
		Debug.Log (name + " damaged " + damage);
	}
}
