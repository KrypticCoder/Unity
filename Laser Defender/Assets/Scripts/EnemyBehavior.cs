using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 150;
	public GameObject projectile;
	public float projectileSpeed = 5;
	public float firingRate = 0.2f;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}
		
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
				Die();
			}
		}
	}
	
	void Die(){
		scoreKeeper.Score (scoreValue);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
	}
	
	void Fire(){
		GameObject missile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
}
