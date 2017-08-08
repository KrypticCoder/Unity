using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoplay = false;
	public float minX;
	public float maxX;
	
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoplay){
			MoveWithMouse ();
		} else {
			AutoPlay();
		}
		
	}
	
	void MoveWithMouse(){
		Vector3 mousePosInBlocks = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks.x, minX, maxX), this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		Vector3 ballPos = ball.transform.position;
		Vector3 paddlePos = new Vector3(Mathf.Clamp (ballPos.x, minX, maxX), this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
