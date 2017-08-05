using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public float damage = 100f;

	public void Hit(){
		Destroy (gameObject);
	}

	public float GetDamage(){
		return damage;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
