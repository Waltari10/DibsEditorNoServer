using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class getQuote : MonoBehaviour {
	public int random;
	public TextAsset tekstitiedosto;
	InputField fieldi;
	
	public void lue() {
		string teksti = tekstitiedosto.text.ToString();
		string[] taulukko = teksti.Split ('\n');
		random = (int)Random.Range(0,100);
		Debug.Log (random);
		fieldi = GameObject.Find ("quoteField").GetComponent<InputField>();
		fieldi.text = taulukko [random];
	}
}