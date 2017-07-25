using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif
public class LevelController : MonoBehaviour {
	public static LevelController LvlCon;


	// Use this for initialization
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (LvlCon == null)
		{
			LvlCon = this;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//GameplayScreen Methods
	private IEnumerator BallDraw() // Coroutine that controls all aspects of the ball.  Put any methods to affect the ball here.
	{
		UIController.UICon.GameplayStartButton.GetComponent<Animator> ().SetTrigger ("Released");
		yield return new WaitForSeconds (1);
		while (true) 
		{
			UIController.UICon.Gameplay_AnimateBall ("Next");
			GameController.GameCon.AssignBallInfo ();
			GameController.GameCon.UpdateBallUI ();
			yield return new WaitForSeconds(4);
		}
	}
	public void Gameplay_StartBalls() // Starts the Coroutine that controls the balls.
	{
		StopCoroutine ("BallDraw");
		StartCoroutine ("BallDraw");

	}
	public void Gameplay_StopBalls() // Stops the Coroutine that Controls the balls.
	{
		StopCoroutine ("BallDraw");
	}
}
