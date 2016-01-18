using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class graphicTemplate : MonoBehaviour {
	public Sprite templaatti;

	public void VaihdaTemplaatti(){
		Image kuva = GameObject.Find ("Templateimage").GetComponent<Image>();
		kuva.sprite = templaatti;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
