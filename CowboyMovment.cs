using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyMovment : MonoBehaviour {
	
	//public float jumpPower = 5.0f;
	public float speed = 5.0f;
	public float jumpForce = 5.0f;
	private float moveInput = 5.0f;

	private Rigidbody2D rb;

	private bool facingRight = false;


	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJumps;
	public int extraJumpsValue;


	//Use this for initialization
	void Start () {
		extraJumps = extraJumpsValue;
		rb = GetComponent<Rigidbody2D> ();

	}
	
	private Vector3 outOfCamera = new Vector3(0, -4, 0);
	// Update is called once per frame
	void Update () { 
		
		if (isGrounded == true) {
			extraJumps = extraJumpsValue - 1; //subtracts one because code is weird
		}

		if (Input.GetKeyDown (KeyCode.W) && extraJumps > 0) {
			rb.velocity = Vector2.up * jumpForce;
			extraJumps--;
		} else if (Input.GetKeyDown (KeyCode.W) && extraJumps == 0  && isGrounded == true) {
			rb.velocity = Vector2.up * jumpForce;
		}

		keepUpRight ();

		if(transform.position.y <= outOfCamera.y){
			transform.position = new Vector2 (transform.position.x, 5.0f);
		}
	}

	void FixedUpdate(){

		isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

		moveInput = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

		if (facingRight == false && moveInput > 0) {
			flip ();
		}else if(facingRight == true && moveInput <0){
			flip ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log(collision.collider.name);
		if (collision.collider.name == "BadGuy") {
			Debug.Log ("you hit a bad guy");
		}
	}

	void flip(){
		/*
		 * Keeps the player facing the direction its moving
		 */
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	}

	void keepUpRight(){
		/**
		 * keeps the player with zero rotation
		 */
		Quaternion Rotation = transform.rotation;

		Quaternion noRotation = new Quaternion(0, 0, 0, 1);
		//Vector3 Rotation_ = new Vector3 (0, 0, 0);
		if (Rotation != noRotation) {

			Rotation = noRotation;
			transform.SetPositionAndRotation (transform.localPosition, Rotation);
		}
	}
}
