using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GooglePlayGames;

public class ButtonController : MonoBehaviour {
	public static ButtonController BtnCon;
	// Use this for initialization
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (BtnCon == null)
		{
			BtnCon = this;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void testingButton() // testing, remove before final build
	{


	}
	public void testingBallClick()
	{

	}



	// General Buttons
	public void Play()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.Save ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadPlayModeScreen ();
		UIController.UICon.hideNoPrizesScreen();
	}
	public void Done()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.hideNoPrizesScreen();
		GameController.GameCon.updatePlayerBingoCards ();
	}
	public void ClosePopUp()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hidePopup ();
	}
	//Gameplay Screen Specific Buttons
	public void GameoplayStart()
	{
		if (GameController.GameCon.infiniteBonusIsOn == 0 && GameController.GameCon.infiniteBonusSevenDaysIsOn == 0 && GameController.GameCon.premiumAccount == 0) {
			GameController.GameCon.reducePlayersBingoCards ();
		}
		LevelController.LvlCon.Gameplay_StartBalls ();
		GameController.GameCon.isGameStarted = true;
		if (GameController.GameCon.isMultiplayerGame == false) {
			GameController.GameCon.blockers [0].gameObject.SetActive (false);
			GameController.GameCon.StampFreeButton ();
		}
		GameController.GameCon.Save ();
	}
	public void GameplayMenu()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.showGameplayMenu ();
		if (GameController.GameCon.isMultiplayerGame == false) {
			LevelController.LvlCon.Gameplay_StopBalls ();
		}
	}
	public void GameplayBack()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideGameplayMenu ();
		if(GameController.GameCon.isGameStarted && GameController.GameCon.isMultiplayerGame == false)
			LevelController.LvlCon.Gameplay_StartBalls ();
	}
	public void Stamp(GameObject button)
	{
		GameController.GameCon.stampingSound ();
		button.gameObject.transform.GetChild (1).gameObject.SetActive (true);
		if (GameController.GameCon.stampChoice == 4) {
			GameController.GameCon.stampColorPicker ();
			button.gameObject.transform.GetChild (1).GetComponent<Image> ().color = GameController.GameCon.stampColor;
		}
		button.GetComponent<Button> ().interactable = false;
		button.GetComponent<Image> ().color = new Color (255, 255, 255, 0);
	}
	public void GameplayQuit()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.showGameplayQuitGroup ();
		if (GameController.GameCon.isMultiplayerGame == false) {
			UIController.UICon.loadQuitYesSingleplayer ();
		} else{
			UIController.UICon.loadQuitYesMultiplayer ();
		}
	}

	public void GameplayClaim()
	{
		GameController.GameCon.levelWonSound ();
		GameController.GameCon.claimPrizeWin.interactable = false;
		UIController.UICon.StopCoroutine ("Gameplay_BingoAnimation");
		if (!GameController.GameCon.isMultiplayerGame) {
			UIController.UICon.StartCoroutine ("Gameplay_ClaimAnimation");
		} else {
			UIController.UICon.StartCoroutine ("Gameplay_ClaimAnimationMultiplayer");
		}

	}

	public void GameplayPlayAgain()
	{
		if (GameController.GameCon.gamesWonCountTwo >= 3 && GameController.GameCon.neverShowPopup == 0) {
			UIController.UICon.loadEnjoyBasicBingo ();
			UIController.UICon.GameplayYesButton.GetComponent<Button> ().interactable = false;
			UIController.UICon.GameplayNoButton.GetComponent<Button> ().interactable = false;
			GameController.GameCon.gamesWonCountTwo = 4;
			GameController.GameCon.Save ();
		} else {
			if (!GameController.GameCon.bingoCardsRemaining ()) {
				GameController.GameCon.buttonClickSound ();
				UIController.UICon.loadNoMoreCardsGamePlay ();
			} else {
				UIController.UICon.Gameplay_ResetWinGroup ();
				UIController.UICon.Gameplay_ResetPlayGroup ();
				PlaymodeComputer ();
			}
		}
	}

	public void GameplayQuitYes()
	{
		if (GameController.GameCon.gamesWonCountTwo >= 3 && GameController.GameCon.neverShowPopup == 0) {
			UIController.UICon.loadEnjoyBasicBingo ();
			UIController.UICon.GameplayYesButton.GetComponent<Button> ().interactable = false;
			UIController.UICon.GameplayNoButton.GetComponent<Button> ().interactable = false;
			GameController.GameCon.gamesWonCountTwo = 4;
			GameController.GameCon.Save ();
		} else {
			if (GameController.GameCon.isMultiplayerGame) {
				MultiplayerController.Instance.LeaveGame ();
			}
			LevelController.LvlCon.Gameplay_StopBalls ();
			UIController.UICon.Gameplay_ResetWinGroup ();
			UIController.UICon.Gameplay_ResetPlayGroup ();
			GameController.GameCon.buttonClickSound ();
			GameController.GameCon.stopBackgroundMusic ();
			GameController.GameCon.playMenuMusic ();
			UIController.UICon.hideScreens ();
			UIController.UICon.loadMainMenuScreen ();
			UIController.UICon.showGameplayPlayGroup ();
			UIController.UICon.hidGameplayQuitGroup ();
			UIController.UICon.hideGameplayMenu ();
			UIController.UICon.hideMiniScreens ();
			if (GameController.GameCon.multiplayerGameStarted && GameController.GameCon.didPlayerLeft || GameController.GameCon.internetConnIsOn) {
				UIController.UICon.loadDisconnected ();
				GameController.GameCon.remainingBingoCards++;
				GameController.GameCon.updatePlayerBingoCards ();
				GameController.GameCon.Save ();
				GameController.GameCon.multiplayerGameStarted = false;
			} else if (GameController.GameCon.multiplayerGameStarted) {
				UIController.UICon.loadDisconnectedOrLeft ();
				GameController.GameCon.multiplayerGameStarted = false;
			}
		}
	}

	public void GameplayQuitYesSinglePlayer()
	{
		LevelController.LvlCon.Gameplay_StopBalls ();
		UIController.UICon.Gameplay_ResetWinGroup ();
		UIController.UICon.Gameplay_ResetPlayGroup ();
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.stopBackgroundMusic ();
		GameController.GameCon.playMenuMusic ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.showGameplayPlayGroup();
		UIController.UICon.hidGameplayQuitGroup ();
		UIController.UICon.hideGameplayMenu ();
		UIController.UICon.hideMiniScreens ();
	}

	public void GameplayQuitYesSinglePlayerTwo()
	{
		LevelController.LvlCon.Gameplay_StopBalls ();
		UIController.UICon.Gameplay_ResetWinGroup ();
		UIController.UICon.Gameplay_ResetPlayGroup ();
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.stopBackgroundMusic ();
		GameController.GameCon.playMenuMusic ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.showGameplayPlayGroup();
		UIController.UICon.hidGameplayQuitGroup ();
		UIController.UICon.hideGameplayMenu ();
		UIController.UICon.hideMiniScreens ();
		//MultiplayerController.Instance.SignOut ();
		UIController.UICon.hideDisconnectedGamePlay ();
		GameController.GameCon.multiplayerGameStarted = false;
	}

	public void GameplayQuitNo()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideMiniScreens ();
		UIController.UICon.hidGameplayQuitGroup ();
		UIController.UICon.showGameplayMenu ();
	}
	public void GameplayMuteSfx()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteSfx ();
		UIController.UICon.Gameplay_UpdateSfxToggles ();
	}
	public void GameplayMuteCallouts()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteDrawSounds ();
		UIController.UICon.Gameplay_UpdateCalloutToggles ();
	}
	public void GameplayMuteMusic()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteAudio ();
		GameController.GameCon.muteMusicPlayer ();
		UIController.UICon.Gameplay_UpdateMusicToggles ();
	}

	// Main Menu Screem Specific Buttons
	public void MainMenuProfile()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadProfileSreen ();
	}

	public void MainMenuStore()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadShopScreen ();
	}

	public void MainMenuOptions()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptionsScreen ();
		GameController.GameCon.checkForBingoCallsLanguage ();
		GameController.GameCon.UpdateSignInSignOut ();
	}

	//Options Screen Specific Buttons
	public void OptionsSignIn(){
		GameController.GameCon.buttonClickSound ();
		MultiplayerController.Instance.SignInAndStartMPGame ();
	}

	public void OptionsSignOut(){
		GameController.GameCon.buttonClickSound ();
		MultiplayerController.Instance.SignOut ();
	}

	public void OptionsBingoCards ()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.UpdateWonTotalBingoCards ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadBingoCardsScreen ();
	}

	public void OptionsBackgrounds()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.UpdateWonTotalBackgrounds ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadBackgroundsScreen ();
	}

	public void OptionsMoreGames()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.moreGamesButton ();
	}

	public void OptionsRules()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadRulesScreen ();
	}

	public void OptionsCredits()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadCreditsScreen ();
	}
	public void OptionsMuteSfx()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteSfx ();
		UIController.UICon.Options_UpdateSfxToggles ();
	}

	public void OptionsMuteMusic()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteAudio ();
		UIController.UICon.Options_UpdateMusicToggles ();
	}
	public void OptionsMuteBingoCalls()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteDrawSounds ();
		UIController.UICon.Options_UpdateCalloutToggles ();
	}
	public void OptionsEnglishCalls()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.englishCalls = 0;
		GameController.GameCon.Save ();
	}
	public void OptionsSpanishCalls()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.englishCalls = 1;
		GameController.GameCon.Save ();
	}
	//Backgrounds Screen Specific Buttons
	public void BackgroundsLeftArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changeBackgroundLeft ();
	}

	public void BackgroundsRightArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changeBackgroundRight ();
	}

	public void BackgroundsBack()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.Save ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptionsScreen ();
	}

	//BingoCards Screen Specific Buttons
	public void BingoCardsLeftArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changeCardDesignsLeft ();
	}

	public void BingoCardsRightArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changeCardDesignsRight ();
	}

	public void BingoCardsFlip()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.flipCardDesigns ();
	}

	public void BingoCardsBack()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.Save ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptionsScreen ();
	}

	//Rules Screen Specific Buttons
	public void RulesBack()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptionsScreen ();
	}

	//PlayMode Screen Specific Buttons
	public void PlaymodeOnline()
	{
		GameController.GameCon.buttonClickSound ();
		if (GameController.GameCon.bingoCardsRemaining () && !GameController.GameCon.inQueForOnlineMatch && PlayGamesPlatform.Instance.localUser.authenticated) {
			UIController.UICon.loadPlaymodeOnlineGroup ();
			UIController.UICon.hidePlaymodeMainGroup ();
			MultiplayerController.Instance.StartMatchMaking ();
		} else if (!GameController.GameCon.bingoCardsRemaining ()) {
			UIController.UICon.loadNoMoreCardsPlayMode ();
		} else if (GameController.GameCon.inQueForOnlineMatch) {
			UIController.UICon.loadAlreadyInQue ();
		} else {
			UIController.UICon.loadNotSignedIn ();
		}
	}

//	public void SignOut(){
//		if (MultiplayerController.Instance.IsAuthenticated()) {
//				MultiplayerController.Instance.SignOut();
//			}
//	}

	public void PlaymodeComputer()
	{
		if (GameController.GameCon.bingoCardsRemaining () || GameController.GameCon.infiniteBonusIsOn == 1) {
			UIController.UICon.ball = 0;
			GameController.GameCon.levelStartSound ();
			GameController.GameCon.stopMenuMusic ();
			GameController.GameCon.PlayCurrent ();
			GameController.GameCon.Save ();
			UIController.UICon.hideScreens ();
			UIController.UICon.loadGameplayScreen ();
			UIController.UICon.showGameplayPlayGroup ();
			GameController.GameCon.GenerateBallNumbers ();
			GameController.GameCon.resetBallUI ();
			GameController.GameCon.resetBallCounters ();
			GameController.GameCon.PlayerCard.GetComponent<CardController> ().resetButtons ();
			GameController.GameCon.OpponentCard.GetComponent<CardController> ().resetButtons ();
			GameController.GameCon.claimPrizeWin.interactable = true;
			UIController.UICon.GameplayPlayAgainText.GetComponent<Image>().sprite = GameController.GameCon.playAgainCongrats [0];
			GameController.GameCon.doneButtonGameWin.SetActive (false);
			GameController.GameCon.SetRightStamps ();
			if (!GameController.GameCon.isMultiplayerGame) {
				GameController.GameCon.startButton.SetActive (true);
				GameController.GameCon.playerReadyScreen [0].gameObject.SetActive (false);
				GameController.GameCon.playerReadyScreen [1].gameObject.SetActive (false);
				GameController.GameCon.PlayerCard.GetComponent<CardController> ().GenerateCardNumbers ();
				GameController.GameCon.PlayerCard.GetComponent<CardController> ().UpdateCardUI ();
				GameController.GameCon.OpponentCard.GetComponent<CardController> ().GenerateCardNumbers ();
				GameController.GameCon.OpponentCard.GetComponent<CardController> ().UpdateCardUI ();

//				if (GameController.GameCon.flipped) {
//					GameController.GameCon.SetRightStamps ();
//					GameController.GameCon.playerBingoCard [3].sprite = GameController.GameCon.opponentBingoCards [GameController.GameCon.bingoCardCounter];
//					GameController.GameCon.opponentBingoCard [3].sprite = GameController.GameCon.playerBingoCards [GameController.GameCon.bingoCardCounter];
//				} else {
//					GameController.GameCon.playerBingoCard [3].sprite = GameController.GameCon.playerBingoCards [GameController.GameCon.bingoCardCounter];
//					GameController.GameCon.opponentBingoCard [3].sprite = GameController.GameCon.opponentBingoCards [GameController.GameCon.bingoCardCounter];
//				}
			} else {
				GameController.GameCon.myCard.GetComponent<CardController> ().GenerateCardNumbers ();
				GameController.GameCon.myCard.GetComponent<CardController> ().UpdateCardUI ();
			}

		} else {
			GameController.GameCon.buttonClickSound ();
			UIController.UICon.loadNoMoreCardsPlayMode ();
		}
	}

	public void PlaymodeBack()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideMiniScreens ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.hideAlreadyInQue ();
		UIController.UICon.hideNotSignedIn ();
	}

	//Shop Screen Specific Buttons
	public void ShopFreeCards()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadFreeCardScreen ();
		UIController.UICon.hideMiniScreens ();
		GameController.GameCon.UpdateWatchedAds ();
	}

	public void ShopFreeCardsMiniButton()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadFreeCardScreen ();
		UIController.UICon.hideMiniScreens ();
		GameController.GameCon.stopBackgroundMusic ();
		GameController.GameCon.playMenuMusic ();
	}
	public void TryShopBuySku1()
	{
		GameController.GameCon.buttonClickSound ();
		if (GameController.GameCon.infiniteBonusSevenDaysIsOn == 0 && GameController.GameCon.premiumAccount == 0) {
			UIController.UICon.loadAreYouSureOne ();
		} else {
			UIController.UICon.loadCantBuyAgain ();
		}
	}

	public void TryShopBuySku2()
	{
		GameController.GameCon.buttonClickSound ();
		if (GameController.GameCon.premiumAccount == 0) {
			UIController.UICon.loadAreYouSureTwo ();
		} else {
			UIController.UICon.loadCantBuyAgain ();
		}
	}

	public void TryShopBuySku3()
	{
		if (GameController.GameCon.isMasterKeyPurchased == 0) {
			GameController.GameCon.buttonClickSound ();
			UIController.UICon.loadAreYouSureThree ();
		} else {
			UIController.UICon.loadCantBuyAgain ();
		}
	}
	public void ShopBuySku1()
	{
		GameController.GameCon.buttonClickSound ();
		IAPManager.Instance.Buy5CardPack ();
		UIController.UICon.hideMiniScreens ();
	}

	public void ShopBuySku2()
	{
		GameController.GameCon.buttonClickSound ();
		IAPManager.Instance.BuyExtraFreeCards ();
		UIController.UICon.hideMiniScreens ();
	}

	public void ShopBuySku3()
	{
		GameController.GameCon.buttonClickSound ();
		IAPManager.Instance.BuyMasterKey ();
		UIController.UICon.hideMiniScreens ();
	}

	//FreeCard Screen Specific Buttons
	public void FreeCardWatch()
	{
		GameController.GameCon.buttonClickSound ();
		if (GameController.GameCon.infiniteBonusSevenDaysIsOn == 0) {
			GameController.GameCon.ShowRewardedAd ();
			GameController.GameCon.claimFreeCard.interactable = true;
		} else {
			UIController.UICon.loadCantWatchAd ();
		}
	}

	public void FreeCardClaim()
	{
		GameController.GameCon.freeCardRewardSfxSound ();
		GameController.GameCon.adRewardClaim();
		UIController.UICon.StartFCCardAnim ();
		GameController.GameCon.updatePlayerBingoCards();
		GameController.GameCon.claimFreeCard.interactable = false;
		UIController.UICon.WatchAd.GetComponent<Button> ().interactable = true;
		GameController.GameCon.Save ();
	}
	public void FreeCardDone ()
	{
		UIController.UICon.ResetFCCardAnim ();
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.hideNoPrizesScreen();
		GameController.GameCon.updatePlayerBingoCards ();
	}
		
	//Profile Screen Specific Buttons
	public void ProfilePrizes()
	{
		GameController.GameCon.buttonClickSound ();
		if(GameController.GameCon.wonPrizes.Count != 0){
			GameController.GameCon.updatePrizes();
			GameController.GameCon.UpdateWonTotalPrizes ();
			GameController.GameCon.SetMoodRingText ();
			UIController.UICon.hideScreens ();
			UIController.UICon.loadPrizesScreen ();
		}else{
			UIController.UICon.loadNoPrizesScreen();
		}
	}

	public void FindMoodRingPrize(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadPrizesScreen ();
		GameController.GameCon.findMoodRing ();
	}

	public void ProfileLeaderboards()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.toLeaderboards ();
		UIController.UICon.hideNoPrizesScreen();
	}

	//Prizes Screen Specific Buttons
	public void PrizesLeftArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changePrizeLeft ();
	}

	public void PrizesRightArrow()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.changePrizeRight ();
	}

	public void PrizesBack()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadProfileSreen();
	}

	public void PrizesUnlockBackground()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.Prizes_PuzzlePiece.GetComponent<Animator> ().SetTrigger ("Unlock");
		GameController.GameCon.claimBackgroundButton ();
	}

	public void PrizesUnlockCardSet()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.Prizes_CardSet.GetComponent<Animator> ().SetTrigger ("Unlock");
	}

	public void PrizesUseBackground()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.setBackgroundPrizes ();
	}

	public void PrizesUseCardSet()
	{
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.SetCardDesign ();
	}
	//Credits Screen Specific Buttons
	public void CreditsBack()
	{
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadOptionsScreen ();
	}

	// Submenu Specific Buttons
	public void alreadyInQueBack(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideAlreadyInQue ();
	}
	public void notSignedInBack(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideNotSignedIn ();
	}


	public void goToDailyRewards(){
		if (GameController.GameCon.remainingBingoCards != GameController.GameCon.maxRemainingBingoCards) {
			GameController.GameCon.alreadySwiped = false;
			GameController.GameCon.dailyRewardMusic ();
			UIController.UICon.DRCardIndicator.text = ": " + GameController.GameCon.remainingBingoCards.ToString () + 
				"/" + GameController.GameCon.maxRemainingBingoCards.ToString();
			UIController.UICon.hideScreens ();
			UIController.UICon.ResetDRAnim ();
			UIController.UICon.showDailyRewardClaim ();
			GameController.GameCon.rollButton.SetActive (true);
		} else {
			UIController.UICon.loadMaxCardReached ();
		}
	}

	public void claimDailyReward(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.dailyRewardSpin();
		GameController.GameCon.updatePlayerBingoCards();
		GameController.GameCon.enableClaimFreeCards ();
		GameController.GameCon.Save ();
		UIController.UICon.hideScreens();
		UIController.UICon.loadMainMenuScreen();
	}

	public void NoPrizesBack(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideNoPrizesScreen();
	}

	public void nextSong(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.Seek(GameController.SeekDirection.Forward);
		GameController.GameCon.PlayCurrent();
	}

	public void previousSong(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.Seek(GameController.SeekDirection.Backward);
		GameController.GameCon.PlayCurrent();
	}

	public void muteMusicPlayer(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.muteMusicPlayer ();
	}

	public void stopBackgroundMusic(){
		GameController.GameCon.stopBackgroundMusic ();
		GameController.GameCon.playMenuMusic ();
	}

	// Daily Rewards Screen Specific Buttons

	public void DailyRewardsRoll()
	{
		GameController.GameCon.dailyRewardSpin();
		GameController.GameCon.dailyRewardSfxSound();
		UIController.UICon.StartDRAnim ();
	}
	public void DailyRewardsDone()
	{
		UIController.UICon.ResetDRAnim ();
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadMainMenuScreen ();
		UIController.UICon.hideNoPrizesScreen();
		GameController.GameCon.updatePlayerBingoCards ();
	}
	public void SignInMultiplayer(){
		GameController.GameCon.buttonClickSound ();
		MultiplayerController.Instance.SignInAndStartMPGame ();
		UIController.UICon.hideMiniScreens ();
	}
	public void MiniScreensClose(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideMiniScreens ();
	}

	public void LeaveMultiplayerGame(){
		GameController.GameCon.buttonClickSound ();
		MultiplayerController.Instance.LeaveGame ();
		MultiplayerController.Instance.showingWaitingRoom = false;
		GameController.GameCon.inQueForOnlineMatch = false;
		GameController.GameCon.computerPlay.interactable = true;
		UIController.UICon.hideMiniScreens ();
		GameController.GameCon.computerPlay.interactable = true;
		GameController.GameCon.onlinePlay.interactable = true;
		GameController.GameCon.backPlayMode.interactable = true;
		GameController.GameCon.findingOpponent.SetActive (false);
//		if(!UIController.UICon.MainMenuScreen.activeSelf && !UIController.UICon.OptionsScreen.activeSelf && !UIController.UICon.BackgroundsScreen.activeSelf && !UIController.UICon.BingoCardsScreen.activeSelf && !UIController.UICon.RulesScreen.activeSelf && !UIController.UICon.ShopScreen.activeSelf && !UIController.UICon.FreeCardScreen.activeSelf && !UIController.UICon.ProfileScreen.activeSelf && !UIController.UICon.PrizesScreen.activeSelf && !UIController.UICon.CreditsScreen.activeSelf && !UIController.UICon.DailyRewardScreen.activeSelf){
//			UIController.UICon.loadPlayModeScreen();
//		}
	}
	public void CancelGameQuit(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.exitGame = false;
		UIController.UICon.hidePressAgainToExit ();
	}
	public void CloseCantWatchAd(){
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.WatchAd.GetComponent<Button> ().interactable = true;
		UIController.UICon.hideCantWatchAd2 ();
	}
	public void FindPuzzlePiece(){
		if (GameController.GameCon.isMultiplayerGame) {
			MultiplayerController.Instance.LeaveGame ();
		}
		GameController.GameCon.buttonClickSound ();
		UIController.UICon.hideScreens ();
		UIController.UICon.loadPrizesScreen ();
		GameController.GameCon.stopBackgroundMusic ();
		GameController.GameCon.playMenuMusic ();
		if (GameController.GameCon.UnlockBackgroundOrCardset ()) {
			GameController.GameCon.findPuzzlePieces ();
		} else {
			GameController.GameCon.findCardSet ();
		}
	}

	public void UserNameOk(){
		GameController.GameCon.buttonClickSound ();
		GameController.GameCon.userNameOk ();
		UIController.UICon.hideUserName ();
	}

}
