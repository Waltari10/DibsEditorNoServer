using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ImageVideoContactPicker;

public class CropLogic : MonoBehaviour {


	public Texture2D debugTexture;
   

    private Image sceneImage;
	private Image userPicture;
	private Button button;
	private RectTransform userPicRect;
	private RectTransform pictureBorderRect;

	private float pictureYXRatio;
    private bool pictureLoaded = false;
	private Texture2D cropThisTex;

	private float distanceChangeTouches;
	private float TouchedPointsDistanceLastTime;
	private float width2;
	private float height2;
	private float originalUserPicWidth;
	private float pictureRatio;
	private float picLeftBorder;
	private float picBotBorder;
	private float picRightBorder;
	private float picTopBorder;
	private float bordLeftBorder;
	private float bordBotBorder;
	private float bordRightBorder;
	private float bordTopBorder;
	private float newWidth;
	private float newHeight;



    void Start () {
        
		userPicture = GameObject.Find ("UserPicture").GetComponent<Image>();
		userPicRect = GameObject.Find ("UserPicture").GetComponent<RectTransform>();
		pictureBorderRect = GameObject.Find ("PictureBorder").GetComponent<RectTransform> ();
		button = GameObject.Find ("setPictureButton").GetComponent<Button> ();
		sceneImage = GameObject.Find ("CamButton").GetComponent<Image> ();
        
		button.onClick.AddListener(() => CropPicture());

		fitPictureBorderToScreen ();

		if (Application.platform == RuntimePlatform.WindowsEditor) {
            OnImageLoadDebugPC();
			FitPicToScreen (debugTexture);
		} else if (Application.platform == RuntimePlatform.Android) {
			Debug.Log ("The platform is indeed android");
			AndroidPicker.BrowseImage ();
		} else {

			Debug.Log ("The platform is something else");
		}

	}

    void fitPictureBorderToScreen() {
		float ratioX = (float) (Screen.width / pictureBorderRect.rect.width);
		float ratioY = (float)(Screen.height * 0.9) / pictureBorderRect.rect.height;

		if (ratioX < ratioY) {			//Width Restricts
			//Debug.Log ("fitPictureBorder ratioX < ratioY Width Restricts");
			width2 = (float) (Screen.width * 0.9);
			height2 = (width2 * pictureBorderRect.rect.height) / pictureBorderRect.rect.width;
		} else if (ratioX > ratioY){	//Height restricts
			//Debug.Log ("fitPictureBorder ratioX > ratioY Height restricts");
			height2 = (float) (Screen.height * 0.9);
			width2 = (pictureBorderRect.rect.width * height2) / pictureBorderRect.rect.height;
		} 
		pictureBorderRect.sizeDelta = new Vector2 (width2, height2);
	}

	public void FitPicToScreen(Texture2D rawTexture) {

		float ratioX = (float) pictureBorderRect.rect.width / rawTexture.width;
		float ratioY = (float) (pictureBorderRect.rect.height) / rawTexture.height;
		pictureYXRatio = (float) rawTexture.height /rawTexture.width;

		if (ratioX < ratioY) {
			userPicRect.sizeDelta = new Vector2(pictureBorderRect.rect.height * (1/pictureYXRatio), pictureBorderRect.rect.height);
		} else if (ratioX > ratioY){
			float pictureWidth = (float)((pictureBorderRect.rect.width) * rawTexture.height)/rawTexture.width;
			userPicRect.sizeDelta = new Vector2((float)(pictureBorderRect.rect.width), pictureWidth);
		} else if (ratioX == ratioY) {
			Debug.Log ("picture ratioX == ratioY");
		}
	}

	public void CropPicture() {	//called when set picture is pressed

		float picLeftBorder = userPicRect.position.x - (userPicRect.rect.width / 2);
		float cropPosX = pictureBorderRect.position.x - picLeftBorder;
		float picBotBorder = userPicRect.position.y - (userPicRect.rect.height/2);
		float cropPosY = pictureBorderRect.position.y - picBotBorder;
		float textureRectangleRatio = cropThisTex.width / userPicRect.rect.width;
		int width = (int) (pictureBorderRect.rect.width * textureRectangleRatio);
		int height = (int) (pictureBorderRect.rect.height * textureRectangleRatio);

		cropPosX = (cropPosX * textureRectangleRatio) - (width / 2);
		cropPosY = (cropPosY * textureRectangleRatio) - (height /2);

		Color[] pix = cropThisTex.GetPixels((int)cropPosX,(int) cropPosY, width, height);

		Texture2D destTex = new Texture2D(width, height);
		destTex.SetPixels(pix);
		destTex.Apply();

		Sprite sprite = new Sprite();
		sprite = Sprite.Create (destTex, new Rect (0, 0, width, height), new Vector2 (0.5f, 0.5f));
		sceneImage.overrideSprite = sprite;

        //	GO.SetActive (false);
        if (UIScene.Instance.currentScenario != 0)
        {
            UIScene.Instance.currentScenario = 0;
            Debug.Log(UIScene.Instance.currentScenario);
            UIScene.Instance.UpdateScenario();
        }

    }

		
	// Update is called once per frame
	void Update () {
		userPicScale ();
	}

	void userPicScale() {
		if (Input.touchCount > 1) {
			//distance change per frame
			Touch touch1 = Input.GetTouch (0);
			Touch touch2 = Input.GetTouch (1);
			distanceChangeTouches = Mathf.Sqrt (Mathf.Pow ((touch2.deltaPosition.y - touch1.deltaPosition.y), 2) + Mathf.Pow ((touch2.deltaPosition.x - touch1.deltaPosition.x), 2));

			//Distance of touched points
			float TouchedPointsDistance = Mathf.Sqrt (Mathf.Pow ((touch2.position.y - touch1.position.y), 2) + Mathf.Pow ((touch2.position.x - touch1.position.x), 2));

			Debug.Log (distanceChangeTouches);

			if (TouchedPointsDistance > TouchedPointsDistanceLastTime) {
				if (userPicRect.rect.width + distanceChangeTouches * 3 < (originalUserPicWidth * 3)) {
					Debug.Log ("trying to make it bigger");
					userPicRect.sizeDelta = new Vector2 (userPicRect.rect.width + distanceChangeTouches * 3, userPicRect.rect.height + distanceChangeTouches * 3 * pictureRatio); 
				} 
			} else if (TouchedPointsDistance < TouchedPointsDistanceLastTime) {

				newWidth = userPicRect.rect.width - distanceChangeTouches * 3;
				newHeight = userPicRect.rect.height - distanceChangeTouches * 3 * pictureRatio;

				picLeftBorder = userPicRect.position.x - (newWidth / 2);
				picBotBorder = userPicRect.position.y- (newHeight/2);
				picRightBorder = userPicRect.position.x + (newWidth / 2);
				picTopBorder = userPicRect.position.y + (newHeight/2);

				bordLeftBorder = pictureBorderRect.position.x - (pictureBorderRect.rect.width / 2);
				bordBotBorder = pictureBorderRect.position.y - (pictureBorderRect.rect.height / 2);
				bordRightBorder = pictureBorderRect.position.x + (pictureBorderRect.rect.width / 2);
				bordTopBorder = pictureBorderRect.position.y + (pictureBorderRect.rect.height / 2);

				Debug.Log("Bring it DOWN");
				if (userPicRect.rect.width - distanceChangeTouches * 3 > (originalUserPicWidth/3) && picLeftBorder < bordLeftBorder && picRightBorder > bordRightBorder && picTopBorder > bordTopBorder && picBotBorder < bordBotBorder) {
					Debug.Log ("trying to make it smaller");
					userPicRect.sizeDelta = new Vector2 (userPicRect.rect.width - distanceChangeTouches * 3 , userPicRect.rect.height - distanceChangeTouches * 3 * pictureRatio);
				}
			} 
			TouchedPointsDistanceLastTime = TouchedPointsDistance;
		} 

	}

	void OnEnable() {
		PickerEventListener.onImageLoad += OnImageLoad;

	}

	void OnDisable() {
		PickerEventListener.onImageLoad -= OnImageLoad;

	}

	void OnImageLoadDebugPC() {
		cropThisTex = new Texture2D (debugTexture.width, debugTexture.height, debugTexture.format, false);
		cropThisTex.LoadRawTextureData(debugTexture.GetRawTextureData ());
		Sprite sprite = new Sprite ();
		sprite = Sprite.Create (debugTexture, new Rect (0, 0, debugTexture.width, debugTexture.height), new Vector2 (0.5f, 0.5f));
		userPicture.overrideSprite = sprite;

		originalUserPicWidth = userPicRect.rect.width;
		pictureRatio = (userPicRect.rect.height/ userPicRect.rect.width);
        pictureLoaded = true;
	}

	void OnImageLoad(string imgPath, Texture2D tex) {
		cropThisTex = new Texture2D (tex.width, tex.height, tex.format, false);
		cropThisTex.LoadRawTextureData(tex.GetRawTextureData ()); //Makes the texture readable
		Sprite sprite = new Sprite ();
		sprite = Sprite.Create (tex, new Rect (0, 0, cropThisTex.width, cropThisTex.height), new Vector2 (0.5f, 0.5f));
		userPicture.overrideSprite = sprite;
		FitPicToScreen(cropThisTex);
		originalUserPicWidth = userPicRect.rect.width;
		pictureRatio = (userPicRect.rect.height / userPicRect.rect.width);
        pictureLoaded = true;
    }
}
