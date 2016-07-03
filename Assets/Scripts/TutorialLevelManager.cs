﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialLevelManager : LevelManager {

	bool b;

	public Canvas tutorialOne;
	public Canvas tutorialTwo;
	public Canvas tutorialThree;
	public Canvas tutorialFour;

	void Start(){
		tutorialOne.enabled = true;
		tutorialTwo.enabled = true;
		b = true;
		backgroundMusic = Camera.main.GetComponent<AudioSource> ();//background music audio source is attached to the main camera
		if (PlayerPrefs.GetInt ("isMusicOn") == 0) {//0 = true = music is on, 1 = false = music is off
			backgroundMusic.mute = false;
		} else {
			backgroundMusic.mute = true;
		}
		isAudioOn = PlayerPrefs.GetInt ("isAudioOn") == 0;//0 = true = audio is on, 1 = false = audio is off
		selectedNodes = new HashSet<Node> ();
		SetSum (10);
		audioSource = GetComponent<AudioSource> ();
		isJuicing = true;
		Instantiate (bricks [3], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [3], spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [1], spawnPoints [4].position, Quaternion.Euler (0, 180, 0));
	}

	void Update(){
		if (score == 3 && b) {
			b = false;
			tutorialOne.enabled = false;
			tutorialThree.enabled = true;
			StartCoroutine ("tutorialTwoSpawn");
		}
		else if(score == 6 && !b){
			b = true;
			tutorialTwo.enabled = false;
			tutorialThree.enabled = false;
			tutorialFour.enabled = true;
			StartCoroutine ("tutorialThreeSpawn");
		}
		else if(score == 11 && b){
			b = false;
			tutorialFour.enabled = false;
		}
		GetInput<Node> ();
	}

	public void JuanFreeCoin(){
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt("Coins") + 1);
	}

	IEnumerator tutorialTwoSpawn(){
		Instantiate (bricks [2], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [2], spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [2], spawnPoints [4].position, Quaternion.Euler (0, 180, 0));
		yield return new WaitForSeconds (1f);
		Instantiate (bricks [4], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bomb, spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [4], spawnPoints [4].position, Quaternion.Euler (0, 180, 0));
		yield return new WaitForSeconds (1f);
		Instantiate (bricks [2], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [2], spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [2], spawnPoints [4].position, Quaternion.Euler (0, 180, 0));
	}

	IEnumerator tutorialThreeSpawn(){
		Instantiate (bricks [2], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (coin, spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [1], spawnPoints [4].position, Quaternion.Euler (0, 180, 0));
		yield return new WaitForSeconds (1f);
		Instantiate (bricks [2], spawnPoints [2].position, Quaternion.Euler (0, 180, 0));
		Instantiate (bricks [1], spawnPoints [3].position, Quaternion.Euler (0, 180, 0));
	}
}
