using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour {
	public static DailyReward DailyRwd;

	private Text chestTimer;
	private float msToWait = 86400000.0f;
	private Button chestButton;
	private ulong lastChestOpen;

	void Start(){
		if (DailyRwd == null)
		{
			DailyRwd = this;
		}

		chestTimer = GetComponentInChildren<Text>();
		chestButton = GetComponent<Button>();
		lastChestOpen = ulong.Parse(PlayerPrefs.GetString("LastChestOpen"));

		if(!isChestReady())
			chestButton.interactable = false;
	}

	void Update(){
		if (GameController.GameCon.tierTwoPrizeCharmThree == 1) {
			msToWait = 43200000.0f;
		}
		if(!chestButton.IsInteractable()){
			if(isChestReady()){
				chestButton.interactable = true;
				return;
			}

			//Set the timer
			ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
			ulong m = diff / TimeSpan.TicksPerMillisecond;
			float secondsLeft = (float)(msToWait - m) / 1000.0f;

			string r = "";
			//Hours
			r += ((int)secondsLeft / 3600).ToString() + "h ";
			secondsLeft -= ((int)secondsLeft / 3600) * 3600;
			//Minutes
			r += ((int)secondsLeft / 60).ToString("00") + "m ";
			//Seconds
			r += (secondsLeft % 60).ToString("00") + "s"; ;
			chestTimer.text = r;
		}
		if (chestButton.interactable == true) {
			GameController.GameCon.claimFreeCards.SetActive (false);
		} else {
			GameController.GameCon.claimFreeCards.SetActive (true);
		}
	}

	public void ChestClick(){
		lastChestOpen = (ulong)DateTime.Now.Ticks;
		PlayerPrefs.SetString("LastChestOpen", lastChestOpen.ToString());
		chestButton.interactable = false;
		GameController.GameCon.alreadySwiped = true;
	}

	private bool isChestReady(){
		ulong diff = ((ulong)DateTime.Now.Ticks - lastChestOpen);
		ulong m = diff / TimeSpan.TicksPerMillisecond;
		float secondsLeft = (float)(msToWait - m) / 1000.0f;

		if(secondsLeft < 0){
			chestTimer.text = "Daily Reward";
			return true;
		}
			return false;
		
	}
}
