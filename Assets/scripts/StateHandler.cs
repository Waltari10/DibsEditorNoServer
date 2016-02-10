using UnityEngine;
using System.Collections;

public class StateHandler : MonoBehaviour {
	
	public void TextScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 0) {
			UIScene.Instance.currentScenario = 0;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void CardScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 1) {
			UIScene.Instance.currentScenario = 1;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void FontScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 2) {
			UIScene.Instance.currentScenario = 2;
			Debug.Log (UIScene.Instance.currentScenario);
			UIScene.Instance.UpdateScenario ();
		}
		
	}
	public void FinishScene ()
	{
		//  ladataan skenaario uudestaan vain jos sitä ei ole jo ladattu (ei voi avata samaa uudestaan)
		if (UIScene.Instance.currentScenario != 3) {
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
