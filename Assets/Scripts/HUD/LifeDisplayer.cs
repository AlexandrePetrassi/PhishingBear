using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;
using UnityEngine.UI;

public class LifeDisplayer : MonoBehaviour {

	public Image[] images;
	public Text score;
	public GameObject resultScreen;
	void Start(){
		for(int i = 0; i < Player.lives; ++i){
			images[i].enabled = true;
		}
	}

	public void callResults(){
		Player.isPaused = true;
		resultScreen.GetComponent<ResultDisplayer>().display();
	}
}
