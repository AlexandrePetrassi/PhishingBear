using UnityEngine;
using System.Collections;
using TecnoCop.Collisions;
using TecnoCop.PlayerControl;

public class Fish : Collideable {

	public GameObject message;

	public override void collideOnEnter(CollisionDetector collider){
		if(collider.gameObject.tag != "Player" || collider.gameObject.transform.parent.tag != "Player") return;
		Player.isPaused = true;
		GameObject go = Instantiate(message);
		go.transform.SetParent(FindObjectOfType<Canvas>().transform);
		Destroy(gameObject);
	}
	
}
