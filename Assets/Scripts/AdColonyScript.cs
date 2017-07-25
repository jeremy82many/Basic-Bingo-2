using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdColonyScript : MonoBehaviour {
	public static AdColonyScript AdColonyCon;
	// Use this for initialization
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (AdColonyCon == null)
		{
			AdColonyCon = this;
		}

	}

	AdColony.InterstitialAd Ad = null;
	private string AppId = "app4df50b5b62ee4e52af";
	private string ZoneId = "vz9347412df9c346418f";

	private void Awake(){
		ConfigureAds ();
	}

	private void IntEventHandler(){

		AdColony.Ads.OnConfigurationCompleted += (List<AdColony.Zone> zones_) => {
			Debug.Log("AdColony.Ads.OnConfigurationCompleted called");
			if (zones_ == null || zones_.Count <= 0) {
				Debug.Log("Configure Failed");
			}
			else {
				Debug.Log("Configure Succeeded.");
			}
		};

		AdColony.Ads.OnRequestInterstitial += (AdColony.InterstitialAd ad_) => {
			Debug.Log("AdColony.Ads.OnRequestInterstitial called");
			Ad = ad_;
		};

		AdColony.Ads.OnRequestInterstitialFailed += () => {
			Debug.Log("AdColony.Ads.OnRequestInterstitialFailed called");
		};

		AdColony.Ads.OnOpened += (AdColony.InterstitialAd ad_) => {
			Debug.Log("AdColony.Ads.OnOpened called");
			RequestAd();
		};

		AdColony.Ads.OnClosed += (AdColony.InterstitialAd ad_) => {
			Debug.Log("AdColony.Ads.OnClosed called, expired: " + ad_.Expired);
		};

		AdColony.Ads.OnExpiring += (AdColony.InterstitialAd ad_) => {
			Debug.Log("AdColony.Ads.OnExpiring called");
			Ad = null;
		};

		AdColony.Ads.OnIAPOpportunity += (AdColony.InterstitialAd ad_, string iapProductId_, AdColony.AdsIAPEngagementType engagement_) => {
			Debug.Log("AdColony.Ads.OnIAPOpportunity called");
		};

		AdColony.Ads.OnCustomMessageReceived += (string type, string message) => {
			Debug.Log(string.Format("AdColony.Ads.OnCustomMessageReceived called\n\ttype: {0}\n\tmessage: {1}", type, message));
		};

		AdColony.Ads.OnRewardGranted += (string zoneId, bool success, string name, int amount) => {
			Debug.Log(string.Format("AdColony.Ads.OnRewardGranted called\n\tzoneId: {0}\n\tsuccess: {1}\n\tname: {2}\n\tamount: {3}", zoneId, success, name, amount));
		};
	}

	void ConfigureAds() {
		Debug.Log("**** Configure ADC SDK ****");

		AdColony.AppOptions appOptions = new AdColony.AppOptions();
		appOptions.UserId = "foo";
		appOptions.AdOrientation = AdColony.AdOrientationType.AdColonyOrientationAll;

		string[] zoneIDs = new string[] { ZoneId };

		AdColony.Ads.Configure(AppId, appOptions, zoneIDs);

		RequestAd ();
	}

	void RequestAd() {
		Debug.Log("**** Request Ad ****");

		AdColony.AdOptions adOptions = new AdColony.AdOptions();
		//adOptions.ShowPrePopup = true;
		//adOptions.ShowPostPopup = true;

		AdColony.Ads.RequestInterstitialAd(ZoneId, adOptions);
		IntEventHandler ();
	}
	 
	public void PlayAd() {
		Debug.Log("**** Play Ad ****");
		if (Ad != null) {
			AdColony.Ads.ShowAd (Ad);
		} else {
			RequestAd ();
		}
	}

	public bool IsAdColonyReady(){
		if (Ad != null) {
			return true;
		} else {
			return false;
		}
	}
}
