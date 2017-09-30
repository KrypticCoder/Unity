using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun; 
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner mySpawner;
	
	// Use this for initialization
	void Start () {
	
		animator = GameObject.FindObjectOfType<Animator>();
		
		projectileParent = GameObject.Find ("Projectiles");
		
		if(!projectileParent)
			projectileParent = new GameObject("Projectiles");
			
		SetMyLaneSpawner ();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		} else {
			animator.SetBool("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner(){
		foreach(Spawner spawner in GameObject.FindObjectsOfType<Spawner>()){
			if(spawner.transform.position.y == transform.position.y){
				mySpawner = spawner;
				return;
			}
		}
		
		Debug.LogError(name + " can't find spawner in lane");
	}
	
	bool IsAttackerAheadInLane(){
		
		// Exit if no attackers in lane
		if(mySpawner.transform.childCount <= 0){
			return false;
		}
		
		// If there are attackers, are they ahead?
		foreach(Transform attacker in mySpawner.transform){
			if(attacker.transform.position.x > transform.position.x){
				return true;
			}
		}
		
		// Attacker in lane, but behind us
		return false;
		


	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
