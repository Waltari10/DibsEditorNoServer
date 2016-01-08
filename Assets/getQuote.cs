using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class getQuote : MonoBehaviour {
	public InputField inputfield;
	int random;
	public TextAsset tekstitiedosto;
	
	public void lue() {
		string teksti = tekstitiedosto.text.ToString();
		string[] taulukko = teksti.Split ('\n');
		random = (int)Random.Range(0,100);
		Debug.Log (random);
		inputfield.text = taulukko [random];
	}
}