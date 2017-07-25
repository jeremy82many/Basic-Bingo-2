using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour {

	public Text[] highscoreFields;
	public Text[] highscoreFieldsTotalWins;
	public Text[] highscoreFieldsWinStreak;
	public Text[] highscoreFieldsTotalLoses;
	public Text[] highscoreFieldsLoseStreak;
	Highscores highscoresManager;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}


		highscoresManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");
	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFields[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	public void OnHighscoresDownloadedTotalWins(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFieldsTotalWins[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFieldsTotalWins[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	public void OnHighscoresDownloadedWinStreak(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFieldsWinStreak[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFieldsWinStreak[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	public void OnHighscoresDownloadedTotalLoses(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFieldsTotalLoses[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFieldsTotalLoses[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	public void OnHighscoresDownloadedLoseStreak(Highscore[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			highscoreFieldsLoseStreak[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				highscoreFieldsLoseStreak[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			highscoresManager.DownloadHighscoresTotalWins ();
			highscoresManager.DownloadHighscoresWinStreak();
			highscoresManager.DownloadHighscoresTotalLoses();
			highscoresManager.DownloadHighscoresLoseStreak();
			yield return new WaitForSeconds(30);
		}
	}
}