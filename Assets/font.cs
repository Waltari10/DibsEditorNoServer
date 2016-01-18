using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class font : MonoBehaviour {
	Text nimi;
	Text quote;
	public Font fontti;
	// Use this for initialization
	public void Vaihda () {
		nimi = GameObject.Find ("nimi").GetComponent<Text>();
		quote = GameObject.Find ("quote").GetComponent<Text>();
		nimi.font = fontti;
		quote.font = fontti;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
