using UnityEngine;
using System.Collections;

public class AnimationEventController : MonoBehaviour {

	// This script is specifically for objects that have animation events in their animations, providing a single script that allows the animation access to the 
	// functions it needs since they can only access functions on scripts attached to the target of the animation.  This prevents having to attach copies of unrelated scripts 
	// to objects, just so their animations can access a certain function.
	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = this.GetComponent<Animator>();
	}

	public void Trigger(string trigger)
	{
		animator.SetTrigger (trigger.ToString());
	}

	public void SetActiveFalse()
	{
		gameObject.SetActive (false);
	}
	// Gameplay Screen
	public void Gameplay_StampBlinkSfx()
	{
	}
	// Daily Rewards Screen 
	public void CageStopRoll ()
	{
		animator.SetTrigger ("StopRoll");
	}

	public void CageStartRoll ()
	{
		animator.SetTrigger ("StartRoll");
	}

	public void RewardsIndicatorAnimate()
	{
		animator.SetTrigger ("Start");
	}
	public void RewardsIndicatorStop()
	{
		animator.SetTrigger ("Stop");
	}

	//Prizes Screen
	public void Prizes_CardSetConfetti()
	{
		UIController.UICon.Prizes_CardSetConfetti.Emit (true);
	}
	public void Prizes_ShowCardSetUse()
	{
		UIController.UICon.Prizes_CardSetUseBtn.SetActive (true);
	}
	public void Prizes_ShowBackgroundUse()
	{
		UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
	}
	public void Prizes_HideCardSetUnlock()
	{
		UIController.UICon.Prizes_CardSetUnlockBtn.SetActive (false);
	}
	public void Prizes_HideBckgrdSetUnlock()
	{
		UIController.UICon.Prizes_BckgrdUnlockBtn.SetActive (false);
	}
	public void Prizes_LoadCardsetImage()
	{
		GameController.GameCon.UnlockCardDesign ();
	}
	public void Prizes_PuzzleAnimFinishSfx()
	{
		GameController.GameCon.backgroundSetUnlockSound ();
	}
	public void Prizes_CardSetAnimFinishSfx()
	{
		GameController.GameCon.cardSetUnlockSound ();
	}
	public void Prizes_BoardConfetti()
	{
		UIController.UICon.Prizes_BoardConfetti.Emit (true);
	}
	//Free Cards Screen
	public void FC_UpdateCardCountInd()
	{
		UIController.UICon.FCCardCountInd.text = ": " + GameController.GameCon.remainingBingoCards.ToString () + 
			"/" + GameController.GameCon.maxRemainingBingoCards.ToString();
	}
	public void FC_ShowDoneButton()
	{
		UIController.UICon.FCButtonBar.GetComponent<Animator> ().SetTrigger ("Show");
	}
	public void FC_ShowWatchButton()
	{
		UIController.UICon.showWatchAdButton();
	}
	public void FC_StartTxtIndAnim1()
	{
		UIController.UICon.StartFCIndAnim (UIController.UICon.FCIndL1, UIController.UICon.FCIndR1);
	}
	public void FC_StartTxtIndAnim2()
	{
		UIController.UICon.StartFCIndAnim (UIController.UICon.FCIndL2, UIController.UICon.FCIndR2);
	}
	public void FC_StartTxtIndAnim3()
	{
		UIController.UICon.StartFCIndAnim (UIController.UICon.FCIndL3, UIController.UICon.FCIndR3);
	}
	public void FC_ReverseTxtAnim1()
	{
		UIController.UICon.ReverseFCIndAnim (UIController.UICon.FCIndL1, UIController.UICon.FCIndR1);
	}
	public void FC_ReverseTxtAnim2()
	{
		UIController.UICon.ReverseFCIndAnim (UIController.UICon.FCIndL2, UIController.UICon.FCIndR2);
	}
	public void FC_ReverseTxtAnim3()
	{
		UIController.UICon.ReverseFCIndAnim (UIController.UICon.FCIndL3, UIController.UICon.FCIndR3);
	}
	public void FC_EnlargeWatchVideoTxt()
	{
		UIController.UICon.AnimateWatchVideoText ("Enlarge");
	}
	public void FC_ResetFCAnimations ()
	{
		UIController.UICon.ResetFCCardAnim ();
	}
}
