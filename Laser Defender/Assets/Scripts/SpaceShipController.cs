using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour {

	private GameObject spaceShip;
	private float speed = 7f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
			moveSpaceShip ();
		}
	}

	void moveSpaceShip(){
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3 (speed * Time.deltaTime,0,0);
		}else if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-speed* Time.deltaTime,0,0);
		}
	}
}
