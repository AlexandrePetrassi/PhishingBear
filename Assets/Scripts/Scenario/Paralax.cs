using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paralax : MonoBehaviour {
	public Vector2 intesisty;

	private Renderer myRenderer;
	private Renderer rendererComponent{
		get{
			if(myRenderer == null) myRenderer = GetComponent<Renderer>();
			return myRenderer;
		}
	}

	// Update is called once per frame
	public void update () {
		//Vector3 cp = Camera.main.transform.position;
		rendererComponent.material.SetTextureOffset("_MainTex",new Vector2(transform.position.x *intesisty.x,0));
	}
}
