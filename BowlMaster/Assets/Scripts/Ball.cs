using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = launchVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
