﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

	private GameObject spaceShip;
	private float speed = 7f;
	float padding = 0.4f;
	float xmin = 0.3f;
	float xmax = 15.7f;
	private float health = 1000f;

	public GameObject projectile;
	public float projectileSpeed;
	public float repeatRate;
	public AudioClip hitAudio;
	public AudioClip destroyAudio;
	public AudioClip laser;

	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
			moveSpaceShip ();
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.00001f, repeatRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void moveSpaceShip(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			//transform.position += new Vector3 (speed * Time.deltaTime,0,0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		}else if (Input.GetKey(KeyCode.RightArrow)) {
			//transform.position += new Vector3 (-speed* Time.deltaTime,0,0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
	}

	void Fire(){
		AudioSource.PlayClipAtPoint (laser, transform.position);
		GameObject beam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		Rigidbody2D rb = beam.GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (0,projectileSpeed);
	}

	void OnTriggerEnter2D(Collider2D coll){
		string tag = coll.gameObject.tag;
		ProjectileScript obj = coll.gameObject.GetComponent<ProjectileScript>();
		Debug.Log (health);
		if (tag == "enemylaser") {
			health -= obj.GetDamage ();
			obj.Hit ();
			AudioSource.PlayClipAtPoint (hitAudio, transform.position);
			if (health <= 0) { 
				Die ();
			}
		}
	}

	void Die(){
		LevelManager level = GameObject.FindGameObjectWithTag("levelmanager").GetComponent<LevelManager> ();
		level.LoadNextLevel ();
		AudioSource.PlayClipAtPoint (destroyAudio, transform.position);
		Destroy (gameObject);
	}
}
