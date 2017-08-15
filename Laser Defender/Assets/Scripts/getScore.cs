using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text> ();
		myText.text = ScoreScript.score.ToString ();
		ScoreScript.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
