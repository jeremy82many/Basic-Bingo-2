using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Test : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
		other.gameObject.transform.localScale = new Vector3(0.1387803f,0.1387803f,0.1387803f);
    }
    // private Button dailyRewardButton;
    // private string timer = "2.47:00";
    // private DateTime currentTime;

    // void Start () {

    //     currentTime = System.DateTime.Now;
    //     dailyRewardButton = GetComponent<Button>();
        
    //     Debug.Log(currentTime);
    //  }

    //  void Update(){
    //     //StartCoroutine("getTime");
    //  }


 
    //  IEnumerator getTime()
    //  {
    //      WWW www = new WWW("http://www.saadkhawaja.com/gettime.php");
    //      yield return www;
 
    //     if(www.text == timer){
    //         dailyRewardButton.interactable = true;
    //     }
    //      Debug.Log("Time on the server is now: " + www.text);
    //  }

    //  public void claimDailyReward(){
    //     dailyRewardButton.interactable = false;


    //  }

}
/*	     void Start () {
 
         string url = "http://imagestud.com/login.php";
 
         WWWForm form = new WWWForm();
         form.AddField("var1", "value1");
         form.AddField("var2", "value2");
         WWW www = new WWW(url, form);
 
         StartCoroutine(WaitForRequest(www));
     }
 
     IEnumerator WaitForRequest(WWW www)
     {
         yield return www;
 
         // check for errors
         if (www.error == null)
         {
             Debug.Log("WWW Ok!: " + www.text);
         } else {
             Debug.Log("WWW Error: "+ www.error);
         }    
     }    */

//	public Transform startMarker;
//	public Transform endMarker;
//	private float speed = 150f;
//	private float startTime;
//	private float journeyLength;
//
//	float scale = 0.1387803f;
//	float minScale = 0.0987803f;
//	//float maxScale = 0.2387803f;
//	float scaleSpeed = 0.05f;
//
//	void Start() {
//		startTime = Time.time;
//		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
//	}
//	void Update() {
//		float distCovered = (Time.time - startTime) * speed;
//		float fracJourney = distCovered / journeyLength;
//		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
//
//		// Grow
//		scale -= scaleSpeed * Time.deltaTime;
//		// Limit the growth
//		if (scale < minScale) {
//			scale = minScale;
//		}
//		// Apply the new scale
//		transform.localScale = new Vector3(scale, scale, scale);
//	}

//	public string moviePath = "SnickersCommercial.mp4";
//	// Use this for initialization
//	void Start () {
//		Invoke("doPlay",1.0f);
//	}
//	
//	void doPlay()
//	{
//		Debug.Log("Starting Movie: " + moviePath);  
//		Handheld.PlayFullScreenMovie (moviePath, Color.black, FullScreenMovieControlMode.Full);
//		Debug.Log("All Done!"); 
//	}

