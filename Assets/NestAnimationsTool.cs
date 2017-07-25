#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
#endif
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
public class NestAnimationsTool: EditorWindow
{
	

	AnimatorController user_animator;
	AnimationClip user_animation;
	Motion user_motion;
	string clipName;


	// Add menu item named "My Window" to the Window menu
	[MenuItem("Window/NestAnimationsTool")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow.GetWindow(typeof(NestAnimationsTool));

	}

	void OnGUI()
	{
		

		EditorGUILayout.LabelField ("Select Animator");
		user_animator = EditorGUILayout.ObjectField (user_animator, typeof(AnimatorController), false) as AnimatorController;
		GUILayout.Label ("Nest Animations", EditorStyles.boldLabel);
		EditorGUILayout.LabelField ("(Warning! Once created, nested animations cannot be unnested!)");
		EditorGUILayout.LabelField ("Select Clip Name");
		clipName = EditorGUILayout.TextField (clipName);
		if (GUILayout.Button ("Create")) 
		{
			NestAnimations ();
		}
			
		GUILayout.Label ("Delete Animations", EditorStyles.boldLabel);
		EditorGUILayout.LabelField ("Select Animation");
		user_animation  = EditorGUILayout.ObjectField (user_animation , typeof(AnimationClip), false)as AnimationClip;
		if (GUILayout.Button ("Delete")) 
		{
			RemoveAnimation ();
		}

	}
	void NestAnimations()
	{
		
			AnimationClip animationClip = AnimatorController.AllocateAnimatorClip (clipName);
			AssetDatabase.AddObjectToAsset (animationClip, user_animator);
			AssetDatabase.ImportAsset (AssetDatabase.GetAssetPath (user_animator));

	}
	void RemoveAnimation()
	{
		string name = user_animation.name;


			DestroyImmediate (user_animation,true);


		AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(user_animator));
	}
}
#endif