using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class key : MonoBehaviour {
	public GameObject player;
	public int keys_count = 0;
	List<string> keys = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void  OnCollisionEnter ( Collision key  ){
		if (key.gameObject == player && !keys.Contains(this.gameObject.ToString())) {
			keys.Add (this.gameObject.ToString());
			keys_count = keys_count + 1;
			print("key+"+keys_count);
			this.gameObject.SetActive(false);
			print(keys_count);
		}
	}
}
