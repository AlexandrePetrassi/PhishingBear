using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroController : MonoBehaviour {

	public string nextScene;
	public GameObject loading;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0)){
			if(loading != null) loading.SetActive(true);
			Application.LoadLevel(nextScene);
		}
	}
}
