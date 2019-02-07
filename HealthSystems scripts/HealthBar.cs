using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private HealthSystem healthSystem;

	// Use this for initialization
	public void Setup (HealthSystem healthSystem) {
		this.healthSystem = healthSystem;

		healthSystem.OnHealthChanged += HealthSystem_OnHeathChanged;
	}

	private void HealthSystem_OnHeathChanged(object sender, System.EventArgs e) {
		transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
		transform.localPosition = new Vector3 (1, 0, 0);
		//Debug.Log (transform.localPosition);
		//Debug.Log (GameObject.Find ("BadGuy").transform.position + "1");


	}
	
	// Update is called once per frame
	private void Update () {
		
	}
}
