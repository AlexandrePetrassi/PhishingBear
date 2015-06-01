using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DirtTile : MonoBehaviour {
	public List<Texture> textures;

	void Awake(){
		GetComponent<Renderer>().material.mainTexture = textures[(int)transform.position.x % textures.Count];
	}

}
