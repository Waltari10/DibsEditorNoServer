using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIScene : MonoBehaviour {
	public static UIScene Instance;
	
	public Transform canvas;
	public GameObject[] scenarios;
	public int currentScenario = 0;
	public GameObject currentScenarioObj;
	
	void Awake ()
	{
		Instance = this;
	}
	
	void Start ()
	{
		UpdateScenario ();
	}
	
	public void UpdateScenario ()
	{
		if(currentScenarioObj != null)
			Destroy (currentScenarioObj);
		
		currentScenarioObj = Instantiate (scenarios[currentScenario], Vector3.zero, Quaternion.identity) as GameObject;
	}
	public void UpdateWithoutDestrpyingScenario ()
	{
		currentScenarioObj = Instantiate (scenarios[currentScenario], Vector3.zero, Quaternion.identity) as GameObject;
	}
}
