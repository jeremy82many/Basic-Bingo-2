using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;


[CustomEditor(typeof(SurveyController))]
[CanEditMultipleObjects]
public class SurveyInspector : Editor
{
	SerializedProperty Prop_Survey;
	SerializedProperty Prop_SurveyStart;
	SerializedProperty Prop_SurveyEnd;
	SerializedProperty Prop_SurveyQuestion;
	SerializedProperty Prop_Email;
	SerializedProperty Prop_Password;
	SerializedProperty Prop_SMTPaddress;
	SerializedProperty Prop_Port;
	SerializedProperty Prop_Apple;
	SerializedProperty Prop_Yahoo;
	SerializedProperty Prop_Gmail;
	SerializedProperty Prop_Other;
	SerializedProperty other;
	SurveyController Controller;
	bool addButton;
	string emailHost;
	void Awake()
	{
		
	}
	void OnEnable()
	{
		addButton = false;
		Prop_Apple = serializedObject.FindProperty ("Apple");
		Prop_Yahoo = serializedObject.FindProperty ("Yahoo");
		Prop_Gmail = serializedObject.FindProperty ("Gmail");
		Prop_Other = serializedObject.FindProperty ("Other");
		Prop_Email = serializedObject.FindProperty ("Email");
		Prop_Password = serializedObject.FindProperty ("Password");
		Prop_SMTPaddress = serializedObject.FindProperty ("SMTPaddress");
		Prop_Port = serializedObject.FindProperty ("Port");
		Prop_Survey = serializedObject.FindProperty ("Survey");
		Prop_SurveyStart = serializedObject.FindProperty ("SurveyStart");
		Prop_SurveyEnd = serializedObject.FindProperty ("SurveyEnd");
		Prop_SurveyQuestion = serializedObject.FindProperty ("SurveyQuestions");
		Controller = (SurveyController)target;

	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update ();
		EditorGUILayout.BeginVertical (GUI.skin.GetStyle ("GroupBox"));
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.LabelField ("Yahoo", GUILayout.Width (40));
		if (Prop_Yahoo.boolValue = EditorGUILayout.Toggle(Prop_Yahoo.boolValue,GUILayout.MaxWidth(20f))) 
		{
			Prop_Gmail.boolValue = false; Prop_Other.boolValue = false; Prop_Apple.boolValue = false;
			Controller.HostEmail = "Yahoo";
			emailHost = "@Yahoo.com";
		}
		EditorGUILayout.LabelField ("Gmail", GUILayout.Width (37));
		if (Prop_Gmail.boolValue = EditorGUILayout.Toggle(Prop_Gmail.boolValue,GUILayout.MaxWidth(20f))) 
		{
			Prop_Yahoo.boolValue = false; Prop_Other.boolValue = false; Prop_Apple.boolValue = false;
			Controller.HostEmail = "Gmail";
			emailHost = "@Gmail.com";
		}
		EditorGUILayout.LabelField ("Apple", GUILayout.Width (37));
		if (Prop_Apple.boolValue = EditorGUILayout.Toggle(Prop_Apple.boolValue,GUILayout.MaxWidth(20f))) 
		{
			Prop_Yahoo.boolValue = false; Prop_Gmail.boolValue = false; Prop_Other.boolValue = false;
			Controller.HostEmail = "Apple";
			emailHost = "@iCloud";
		}
		EditorGUILayout.LabelField ("Other", GUILayout.Width (37));
		if (Prop_Other.boolValue = EditorGUILayout.Toggle(Prop_Other.boolValue,GUILayout.MaxWidth(20f))) 
		{
			Prop_Yahoo.boolValue = false; Prop_Gmail.boolValue = false; Prop_Apple.boolValue = false;
			Controller.HostEmail = "Other";
			emailHost = "";
		}
		EditorGUILayout.EndHorizontal ();

		if (Controller.Other) 
		{
			EditorGUILayout.PropertyField (Prop_SMTPaddress, new GUIContent ("SMTP Host", "This is the server address of the email client"),GUILayout.Width(300));
			EditorGUILayout.PropertyField (Prop_Port, new GUIContent ("Port #", "This is the port number needed to access the SMTP Host"), GUILayout.Width(200));
		}
		EditorGUILayout.BeginHorizontal ();
		EditorGUILayout.PropertyField (Prop_Email, new GUIContent("Email","This Email will be used to send and recieve the survey results"),GUILayout.Width(260));
		EditorGUILayout.LabelField (emailHost);
		GUILayout.FlexibleSpace ();
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.PropertyField (Prop_Password, new GUIContent ("Password", "Password to the email address that is being used to send the survey results(This information is only used locally within the plugin to allow it to access the given email)"));
		EditorGUILayout.Space ();
		EditorGUILayout.PropertyField (Prop_Survey, new GUIContent ("Survey"));
		EditorGUILayout.PropertyField (Prop_SurveyStart, new GUIContent ("SurveyStart"));
		EditorGUILayout.PropertyField (Prop_SurveyEnd, new GUIContent ("SurveyEnd"));
		EditorGUILayout.EndVertical ();
		EditorDivider ();

		/// This is here to catch if players delete a question from the Heirarchy rather than the inspector.
		/// Checks to see if the array location is null and breaks out of the function to prevent null refrence exceptions and drawing errors.
		for (int i = 0; i < Controller.SurveyQuestions.Count; i++)
		{
			if (Controller.SurveyQuestions[i] == null) 
			{
				Controller.SurveyQuestions.Remove (Controller.SurveyQuestions[i]);
				break;
			}
		}
		EditorGUILayout.BeginVertical (GUI.skin.GetStyle("PreBackground"));
		EditorGUILayout.Space ();
		EditorGUILayout.LabelField ("Survey Questions", EditorStyles.boldLabel);
		EditorGUILayout.Space ();
		for (int i = 0; i < Controller.SurveyQuestions.Count; i++) 
		{
			
			GameObject question = Controller.SurveyQuestions [i];
			SerializedProperty  questions = Prop_SurveyQuestion.GetArrayElementAtIndex (i);
			EditorGUILayout.BeginHorizontal (GUI.skin.GetStyle("box"));
			EditorGUILayout.PropertyField(questions, new GUIContent ("Question " + (i + 1)));

			if (GUILayout.Button ("/\\", GUILayout.Width (20f)) && i > 0) 
			{
				GameObject prevQues = Controller.SurveyQuestions [i - 1];
				Undo.RegisterFullObjectHierarchyUndo (Controller.Survey, "Undo");
				Controller.SurveyQuestions.RemoveAt(i);
				Controller.SurveyQuestions.Insert (i - 1, question);

				if (prevQues.CompareTag ("YesNoQuestion") && prevQues.GetComponent<YesNoQuestion> ().hasFollowUp) 
				{
					question.transform.SetSiblingIndex (question.transform.GetSiblingIndex () - 2);
					if (question.CompareTag ("YesNoQuestion") && question.GetComponent<YesNoQuestion> ().hasFollowUp) 
					{
						GameObject temp = question.GetComponent<YesNoQuestion> ().Question_FollowUp;
						temp.transform.SetSiblingIndex (temp.transform.GetSiblingIndex () - 2);
					}
				} else 
				{
					
					question.transform.SetSiblingIndex (question.transform.GetSiblingIndex () - 1);
					if (question.CompareTag ("YesNoQuestion") && question.GetComponent<YesNoQuestion> ().hasFollowUp) {
						GameObject temp = question.GetComponent<YesNoQuestion> ().Question_FollowUp;
						temp.transform.SetSiblingIndex (temp.transform.GetSiblingIndex () - 1);
					}
				}
			}
			if (GUILayout.Button ("\\/", GUILayout.Width (20f)) && i + 1 < Controller.SurveyQuestions.Count) 
			{
				GameObject nextQues = Controller.SurveyQuestions [i + 1];
				Undo.RegisterFullObjectHierarchyUndo (Controller.Survey, "Undo");
				Controller.SurveyQuestions.RemoveAt(i);
				Controller.SurveyQuestions.Insert (i + 1, question);
				if (nextQues.CompareTag ("YesNoQuestion") && nextQues.GetComponent<YesNoQuestion> ().hasFollowUp) 
				{
					if (question.CompareTag ("YesNoQuestion") && question.GetComponent<YesNoQuestion> ().hasFollowUp) 
					{
						GameObject temp = question.GetComponent<YesNoQuestion> ().Question_FollowUp;
						Undo.RecordObject (temp, "Change position");
						temp.transform.SetSiblingIndex (temp.transform.GetSiblingIndex () + 2);
					}
					Undo.RecordObject (question, "Change position");
					question.transform.SetSiblingIndex (question.transform.GetSiblingIndex () + 2);
				} 
				else 
				{
					if (question.CompareTag ("YesNoQuestion") && question.GetComponent<YesNoQuestion> ().hasFollowUp) 
					{
						GameObject temp = question.GetComponent<YesNoQuestion> ().Question_FollowUp;
						Undo.RecordObject (temp, "Change position");
						temp.transform.SetSiblingIndex (temp.transform.GetSiblingIndex () + 1);
					}
					Undo.RecordObject (question, "Change position");
					question.transform.SetSiblingIndex (question.transform.GetSiblingIndex () + 1);
				}
			}
			if (GUILayout.Button ("x", GUILayout.Width (20f))) 
			{   
				if (question.CompareTag("YesNoQuestion") && question.GetComponent<YesNoQuestion>().Question_FollowUp)
				{
					Undo.RecordObject (question.GetComponent<YesNoQuestion> (), "Delete Question");
					Undo.DestroyObjectImmediate (question.GetComponent<YesNoQuestion> ().Question_FollowUp);		
				}
				Undo.RecordObject (Controller, "Delete Question");
				Controller.SurveyQuestions.Remove (question);
				Undo.DestroyObjectImmediate (question);
				break;
			}
			EditorGUILayout.EndHorizontal();

			if (question != null && question.CompareTag("YesNoQuestion"))
			{   

				YesNoQuestion script = question.GetComponent<YesNoQuestion> ();
				/// This is here to catch if players delete a follow-up question from the Heirarchy rather than the inspector which will prevent the proper button
				/// from displaying.
				/// Checks to see if the reference location is null and sets the appropriate bool to false so the proper button will be shown.
				if (script.Question_FollowUp == null) 
				{
					script.hasFollowUp = false;
				}

				if (script.hasFollowUp == false && script.addingButton == false) 
				{
					if (GUILayout.Button ("Add Follow-Up Question")) 
					{
						script.addingButton = true;
					}
				}

				if (script.hasFollowUp == false && script.addingButton == true) 
				{
					
					GUILayout.BeginHorizontal ();
					GUILayout.FlexibleSpace ();
					if (GUILayout.Button("Long Answer",GUI.skin.GetStyle ("ButtonLeft"), GUILayout.Height(20f), GUILayout.Width(100f)))
					{
						GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Long Answer Question") as GameObject, Controller.Survey.transform,false);
						Undo.RegisterCreatedObjectUndo (temp, "Created question");
						Button btn = temp.GetComponentInChildren<Button> ();
						script.Question_FollowUp = temp;
						script.YesTrg = true;
						temp.name = question.name + " Follow-Up";
						temp.transform.SetSiblingIndex (question.transform.GetSiblingIndex () + 1);
						UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityEngine.Events.UnityAction(Controller.Button_Next));
						script.addingButton = false;
						script.hasFollowUp = true;
					}

					if (GUILayout.Button("Short Answer",GUI.skin.GetStyle ("ButtonMid"), GUILayout.Height(20f), GUILayout.Width(100f)))
					{
						GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Short Answer Question") as GameObject, Controller.Survey.transform,false);
						Undo.RegisterCreatedObjectUndo (temp, "Created question");
						Button btn = temp.GetComponentInChildren<Button> ();
						script.Question_FollowUp = temp;
						script.YesTrg = true;
						temp.name = question.name + " Follow-Up";
						temp.transform.SetSiblingIndex (question.transform.GetSiblingIndex () + 1);
						UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityEngine.Events.UnityAction(Controller.Button_Next));
						script.addingButton = false;
						script.hasFollowUp = true;
					}

					if (GUILayout.Button("Yes/No Answer",GUI.skin.GetStyle ("ButtonRight"), GUILayout.Height(20f), GUILayout.Width(100f)))
					{
						GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Yes_No Question") as GameObject, Controller.Survey.transform, false);
						Undo.RegisterCreatedObjectUndo (temp, "Created question");
						Toggle[] btn = temp.GetComponentsInChildren<Toggle> ();
						script.Question_FollowUp = temp;
						script.YesTrg = true;
						temp.name = question.name + " Follow-Up";
						temp.transform.SetSiblingIndex (question.transform.GetSiblingIndex () + 1);
						for(int t = 0; t < btn.Length; t++)
						{
							if (btn[t].CompareTag("Answer Yes"))
							{
								UnityEditor.Events.UnityEventTools.AddPersistentListener<bool> (btn[t].onValueChanged, new UnityEngine.Events.UnityAction<bool> (Controller.Button_Yes));
							}
							if (btn[t].CompareTag("Answer No"))
							{

								UnityEditor.Events.UnityEventTools.AddPersistentListener<bool> (btn[t].onValueChanged, new UnityEngine.Events.UnityAction<bool> (Controller.Button_No));
							}
						}
						script.addingButton = false;
						script.hasFollowUp = true;
					}
					GUILayout.FlexibleSpace ();
					GUILayout.EndHorizontal ();

				}


				if (script.hasFollowUp == true) 
				{
					GUILayout.BeginHorizontal (GUI.skin.GetStyle("ObjectFieldThumb"));
					GameObject followup = question.GetComponent<YesNoQuestion> ().Question_FollowUp;
					EditorGUILayout.Space ();
					EditorGUILayout.LabelField (new GUIContent("Yes","Choose what answer will trigger this follow-up Question"),GUILayout.Width(25));
					if (question.GetComponent<YesNoQuestion> ().YesTrg = EditorGUILayout.Toggle(question.GetComponent<YesNoQuestion> ().YesTrg,GUILayout.MaxWidth(20)))
					{
						Undo.RecordObject (question.GetComponent<YesNoQuestion> (), "Bool change");
						question.GetComponent<YesNoQuestion> ().NoTrg = false;
					}
					EditorGUILayout.LabelField (new GUIContent("No","Choose what answer will trigger this follow-up Question"),GUILayout.Width(20));
					if (question.GetComponent<YesNoQuestion> ().NoTrg = EditorGUILayout.Toggle(question.GetComponent<YesNoQuestion> ().NoTrg,GUILayout.MaxWidth(20)))
					{	
						Undo.RecordObject (question.GetComponent<YesNoQuestion> (), "Bool change");
						question.GetComponent<YesNoQuestion> ().YesTrg = false;
					}
					EditorGUILayout.ObjectField (followup, typeof(GameObject),true, GUILayout.MaxWidth(100));
					if (GUILayout.Button ("x", GUILayout.Width (20f))) 
					{
						Undo.RecordObject (question.GetComponent<YesNoQuestion>(), "List Change");
						script.hasFollowUp = false;
						script.addingButton = false;
						Undo.DestroyObjectImmediate (followup);
					}

					GUILayout.EndHorizontal ();
				}
			} 
		}
		EditorGUILayout.EndVertical ();
		EditorGUILayout.BeginVertical ();
		EditorGUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if (!addButton) 
		{
			if (GUILayout.Button ("Add Question", GUILayout.Height (30f), GUILayout.Width (100f))) 
			{
				addButton = !addButton;
			}
		}
		if(addButton)
		{
			if (GUILayout.Button("Long Answer",GUI.skin.GetStyle("LargeButtonLeft"), GUILayout.Height(30f), GUILayout.Width(115f)))
			{
				GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Long Answer Question") as GameObject, Controller.Survey.transform,false);
				Undo.RegisterCreatedObjectUndo (temp, "Created question");
				Button btn = temp.GetComponentInChildren<Button> ();
				Controller.SurveyQuestions.Add (temp);
				temp.name = "Question " + Controller.SurveyQuestions.Count.ToString();
				UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityEngine.Events.UnityAction(Controller.Button_Next));
				addButton = !addButton;
			}
			if (GUILayout.Button("Short Answer",GUI.skin.GetStyle("LargeButtonMid"), GUILayout.Height(30f), GUILayout.Width(115f)))
			{
				GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Short Answer Question") as GameObject, Controller.Survey.transform,false);
				Undo.RegisterCreatedObjectUndo (temp, "Created question");
				Button btn = temp.GetComponentInChildren<Button> ();
				Controller.SurveyQuestions.Add (temp);
				temp.name = "Question " + Controller.SurveyQuestions.Count.ToString();
				UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityEngine.Events.UnityAction(Controller.Button_Next));
				addButton = !addButton;
			}
			if (GUILayout.Button("Yes/No Answer",GUI.skin.GetStyle("LargeButtonRight"), GUILayout.Height(30f), GUILayout.Width(115f)))
			{
				GameObject temp = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Questions/Yes_No Question") as GameObject, Controller.Survey.transform,false);
				Undo.RegisterCreatedObjectUndo (temp, "Created question");
				Toggle[] btn = temp.GetComponentsInChildren<Toggle> ();
				Controller.SurveyQuestions.Add (temp);
				temp.name = "Question " + Controller.SurveyQuestions.Count.ToString();
				for (int i = 0; i < btn.Length; i++)
				{
					if (btn[i].CompareTag("Answer Yes"))
					{
						UnityEditor.Events.UnityEventTools.AddPersistentListener<bool> (btn[i].onValueChanged, new UnityEngine.Events.UnityAction<bool> (Controller.Button_Yes));
					}
					if (btn[i].CompareTag("Answer No"))
					{
						
						UnityEditor.Events.UnityEventTools.AddPersistentListener<bool> (btn[i].onValueChanged, new UnityEngine.Events.UnityAction<bool> (Controller.Button_No));
					}
				}
				addButton = !addButton;
			}
		}
		GUILayout.FlexibleSpace ();
		EditorGUILayout.EndHorizontal ();
		EditorGUILayout.EndVertical ();





		serializedObject.ApplyModifiedProperties ();
	}

	void EditorDivider()
	{
		EditorGUILayout.LabelField ("________________________________________________________________________________________________________________________________");
	}

}

