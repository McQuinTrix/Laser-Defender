using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//Whenver you want to let a function to be accessed by Unity, make it "public"
	public void LoadLevel(string name){
		Debug.Log ("Level Load requested for "+name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit this game ?");
		Application.Quit ();
	}

	public void LoadNextLevel (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Correct(){
		Debug.Log ("Computer Won!");
		LoadLevel ("Lose");
	}
}