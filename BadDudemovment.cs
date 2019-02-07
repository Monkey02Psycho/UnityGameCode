using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDudemovment : MonoBehaviour {

	private bool movingRight = true;

	public float speed;

	public Transform groundDetection;

	private Rigidbody2D rb;

	public Transform pfHealthBar;
	private HealthSystem healthSystem = new HealthSystem (100);
	private Transform healthBarTransform;
	private HealthBar healthBar;

	// Use this for initialization
	void Start () {
		healthBarTransform = Instantiate (pfHealthBar, new Vector3 (0, 0), Quaternion.identity);

		healthBar = healthBarTransform.GetComponent<HealthBar> ();
		healthBar.Setup (healthSystem);
		healthSystem.Damage (50);

	}
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * speed * Time.deltaTime);
		healthBarTransform.position = transform.position + new Vector3(0, 1);

	}
	void FixedUpdate (){
		RaycastHit2D groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, 2);
		if (groundInfo.collider == false) {
			if (movingRight == true) {
				transform.eulerAngles = new Vector3 (0, -180, 0);
				movingRight = false;
			}else{
				transform.eulerAngles = new Vector3 (0, 0, 0);
				movingRight = true;
			}
		}
	}
}