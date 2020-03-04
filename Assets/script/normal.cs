using UnityEngine;
using System.Collections;

public class normal : MonoBehaviour {
	public GameObject baller;
	public GameObject site;
	public GameObject randam;
	public GameObject adventure;
	public GameObject meiro;
	public GameObject finish;
	private bool move = false;
	private bool finishing = false;
	private bool stage = false;
	private bool back = false;
	private bool slide = false;
	private float rect = 0.0f;
	private float rect_ = 0.0f;
	private float rect__ = 0.0f;
	private float rect___ = 0.0f;
	private float blank;
	private float timer;

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
				move = true;
				break;
			case BUTTON_STATUS.UP:
				GetComponent<GUITexture>().texture = textureUp;
				break;
			}
		}
		if (Application.platform == RuntimePlatform.Android && Input.GetKey (KeyCode.Escape) && timer == 0.0f && stage && !slide) {
			back = true;
		}
		//「戻るキー」でアプリ終了 (Android) ※機種判定を外すとESCでアプリ終了(Win)
		else if (Application.platform == RuntimePlatform.Android && Input.GetKey (KeyCode.Escape) && timer == 0.0f && !stage && !slide) {
			finishing = true;
		}
		
		if (finishing) {
			blank = blank + 0.01f;
			finish.GetComponent<GUITexture>().color = new Color(0.5f,0.5f,0.5f,blank);
			if (Application.platform == RuntimePlatform.Android && Input.GetKey (KeyCode.Escape) && blank >= 0.2f) {
				Application.Quit();
			}
			if (blank >= 0.45f) {
				finishing = false;
			}
		}
		else if (!finishing && blank >= 0.45f) {
			timer += Time.deltaTime;
			if (Application.platform == RuntimePlatform.Android && Input.GetKey (KeyCode.Escape)) {
				Application.Quit();
			}
		}
		if (!finishing && timer >= 2.0f) {
			blank = blank - 0.01f;
			finish.GetComponent<GUITexture>().color = new Color(0.5f,0.5f,0.5f,blank);
		}
		if (blank <= 0.0f) {
			timer = 0.0f;
			blank = 0.0f;
		}
		if (move) {
			slide = true;
			rect += 0.02f;
			baller.transform.position = new Vector3(0.48f, 1.05f + rect, 0.0f);
			site.transform.position = new Vector3(0.0f - rect, 0.0f, 0.0f);
			randam.transform.position = new Vector3(0.55f, 0.15f - rect, 0.0f);
			this.transform.position = new Vector3(0.55f, 0.35f - rect, 0.0f);
			if (rect >= 0.5f) {
				move = false;
			}
		}
		else if (!move && rect >= 0.5f) {
			rect_ += 0.04f;
			meiro.transform.position = new Vector3(-1.78f + rect_, 0.93f, 1.0f);
			adventure.transform.position = new Vector3(2.46f - rect_, 0.47f, 1.0f);
			if (rect_ >= 2.08f) {
				rect_ = 0.0f;
				rect = 0.0f;
				slide = false;
				stage = true;
			}
		}
		if (back) {
			slide = true;
			stage = false;
			rect__ += 0.04f;
			meiro.transform.position = new Vector3(0.36f + rect__, 0.93f, 1.0f);
			adventure.transform.position = new Vector3(0.36f - rect__, 0.47f, 1.0f);
			if (rect__ >= 2.1f) {
				back = false;
			}
		}
		else if (!back && rect__ >= 2.1f) {
			rect___ += 0.02f;
			baller.transform.position = new Vector3(0.48f, 1.5f - rect___, 0.0f);
			site.transform.position = new Vector3(-0.5f + rect___, 0.0f, 0.0f);
			randam.transform.position = new Vector3(0.55f, -0.35f + rect___, 0.0f);
			this.transform.position = new Vector3(0.55f, -0.15f + rect___, 0.0f);
			if (rect___ >= 0.5f) {
				rect___ = 0.0f;
				rect__ = 0.0f;
				slide = false;
			}
		}

	}
}