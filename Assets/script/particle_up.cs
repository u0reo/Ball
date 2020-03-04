using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class particle_up : MonoBehaviour {
	public GameObject ball;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnParticleCllision ( GameObject key  ){
		Debug.Log("up");
		ParticleCollisionEvent[] ces = new ParticleCollisionEvent[GetComponent<ParticleSystem>().GetSafeCollisionEventSize()];
		int count = GetComponent<ParticleSystem>().GetCollisionEvents (key, ces);
		foreach (ParticleCollisionEvent item in ces){
			// action
			Vector3 up = new Vector3 (0.0f, 5.0f, 0.0f);
			ball.GetComponent<Rigidbody>().AddForce(up);
			Debug.Log("up");
			Debug.Log (item.colliderComponent);
		}
	}
}
