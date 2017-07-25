using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioToggleController : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Toggle()
	{
		GameController.GameCon.sfxToggle [1].isOn = GameController.GameCon.sfxToggle [0].isOn;
	}
}
