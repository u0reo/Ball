using UnityEngine;
using System.Collections;

public class denden : MonoBehaviour {
	public enum BUTTON_STATUS
	{
		NONE = -1,
		
		UP = 0,
		DOWN,
		END,
		CANCEL,
	};
	
	public BUTTON_STATUS buttonStatus = BUTTON_STATUS.UP;
	private BUTTON_STATUS buttonStatusNext = BUTTON_STATUS.NONE;
	
	public Texture textureUp;
	public Texture textureDown;
	
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		switch (buttonStatus)
		{
		case BUTTON_STATUS.UP:
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				
				if (touch.phase == TouchPhase.Began)
				{
					if (GetComponent<GUITexture>().HitTest(touch.position))
					{
						buttonStatusNext = BUTTON_STATUS.DOWN;
					}
				}
			}
			break;
			
		case BUTTON_STATUS.DOWN:
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				
				if (touch.phase == TouchPhase.Moved)
				{
					if (!GetComponent<GUITexture>().HitTest(touch.position))
					{
						buttonStatusNext = BUTTON_STATUS.CANCEL;
					}
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					if (GetComponent<GUITexture>().HitTest(touch.position))
					{
						buttonStatusNext = BUTTON_STATUS.END;
					}
				}
			}
			break;
			
		case BUTTON_STATUS.CANCEL:
			buttonStatusNext = BUTTON_STATUS.UP;
			break;
			
		case BUTTON_STATUS.END:
			buttonStatusNext = BUTTON_STATUS.UP;
			break;
		}
		
		while (buttonStatusNext != BUTTON_STATUS.NONE)
		{
			buttonStatus = buttonStatusNext;
			buttonStatusNext = BUTTON_STATUS.NONE;
			
			switch (buttonStatus)
			{
			case BUTTON_STATUS.DOWN:
				GetComponent<GUITexture>().texture = textureDown;
				break;
			case BUTTON_STATUS.CANCEL:
				break;
			case BUTTON_STATUS.END:
				Application.OpenURL("http://tsukubadenden.appspot.com/index.html");
				break;
			case BUTTON_STATUS.UP:
				GetComponent<GUITexture>().texture = textureUp;
				break;
			}
		}
	}
}
