using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
    public bool inPlay = false;


	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;
    
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();

		rigidBody = GetComponent<Rigidbody>();
		rigidBody.useGravity = false;

		startPosition = transform.position;
	}

	public void Launch(Vector3 velocity){

        inPlay = true;

		audioSource.Play();

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		transform.position = startPosition;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
		inPlay = false;
	}
}
