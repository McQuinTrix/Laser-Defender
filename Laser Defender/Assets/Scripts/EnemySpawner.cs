using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xMax;
	private float xMin;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));
		xMax = rightEdge.x;
		xMin = leftEdge.x;
		SpawnUntilFull ();
	}

	void EnemyFormation(){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull(){
		Transform freePos = nextFreePos ();
		if (freePos) {
			GameObject enemy = Instantiate (enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePos;
		}
		if (nextFreePos ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	public void OnDrawGizmos(){
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 3);
		Gizmos.DrawWireCube (pos, new Vector3 (width, height));
	}

	// Update is called once per frame
	void Update () {
		if (movingRight) {
			//transform.position += new Vector3 (speed * Time.deltaTime, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);
		if (leftEdgeOfFormation < xMin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xMax) {
			movingRight = false;
		}

		//Enemies dead checker
		if(AllEnemiesDead()){
			SpawnUntilFull ();
		}
	}

	Transform nextFreePos(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}

		return null;
	}

	bool AllEnemiesDead(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
