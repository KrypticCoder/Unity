using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public float padding = 1f;
	public float xmin, xmax;
	
	public GameObject projectile;
	public float projectileSpeed = 5;
	public float firingRate = 0.2f;
	
	public float health = 250f;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
		
	}
	
	void Fire(){
			
		Vector3 startPosition = transform.position + new Vector3(0,1,0);
		GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
		missile.rigidbody2D.velocity = new Vector2(0, projectileSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.RightArrow)){
			gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
		}
			
		// restrict player to game space
		float newX = Mathf.Clamp (gameObject.transform.position.x, xmin, xmax);
		gameObject.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		Debug.Log ("Player Hit");
		Projectile missile = trigger.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit ();
			if(health <= 0){
				Destroy (gameObject);
			}
		}
	}
}
