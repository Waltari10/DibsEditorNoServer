using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Reign;

public class readCardPixels : MonoBehaviour {

	private RectTransform cardTrans;
	string path;
	byte[] bytes;
	Button saveButton;
	
	// Use this for initialization
	void Start () {
		saveButton = GameObject.Find ("save").GetComponent<Button>();
		cardTrans = GameObject.Find ("Templateimage").GetComponent<RectTransform>();
		saveButton.onClick.AddListener(() => startCoroutineTakeShot());
	}

	public void startCoroutineTakeShot() {
		StartCoroutine (takeShot());
	}

	public IEnumerator takeShot() {

		yield return new WaitForEndOfFrame ();

		int pictureWidth = (int)cardTrans.rect.width;
		int pictureheight = (int)cardTrans.rect.height;

		int cropPosX = (int) cardTrans.position.x - (int) (cardTrans.rect.width/2);
		int cropPosY = (int) cardTrans.position.y - (int) (cardTrans.rect.height/2);
	
		Texture2D cardPic = new Texture2D(pictureWidth, pictureheight, TextureFormat.ARGB32, false);
		cardPic.ReadPixels(new Rect(cropPosX, cropPosY , pictureWidth, pictureheight), 0, 0);  //Crashes everything
		cardPic.Apply();
		bytes = cardPic.EncodeToPNG();
	
		saveToPictures ();

	}

	private void saveToPictures()
	{
		StreamManager.SaveFile("TEST.png", bytes, FolderLocations.Pictures, imageSavedCallback);
	}
		
	private void imageSavedCallback(bool succeeded)
	{
		if (succeeded) {
			MessageBoxManager.Show ("Image Status", "Image saved succesfully!");
		} else {
			MessageBoxManager.Show ("Image Status", "Image saving failed!");
		}

	}
}