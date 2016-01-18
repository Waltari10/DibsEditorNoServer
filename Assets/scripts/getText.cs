using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class getText : MonoBehaviour {
	int random;
	int random2;
	public TextAsset tekstitiedosto;
	public TextAsset tekstitiedosto2;
	InputField fieldi;

	public void lue() {

		string teksti = tekstitiedosto.text.ToString();
		string[] taulukko = teksti.Split ('\n');
		string teksti2 = tekstitiedosto2.text.ToString();
		string[] taulukko2 = teksti2.Split ('\n');
		random = (int)Random.Range(0,146);
		Debug.Log (random);
		random2 = (int)Random.Range(0,561);
		Debug.Log (random2);
		fieldi = GameObject.Find ("nameField").GetComponent<InputField>();
		fieldi.text = taulukko [random] + " " + taulukko2[random2];
	}
	//open the file
	//public string PATHNAME
	//put the strings into table "/n" as a separator
	//choose a random index and fetch the string
	//onClick
	//public input field
	//aseta haettu string input fieldiin
	/*void Load(string filename)
	{
			string line;
			StreamReader theReader = new StreamReader(filename);
			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						entries = line.Split('\n');
						if (entries.Length > 0)
						Debug.Log(entries[1]);
							ShowText();
					}
				}
				while (line != null);   
				theReader.Close();
			}

	}
	public void ShowText() {
		Debug.Log(entries[1]);
		inputfield.text = entries [random];
	}*/
}

