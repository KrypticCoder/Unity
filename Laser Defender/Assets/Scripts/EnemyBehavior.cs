using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	
	public GameObject projectile;
	public float projectileSpeed = 5;
	public float firingRate = 0.2f;
	
	public float shotsPerSeconds = 0.5f;
		
	void Update(){
		float probability = shotsPerSeconds * Time.deltaTime;
		
		if(Random.value < probability){
			Fire();
		}
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		Projectile missile = trigger.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit ();
			if(health <= 0){
				Destroy (gameObject);
			}
		}
	}
	
	void Fire(){
		Vector3 startPosition = transform.position + new Vector3(0,-1,0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
	}
}
