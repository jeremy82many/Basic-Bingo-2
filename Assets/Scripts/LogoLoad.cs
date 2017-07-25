using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("StartTheGame");
	}

	private IEnumerator StartTheGame(){
		yield return new WaitForSeconds (0.1f);
		SceneManager.LoadScene ("Scene");
	}
}
