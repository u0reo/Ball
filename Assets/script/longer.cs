using UnityEngine;
using System.Collections;

public class longer : MonoBehaviour {
	int count = 0;
	int keys_count = 0;
	public GameObject hart1;
	public GameObject hart2;
	public GameObject hart3;
	public GameObject go;
	public GameObject goal;
	public GameObject pause;
	public GameObject timer;
	public GameObject light1;
	//public GameObject light2;
	public GameObject macamera;
	public GameObject sbcamera;
	public GameObject retry;
	public GameObject title;
	public GameObject pointlight;
	public GameObject keys;
	public GameObject sphere_earth;
	public GameObject earth;
	private GameObject elevator;
	public Texture bad;
	private bool move = true;
	private bool game = false;
	private bool pauseing = false;
	private bool block = false;
	private float positon = 1.2f;
	private float rect = 0.7f;
	private float time = 0.0f;
	private float countdown = 200.0f;
	private float xac = 0.0f;
	private float yac = 0.0f;
	private float zac = 0.0f;
	private float elevator_time = 0.0f;
	private float up = -3.8f;
	private float downtime = 0.0f;
	private Vector3 positon_pause;
	private Vector3 rotation;
	
	void Awake () {
		Application.targetFrameRate = 60;
		Screen.sleepTimeout = SleepTimeout.NeverSleep ;
	}
	
	void Start () {
		//go.guiText.fontSize = 75 * Screen.currentResolution.width / 480;
		//goal.guiText.fontSize = 75 * Screen.currentResolution.width / 480;
		Input.gyro.enabled = true;
		game = true;
	}
	
	void Update () {
		earth.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime);
		if (game)
		{
			macamera.transform.position = new Vector3(transform.position.x,transform.position.y + 2.77f, transform.position.z);
			time = Time.deltaTime;
			countdown = countdown - time;
			timer.GetComponent<GUIText>().text = ("あと" + countdown.ToString("0.0") + "秒");
		}
		if (SystemInfo.supportsGyroscope && move)
		{
			// ジャイロから重力の下向きのベクトルを取得。水平に置いた場合は、gravityV.zが-9.8になる.
			Vector3 gravityV = Input.gyro.gravity;
			
			// 外力のベクトルを計算.
			float scale = 2.5f;
			Vector3 forceV = new Vector3(gravityV.x, 0.0f, gravityV.y) * scale;
			
			// 外力を加える.
			this.GetComponent<Rigidbody>().AddForce(forceV);
		}
		else if (move)
		{
			xac = (0.1f * xac + 0.1f * Input.acceleration.x) * 10.0f;
			yac = (0.1f * yac + 0.1f * Input.acceleration.y) * 10.0f;
			zac = (0.1f * zac + 0.1f * Input.acceleration.z) * 10.0f;
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
		/*if (this.transform.position.y < -5.0f && count < 2)
		{
			this.transform.position = new Vector3(-7.0f, 4.0f, 3.5f);
			count += 1;
		}*/
		if (this.transform.position.y > 1.0f/* || this.transform.position.y < -4.0f*/)
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
            move = false;
        }
		if (countdown <= 0.0f && game)
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			move = false;
			count = 3;
			GetComponent<AudioSource>().Stop();
			go.SetActive(true);
			pause.SetActive(false);
			light1.GetComponent<Light>().intensity = 0.1f;
			this.GetComponent<Rigidbody>().drag = 100;
			rect += 0.02f;
			sbcamera.GetComponent<Camera>().rect = new Rect(rect,0.0f,0.2f,0.2f);
			timer.transform.position = new Vector3(0.0f - rect, 1.0f, 0.0f);
			keys.transform.position = new Vector3(0.0f - rect, 0.9f, 0.0f);
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
		if (rect >= 1.0f) {
			game = false;
		}
		if (pauseing) {
			transform.position = positon_pause;
		}
		if (block) {
			downtime += Time.deltaTime;
			Debug.Log(downtime);
			if (downtime > 1.5f && game) {
				rotation = this.transform.eulerAngles;
				if (count >= 2) {
					//this.transform.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
					//positon_pause = this.transform.position;
					//pauseing = true;
					move = false;
					count = 3;
					GetComponent<AudioSource>().Stop();
					go.SetActive(true);
					pause.SetActive(false);
					light1.GetComponent<Light>().intensity = 0.1f;
					this.GetComponent<Rigidbody>().drag = 10;
					GetComponent<ParticleSystem>().Play();
					rect += 0.02f;
					sbcamera.GetComponent<Camera>().rect = new Rect(rect,0.0f,0.2f,0.2f);
					timer.transform.position = new Vector3(0.0f - rect, 1.0f, 0.0f);
					keys.transform.position = new Vector3(0.0f - rect, 0.9f, 0.0f);
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
				else {
					Vector3 ball_rigidbody = GetComponent<Rigidbody>().velocity;
					// 弾を生成
					GameObject shot = Instantiate (sphere_earth, transform.position, transform.rotation) as GameObject;
					// Shotスクリプトオブジェクトを取得
					down s = shot.GetComponent<down>();
					// 移動速度を設定
					s.Create(ball_rigidbody);
					this.transform.position = new Vector3(-7.0f, 4.0f, 3.5f);
					count += 1;
					downtime = 0.0f;
				}
			}
		}
		if (!game) {
			this.transform.eulerAngles = rotation;
		}
	}
	void OnCollisionEnter ( Collision key  ){
		if (LayerMask.LayerToName(key.gameObject.layer) == "key") {
			keys_count += 1;
			key.gameObject.SetActive(false);
			keys.GetComponent<GUIText>().text = ("Key:" + keys_count);
		}
	}
	void OnCollisionStay ( Collision key  ){
		block = false;
		if (LayerMask.LayerToName(key.gameObject.layer) == "elevator") {
			elevator = key.gameObject;
			elevator_time += Time.deltaTime;
			elevator.transform.position = new Vector3(elevator.transform.position.x,up,elevator.transform.position.z);
			if (elevator_time <=1.0f) {
				up = -3.8f;
			}
			if (elevator_time >= 1.5f && elevator_time <= 9.0f) {
				up += 0.025f;
				if (up >= 0.3f) {
					elevator_time = 10.0f;
				}
			}
		}
		else if (up > -3.7f){
			elevator_time = 0.0f;
			up = up - 0.1f;
			elevator.transform.position = new Vector3(elevator.transform.position.x,up,elevator.transform.position.z);
			if (up <= -3.6f) {
				up = -3.7f;
			}
		}
	}
	void OnCollisionExit ( Collision key  ){
		block = true;
		//
		downtime = 0.0f;
	}
	public void paused() {
		if (game && move) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			retry.SetActive (true);
			title.SetActive (true);
			light1.GetComponent<Light>().intensity = 0.1f;
			//light2.SetActive (false);
			pointlight.SetActive (false);
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			sbcamera.GetComponent<Camera>().rect = new Rect (0.8f, 0.0f, 0.2f, 0.2f);
			game = false;
			move = false;
		}
	}
	public void continued() {
		if (game == false && move == false) {
			retry.SetActive (false);
			title.SetActive (false);
			light1.GetComponent<Light>().intensity = 0.3f;
			//light2.SetActive (true);
			pause.SetActive (true);
			pointlight.SetActive (true);
			game = true;
			move = true;
			sbcamera.GetComponent<Camera>().rect = new Rect (0.7f, 0.0f, 0.3f, 0.3f);
		}
	}
}