using UnityEngine;
using System.Collections;

public class OpponentCarController : MonoBehaviour {

	public Sprite[] carSprites;

	public void SetCarNumber (int carNum) {
		GetComponent<SpriteRenderer>().sprite = carSprites[carNum-1];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
