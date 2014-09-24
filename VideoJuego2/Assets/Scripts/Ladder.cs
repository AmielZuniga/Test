using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public bool isClimbing;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D target){
		isClimbing = true;
	}

	
	public void OnTriggerExit2D(Collider2D target){
		isClimbing = false;
			

	}
}
