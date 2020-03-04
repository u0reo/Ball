using UnityEngine;
using System.Collections;

public class down : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Create(Vector3 ball_rigidbody) {
		GetComponent<Rigidbody>().velocity = ball_rigidbody;
	}
}
