using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscores : MonoBehaviour {

	const string privateCode = "hqL8yZ48YUiQSvzM5girmwx5lLVmZcS0CpMNgQlK9hkw";
	const string publicCode = "594a577a758d26034467f4f0";
	const string webURL = "http://dreamlo.com/lb/";

	const string privateCodeTotalWins = "zbG0cbzRlEu3d34NmQUKBAhKaXYA-qkkq0idVVH0Eq0A";
	const string publicCodeTotalWins = "5952259e777fa10d60afdbe0";

	const string privateCodeWinStreak = "BX5-ED9FA0OIeHwvp0eYYQ1M7Z2N-MfUq4VHV6m7XGPw";
	const string publicCodeWinStreak = "595243cb777fa10d60b02c28";

	const string privateCodeTotalLoses = "bFt-lPKDkk-5VvKu4O2OFwtTs9Frt5aEO0Ddk5qhnl-g";
	const string publicCodeTotalLoses = "595244af777fa10d60b02e06";

	const string privateCodeLoseStreak = "9MbbEBlnnUqbaQCLL3RcLwEOYFkfPjFU2dXFkEUzqLhA";
	const string publicCodeLoseStreak = "595244ff777fa10d60b02eb1";

	public Highscore[] highscoresList;
	static Highscores instance;
	DisplayHighscores highscoresDisplay;

	void Awake() {
		instance = this;
		highscoresDisplay = GetComponent<DisplayHighscores> ();
	}

	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	public static void AddNewHighscoreTotalWins(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscoreTotalWins(username,score));
	}

	public static void AddNewHighscoreWinStreak(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscoreWinStreak(username,score));
	}

	public static void AddNewHighscoreTotalLoses(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscoreTotalLoses(username,score));
	}

	public static void AddNewHighscoreLoseStreak(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscoreLoseStreak(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighscores ();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	IEnumerator UploadNewHighscoreTotalWins(string username, int score) {
		WWW www = new WWW(webURL + privateCodeTotalWins + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighscoresTotalWins ();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	IEnumerator UploadNewHighscoreWinStreak(string username, int score) {
		WWW www = new WWW(webURL + privateCodeWinStreak + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighscoresWinStreak ();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	IEnumerator UploadNewHighscoreTotalLoses(string username, int score) {
		WWW www = new WWW(webURL + privateCodeTotalLoses + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighscoresTotalLoses ();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	IEnumerator UploadNewHighscoreLoseStreak(string username, int score) {
		WWW www = new WWW(webURL + privateCodeLoseStreak + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighscoresLoseStreak ();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	public void DownloadHighscoresTotalWins() {
		StartCoroutine("DownloadHighscoresFromDatabaseTotalWins");
	}

	public void DownloadHighscoresWinStreak() {
		StartCoroutine("DownloadHighscoresFromDatabaseWinStreak");
	}

	public void DownloadHighscoresTotalLoses() {
		StartCoroutine("DownloadHighscoresFromDatabaseTotalLoses");
	}

	public void DownloadHighscoresLoseStreak() {
		StartCoroutine("DownloadHighscoresFromDatabaseLoseStreak");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloaded (highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	IEnumerator DownloadHighscoresFromDatabaseTotalWins() {
		WWW www = new WWW(webURL + publicCodeTotalWins + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloadedTotalWins (highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	IEnumerator DownloadHighscoresFromDatabaseWinStreak() {
		WWW www = new WWW(webURL + publicCodeWinStreak + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloadedWinStreak (highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	IEnumerator DownloadHighscoresFromDatabaseTotalLoses() {
		WWW www = new WWW(webURL + publicCodeTotalLoses + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloadedTotalLoses (highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	IEnumerator DownloadHighscoresFromDatabaseLoseStreak() {
		WWW www = new WWW(webURL + publicCodeLoseStreak + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			highscoresDisplay.OnHighscoresDownloadedLoseStreak (highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}