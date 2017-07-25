using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SurveyCreator {

	SerializedObject Survey;

	[MenuItem("Assets/Create/Survey")]
	static void CreateSurvey()
	{
		if (Resources.Load("Prefabs/Survey") != null) 
		{
			
			//GameObject NewSurvey = (GameObject)Editor.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>("Assets/SurveyPlugin/Editor/Resources/Survey.prefab") as GameObject);
			GameObject NewSurvey = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/Survey") as GameObject);
			Undo.RegisterCreatedObjectUndo (NewSurvey, "Created survey");
			NewSurvey.name = "Survey";
			if (Camera.main != null) 
			{
				NewSurvey.GetComponent<Canvas> ().worldCamera = Camera.main;
			}
			if (GameObject.Find ("EventSystem") == null) 
			{
				GameObject EventSystem = (GameObject)Editor.Instantiate(Resources.Load ("Prefabs/EventSystem") as GameObject);
				EventSystem.name = "EventSystem";
			}
		} 
		else if (Resources.Load("Prefabs/Survey") == null) 
		{
			popUp window = ScriptableObject.CreateInstance<popUp>();
			window.content = "Can't access the Survey.prefab\n\nPrefab has been moved or renamed\n ";
			window.ShowAuxWindow ();
		}
	}

	class popUp : EditorWindow
	{
		public string content;

		void OnGUI()
		{
			GUILayout.Label (content,EditorStyles.boldLabel);
		}
	}




}
