using System;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteCardBonus : MonoBehaviour {
	public static InfiniteCardBonus InfiniteCtrl;

	private DateTime unbiasedTimerEndTimestamp;

	void Awake () {
		unbiasedTimerEndTimestamp = this.ReadTimestamp("unbiasedTimer", UnbiasedTime.Instance.Now().AddSeconds(1));
	}

	void Start(){
		if (InfiniteCtrl == null)
		{
			InfiniteCtrl = this;
		}
	}

	void OnApplicationPause (bool paused) {
		if (paused) {
			this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
		}
		else {
			unbiasedTimerEndTimestamp = this.ReadTimestamp("unbiasedTimer", UnbiasedTime.Instance.Now().AddSeconds(60));
		}
	}

	void OnApplicationQuit () {
		this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
	}

	public void AddTime(){
		if (GameController.GameCon.infiniteBonusSevenDaysIsOn == 0) {
			unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now ().AddSeconds (86400);
			this.WriteTimestamp ("unbiasedTimer", unbiasedTimerEndTimestamp);
		}
	}

	public void AddTimeSevenDays(){
		unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(604800);
		this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
	}

//	public void AddSeconds(){
//		unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(5);
//		this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
////		unbiasedTimerEndTimestamp = unbiasedTimerEndTimestamp.AddSeconds(-3600);
////		this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
//	}

	public void RemoveTimer(){
		unbiasedTimerEndTimestamp = UnbiasedTime.Instance.Now().AddSeconds(1);
		this.WriteTimestamp("unbiasedTimer", unbiasedTimerEndTimestamp);
	}

	void OnGUI () {
		// Calculate remaining time
		TimeSpan unbiasedRemaining = unbiasedTimerEndTimestamp - UnbiasedTime.Instance.Now();

		// Unbiased timer gui
		string unbiasedFormatted = "Bonus is inactive";
		if (unbiasedRemaining.TotalSeconds > 0) {
			GameController.GameCon.infiniteBonusIsOn = 1;
			if (GameController.GameCon.premiumAccount == 0) {
				GameController.GameCon.UpdateInfiniteSigns ();
				UIController.UICon.MM_BonusIcon.SetActive (true);
				UIController.UICon.MM_BonusTimerInd.gameObject.SetActive (true);
			}
			if (GameController.GameCon.infiniteBonusSevenDaysIsOn == 1) {
				unbiasedFormatted = string.Format ("{0}d:{1}:{2:D2}:{3:D2}", unbiasedRemaining.Days, unbiasedRemaining.Hours, unbiasedRemaining.Minutes, unbiasedRemaining.Seconds);
			} else {
				unbiasedFormatted = string.Format ("{0}:{1:D2}:{2:D2}", unbiasedRemaining.Hours, unbiasedRemaining.Minutes, unbiasedRemaining.Seconds);
			}
		} else {
			GameController.GameCon.infiniteBonusIsOn = 0;
			GameController.GameCon.infiniteBonusSevenDaysIsOn = 0;
			UIController.UICon.MM_BonusIcon.SetActive (false);
			UIController.UICon.MM_BonusTimerInd.gameObject.SetActive (false);
			if (GameController.GameCon.premiumAccount == 0) {
				UIController.UICon.hideInfiniteSigns ();
			}
		}
		UIController.UICon.MM_BonusTimerInd.text = unbiasedFormatted;
	}

	private DateTime ReadTimestamp (string key, DateTime defaultValue) {
		long tmp = Convert.ToInt64(PlayerPrefs.GetString(key, "0"));
		if ( tmp == 0 ) {
			return defaultValue;
		}
		return DateTime.FromBinary(tmp);
	}

	private void WriteTimestamp (string key, DateTime time) {
		PlayerPrefs.SetString(key, time.ToBinary().ToString());
	}
}