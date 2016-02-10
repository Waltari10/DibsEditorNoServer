using UnityEngine;
using System.Collections;

public class Pan_User_Picture : MonoBehaviour {
	
	private RectTransform userPicRect;
	private RectTransform bord;
	private float picLeftBorder;
	private float picBotBorder;
	private float picRightBorder;
	private float picTopBorder;
	private float bordLeftBorder;
	private float bordBotBorder;
	private float bordRightBorder;
	private float bordTopBorder;
	private Touch touch;
	private Vector3 newPosition;

	
	void Start() {
		userPicRect = GameObject.Find ("UserPicture").GetComponent<RectTransform>();
		bord = GameObject.Find ("PictureBorder").GetComponent<RectTransform> ();	
		
	}
	
	void Update() {
		
		if (Input.touchCount == 1) {
			
			touch = Input.GetTouch (0);

			newPosition = new Vector3 ( (float)(touch.deltaPosition.x * 1.6 + userPicRect.position.x ), (float)(touch.deltaPosition.y * 1.6 + userPicRect.position.y), 0f);

			picLeftBorder = newPosition.x - (userPicRect.rect.width / 2);
			picBotBorder = newPosition.y - (userPicRect.rect.height/2);
			picRightBorder = newPosition.x + (userPicRect.rect.width / 2);
			picTopBorder = newPosition.y + (userPicRect.rect.height/2);

			bordLeftBorder = bord.position.x - (bord.rect.width / 2);
			bordBotBorder = bord.position.y - (bord.rect.height / 2);
			bordRightBorder = bord.position.x + (bord.rect.width / 2);
			bordTopBorder = bord.position.y + (bord.rect.height / 2);

			//if inside then allowed to move on x-axis

			if (picLeftBorder < bordLeftBorder && picRightBorder > bordRightBorder) {
				userPicRect.position = new Vector3 ( (float)(touch.deltaPosition.x * 1.6 + userPicRect.position.x ), (float)userPicRect.position.y, 0f);
			}

			if (picTopBorder > bordTopBorder && picBotBorder < bordBotBorder) {
				userPicRect.position = new Vector3 ( (float)(userPicRect.position.x ), (float)(touch.deltaPosition.y * 1.6 + userPicRect.position.y), 0f);
			}
				

		}
	}
}
