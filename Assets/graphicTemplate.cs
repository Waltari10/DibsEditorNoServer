using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class graphicTemplate : MonoBehaviour {
	public Sprite templaatti;
	public float r = 1;
	public float g = 1;
	public float b = 1;

	public void VaihdaTemplaatti(){
		Image kuva = GameObject.Find ("Templateimage").GetComponent<Image>();
		Text teksti = GameObject.Find ("quote").GetComponent<Text>();
		Text nimi = GameObject.Find ("nimi").GetComponent<Text>();
		kuva.sprite = templaatti;
		Color vari = new Color(r /255, g /255, b /255);
		teksti.color = vari;
		nimi.color = vari;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
