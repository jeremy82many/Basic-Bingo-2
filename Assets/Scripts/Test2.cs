using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Test2 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.transform.localScale = new Vector3(0.1387803f,0.1387803f,0.1387803f);
		other.GetComponentInChildren<Text> ().text = "";
	}
}
