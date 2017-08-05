using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 1000f;
	public GameObject projectile;
	public SpaceShipController ss;
	public float projectileSpeed;
	public float repeatRate;

	void OnTriggerEnter2D(Collider2D coll){
		string tag = coll.gameObject.tag;
		ProjectileScript obj = coll.gameObject.GetComponent<ProjectileScript>();
		Debug.Log (coll);
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
		InvokeRepeating ("Fire", (float)Random.Range (0, 1) , repeatRate);
	}
	void Fire(){
		GameObject beam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		Rigidbody2D rb = beam.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0,-projectileSpeed);
	}
}
