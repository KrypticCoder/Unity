using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray){
			if(IsTimeToSpawn(thisAttacker))
				Spawn (thisAttacker);
		}
	}
	
	bool IsTimeToSpawn(GameObject myGameObject){
		
		Attacker attacker = myGameObject.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if(Time.deltaTime > meanSpawnDelay){
			Debug.Log ("Spawn Rate capped by frame rate");
		} 
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		
		return Random.value < threshold;
		
		
	}
	
	void Spawn(GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject, transform.position, Quaternion.identity) as GameObject;
		myAttacker.transform.parent = transform;;
		
	}
}
