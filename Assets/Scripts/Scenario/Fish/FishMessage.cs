using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;
using UnityEngine.UI;
using TecnoCop;

public class FishMessage : MonoBehaviour {
	
	public float health = 1;
	public string[] urls;
	public string[] tips;
	public bool[]   fake;
	private int index;
	public GameObject trap;
	public int points = 10;
	public GameObject badThrowMessage;
	public GameObject goodEatMessage;
	public GameObject goodThrowMessage;

	// Use this for initialization
	void Start () {
		setPosition();
		index = Random.Range(0,urls.Length);
		GetComponentInChildren<Text>().text = urls[index] + "\n\nW(Jogar Fora) E(Comer)";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.W))
			throwAway();
		else if(Input.GetKeyUp(KeyCode.E))
		   eatFish();
	}

	public void throwAway(){
		addToResults(false);
		Player.isPaused = false;
		if(fake[index]){
			Player.player.score += points;
			((GameObject)Instantiate(goodThrowMessage,transform.position,Quaternion.identity)).transform.SetParent(transform.parent);
		}
		else
			((GameObject)Instantiate(badThrowMessage,transform.position,Quaternion.identity)).transform.SetParent(transform.parent);
		Destroy(gameObject);
	}

	public void eatFish(){

		addToResults(true);
		Player.isPaused = false;
		if(!fake[index])
			goodFish();
		else
			callTrap();
		Destroy(gameObject);
	}

	public void goodFish(){
		Player.player.score += points;
		Player.player.damager.SendMessage("heal",health);
		((GameObject)Instantiate(goodEatMessage,transform.position,Quaternion.identity)).transform.SetParent(transform.parent);

	}

	public void callTrap(){
		Player.player.damager.damage = new Damage(health*2);
		Instantiate(trap,Player.player.transform.position - new Vector3(0,1,0),Quaternion.identity);
	}

	public void setPosition(){
		Vector2 playerPosition = Camera.main.WorldToScreenPoint(Player.player.transform.position);
		((RectTransform)transform).position = playerPosition + new Vector2((playerPosition.x > Screen.width/2)?-100:100,(playerPosition.y > Screen.height/2)?-100:100);
	}

	void addToResults(bool said){
		ResultDisplayer rd = FindObjectOfType<ResultDisplayer>();
		rd.urls.Add(urls[index]);
		rd.tip.Add(tips[index]);
		rd.fake.Add(fake[index]);
		rd.said.Add(said);
		if(rd.urls.Count >= 10) {
			Player.isPaused = true;
			FindObjectOfType<LifeDisplayer>().callResults();
		}
	}
}
