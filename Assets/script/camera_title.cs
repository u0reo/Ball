using UnityEngine;
using System.Collections;

public class camera_title : MonoBehaviour {
	private float rotation = 0.0f;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		rotation += 0.00001f;
		transform.Rotate(new Vector3(0, 2.0f, 0)* Time.deltaTime);
	}
}
