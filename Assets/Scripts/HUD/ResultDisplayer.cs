using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TecnoCop.PlayerControl;

public class ResultDisplayer : MonoBehaviour {

	public List<string> urls = new List<string>();
	public List<string> tip = new List<string>();
	public List<bool> fake = new List<bool>();
	public List<bool> said = new List<bool>();
	public GameObject[] elements;
	public int pointsToWin = 60;
	public GameObject SUCCESS,FAILURE;
	public GameObject panel;
	public string nextLevelName;

	bool active = false;
	// Use this for initialization
	public void display () {
		Player.isPaused = true;
		active = true;
		panel.SetActive(true);
		for(int i = 0; i<urls.Count;++i){
			elements[i].SetActive(true);
			elements[i].GetComponent<URLDisplayer>().setTexts(urls[i],tip[i],fake[i],said[i]);
		}
		if(Player.player.score >= pointsToWin){
			SUCCESS.SetActive(true);
			FAILURE.SetActive(false);
		}
			
		else{
			FAILURE.SetActive(true);
			SUCCESS.SetActive(false);
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.E) && active){
			if(Player.player.score >= pointsToWin)
				Application.LoadLevel(nextLevelName);
			else{
				--Player.lives;
				if(Player.lives <= 0) Application.LoadLevel("GameOver");
				else Application.LoadLevel(Application.loadedLevel);
			}
			Player.player.score = 0;
			Player.player.damager.Health = Player.player.damager.MaxHealth;
		}else if(Input.GetKeyUp(KeyCode.W) && active){
			Application.LoadLevel("MainMenu");
			Player.player.score = 0;
			Player.player.damager.Health = Player.player.damager.MaxHealth;
		}
	}
}
