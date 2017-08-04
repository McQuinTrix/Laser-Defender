using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 1000f;

	void OnTriggerEnter2D(Collider2D coll){
		string tag = coll.gameObject.tag;
		ProjectileScript obj = coll.gameObject.GetComponent<ProjectileScript>();
		if (tag == "laser") {
			health -= obj.GetDamage ();
			obj.Hit ();
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
