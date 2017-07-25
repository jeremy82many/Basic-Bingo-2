using UnityEngine;
using System;
using UnityEngine.UI;

public class MoodRing : MonoBehaviour {
	public static MoodRing MoodCon;
	//private Text chestTimerr;
	private float msToWaitt = 86400000.0f;//3000.0f;
	//private Button chestButtonn;
	private ulong lastChestOpenn;



	void Start(){
		if (MoodCon == null)
		{
			MoodCon = this;
		}

		//chestTimerr = GetComponent<Text>();
		//chestButtonn = GetComponent<Button>();
		lastChestOpenn = ulong.Parse(PlayerPrefs.GetString("OpenedMoodRing"));

//		if(!isChestReadyy())
//			chestButtonn.interactable = false;
	}

	void Update(){
		
//		if(!chestButtonn.IsInteractable()){
			if(isChestReadyy()){
				//chestButtonn.interactable = true;
				ChestClickMoodRing ();
				Debug.Log(GameController.GameCon.moodRingBonus);
				return;
			}

			//Set the timer
			ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpenn);
			ulong m = diff / TimeSpan.TicksPerMillisecond;
			float secondsLeft = (float)(msToWaitt - m) / 1000.0f;

//			string r = "";
//			//Hours
//			r += ((int)secondsLeft / 3600).ToString() + "h ";
//			secondsLeft -= ((int)secondsLeft / 3600) * 3600;
//			//Minutes
//			r += ((int)secondsLeft / 60).ToString("00") + "m ";
//			//Seconds
//			r += (secondsLeft % 60).ToString("00") + "s"; ;
//			chestTimerr.text = r;
//		}
//		if (chestButtonn.interactable == true) {
//			GameController.GameCon.claimFreeCards.SetActive (false);
//		}
	}

	public void ChestClickMoodRing(){
		lastChestOpenn = (ulong)DateTime.Now.Ticks;
		PlayerPrefs.SetString("OpenedMoodRing", lastChestOpenn.ToString());
		//chestButtonn.interactable = false;

		int randNum = UnityEngine.Random.Range(0,4);
		if (randNum == 0) {
			GameController.GameCon.moodRingBonus = 1;
			GameController.GameCon.moodRingText = GameController.GameCon.moodRingTexts [0];
		} else if (randNum == 1) {
			GameController.GameCon.moodRingBonus = 2;
			GameController.GameCon.moodRingText = GameController.GameCon.moodRingTexts [1];
		} else if (randNum == 2) {
			GameController.GameCon.moodRingBonus = 3;
			GameController.GameCon.moodRingText = GameController.GameCon.moodRingTexts [2];
		} else if (randNum == 3) {
			GameController.GameCon.moodRingBonus = 4;
			GameController.GameCon.moodRingText = GameController.GameCon.moodRingTexts [3];
		}

		GameController.GameCon.Save ();
	}

	private bool isChestReadyy(){
		ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpenn);
		ulong m = diff / TimeSpan.TicksPerMillisecond;
		float secondsLeft = (float)(msToWaitt - m) / 1000.0f;

		if(secondsLeft < 0){
			//chestTimerr.text = "Daily Reward";
			return true;
		}
		return false;

	}	 
}
