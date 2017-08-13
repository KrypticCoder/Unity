using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 20f;
	public float height = 10f;
	public float speed = 5;
	public float spawnDelay = 0.5f;
	
	private float xmin, xmax;
	private bool movingLeft = true;

	
	
	// Use this for initialization
	void Start () {
	
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xmin = leftMost.x;
		xmax = rightMost.x;
		
		SpawnUntilFull();
		
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {
		if(movingLeft){
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		float rightEdgeOfFormation = transform.position.x + 0.5f*width;
		float leftEdgeOfFormation = transform.position.x - 0.5f*width;
		
		if(leftEdgeOfFormation < xmin){
			movingLeft = false;
		} else if (rightEdgeOfFormation > xmax){
			movingLeft = true;
		}
		
		if(AllMembersDead()){
			SpawnUntilFull();
		}
		
	}
	
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		} else {
			return;
		}
		
		if(NextFreePosition()){
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	
	Transform NextFreePosition(){
		foreach(Transform child in transform){
			if(child.childCount == 0){
				return child;
			}
		}
		return null;
	}
	
	bool AllMembersDead(){
		foreach(Transform child in transform){
			if(child.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
