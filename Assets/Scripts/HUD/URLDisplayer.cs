using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class URLDisplayer : MonoBehaviour {

	public Text url;
	public Text tip;
	public Text fake;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setTexts(string url,string tip,bool fake, bool said){
		this.url.text = url;
		this.tip.text = tip;
		this.fake.text = fake?"FALSO":"LEGITIMO";
		this.fake.color = fake?Color.red:Color.green/2;
		//this.fake.text += (fake==said)?"(Errou)":"(Acertou)";
		if(fake==said){
			GetComponent<Image>().color = GetComponent<Image>().color - Color.cyan + Color.black;
			this.fake.color += Color.gray;
			this.tip.color = Color.white;
			this.url.color = Color.white;
		}

	}
}
