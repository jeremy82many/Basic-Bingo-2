using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ParticlePlayground;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {
	public static UIController UICon;

	//Screens
	public GameObject GameplayScreen;
	public GameObject MainMenuScreen;
	public GameObject OptionsScreen;
	public GameObject BackgroundsScreen;
	public GameObject BingoCardsScreen;
	public GameObject RulesScreen;
	public GameObject PlayModeScreen;
	public GameObject ShopScreen;
	public GameObject FreeCardScreen;
	public GameObject ProfileScreen;
	public GameObject PrizesScreen;
	public GameObject CreditsScreen;
	public GameObject WatchAd;
	public GameObject ClaimAdReward;
	public GameObject DailyRewardScreen;
	public GameObject DailyReward;
	public GameObject NoPrizesScreen;
	public GameObject LeaderboardsScreen;

	//Main Menu Screen
	public Text MM_CurCardCountInd;
	public Text MM_MaxCardCountInd;
	public Text MM_CardSeparator;
	public Text MM_BonusTimerInd;
	public GameObject MM_BonusIcon;
	public GameObject MM_InfiniteSignLeft;
	public GameObject MM_InfiniteSignRight;
	public GameObject MM_ThankYou;
	public GameObject BonusTimerWarning;
	public GameObject MM_UserName;

	//Gameplay Screen objects / variables
	public GameObject GameplayMenu;
	public GameObject GameplayQuitGroup;
	public GameObject GameplayMenuButton;
	public GameObject GameplayPlayGroup;
	public GameObject GameplayBallBasket;
	public GameObject GameplayMusicBasket;
	public GameObject GameplayPlayAgainGroup;
	public GameObject GameplayWinGroup;
	public GameObject GameplayStartButton;
	public GameObject GameplayBingoButton;
	public GameObject GameplayGameOverGroup;
	public GameObject GameplayGameOverGroupMultiplayer;
	public PlaygroundParticlesC BingoWinEmitter;
	public PlaygroundParticlesC ClaimPrizeEmitter;
	public PlaygroundParticlesC ClaimPrizeEmitterB;
	public GameObject GameplayClaimButton;
	public GameObject GameplayClaimText;
	public GameObject GameplayBallStopper;
	public GameObject GameplayPlayAgainText;
	public GameObject GameplayYesButton;
	public GameObject GameplayNoButton;
	public GameObject GameplayPrize;
	public GameObject GameplayPrizeText;
	public GameObject GameplayNoMoreCardsGameOver;
	public GameObject QuitYesMultiplayer;
	public GameObject QuitYesSingleplayer;
	public int ball = 0; //Used to control the sequence of the first full cycle of ball animations.

	//PlayMode Screen objects
	public Text PM_CurCardCountInd;
	public Text PM_MaxCardCountInd;
	public GameObject PM_InfiniteSignLeft;
	public GameObject PM_InfiniteSignRight;
	public GameObject PM_CardSeparator;
	public GameObject MainGroup;
	public GameObject OnlineGroup;
	public GameObject AlreadyInQue;
	public GameObject NotSignedIn;
	public GameObject NoMoreCardsPlayMode;
	public GameObject CantStartNormalGame;

	//DailyReward Screen Objects
	public GameObject DailyRewardsCage;
	public GameObject MoodRing;
	public Text BonusText;
	public GameObject LeftIndicator;
	public PlaygroundParticlesC IndicatorEmitter;
	public GameObject RightIndicator;
	public GameObject rollButton;
	public GameObject DRResultsText;
	public GameObject DRButtonbar;
	public Text DRCardIndicator;

	//FreeCards Screen Objects
	public Text FCCardCountInd;
	public Text FCWatchedAdCountInd;
	public GameObject FCCardsImage;
	public GameObject FCBonusIcon;
	public GameObject FCBonusInfo;
	public GameObject FCButtonBar;
	public GameObject CantWatchAd;
	public GameObject CantWatchAd2;
	public GameObject CantBuyAgain;
	public GameObject WatchVideoTxt;
	public GameObject FCCardGroup1;
	public GameObject FCCardGroup2;
	public GameObject FCCardGroup3;
	public GameObject FCIndL3;
	public GameObject FCIndR3;
	public GameObject FCIndL2;
	public GameObject FCIndR2;
	public GameObject FCIndL1;
	public GameObject FCIndR1;
	public GameObject FCCard3_1;
	public GameObject FCCard3_2;
	public GameObject FCCard3_3;
	public GameObject FCCard2_1;
	public GameObject FCCard2_2;
	public GameObject FCCard1_1;

	//BingoCard Screen 
	public Text BingoCards_UnlockedInd;

	public GameObject PressAgainToExit;
	public GameObject Disconnected;
	public GameObject DisconnectedOrLeft;
	public GameObject AreYouSureOne;
	public GameObject AreYouSureTwo;
	public GameObject AreYouSureThree;
	public GameObject DisconnectedGamePlay;
	public GameObject UnlockedBackground;
	public GameObject MaxCardReached;
	public GameObject EnjoyBasicBingo;

	//Profile Screen
	public Text Profile_GamesPlayedInd;
	public Text Profile_GamesWonInd;
	public Text Profile_PrizesCollInd;
	public Text Profile_CurrCardCountInd;

	//Prizes Screen
	public GameObject Prizes_PuzzlePiece;
	public GameObject Prizes_CardSet;
	public GameObject Prizes_LeftCard;
	public GameObject Prizes_RightCard;
	public GameObject Prizes_BckgrdUnlockBtn;
	public GameObject Prizes_BckgrdUseBtn;
	public GameObject Prizes_CardSetUnlockBtn;
	public GameObject Prizes_CardSetUseBtn;
	public Image Prizes_PrizeImage;
	public Text Prizes_PrizeText;
	public PlaygroundParticlesC Prizes_CardSetConfetti;
	public PlaygroundParticlesC Prizes_BoardConfetti;

	//Options Screen
	public Toggle englishBingoCalls;
	public Toggle spanishBingoCalls;
	public GameObject SignIn;
	public GameObject SignOut;

	// Use this for initialization
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (UICon == null)
		{
			UICon = this;
		}


	}

	// General UI Methods
	public void hidePopup()
	{
		EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive(false);
	}
	//Gameplay Screen Methods
	public void showGameplayMenu()
	{
		GameplayMenu.SetActive (true);
		GameplayMenuButton.SetActive (false);
	}
	public void hideGameplayMenu()
	{
		GameplayMenu.SetActive (false);
		GameplayMenuButton.SetActive (true);
	}
	public void showGameplayQuitGroup()
	{
		GameplayQuitGroup.SetActive (true);
		GameplayMenu.SetActive (false);
	}
	public void hidGameplayQuitGroup()
	{
		GameplayQuitGroup.SetActive (false);
		QuitYesMultiplayer.SetActive (false);
		QuitYesSingleplayer.SetActive (false);
		GameplayMenu.SetActive (true);
	}
	public void showGameplayPlayGroup(){
		GameplayPlayGroup.SetActive (true);
	}
	public void hideGameplayPlayGroup(){
		GameplayPlayGroup.SetActive (false);
	}
	public void Gameplay_AnimateBall (string Trigger)
	{
		for (int i = 0; i <= ball; i++)
		{
			GameController.GameCon.Balls [i].GetComponent<Animator> ().SetTrigger (Trigger);
		}

		if (ball < 5) 
		{
			ball += 1;
		}
	}
	public void Gameplay_ResetBallAnim()
	{
		Gameplay_AnimateBall ("Reset");
		ball = 0;
	}
	public void Gameplay_ResetPlayGroup()
	{
		GameplayBallBasket.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayMusicBasket.GetComponent<Animator> ().SetTrigger ("Reset");
		Gameplay_ResetBallAnim ();
		GameplayStartButton.GetComponent<Animator> ().SetTrigger ("Reset");
		GameController.GameCon.PlayerCard.GetComponent<Animator> ().SetTrigger ("Reset");
		GameController.GameCon.OpponentCard.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayBallStopper.SetActive (true);
	}
	public void Gameplay_ResetWinGroup()
	{
		GameplayPlayAgainText.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayYesButton.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayNoButton.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayPrize.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayPrizeText.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayClaimText.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayClaimButton.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayWinGroup.SetActive (false);
	}
	public IEnumerator Gameplay_BingoAnimation_Computer(GameObject[] stamp)
	{
		GameplayMenu.SetActive (false);
		GameplayQuitGroup.SetActive (false);
		GameController.GameCon.playerCardBlocker.gameObject.SetActive (true);
		GameController.GameCon.opponentCardBlocker.gameObject.SetActive (true);
		GameController.GameCon.multiplayerGameStarted = false;
		GameController.GameCon.loseStreakCalculations ();
		LevelController.LvlCon.Gameplay_StopBalls ();
		GameplayMenuButton.GetComponent<Animator> ().SetTrigger ("Hide");
		//Add Stamp Animation Here
		if (BingoButton.BingoBtn.isFourCorners) {
			for (int i = 0; i < 4; i++) {
				stamp [i].GetComponent<Animator> ().SetTrigger ("Start");
			}
		} else {
			for (int i = 0; i < 5; i++) {
				stamp [i].GetComponent<Animator> ().SetTrigger ("Start");
			}
		}

		yield return new WaitForSeconds (0.5f);
	}
		
	public IEnumerator Gameplay_BingoAnimation(GameObject[] stamp)
	{
		GameplayMenu.SetActive (false);
		GameplayQuitGroup.SetActive (false);
		GameController.GameCon.playerCardBlocker.gameObject.SetActive (true);
		GameController.GameCon.opponentCardBlocker.gameObject.SetActive (true);
		GameController.GameCon.multiplayerGameStarted = false;
		GameController.GameCon.gameWon = true;
		GameController.GameCon.winStreakCalculations ();
		LevelController.LvlCon.Gameplay_StopBalls ();
		GameplayMenuButton.GetComponent<Animator> ().SetTrigger ("Hide");
		//Add Stamp Animation Here
		if (BingoButton.BingoBtn.isFourCorners) {
			for (int i = 0; i < 4; i++) {
				stamp [i].GetComponent<Animator> ().SetTrigger ("Start");
			}
		} else {
			for (int i = 0; i < 5; i++) {
				stamp [i].GetComponent<Animator> ().SetTrigger ("Start");
			}
		}

//		if (ComputerOpponent.CompOpp.isGameOver)
//			return;
		yield return new WaitForSeconds (2.5f);
		GameController.GameCon.bingoWinSfxSound ();
		BingoWinEmitter.GetComponent<PlaygroundParticlesC> ().Emit (true);
		GameplayBingoButton.GetComponent<Animator> ().SetTrigger ("Win");
		yield return new WaitForSeconds (3f);
		GameplayBingoButton.GetComponent<Animator> ().SetTrigger ("Reset");
		GameplayBallBasket.GetComponent<Animator> ().SetTrigger ("SlideRight");
		GameplayMusicBasket.GetComponent<Animator> ().SetTrigger ("SlideLeft");
		GameController.GameCon.PlayerCard.GetComponent<Animator> ().SetTrigger ("Hide");
		GameController.GameCon.OpponentCard.GetComponent<Animator> ().SetTrigger ("Hide");
		for (int i = 0; i < 6; i++) {
			GameController.GameCon.Balls [i].GetComponent<Animator> ().SetTrigger ("Win");
		}
		yield return new WaitForSeconds (.5f);
		GameplayWinGroup.SetActive (true);

		GameplayClaimText.GetComponent<Animator> ().SetTrigger ("Show");
		yield return new WaitForSeconds (1);
		GameplayClaimButton.GetComponent<Animator> ().SetTrigger ("Next");
		yield return new WaitForSeconds (.5f);
		ClaimPrizeEmitterB.GetComponent<PlaygroundParticlesC> ().Emit (true);
	}
	public IEnumerator Gameplay_ClaimAnimation()
	{
		
		ClaimPrizeEmitter.GetComponent<PlaygroundParticlesC> ().Emit (true);
		yield return new WaitForSeconds (.2f);
		GameplayClaimButton.GetComponent<Animator> ().SetTrigger ("Hide");
		GameplayBallStopper.SetActive (false);
		GameplayPrize.GetComponent<Animator> ().SetTrigger ("Show");
		GameplayClaimText.GetComponent<Animator> ().SetTrigger ("Reset");
		yield return new WaitForSeconds (.5f);
		GameplayPlayAgainText.GetComponent<Animator> ().SetTrigger ("Show");
		GameplayPrizeText.GetComponent<Animator> ().SetTrigger ("Show");
		yield return new WaitForSeconds (1);
		ClaimPrizeEmitterB.GetComponent<PlaygroundParticlesC> ().Emit(false);
		GameplayYesButton.GetComponent<Animator> ().SetTrigger ("Show");
		GameplayNoButton.GetComponent<Animator> ().SetTrigger ("Show");
		if (GameController.GameCon.HasFivePuzzlePiecesOrCardSets()) {
			loadUnlockedBackground ();
		}
		yield return null;
	}

	public IEnumerator Gameplay_ClaimAnimationMultiplayer()
	{
		ClaimPrizeEmitter.GetComponent<PlaygroundParticlesC> ().Emit (true);
		yield return new WaitForSeconds (.2f);
		GameplayClaimButton.GetComponent<Animator> ().SetTrigger ("Hide");
		GameplayBallStopper.SetActive (false);
		GameplayPrize.GetComponent<Animator> ().SetTrigger ("Show");
		GameplayClaimText.GetComponent<Animator> ().SetTrigger ("Reset");
		yield return new WaitForSeconds (.5f);
		GameplayPlayAgainText.GetComponent<Image>().sprite = GameController.GameCon.playAgainCongrats [1];
		GameplayPlayAgainText.GetComponent<Animator> ().SetTrigger ("Show");
		GameplayPrizeText.GetComponent<Animator> ().SetTrigger ("Show");
		yield return new WaitForSeconds (1);
		ClaimPrizeEmitterB.GetComponent<PlaygroundParticlesC> ().Emit(false);
		GameController.GameCon.doneButtonGameWin.SetActive (true);
		if (GameController.GameCon.tierThreePrizePuzzlePieceOne == 1 && GameController.GameCon.tierThreePrizePuzzlePieceTwo == 1 && GameController.GameCon.tierThreePrizePuzzlePieceThree == 1 && GameController.GameCon.tierThreePrizePuzzlePieceFour == 1) {
			loadUnlockedBackground ();
		}
		yield return null;
	}
	public void Gameplay_UpdateSfxToggles()
	{
		GameController.GameCon.sfxToggle [1].isOn = GameController.GameCon.sfxToggle [0].isOn;
	}
	public void Gameplay_UpdateMusicToggles()
	{
		GameController.GameCon.audioToggle [1].isOn = GameController.GameCon.audioToggle [0].isOn;
	}
	public void Gameplay_UpdateCalloutToggles()
	{
		GameController.GameCon.calloutsToggle [1].isOn = GameController.GameCon.calloutsToggle [0].isOn;
	}

	// Options Screen Methods
	public void Options_UpdateSfxToggles()
	{
		GameController.GameCon.sfxToggle [0].isOn = GameController.GameCon.sfxToggle [1].isOn;
	}
	public void Options_UpdateMusicToggles()
	{
		GameController.GameCon.audioToggle [0].isOn = GameController.GameCon.audioToggle [1].isOn;
	}
	public void Options_UpdateCalloutToggles()
	{
		GameController.GameCon.calloutsToggle [0].isOn = GameController.GameCon.calloutsToggle [1].isOn;
	}
	// Profile Screen Methods

	//Daily Rewards Screen Methods
	public void RollCage()
	{	
		DailyRewardsCage.GetComponent<Animator> ().SetTrigger ("StartRoll");

	}
	public void StopCage()
	{	
		DailyRewardsCage.GetComponent<Animator> ().SetTrigger ("StopRoll");

	}
	public void AnimateDRIndicators()
	{
		LeftIndicator.GetComponent<Animator> ().SetTrigger ("Start");
		RightIndicator.GetComponent<Animator> ().SetTrigger ("Start");
	}
	public void StopDRIndicatorAnim()
	{
		LeftIndicator.GetComponent<Animator> ().SetTrigger ("Stop");
		RightIndicator.GetComponent<Animator> ().SetTrigger ("Stop");
	}
	public IEnumerator RunDRAnim()
	{  
		rollButton.GetComponent<Animator> ().SetTrigger ("Release");
		RollCage ();
		DRButtonbar.GetComponent<Animator> ().SetTrigger ("Hide");
		yield return new WaitForSeconds(5);
		StopCage ();
		DRButtonbar.GetComponent<Animator> ().SetTrigger ("Show");
		LeftIndicator.SetActive (true);
		RightIndicator.SetActive (true);
		AnimateDRIndicators ();
		AnimDRResultText ();
		IndicatorEmitter.GetComponent<PlaygroundParticlesC> ().Emit (true);
		ClaimPrizeEmitterB.GetComponent<PlaygroundParticlesC> ().Emit (true);
		DRCardIndicator.text = ": " + GameController.GameCon.remainingBingoCards.ToString () + 
			"/" + GameController.GameCon.maxRemainingBingoCards.ToString();

	}
	public void ResetDRAnim()
	{
		StopCoroutine ("RunDRAnim");
		ClaimPrizeEmitterB.GetComponent<PlaygroundParticlesC> ().Emit (false);
		rollButton.GetComponent<Animator> ().SetTrigger ("Reset");
		DRResultsText.GetComponent<Animator> ().SetTrigger ("Reset");
		LeftIndicator.GetComponent<Animator> ().SetTrigger ("Reset");
		RightIndicator.GetComponent<Animator> ().SetTrigger ("Reset");
		LeftIndicator.SetActive (false);
		RightIndicator.SetActive (false);
	}
	public void StartDRAnim()
	{
		StopCoroutine ("RunDRAnim");
		StartCoroutine ("RunDRAnim");
	}
	public void AnimDRResultText()
	{
		DRResultsText.GetComponent<Animator> ().SetTrigger ("Start");
	}

	//Free Cards Screen Methods
	public void StartFCIndAnim(GameObject FCIndL, GameObject FCIndR)
	{
		FCIndL.GetComponent<Animator> ().SetTrigger ("StartLeft");
		FCIndR.GetComponent<Animator> ().SetTrigger ("StartRight");
	}
	public void ReverseFCIndAnim(GameObject FCIndL, GameObject FCIndR)
	{
		FCIndL.GetComponent<Animator> ().SetTrigger ("ReverseLeft");
		FCIndR.GetComponent<Animator> ().SetTrigger ("ReverseRight");
	}
	public void StartFCCardAnim()
	{
		if (GameController.GameCon.howManyCardsWon == 3) {
			FCCardGroup3.SetActive (true);
			FCCard3_1.GetComponent<Animator> ().SetTrigger ("Start");
			FCCard3_2.GetComponent<Animator> ().SetTrigger ("Start");
			FCCard3_3.GetComponent<Animator> ().SetTrigger ("Start");

		} else if (GameController.GameCon.howManyCardsWon == 2) {
			FCCardGroup2.SetActive (true);
			FCCard2_1.GetComponent<Animator> ().SetTrigger ("Start");
			FCCard2_2.GetComponent<Animator> ().SetTrigger ("Start");

		} else if (GameController.GameCon.howManyCardsWon == 1) {
			FCCardGroup1.SetActive (true);
			FCCard1_1.GetComponent<Animator> ().SetTrigger ("Start");

		} else {
			return;
		}
	}
	public void ResetFCCardAnim()
	{
		if (GameController.GameCon.howManyCardsWon == 3) {
			FCCard3_1.GetComponent<Animator> ().SetTrigger ("Reset");
			FCCard3_2.GetComponent<Animator> ().SetTrigger ("Reset");
			FCCard3_3.GetComponent<Animator> ().SetTrigger ("Reset");
			FCCardGroup3.SetActive (false);
		} else if (GameController.GameCon.howManyCardsWon == 2) {
			FCCard2_1.GetComponent<Animator> ().SetTrigger ("Reset");
			FCCard2_2.GetComponent<Animator> ().SetTrigger ("Reset");	
			FCCardGroup2.SetActive (false);
		} else if (GameController.GameCon.howManyCardsWon == 1) {
			FCCard1_1.GetComponent<Animator> ().SetTrigger ("Reset");
			FCCardGroup1.SetActive (false);
		} else {
			return;
		}
	}
	public void AnimateWatchVideoText(string trigger)
	{
		WatchVideoTxt.GetComponent<Animator> ().SetTrigger (trigger.ToString ());
	}

	//Screen loading methods
	public void loadGameplayScreen()
	{
		GameplayScreen.SetActive (true);
	}
	public void loadMainMenuScreen()
	{
		MainMenuScreen.SetActive (true);
		MM_CurCardCountInd.text = GameController.GameCon.remainingBingoCards.ToString ();
		MM_MaxCardCountInd.text = GameController.GameCon.maxRemainingBingoCards.ToString();
	}
	public void loadOptionsScreen()
	{
		OptionsScreen.SetActive (true);
	}
	public void loadBackgroundsScreen()
	{
		BackgroundsScreen.SetActive (true);
	}
	public void loadBingoCardsScreen ()
	{
		BingoCardsScreen.SetActive (true);
	}
	public void loadRulesScreen()
	{
		RulesScreen.SetActive (true);
	}
	public void loadPlayModeScreen()
	{
		PlayModeScreen.SetActive (true);
		PM_CurCardCountInd.text = GameController.GameCon.remainingBingoCards.ToString ();
		PM_MaxCardCountInd.text = GameController.GameCon.maxRemainingBingoCards.ToString();
	}
	public void loadShopScreen()
	{
		ShopScreen.SetActive (true);
	}
	public void loadFreeCardScreen()
	{
		FreeCardScreen.SetActive (true);
		FCCardCountInd.text = ": " + GameController.GameCon.remainingBingoCards.ToString () + 
		"/" + GameController.GameCon.maxRemainingBingoCards.ToString();
		if (GameController.GameCon.InfiniteBonusNoteShow ()) {
			loadInfiniteBonusNote ();
		}
	}
	public void loadProfileSreen()
	{
		ProfileScreen.SetActive (true);
		Profile_GamesPlayedInd.text = GameController.GameCon.totalGamesPlayed.ToString ();
		Profile_GamesWonInd.text = GameController.GameCon.gamesWon.ToString ();
		Profile_PrizesCollInd.text = GameController.GameCon.wonPrizes.Count.ToString () +
		"/" + GameController.GameCon.totalPrizeCount.ToString ();
		Profile_CurrCardCountInd.text = GameController.GameCon.remainingBingoCards.ToString () + 
			"/" + GameController.GameCon.maxRemainingBingoCards.ToString();
	}
	public void loadInfiniteBonusNote()
	{
		FCBonusInfo.SetActive (true);
	}
	public void loadPrizesScreen()
	{
		PrizesScreen.SetActive (true);
	}
	public void loadCreditsScreen()
	{
		CreditsScreen.SetActive (true);
	}
	public void hideScreens()
	{
		MainMenuScreen.SetActive (false);
		OptionsScreen.SetActive (false);
		BackgroundsScreen.SetActive (false);
		BingoCardsScreen.SetActive (false);
		RulesScreen.SetActive (false);
		PlayModeScreen.SetActive (false);
		ShopScreen.SetActive (false);
		FreeCardScreen.SetActive (false);
		ProfileScreen.SetActive (false);
		PrizesScreen.SetActive (false);
		GameplayScreen.SetActive (false);
		CreditsScreen.SetActive (false);
		DailyRewardScreen.SetActive(false);
		GameplayGameOverGroup.SetActive(false);
		GameplayGameOverGroupMultiplayer.SetActive (false);
		LeaderboardsScreen.SetActive (false);
	}
	public void hideMiniScreens(){
		AlreadyInQue.SetActive(false);
		NotSignedIn.SetActive(false);
		NoMoreCardsPlayMode.SetActive(false);
		NoPrizesScreen.SetActive (false);
		GameplayNoMoreCardsGameOver.SetActive (false);
		CantStartNormalGame.SetActive (false);
		CantWatchAd.SetActive (false);
		Disconnected.SetActive (false);
		DisconnectedOrLeft.SetActive (false);
		AreYouSureOne.SetActive (false);
		AreYouSureTwo.SetActive (false);
		AreYouSureThree.SetActive (false);
		UnlockedBackground.SetActive (false);
		MaxCardReached.SetActive (false);
		CantBuyAgain.SetActive (false);
		FCBonusInfo.SetActive (false);
	}
		
	public void showClaimAdRewardButton(){
		WatchAd.SetActive(false);
		ClaimAdReward.SetActive(true);
	}

	public void showWatchAdButton(){
		//yield return new WaitForSeconds(3);
		ClaimAdReward.SetActive(false);
		WatchAd.SetActive(true);
	}

	public void showDailyRewardClaim(){
		DailyRewardScreen.SetActive(true);
  	}

  	public void loadNoPrizesScreen(){
  		NoPrizesScreen.SetActive(true);
  	}
  	public void hideNoPrizesScreen(){
  		NoPrizesScreen.SetActive(false);
  	}
		
	public void loadGameOverGroup(){
		GameplayGameOverGroup.SetActive(true);
	}
	public void hideGameOverGroup(){
		GameplayGameOverGroup.SetActive(false);
	}
	public void loadGameOverGroupMultiplayer(){
		GameplayGameOverGroupMultiplayer.SetActive(true);
	}
	public void hideGameOverGroupMultiplayer(){
		GameplayGameOverGroupMultiplayer.SetActive(false);
	}

	public void loadPlaymodeMainGroup(){
		MainGroup.SetActive (true);
	}
	public void hidePlaymodeMainGroup(){
		MainGroup.SetActive (false);
	}
	public void loadPlaymodeOnlineGroup(){
		OnlineGroup.SetActive (true);
	}
	public void hidePlaymodeOnlineGroup(){
		OnlineGroup.SetActive (false);
	}
	public void loadAlreadyInQue(){
		AlreadyInQue.SetActive(true);
	}
	public void hideAlreadyInQue(){
		AlreadyInQue.SetActive(false);
	}
	public void loadNotSignedIn(){
		NotSignedIn.SetActive(true);
	}
	public void hideNotSignedIn(){
		NotSignedIn.SetActive(false);
	}
	public void loadNoMoreCardsPlayMode(){
		NoMoreCardsPlayMode.SetActive(true);
	}
	public void loadNoMoreCardsGamePlay(){
		GameplayNoMoreCardsGameOver.SetActive (true);
	}
	public void loadCantStartNormalGame(){
		CantStartNormalGame.SetActive (true);
	}
	public void loadCantWatchAd(){
		CantWatchAd.SetActive (true);
	}
	public void loadPressAgainToExit(){
		PressAgainToExit.SetActive (true);
	}
	public void hidePressAgainToExit(){
		PressAgainToExit.SetActive (false);
	}
	public void loadDisconnected(){
		Disconnected.SetActive (true);
	}
	public void loadDisconnectedOrLeft(){
		DisconnectedOrLeft.SetActive (true);
	}
	public void loadAreYouSureOne(){
		AreYouSureOne.SetActive (true);
	}
	public void loadAreYouSureTwo(){
		AreYouSureTwo.SetActive (true);
	}
	public void loadAreYouSureThree(){
		AreYouSureThree.SetActive (true);
	}
	public void loadCantWatchAd2(){
		CantWatchAd2.SetActive (true);
	}
	public void hideCantWatchAd2(){
		CantWatchAd2.SetActive (false);
	}
	public void loadQuitYesMultiplayer(){
		QuitYesMultiplayer.SetActive (true);
	}
	public void loadQuitYesSingleplayer(){
		QuitYesSingleplayer.SetActive (true);
	}
	public void loadDisconnectedGamePlay(){
		DisconnectedGamePlay.SetActive (true);
	}
	public void hideDisconnectedGamePlay(){
		DisconnectedGamePlay.SetActive (false);
	}
	public void loadUnlockedBackground(){
		UnlockedBackground.SetActive (true);
	}
	public void loadMaxCardReached(){
		MaxCardReached.SetActive (true);
	}
	public void loadEnjoyBasicBingo(){
		EnjoyBasicBingo.SetActive (true);
	}
	public void loadCantBuyAgain(){
		CantBuyAgain.SetActive (true);
	}
	public void loadThankYou(){
		MM_ThankYou.SetActive (true);
	}
	public void hideCardSeparator(){
		MM_CardSeparator.gameObject.SetActive (false);
		PM_CardSeparator.gameObject.SetActive (false);
	}
	public void hideJustInfiniteSigns(){
		MM_InfiniteSignLeft.gameObject.SetActive (false);
		MM_InfiniteSignRight.gameObject.SetActive (false);
		PM_InfiniteSignLeft.gameObject.SetActive (false);
		PM_InfiniteSignRight.gameObject.SetActive (false);
	}
	public void hideCardCounters(){
		MM_CurCardCountInd.gameObject.SetActive (false);
		MM_MaxCardCountInd.gameObject.SetActive (false);
		PM_CurCardCountInd.gameObject.SetActive (false);
		PM_MaxCardCountInd.gameObject.SetActive (false);
	}
	public void loadInfiniteSigns(){
		hideCardCounters ();
		MM_InfiniteSignLeft.gameObject.SetActive (true);
		MM_InfiniteSignRight.gameObject.SetActive (true);
		PM_InfiniteSignLeft.gameObject.SetActive (true);
		PM_InfiniteSignRight.gameObject.SetActive (true);
	}
	public void hideInfiniteSigns(){
		MM_CurCardCountInd.gameObject.SetActive (true);
		MM_MaxCardCountInd.gameObject.SetActive (true);
		PM_CurCardCountInd.gameObject.SetActive (true);
		PM_MaxCardCountInd.gameObject.SetActive (true);
		hideJustInfiniteSigns ();
	}
	public void loadSignIn(){
		SignIn.SetActive (true);
		SignOut.SetActive (false);
	}
	public void loadSignOut(){
		SignOut.SetActive (true);
		SignIn.SetActive (false);
	}
	public void hideDailyRewardButton(){
		DailyReward.SetActive (false);
	}
	public void hideCardsAdsCounters(){
		FCCardsImage.SetActive(false);
		FCBonusIcon.SetActive(false);
		FCCardCountInd.gameObject.SetActive(false);
		FCWatchedAdCountInd.gameObject.SetActive(false);
	}
	public void loadUserName(){
		MM_UserName.SetActive (true);
	}
	public void hideUserName(){
		MM_UserName.SetActive (false);
	}
	public void loadLeaderboardsIOS(){
		LeaderboardsScreen.SetActive (true);
	}
}