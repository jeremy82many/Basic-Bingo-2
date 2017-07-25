using UnityEngine;
using System.Collections;

public enum SwipeDirection{
	None = 0,
	Up = 1,
	Down = 2,
}

public class SwipeManager : MonoBehaviour {

	private static SwipeManager instance;
	public static SwipeManager Instance{get {return instance;}}

	public SwipeDirection Direction { set; get;}

	private Vector3 touchPosition;
	private float swipeResistanceY = 100.0f;

	void Start(){
		instance = this;
	}

	void Update(){
		if (SwipeManager.Instance.IsSwiping (SwipeDirection.Up) && !GameController.GameCon.alreadySwiped) {
			ButtonController.BtnCon.DailyRewardsRoll ();
			DailyReward.DailyRwd.ChestClick ();
			GameController.GameCon.rollButton.SetActive (false);
			GameController.GameCon.alreadySwiped = true;
		}
		if (SwipeManager.Instance.IsSwiping (SwipeDirection.Down) && !GameController.GameCon.alreadySwiped) {
			ButtonController.BtnCon.DailyRewardsRoll ();
			DailyReward.DailyRwd.ChestClick ();
			GameController.GameCon.rollButton.SetActive (false);
			GameController.GameCon.alreadySwiped = true;
		}

		Direction = SwipeDirection.None;

		if (Input.GetMouseButtonDown (0)) {
			touchPosition = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp (0)) {
			Vector2 deltaSwipe = touchPosition - Input.mousePosition;

			if (Mathf.Abs (deltaSwipe.y) > swipeResistanceY) {
				//Swipe on the Y axis
				Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
			}
		}
	}

	public bool IsSwiping(SwipeDirection dir)
	{
		return (Direction & dir) == dir;
	}﻿
}
