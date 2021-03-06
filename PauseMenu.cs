﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	void Start (){
		//pauseMenuUI.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}
	public void Resume(){
		GameIsPaused = false;
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1.0f;
	}

	void Pause(){
		GameIsPaused = true;
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0.0f;
	}

	public void LoadMenu(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("Menu");
	}

	public void QuitGame(){
		Application.Quit ();
		Debug.Log ("Quiting");
	}
}
