using UnityEngine;
using System.Collections;

public class saveQuote : MonoBehaviour {
	public getQuote getQuote;
	// Use this for initialization
	public void SaveQuote () {

		int quoteNro = getQuote.random;
		Debug.Log ("quote: " + quoteNro.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	//	int quoteNro = getQuote.random;
	}
}
