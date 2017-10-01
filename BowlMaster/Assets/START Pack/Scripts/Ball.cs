using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float launchSpeed;

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.velocity = new Vector3(0, 0, launchSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
