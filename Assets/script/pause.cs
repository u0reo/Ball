using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	public string script = "none"; 
	private ball ball_;
	private randam randam_;
	private longer longer_;
	private bool pauseing = false;

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

	void Awake ()
	{
	}

    // Use this for initialization
    void Start()
    {
		if (Application.loadedLevelName == "main"){
			script = "ball";
			ball_ =  GameObject.Find("Sphere").GetComponent<ball>();
		}
		if (Application.loadedLevelName == "randam"){
			script = "randam";
			randam_ =  GameObject.Find("Sphere").GetComponent<randam>();
		}
		if (Application.loadedLevelName == "longer"){
			script = "longer";
			longer_ =  GameObject.Find("Sphere").GetComponent<longer>();
		}
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
					if (Application.loadedLevelName == "main" && !pauseing){
						ball_.paused();
					}
					if (Application.loadedLevelName == "randam" && !pauseing){
						randam_.paused();
					}
					if (Application.loadedLevelName == "longer" && !pauseing){
						longer_.paused();
					}
					if (Application.loadedLevelName == "main" && pauseing){
						ball_.continued();
					}
					if (Application.loadedLevelName == "randam" && pauseing){
						randam_.continued();
					}
					if (Application.loadedLevelName == "longer" && pauseing){
						longer_.continued();
					}
					pauseing = !pauseing;
                    break;
                case BUTTON_STATUS.UP:
                    GetComponent<GUITexture>().texture = textureUp;
                    break;
            }
        }
		if (Application.platform == RuntimePlatform.Android && Input.GetKey (KeyCode.Escape)) {
			if (Application.loadedLevelName == "main" && !pauseing){
				ball_.paused();
			}
			if (Application.loadedLevelName == "randam" && !pauseing){
				randam_.paused();
			}
			if (Application.loadedLevelName == "longer" && !pauseing){
				longer_.paused();
			}
			if (Application.loadedLevelName == "main" && pauseing){
				ball_.continued();
			}
			if (Application.loadedLevelName == "randam" && pauseing){
				randam_.continued();
			}
			if (Application.loadedLevelName == "longer" && pauseing){
				longer_.continued();
			}
			pauseing = !pauseing;
		}
    }
}
