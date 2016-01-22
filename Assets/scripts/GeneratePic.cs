using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratePic : MonoBehaviour 
{
	Text text;

	int resWidth;
	int resHeight;

	Image userPicture;
	Camera myCamera;
	int scale;

	string path;
	bool showPreview;
	RenderTexture renderTexture;

	bool isTransparent;

	Button saveButton;
	//Button shareButton;

	string lastScreenshot;

	// Use this for initialization
	void Start () {

		resWidth = Screen.width * 4;
		resHeight = Screen.height * 4;
		showPreview = true;
		path = "C:\\Users\\Oasis3\\Documents\\Github\\testpictures";
		isTransparent = false;
		scale = 3;

		text = GameObject.Find ("quoteField").GetComponent<Text> ();

		myCamera = GameObject.Find ("Camera").GetComponent<Camera> ();
		saveButton = GameObject.Find ("save").GetComponent<Button>();
		//shareButton = GameObject.Find ("share").GetComponent<Button> ();


		saveButton.onClick.AddListener(() => save());
		//shareButton.onClick.AddListener(() => share());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void share () {
//		text.mainTexture;
	}

	void save() {

		int resWidthN = resWidth*scale;
		int resHeightN = resHeight*scale;
		RenderTexture rt = new RenderTexture(resWidthN, resHeightN, 24);
		myCamera.targetTexture = rt;

		Texture2D screenShot = new Texture2D(resWidthN, resHeightN, TextureFormat.ARGB32,false);
		myCamera.Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, resWidthN, resHeightN), 0, 0);
		myCamera.targetTexture = null;
		RenderTexture.active = null; 
		byte[] bytes = screenShot.EncodeToPNG();
		Debug.Log (ScreenShotName(resWidthN, resHeightN));
		string filename = ScreenShotName(resWidthN, resHeightN);

		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));
		Application.OpenURL(filename);
		//takeHiResShot = false;


	}

	public string ScreenShotName(int width, int height) {

		string strPath="";

		strPath = string.Format("{0}/screen_{1}x{2}_{3}.png", 
			path, 
			width, height, 
			System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
		lastScreenshot = strPath;

		return strPath;
	}



}
