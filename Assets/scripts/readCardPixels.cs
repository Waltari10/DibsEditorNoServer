using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class readCardPixels : MonoBehaviour {

	private RectTransform cardTrans;
	string path;
	
	// Use this for initialization
	void Start () {
	
		cardTrans = GameObject.Find ("Templateimage").GetComponent<RectTransform>();

		StartCoroutine (takeShot());

	}

	public IEnumerator takeShot() {

		yield return new WaitForEndOfFrame ();

		path = "C:\\Users\\Oasis3\\Documents\\Github\\testpictures";

		int pictureWidth = (int)cardTrans.rect.width;
		int pictureheight = (int)cardTrans.rect.height;

		int cropPosX = (int) cardTrans.position.x - (int) (cardTrans.rect.width/2);
		int cropPosY = (int) cardTrans.position.y - (int) (cardTrans.rect.height/2);

		Texture2D cardPic = new Texture2D(pictureWidth, pictureheight, TextureFormat.ARGB32, false);

		cardPic.ReadPixels(new Rect(cropPosX, cropPosY , pictureWidth, pictureheight), 0, 0);  //Crashes everything

		cardPic.Apply();

		byte[] bytes = cardPic.EncodeToPNG();

		string filename = ScreenShotName((int)cardTrans.rect.width, (int)cardTrans.rect.height);

		System.IO.File.WriteAllBytes(filename, bytes);
		Debug.Log(string.Format("Took screenshot to: {0}", filename));
		Application.OpenURL(filename);

	}


	public string ScreenShotName(int width, int height) {

		string strPath="";

		strPath = string.Format("{0}/screen_{1}x{2}_{3}.png", 
			path, 
			width, height, 
			System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));

		return strPath;
	}
}
