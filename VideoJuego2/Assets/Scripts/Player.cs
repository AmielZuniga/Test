using UnityEngine;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	private int jumpHeight = 250;
	public bool isJumping = false;

	private PlayerController controller;
	private Ladder ladder;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent <PlayerController> ();
		animator = GetComponent<Animator> ();
		ladder = GetComponent<Ladder> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//Se mueve en x
		if(controller.moving.x != 0 && controller.moving.y == 0 ){
			transform.localScale = new Vector3 (controller.moving.x > 0 ? 3: -3, 3, 3);
			Vector2 currPos = transform.position;
			currPos = currPos + new Vector2 (3, 0) * controller.moving.x * Time.deltaTime;
			transform.position = currPos;
			
			//para animación
			animator.SetInteger("animState", 1);
		}
		else{
			animator.SetInteger("animState", 0);
		}


		//brinca
		if(controller.jump == 2){
			if(isJumping == false){
				Jump();
				isJumping = true;
			}
		}

		if (ladder.isClimbing){
			rigidbody2D.gravityScale = 0;

			//Se mueve en y en escaleraas (o puertas)
			if (controller.moving.y != 0 && controller.moving.x == 0 ) {
				transform.Translate (new Vector2 (0, 3 )*  controller.moving.y * Time.deltaTime);
				animator.SetInteger("animState", 2);
				
			}

			else{
				animator.SetInteger("animState", 3);
			}


		}
		else{
			rigidbody2D.gravityScale = 1;

		}

	}

	void Jump(){
		rigidbody2D.AddForce (new Vector3 (0, jumpHeight, 0), ForceMode2D.Force);
			
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Floor"){
			isJumping = false;

		}
	}



}
