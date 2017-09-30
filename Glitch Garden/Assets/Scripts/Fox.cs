using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject obj = collider.gameObject;
		
		// return if not colliding with Defender 
		if(!obj.GetComponent<Defender>()){
			return;
		}
		
		// call jump animation if colliding with wall
		if(obj.GetComponent<Stone>()){
			animator.SetTrigger ("jump trigger");
			
		// else call attack animation
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
