using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StateHandler : MonoBehaviour {

    Text teksti;
    Text teksti1;
    Text teksti2;
    Text teksti3;
    public Color color;
    public Color notPressed;

	public void TextScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 0) {
            teksti = GameObject.Find("uitext").GetComponent<Text>();
            teksti.color = color;
            teksti1 = GameObject.Find("uicard").GetComponent<Text>();
            teksti2 = GameObject.Find("uifont").GetComponent<Text>();
            teksti3 = GameObject.Find("uisave").GetComponent<Text>();
            teksti1.color = notPressed;
            teksti2.color = notPressed;
            teksti3.color = notPressed;
            UIScene.Instance.currentScenario = 0;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void CardScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 1) {
            teksti = GameObject.Find("uicard").GetComponent<Text>();
            teksti.color = color;
            teksti1 = GameObject.Find("uitext").GetComponent<Text>();
            teksti2 = GameObject.Find("uifont").GetComponent<Text>();
            teksti3 = GameObject.Find("uisave").GetComponent<Text>();
            teksti1.color = notPressed;
            teksti2.color = notPressed;
            teksti3.color = notPressed;
            UIScene.Instance.currentScenario = 1;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void FontScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 2) {
            teksti = GameObject.Find("uifont").GetComponent<Text>();
            teksti.color = color;
            teksti1 = GameObject.Find("uicard").GetComponent<Text>();
            teksti2 = GameObject.Find("uitext").GetComponent<Text>();
            teksti3 = GameObject.Find("uisave").GetComponent<Text>();
            teksti1.color = notPressed;
            teksti2.color = notPressed;
            teksti3.color = notPressed;
            UIScene.Instance.currentScenario = 2;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void FinishScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 3) {
            teksti = GameObject.Find("uisave").GetComponent<Text>();
            teksti.color = color;
            teksti1 = GameObject.Find("uicard").GetComponent<Text>();
            teksti2 = GameObject.Find("uifont").GetComponent<Text>();
            teksti3 = GameObject.Find("uitext").GetComponent<Text>();
            teksti1.color = notPressed;
            teksti2.color = notPressed;
            teksti3.color = notPressed;
            UIScene.Instance.currentScenario = 3;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}

    public void CropPictureScene()
    {
        //  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
        if (UIScene.Instance.currentScenario != 4)
        {
            UIScene.Instance.currentScenario = 4;
            Debug.Log(UIScene.Instance.currentScenario);
            UIScene.Instance.UpdateScenario();
        }

    }

}
