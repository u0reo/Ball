using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randam : MonoBehaviour {
	int count = 0;
	int count_wool = 0;
	int floor_count = 0;
	int max_high = 2;
	int max_width = 2;
	int two_high = 0;
	int two_width = 0;
	int fh = 0;
	int fw = 0;
	public GameObject hart1;
	public GameObject hart2;
	public GameObject hart3;
	public GameObject go;
	public GameObject goal;
	public GameObject pause;
	public GameObject timer;
	public GameObject light1;
	public GameObject light2;
	public GameObject macamera;
	public GameObject sbcamera;
	public GameObject retry;
	public GameObject title;
	public GameObject wait;
	public GameObject pointlight;
	public Texture bad;
	private bool move = false;
	private bool game = false;
	private bool counting = false;
	private bool pauseing = false;
	private float positon = 1.2f;
	private float rect = 0.7f;
	private float time = 0.0f;
	private float times = 0.0f;
	private float countdown = 60.0f;
	private float blank = 1.0f;
	private float xac = 0.0f;
	private float yac = 0.0f;
	private float zac = 0.0f;
	private Vector3 positon_pause;
	public GameObject cube;
	public GameObject block;
	public GameObject hoal;
	List<string> wool_high = new List<string>();
	List<string> wool_width = new List<string>();
	List<string> floor = new List<string>();

	void Awake () {
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep ;
	}

	// Use this for initialization
	void Start () {
		//go.guiText.fontSize = 75 * Screen.currentResolution.width / 480;
		//goal.guiText.fontSize = 75 * Screen.currentResolution.width / 480;
		//wait.guiText.fontSize = 120 * Screen.currentResolution.width / 480;
		//timer.guiText.fontSize = 35 * Screen.currentResolution.width / 480;
		Input.gyro.enabled = true;
		wool_high.Add ("0x-1");
		wool_high.Add ("1x-1");
		wool_high.Add ("2x-1");
		wool_high.Add ("3x-1");
		wool_high.Add ("4x-1");
		wool_high.Add ("5x-1");
		wool_high.Add ("6x-1");
		wool_high.Add ("7x-1");
		wool_high.Add ("8x-1");
		wool_high.Add ("9x-1");
		wool_high.Add ("0x17");
		wool_high.Add ("1x17");
		wool_high.Add ("2x17");
		wool_high.Add ("3x17");
		wool_high.Add ("4x17");
		wool_high.Add ("5x17");
		wool_high.Add ("6x17");
		wool_high.Add ("7x17");
		wool_high.Add ("8x17");
		wool_high.Add ("9x17");
		wool_high.Add ("0x16");
		wool_high.Add ("9x0");
		wool_width.Add ("-1x0");
		wool_width.Add ("-1x1");
		wool_width.Add ("-1x2");
		wool_width.Add ("-1x3");
		wool_width.Add ("-1x4");
		wool_width.Add ("-1x5");
		wool_width.Add ("-1x6");
		wool_width.Add ("-1x7");
		wool_width.Add ("-1x8");
		wool_width.Add ("-1x9");
		wool_width.Add ("-1x10");
		wool_width.Add ("-1x11");
		wool_width.Add ("-1x12");
		wool_width.Add ("-1x13");
		wool_width.Add ("-1x14");
		wool_width.Add ("-1x15");
		wool_width.Add ("-1x16");
		wool_width.Add ("-1x17");
		wool_width.Add ("-1x18");
		wool_width.Add ("9x0");
		wool_width.Add ("9x1");
		wool_width.Add ("9x2");
		wool_width.Add ("9x3");
		wool_width.Add ("9x4");
		wool_width.Add ("9x5");
		wool_width.Add ("9x6");
		wool_width.Add ("9x7");
		wool_width.Add ("9x8");
		wool_width.Add ("9x9");
		wool_width.Add ("9x10");
		wool_width.Add ("9x11");
		wool_width.Add ("9x12");
		wool_width.Add ("9x13");
		wool_width.Add ("9x14");
		wool_width.Add ("9x15");
		wool_width.Add ("9x16");
		wool_width.Add ("9x17");
		wool_width.Add ("9x18");
		wool_width.Add ("0x17");
		wool_width.Add ("8x0");
		floor.Add ("8x0");
		floor.Add ("9x0");
		floor.Add ("9x1");
		floor.Add ("0x16");
		floor.Add ("1x17");
		floor.Add ("0x17");
	}
	
	// Update is called once per frame
	void Update () {
		if (count_wool <= 120) {
			int randam_count = 0;
			int h = Random.Range(0, 10);
			int w = Random.Range(0, 17);
			if (wool_width.Contains((h - 1).ToString() + "x" + (w).ToString())){
				randam_count += 1;
			}
			if (wool_width.Contains((h - 1).ToString() + "x" + (w + 1).ToString())){
				randam_count += 1;
			}
			if (wool_width.Contains((h).ToString() + "x" + (w).ToString())){
				randam_count += 1;
			}
			if (wool_width.Contains((h).ToString() + "x" + (w + 1).ToString())){
				randam_count += 1;
			}
			if (wool_high.Contains(h.ToString() + "x" + w.ToString())) {
				print ("high一致しました。 total:" + count_wool +" point:"+ h + "x" + w);
			}
			else if (randam_count <= max_high) {
				wool_high.Add (h + "x" + w);
				
				float high = ( h * 1.75f )- 7.875f;
				float width = ( w * 1.75f ) - 14.0f;
				
				Instantiate(this.cube, new Vector3(width, 0.75f , high), Quaternion.identity);
				
				count_wool += 1;
				print("high:" + h + "x" + w);

				if (randam_count == 2) {
					two_high += 1 ;
				}
				if (two_high >= 15) {
					max_high = 1;
				}
			}
		}
		if (count_wool <= 120) {
			int randam_count = 0;
			int h = Random.Range(0, 9);
			int w = Random.Range(0, 18);
			if (wool_high.Contains((h + 1).ToString() + "x" + (w).ToString())){
				randam_count += 1;
			}
			if (wool_high.Contains((h + 1).ToString() + "x" + (w-1).ToString())){
				randam_count =+ 1;
			}
			if (wool_high.Contains((h).ToString() + "x" + (w).ToString())){
				randam_count += 1;
			}
			if (wool_high.Contains((h).ToString() + "x" + (w-1).ToString())){
				randam_count += 1;
			}
			if (wool_width.Contains(h.ToString() + "x" + w.ToString())) {
				print ("width一致しました。 total:" + count_wool +" point:"+ h + "x" + w);
			}
			else if (randam_count <= max_width){
				wool_width.Add (h + "x" + w);
				
				float high = ( h * 1.75f )- 7.0f;
				float width = ( w * 1.75f ) - 14.875f;
				
				Instantiate(this.cube, new Vector3(width, 0.75f , high), Quaternion.Euler(0,90,0));
				
				count_wool += 1;
				print("width:" + h + "x" + w);

				if (randam_count == 2) {
					two_width += 1 ;
				}
				if (two_width >= 15) {
					max_width = 1;
				}
			}
		}
		if (floor_count <= 9) {
			int f = Random.Range (0, 18);
			if (floor.Contains (floor_count.ToString () + "x" + f.ToString ())) {
					print ("floor一致しました。 total:" + floor_count + " point:" + floor_count + "x" + f);
			} else {
					floor.Add (floor_count + "x" + f);
				
					float high = (floor_count * 1.75f) - 7.875f;
					float width = (f * 1.75f) - 14.875f;
			
					Instantiate (this.hoal, new Vector3 (width, 0.0f, high), Quaternion.identity);
		
					floor_count += 1;
					print ("floor:" + floor_count + "x" + f);
			}
		}
		else if (floor_count <= 173) {
			if (floor.Contains (fh.ToString () + "x" + fw.ToString ())) {
				print ("floor一致しました。 total:" + floor_count + " point:" + fh + "x" + fw);
			} else {
				floor.Add (fh + "x" + fw);
				
				float high = (fh * 1.75f) - 7.875f;
				float width = (fw * 1.75f) - 14.875f;
				
				Instantiate (this.block, new Vector3 (width, 0.0f, high), Quaternion.identity);
				
				floor_count += 1;
				print ("floor:" + fh + "x" + fw);
			}
			fh += 1;
			if (fh == 10) {
				fh = 0;
				fw += 1;
			}
		}
		macamera.transform.position = new Vector3(transform.position.x,3.5f,transform.position.z);
		times += Time.deltaTime;
		if (times <= 3.0f) {
			if (times >= 0.5f) {
				wait.GetComponent<GUIText>().text = ("Wait.");
			}
			if (times >= 1.0f) {
				wait.GetComponent<GUIText>().text = ("Wait..");
			}
			if (times >= 1.5f) {
				wait.GetComponent<GUIText>().text = ("Wait...");
			}
			if (times >= 2.2f) {
				wait.GetComponent<GUIText>().text = ("Rady?");
			}
			move = false;
			game = false;
			counting = true;
			} 
		else if (times <= 3.7f) {
			blank = blank - 0.03f;
			wait.GetComponent<GUIText>().color = new Color(1.0f,0.0f,0.0f,blank);
			wait.GetComponent<GUIText>().text = ("GO!!");
			move = true;
			game = true;
			counting = true;
		}
		else {
			counting = false;
			wait.SetActive(false);
		}
		if (game)
		{
			time = Time.deltaTime;
			countdown = countdown - time;
			timer.GetComponent<GUIText>().text = ("あと" + countdown.ToString("0.0") + "秒");
		}
		if (SystemInfo.supportsGyroscope && move)
		{
			// ジャイロから重力の下向きのベクトルを取得。水平に置いた場合は、gravityV.zが-9.8になる.
			Vector3 gravityV = Input.gyro.gravity;
			
			// 外力のベクトルを計算.
			float scale = 5.0f;
			Vector3 forceV = new Vector3(gravityV.x, 0.0f, gravityV.y) * scale;
			
			// 外力を加える.
			this.GetComponent<Rigidbody>().AddForce(forceV);
		}
		else if (move)
		{
			xac = (0.1f * xac + 0.1f * Input.acceleration.x) * 8.0f;
			yac = (0.1f * yac + 0.1f * Input.acceleration.y) * 8.0f;
			zac = (0.1f * zac + 0.1f * Input.acceleration.z) * 8.0f;
			Vector3 forceV2 = new Vector3(xac, zac, yac);
			// 外力を加える.
			this.GetComponent<Rigidbody>().AddForce(forceV2);
			
			if (Input.GetKey(KeyCode.UpArrow))
			{
				Vector3 up = new Vector3(0.0f, 0.0f, 1.0f);
				this.GetComponent<Rigidbody>().AddForce(up);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				Vector3 down = new Vector3(0.0f, 0.0f, -1.0f);
				this.GetComponent<Rigidbody>().AddForce(down);
			} if (Input.GetKey(KeyCode.RightArrow))
			{
				Vector3 right = new Vector3(1.0f, 0.0f, 0.0f);
				this.GetComponent<Rigidbody>().AddForce(right);
			} if (Input.GetKey(KeyCode.LeftArrow))
			{
				Vector3 left = new Vector3(-1.0f, 0.0f, 0.0f);
				this.GetComponent<Rigidbody>().AddForce(left);
			}
		}
		if (this.transform.position.y < -5.0f && count < 2)
		{
			this.transform.position = new Vector3(-14.875f, 4.0f, 7.75f);
			count += 1;
		}
		if (this.transform.position.y > 1.0f || this.transform.position.y < 0.0f)
		{
			if (move)
			{
				GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
			move = false;
		}
		else if (this.transform.position.y > 0.8f)
		{
			move = true;
		}
		if (count >= 1 )
		{
			hart3.GetComponent<GUITexture>().texture = bad;
		}
		if (count >= 2)
		{
			hart2.GetComponent<GUITexture>().texture = bad;
		}
		if (count >= 3)
        {
            hart1.GetComponent<GUITexture>().texture = bad;
        }
		if ((this.transform.position.y < -6.0f || countdown <= 0.0f) && game)
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			positon_pause = this.transform.position;
			pauseing = true;
			move = false;
			count = 3;
			GetComponent<AudioSource>().Stop();
			go.SetActive(true);
			pause.SetActive(false);
			light1.SetActive(false);
			light2.SetActive(false);
			rect += 0.02f;
			sbcamera.GetComponent<Camera>().rect = new Rect(rect,0.0f,0.2f,0.2f);
			timer.transform.position = new Vector3(0.0f - rect, 1.0f, 0.0f);
			if (go.transform.position.y > 0.8f)
			{
				positon = positon- 0.05f;
				go.transform.position = new Vector3(0.5f,positon,0.0f);
			}
			else
			{
				retry.SetActive(true);
				title.SetActive(true);
			}
		}
		if (this.transform.position.x > 14.625f && this.transform.position.z < -7.625f && game) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			positon_pause = this.transform.position;
			pauseing = true;
			move = false;
			GetComponent<AudioSource>().Stop ();
			goal.SetActive (true);
			pause.SetActive (false);
			light1.SetActive (false);
			light2.SetActive (false);
			rect += 0.02f;
			sbcamera.GetComponent<Camera>().rect = new Rect (rect, 0.0f, 0.3f, 0.3f);
			timer.transform.position = new Vector3 (0.0f - rect, 1.0f, 0.0f);
			if (goal.transform.position.y > 0.8f) {
				positon = positon - 0.05f;
				goal.transform.position = new Vector3 (0.5f, positon, 0.0f);
			} 
			else {
				retry.SetActive (true);
				title.SetActive (true);
			}
		}
		if (rect >= 1.0f) {
			game = false;
		}
		if (pauseing) {
			transform.position = positon_pause;
		}
	}
	public void paused() {
		if (game && move && counting == false) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			retry.SetActive (true);
			title.SetActive (true);
			wait.SetActive (true);
			wait.GetComponent<GUIText>().color = new Color(1.0f,1.0f,1.0f,1.0f);
			wait.transform.position = new Vector3(0.5f,0.8f,0.0f);
			wait.GetComponent<GUIText>().text = ("Pause");
			light1.SetActive (false);
			light2.SetActive (false);
			pointlight.SetActive (false);
			sbcamera.GetComponent<Camera>().rect = new Rect (0.8f, 0.0f, 0.2f, 0.2f);
			positon_pause = this.transform.position;
			game = false;
			move = false;
			pauseing = true;
		}
	}
	public void continued() {
		if (game == false && move == false && counting == false) {
			retry.SetActive (false);
			title.SetActive (false);
			wait.SetActive (false);
			light1.SetActive (true);
			light2.SetActive (true);
			pointlight.SetActive (true);
			game = true;
			move = true;
			pauseing = false;
			sbcamera.GetComponent<Camera>().rect = new Rect (0.7f, 0.0f, 0.3f, 0.3f);
		}
	}
}
