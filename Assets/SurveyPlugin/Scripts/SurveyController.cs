using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SurveyController : MonoBehaviour {

	public GameObject Survey;
	public GameObject SurveyStart;
	public GameObject SurveyEnd;
	public List<GameObject> SurveyQuestions;
	List<string> Questions;
	List<string> Answers;
	public string Email;
	public string Password;
	public string HostEmail;
	public string SMTPaddress;
	public int Port;
	public bool Yahoo;
	public bool Gmail;
	public bool Other;
	public bool Apple;
	string SurveyResults_String;
	MailMessage message;
	int ActiveQuestion;
	// Use this for initialization
	void Start () 
	{	
		Answers = new List<string>();
		Questions = new List<string> ();
		message = new MailMessage ();
		SurveyStart.SetActive (true);
		ActiveQuestion = 0;
		//StartCoroutine (Timer());
	}

	// Script Methods
	public void ReadySurvey()
	{
		Transform[] temp;
		int QuesCount = SurveyQuestions.Count;
		int CompCount;
		string type;
		for(int i = 0; i < QuesCount; i++) 
		{
			temp = SurveyQuestions[i].GetComponentsInChildren<Transform> (true);
			CompCount = temp.Length;
			for(int t = 0; t < CompCount; t++)
			{
				type = temp[t].tag;
				switch (type) 
				{
				case "Answer String":
					Answers.Add (temp[t].GetComponent<InputField> ().text.ToString());
					break;
				case "Answer Yes":
					if (temp[t].GetComponent<Toggle> ().isOn) 
					{
						Answers.Add ("Yes");
					}
					break;
				case "Answer No":
					if (temp[t].GetComponent<Toggle> ().isOn) 
					{
						Answers.Add ("No");
					}
					break;
				case "Question":
					Questions.Add (temp[t].GetComponent<Text> ().text);
					break;
				}
			}
		}
		Debug.Log (Questions.Count + "\n" + Answers.Count);
	}

	void CreateResults_Txt()
	{
		if (Questions.Count == Answers.Count) 
		{
			using (StreamWriter Survey = File.CreateText (Application.dataPath + "/SurveyResults.txt")) 
			{
				Survey.WriteLine ("Basic Bingo Beta Test Survey");
				for (int i = 0; i < Answers.Count; i++) 
				{
					Survey.WriteLine (Questions [i]);
					Survey.WriteLine (Answers [i]);
				}
			}
		}
	}

	void CreateResults_String()
	{
		if (Questions.Count == Answers.Count) 
		{
			for (int i = 0; i < Answers.Count; i++) 
			{
				SurveyResults_String += "Question " + i.ToString () +
					"\n\n"+ Questions [i]+
					"\n\n"+ Answers [i]+"\n\n";
			}
			Debug.Log (SurveyResults_String);
		}

	}

	void SendEmail()
	{
		//subject of the mail
		string subject = MyEscapeURL("Survey Results");
		//body of the mail which consists of Device Model and its Operating System
		string body = MyEscapeURL(SurveyResults_String +
			"________" +
			"\n\nPlease Do Not Modify This\n\n" +
			"Model: "+SystemInfo.deviceModel+"\n\n"+
			"OS: "+SystemInfo.operatingSystem+"\n\n" +
			"________");
		//Open the Default Mail App
		Application.OpenURL ("mailto:" + Email + "?subject=" + subject + "&body=" + body);
	}  
	IEnumerator SendAutoEmailGmail()
	{
		message.To.Add (Email + "@gmail.com");
		message.Subject = ("Survey Results");
		message.Body = SurveyResults_String + 
			"________" +
			"Model: "+SystemInfo.deviceModel+"\n\n"+
			"OS: "+SystemInfo.operatingSystem+"\n\n" +
			"________";
		message.From = new MailAddress (Email + "@gmail.com");
		SmtpClient smtp = new SmtpClient ("smtp.gmail.com", 587);
		smtp.Credentials = new NetworkCredential (Email + "@gmail.com", Password) as ICredentialsByHost;
		smtp.EnableSsl = true;
		smtp.UseDefaultCredentials = false;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors){
			return true;
		};
		smtp.Send (message);
		Debug.Log ("Sent");
		yield return (null);

	}
	IEnumerator SendAutoEmailYahoo()
	{
		message.To.Add (Email + "@yahoo.com");
		message.Subject = ("Survey Results");
		message.Body = SurveyResults_String +
			"________" +
			"\n\nPlease Do Not Modify This\n\n" +
			"Model: "+SystemInfo.deviceModel+"\n\n"+
			"OS: "+SystemInfo.operatingSystem+"\n\n" +
			"________";;
		message.From = new MailAddress (Email + "@yahoo.com");
		SmtpClient smtp = new SmtpClient ("smtp.mail.yahoo.com", 587);
		smtp.Credentials = new NetworkCredential (Email + "@yahoo.com", Password) as ICredentialsByHost;
		smtp.EnableSsl = true;
		smtp.UseDefaultCredentials = false;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors){
			return true;
		};
		smtp.Send (message);
		Debug.Log ("Sent");
		yield return (null);

	}
	IEnumerator SendAutoEmailApple()
	{
		message.To.Add (Email + "@iCloud.com");
		message.Subject = ("Survey Results");
		message.Body = SurveyResults_String +
			"________" +
			"\n\nPlease Do Not Modify This\n\n" +
			"Model: "+SystemInfo.deviceModel+"\n\n"+
			"OS: "+SystemInfo.operatingSystem+"\n\n" +
			"________";;
		message.From = new MailAddress (Email + "@iCloud.com");
		SmtpClient smtp = new SmtpClient ("smtp.mail.me.com", 587);
		smtp.Credentials = new NetworkCredential (Email + "@iCloud.com", Password) as ICredentialsByHost;
		smtp.EnableSsl = true;
		smtp.UseDefaultCredentials = false;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors){
			return true;
		};
		smtp.Send (message);
		Debug.Log ("Sent");
		yield return (null);

	}
	IEnumerator SendAutoEmailOther()
	{
		message.To.Add (Email);
		message.Subject = ("Survey Results");
		message.Body = SurveyResults_String + 
			"________" +
			"Model: "+SystemInfo.deviceModel+"\n\n"+
			"OS: "+SystemInfo.operatingSystem+"\n\n" +
			"________";
		message.From = new MailAddress (Email);
		SmtpClient smtp = new SmtpClient (SMTPaddress, Port);
		smtp.Credentials = new NetworkCredential (Email, Password) as ICredentialsByHost;
		smtp.EnableSsl = true;
		smtp.UseDefaultCredentials = false;
		ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors){
			return true;
		};
		smtp.Send (message);
		Debug.Log ("Sent");
		yield return (null);

	}
	IEnumerator Timer()
	{
		while (true) 
		{
			yield return new WaitForSeconds (1);
			Debug.Log (SurveyQuestions.Count);
		}

	}
	bool FollowUpCheck()
	{
		GameObject parent = SurveyQuestions [ActiveQuestion]; 
		if (parent.GetComponent<YesNoQuestion>().hasFollowUp) 
		{
			return true;
		}
		else 
		{
			return false;
		}
	}
	void NextQuestion()
	{
		//Debug.Log (SurveyQuestions.Count);
		if (ActiveQuestion + 1 < SurveyQuestions.Count) 
		{
			SurveyQuestions [ActiveQuestion].SetActive (false);
			ActiveQuestion += 1;
			SurveyQuestions [ActiveQuestion].SetActive (true);
		}

		else if (ActiveQuestion + 1 >= SurveyQuestions.Count) 
		{
			SurveyQuestions [ActiveQuestion].SetActive (false);
			SurveyEnd.SetActive (true);
		}
			
	}
	void StartSurvey()
	{
		ActiveQuestion = 0;
		SurveyStart.SetActive (false);
		if (SurveyQuestions.Count > 0) 
		{
			SurveyQuestions [ActiveQuestion].SetActive (true);
		}
		if (SurveyQuestions.Count == 0) 
		{
			SurveyEnd.SetActive (true);
		}
	}
	void EndSurvey()
	{
		ReadySurvey ();
		CreateResults_String ();
		switch (HostEmail) 
		{
		case "Yahoo":
			StartCoroutine ("SendAutoEmailYahoo");
			break;
		case "Gmail":
			StartCoroutine ("SendAutoEmailGmail");
			break;
		case "Other":
			StartCoroutine ("SendAutoEmailOther");
			break;
		}
		Survey.SetActive (false);
	}
	string MyEscapeURL (string url)
	{
		return WWW.EscapeURL (url).Replace ("+", "%20");
	}

	public void OpenStorePage()
	{
		Application.OpenURL("https://goo.gl/sOZnGZ");
	}

	// Button Methods
	public void Button_Close()
	{
		GameController.GameCon.buttonClickSound ();
		Survey.SetActive (false);
	}
	public void Button_CloseMenu()
	{
		GameController.GameCon.buttonClickSound ();
		EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
	}
	public void Button_Next()
	{
		GameController.GameCon.buttonClickSound ();
		NextQuestion ();

	}
	public void Button_Submit()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.neverShowPopup = 1;
		GameController.GameCon.Save ();
		UIController.UICon.GameplayYesButton.GetComponent<Button> ().interactable = true;
		UIController.UICon.GameplayNoButton.GetComponent<Button> ().interactable = true;
		EndSurvey ();

	}
	public void Button_Start()
	{
		GameController.GameCon.buttonClickSound ();
		StartSurvey ();
	}
	public void Button_Yes(bool value)
	{
		GameController.GameCon.buttonClickSound ();
		if (FollowUpCheck () == true) 
		{
			
			bool b = SurveyQuestions [ActiveQuestion].GetComponent<YesNoQuestion> ().YesTrg;
			if (b == true) 
			{
				int insertPoint = ActiveQuestion + 1;
				GameObject followup = SurveyQuestions [ActiveQuestion].GetComponent<YesNoQuestion> ().Question_FollowUp;
				SurveyQuestions.Insert (insertPoint, followup);
			} 
		} 

		NextQuestion ();
		
	}
	public void Button_No(bool val)
	{
		GameController.GameCon.buttonClickSound ();
		if (FollowUpCheck () == true) 
		{
			
			bool b = SurveyQuestions [ActiveQuestion].GetComponent<YesNoQuestion> ().NoTrg;
			if (b == true) 
			{
				int insertPoint = ActiveQuestion + 1;
				GameObject followup = SurveyQuestions [ActiveQuestion].GetComponent<YesNoQuestion> ().Question_FollowUp;
				SurveyQuestions.Insert (insertPoint, followup);
			} 
		} 

		NextQuestion ();
	}
}
