using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.Advertisements;
using GooglePlayGames.BasicApi.Multiplayer;
using System.Net;

public class GameController : MonoBehaviour, MPUpdateListener  {

	public static GameController GameCon;
	public List<int> UndrawnBallNumbers; // List of the numbers 1-75 in a random order which will represent drawn numbers for balls.  
	public List<int> DrawnBallNumbers; // List of the ball numbers that have been 'drawn' in the game.
	int drawnBallCount;
	public GameObject[] Balls;
	public GameObject PlayerCard;
	public GameObject OpponentCard;
	public Image background;
	public Image backgroundText;
	public List<Sprite> backgrounds;
	public List<Sprite> allBackgrounds;
	public Sprite[] backgroundTexts;
	int backgroundCounter;
	int backgroundChoice;

	public String[] prizeTexts;
	[HideInInspector]
	public int totalPrizeCount = 45; // total number of collectable prizes in the game
	int prizeCounter = 0;

	public Image[] playerBingoCard;
	public Image[] opponentBingoCard;
	private Sprite playerCurrentBingoCard;
	public Image playerBingoCardText;
	private Sprite opponentCurrentBingoCard;
	public List<Sprite> playerBingoCards;
	public List<Sprite> opponentBingoCards;
	public List<Sprite> allPlayerBingoCards;
	public List<Sprite> allOpponentBingoCards;
	public Sprite[] playerBingoCardTexts;
	[HideInInspector]
	public int bingoCardCounter = 0;
	//[HideInInspector]
	public int remainingBingoCards = 10;
	public int maxRemainingBingoCards = 10;
	public Text[] remainingBingoCardsNumber;

	public Toggle[] audioToggle;
	public Toggle[] sfxToggle;
	public Toggle[] calloutsToggle;
	public AudioSource menuMusic;
	public AudioSource buttonClickMusic;
	public AudioSource levelStartMusic;
	public AudioSource levelWonMusic;
	public AudioSource[] bingoDrawSounds;
	public AudioSource[] bingoDrawSoundsSpanish;
	public AudioSource stampSound;
	public AudioSource[] backgroundMusic;
	public AudioSource dailyRewardSound;
	public AudioSource gameOverMusic;
	public AudioSource dailyRewardSfx;
	public AudioSource freeCardRewardSfx;
	public AudioSource bingoWinSfx;
	public AudioSource cardSetUnlockSfx;
	public AudioSource backgroundSetUnlockSfx;

	private int ballCounter2 = 0;

	[HideInInspector]
	public int gamesWon;
	[HideInInspector]
	public int gamesWonCount;
	[HideInInspector]
	public int gamesWonCountTwo;
	private int prizesCollected;
	private int totalPrizes = 44;
	public Text gamesPlayedText;
	public Text gamesWonText;
	public Text prizesCollectedText;
	public Text cardsRemainingText;

	public List<Sprite> tierOnePrizes;
	public List<Sprite> tierTwoPrizes;
	public List<Sprite> tierThreePrizes;
	public List<Sprite> cardDesignPrizes;
	public String[] tierOnePrizesText;
	public String[] tierTwoPrizesText;
	public String[] tierThreePrizesText;
	public String[] cardDesignTexts;
	public String[] backgroundsTexts;
	public List<Sprite> wonPrizes;

	[HideInInspector]
	public bool adWatched = false;
	private string _myParticipantId;
	public Image playerCardBlocker;
	public Image opponentCardBlocker;
	[HideInInspector]
	public bool _multiplayerReady = false;
	public Image[] blockers;
	public GameObject[] allCards;
	[HideInInspector]
	public GameObject myCard;
	[HideInInspector]
	public GameObject theOpponentCard;
	[HideInInspector]
	public bool isMultiplayerGame = false;
	public Image[] playerReadyScreen;
	public string[] players;
	public Button[] imReady;
	public Text[] waitingForOpponent;
	[HideInInspector]
	public float bothPlayersReady = 0;
	[HideInInspector]	
	public float bothPlayersReady2 = 0;
	[HideInInspector]
	public int onlyOnce = 0;
	[HideInInspector]
	public int onlyOnce2 = 0;
	[HideInInspector]
	public int onlyOnce3 = 0;
	[HideInInspector]
	public int onlyOnce4 = 0;
	[HideInInspector]
	public int onlyOnce5 = 0;
	[HideInInspector]
	public Text drawnBallNumberText;


	public List<int> MultiplayerUndrawnBallNumbers;
	[HideInInspector]public int tests1;[HideInInspector]public int tests2;[HideInInspector]public int tests3;[HideInInspector]public int tests4;[HideInInspector]public int tests5;[HideInInspector]public int tests6;[HideInInspector]public int tests7;[HideInInspector]public int tests8;[HideInInspector]public int tests9;[HideInInspector]public int tests10;[HideInInspector]public int tests11;[HideInInspector]public int tests12;[HideInInspector]public int tests13;[HideInInspector]public int tests14;[HideInInspector]public int tests15;[HideInInspector]public int tests16;[HideInInspector]public int tests17;[HideInInspector]public int tests18;[HideInInspector]public int tests19;[HideInInspector]public int tests20;[HideInInspector]public int tests21;[HideInInspector]public int tests22;[HideInInspector]public int tests23;[HideInInspector]public int tests24;[HideInInspector]public int tests25;[HideInInspector]public int tests26;[HideInInspector]public int tests27;[HideInInspector]public int tests28;[HideInInspector]public int tests29;[HideInInspector]public int tests30;[HideInInspector]public int tests31;[HideInInspector]public int tests32;[HideInInspector]public int tests33;[HideInInspector]public int tests34;[HideInInspector]public int tests35;[HideInInspector]public int tests36;[HideInInspector]public int tests37;[HideInInspector]public int tests38;[HideInInspector]public int tests39;[HideInInspector]public int tests40;[HideInInspector]public int tests41;[HideInInspector]public int tests42;[HideInInspector]public int tests43;[HideInInspector]public int tests44;[HideInInspector]public int tests45;[HideInInspector]public int tests46;[HideInInspector]public int tests47;[HideInInspector]public int tests48;[HideInInspector]public int tests49;[HideInInspector]public int tests50;[HideInInspector]public int tests51;[HideInInspector]public int tests52;[HideInInspector]public int tests53;[HideInInspector]public int tests54;[HideInInspector]public int tests55;[HideInInspector]public int tests56;[HideInInspector]public int tests57;[HideInInspector]public int tests58;[HideInInspector]public int tests59;[HideInInspector]public int tests60;[HideInInspector]public int tests61;[HideInInspector]public int tests62;[HideInInspector]public int tests63;[HideInInspector]public int tests64;[HideInInspector]public int tests65;[HideInInspector]public int tests66;[HideInInspector]public int tests67;[HideInInspector]public int tests68;[HideInInspector]public int tests69;[HideInInspector]public int tests70;[HideInInspector]public int tests71;[HideInInspector]public int tests72;[HideInInspector]public int tests73;[HideInInspector]public int tests74;[HideInInspector]public int tests75;

	[HideInInspector]
	public float b1 = 1f;
	[HideInInspector]
	public float b2 = 1f;
	[HideInInspector]
	public float b3 = 1f;
	[HideInInspector]
	public float b4 = 1f;
	[HideInInspector]
	public float b5 = 1f;
	[HideInInspector]
	public float i1 = 1f;
	[HideInInspector]
	public float i2 = 1f;
	[HideInInspector]
	public float i3 = 1f;
	[HideInInspector]
	public float i4 = 1f;
	[HideInInspector]
	public float i5 = 1f;
	[HideInInspector]
	public float n1 = 1f;
	[HideInInspector]
	public float n2 = 1f;
	[HideInInspector]
	public float n3 = 1f;
	[HideInInspector]
	public float n4 = 1f;
	[HideInInspector]
	public float n5 = 1f;
	[HideInInspector]
	public float g1 = 1f;
	[HideInInspector]
	public float g2 = 1f;
	[HideInInspector]
	public float g3 = 1f;
	[HideInInspector]
	public float g4 = 1f;
	[HideInInspector]
	public float g5 = 1f;
	[HideInInspector]
	public float o1 = 1f;
	[HideInInspector]
	public float o2 = 1f;
	[HideInInspector]
	public float o3 = 1f;
	[HideInInspector]
	public float o4 = 1f;
	[HideInInspector]
	public float o5 = 1f;
	[HideInInspector]
	public float test1 = 1;

	[HideInInspector]
	public string firstPlayer;
	public GameObject backgroundScreen;
	[HideInInspector]
	public float gameOver = 0;
	[HideInInspector]
	public float _lastUpdateTime2;
	[HideInInspector]
	public bool inQueForOnlineMatch;
	public Button computerPlay;
	public Button onlinePlay;
	public Button backPlayMode;
	public GameObject findingOpponent;
	[HideInInspector]
	public int stampChoice;
	[HideInInspector]
	public Color stampColor;

	private float _nextBroadcastTime = 0;
	public Sprite[] playerStampSprites;
	public Sprite[] opponentStampSprites;
	public GameObject[] playerStamps;
	public GameObject[] opponentStamps;
	[HideInInspector]
	public bool flipped = false;
	public GameObject[] playerTextPositions;

	public GameObject charmOne;
	public GameObject charmTwo;
	public GameObject charmThree;
	public GameObject charmFour;
	public GameObject charmFive;

	public GameObject claimFreeCards;

	[HideInInspector]
	public int tierOnePrizePaperclip = 0;
	[HideInInspector]
	public int tierOnePrizeWinnersTrophy = 0;
	[HideInInspector]
	public int tierOnePrizeRubiksCube = 0;
	[HideInInspector]
	public int tierOnePrizeChocolateBar = 0;
	[HideInInspector]
	public int tierOnePrizePen = 0;
	[HideInInspector]
	public int tierOnePrizeKeychain = 0;
	[HideInInspector]
	public int tierOnePrizeBeanieHat = 0;
	[HideInInspector]
	public int tierOnePrizeBagOfMarbles = 0;
	[HideInInspector]
	public int tierOnePrizePicTriviaToken = 0;
	[HideInInspector]
	public int tierOnePrizeStandardSolitaireDeckOfCards = 0;
	[HideInInspector]
	public int tierOnePrizeSetOfHighRollersDice = 0;
	[HideInInspector]
	public int tierOnePrizeCoffeeMug = 0;
	[HideInInspector]
	public int tierOnePrizeBearFeetSlippers = 0;
	[HideInInspector]
	public int tierOnePrizeGiantGummyBear = 0;
	[HideInInspector]
	public int tierOnePrizeMylarBalloon = 0;
	[HideInInspector]
	public int tierOnePrizeTeddyBear = 0;
	[HideInInspector]
	public int tierOnePrizeRubberDuck = 0;
	[HideInInspector]
	public int tierOnePrizeMegaSharkTooth = 0;
	[HideInInspector]
	public int tierOnePrizeSunglasses = 0;
	[HideInInspector]
	public int tierOnePrizeSlinky = 0;
	[HideInInspector]
	public int tierOnePrizeChineseFingerTrap = 0;
	[HideInInspector]
	public int tierOnePrizeILoveBingoTShirt = 0;
	[HideInInspector]
	public int tierOnePrizeKazoo = 0;
	[HideInInspector]
	public int tierOnePrizePetRock = 0;
	[HideInInspector]
	public int tierOnePrizeStressBall = 0;
	[HideInInspector]
	public int tierTwoPrizeEmptyCharmBracelet = 0;
	[HideInInspector]
	public int tierTwoPrizeCharmOne = 0;
	[HideInInspector]
	public int tierTwoPrizeCharmTwo = 0;
	[HideInInspector]
	public int tierTwoPrizeCharmThree = 0;
	[HideInInspector]
	public int tierTwoPrizeCharmFour = 0;
	[HideInInspector]
	public int tierTwoPrizeCharmFive = 0;
	[HideInInspector]
	public int tierTwoPrizeClayFlowerPot = 0;
	[HideInInspector]
	public int tierTwoPrizePileOfDirt = 0;
	[HideInInspector]
	public int tierTwoPrizeSpecialSeeds = 0;
	[HideInInspector]
	public int tierTwoPrizeMoodRing = 0;
	[HideInInspector]
	public int tierThreePrizePuzzlePieceOne = 0;
	[HideInInspector]
	public int tierThreePrizePuzzlePieceTwo = 0;
	[HideInInspector]
	public int tierThreePrizePuzzlePieceThree = 0;
	[HideInInspector]
	public int tierThreePrizePuzzlePieceFour = 0;
	[HideInInspector]
	public int tierThreePrizeBlankCard = 0;
	[HideInInspector]
	public int tierThreePrizeInterestingDesignPattern = 0;
	[HideInInspector]
	public int tierThreePrizeMaxCardExtender = 0;

	public enum SeekDirection { Forward, Backward }
	public AudioSource source;
	public List<AudioClip> clips = new List<AudioClip>();
	[SerializeField] [HideInInspector] private int currentIndex = 0;
	public List<String> clipNames = new List<String>();
	public Text clipName;
	[HideInInspector]
	public int randomNumber;
	[HideInInspector]
	public int randomNumber2;
	[HideInInspector]
	public int randomNumber3;
	[HideInInspector]
	public int moodRingBonus;
	public String moodRingText;
	public String[] moodRingTexts;
	public GameObject moodRingBonusButton;
	public GameObject freeCardsDoneButton;
	public List<Image> allPlayerStamps = new List<Image>();
	public List<Image> allOpponentStamps = new List<Image>();
	public List<GameObject> moodRingBonusText = new List<GameObject> ();
	[HideInInspector]
	public int howManyCardsWon;
	[HideInInspector]
	public int howManyCardsWonDR;
	[HideInInspector]
	public bool isGameStarted = false;
	public GameObject rollButton;
	public GameObject startButton;
	[HideInInspector]
	public bool exitGame = false;
	[HideInInspector]
	public bool gameWon = false;
	[HideInInspector]
	public bool didPlayerLeave = false;
	[HideInInspector]
	public int isExtraCardsPurchased = 0;
	[HideInInspector]
	public int isMasterKeyPurchased = 0;
	[HideInInspector]
	public int backgroundOne;
	[HideInInspector]
	public int backgroundTwo;
	[HideInInspector]
	public int backgroundThree;
	[HideInInspector]
	public int backgroundFour;
	[HideInInspector]
	public int backgroundFive;
	[HideInInspector]
	public int backgroundSix;
	[HideInInspector]
	public int backgroundSeven;
	[HideInInspector]
	public int backgroundEight;
	[HideInInspector]
	public int cardDesignOne;
	[HideInInspector]
	public int cardDesignTwo;
	[HideInInspector]
	public int cardDesignThree;
	[HideInInspector]
	public int cardDesignFour;
	[HideInInspector]
	public bool isPaused = false;
	public Button claimPrizeWin;
	public Button claimFreeCard;
	public List<Sprite> playAgainCongrats;
	public GameObject doneButtonGameWin;
	[HideInInspector]
	public float _lastUpdateTime;
	private float _timeOutCheckInterval = 1.0f;
	private float _nextTimeoutCheck = 0.0f;
	private float _timeOutCheckInterval2 = 1.0f;
	private float _nextTimeoutCheck2 = 0.0f;
	[HideInInspector]
	public bool multiplayerGameStarted = false;
	[HideInInspector]
	float timer = 0.0f;
	[HideInInspector]
	public float startTime;
	[HideInInspector]
	public int randomRewardTierThree;
	[HideInInspector]
	public bool didPlayerLeft = false;
	[HideInInspector]
	public bool internetConnIsOn = false;
	[HideInInspector]
	public int totalGamesPlayed;
	[HideInInspector]
	public int winStreak;
	[HideInInspector]
	public int loseStreak;
	[HideInInspector]
	public int winStreakTotal;
	[HideInInspector]
	public int loseStreakTotal;
	public GameObject blocker;
	[HideInInspector]
	public bool lostTheGame;
	[HideInInspector]
	public bool wonTheGame;
	[HideInInspector]
	public int backgroundsUnlocked = 1;
	private int backgroundsTotal = 9;
	[HideInInspector]
	public int bingoCardsUnlocked;
	private int bingoCardsTotal = 5;
	public Text prizesUnlockedTotal;
	public Text backgroundsUnlockedTotal;
	public Text bingoCardsUnlockedTotal;
	public GameObject puzzleOne;
	public GameObject puzzleTwo;
	public GameObject puzzleThree;
	public GameObject puzzleFour;
	[HideInInspector]
	public int neverShowPopup;
	[HideInInspector]
	public int englishCalls;
	[HideInInspector]
	public int howManyAdsWatched;
	[HideInInspector]
	public bool alreadySwiped;
	[HideInInspector]
	public int infiniteBonusNote;
	[HideInInspector]
	public int infiniteBonusIsOn;
	[HideInInspector]
	public int infiniteBonusSevenDaysIsOn;
	[HideInInspector]
	public int premiumAccount;
	private int thankYou;
	public Sprite questionMark;
	[HideInInspector]
	public string userName;
	public Text userNamePlaceholder;
	public Text leaderboardName;
	public string[] leaderboardNames;
	[HideInInspector]
	public int leaderboardCounter;
	public GameObject leaderboardTotalGamesL;
	public GameObject leaderboardTotalGamesR;
	public GameObject leaderboardTotalWinsL;
	public GameObject leaderboardTotalWinsR;
	public GameObject leaderboardWinStreakL;
	public GameObject leaderboardWinStreakR;
	public GameObject leaderboardTotalLosesL;
	public GameObject leaderboardTotalLosesR;
	public GameObject leaderboardLoseStreakL;
	public GameObject leaderboardLoseStreakR;

	public void UpdateReceived(string senderId, float b1, float b2, float b3, float b4, float b5, float i1, float i2, float i3, float i4, float i5, float n1, float n2, float n4, float n5, float g1, float g2, float g3, float g4, float g5, float o1, float o2, float o3, float o4, float o5, float colb1, float colb2, float colb3, float colb4, float colb5, float coli1, float coli2, float coli3, float coli4, float coli5, float coln1, float coln2, float coln3, float coln4, float coln5, float colg1, float colg2, float colg3, float colg4, float colg5, float colo1, float colo2, float colo3, float colo4, float colo5, float bothPlayersReady, float test1, float _lastUpdateTime, float test2, float test3, float test4, float test5, float test6, float test7, float test8, float test9, float test10, float test11, float test12, float test13, float test14, float test15, float test16, float test17, float test18, float test19, float test20, float test21, float test22, float test23, float test24, float test25, float test26, float test27, float test28, float test29, float test30, float test31, float test32, float test33, float test34, float test35, float test36, float test37, float test38, float test39, float test40, float test41, float test42, float test43, float test44, float test45, float test46, float test47, float test48, float test49, float test50, float test51, float test52, float test53, float test54, float test55, float test56, float test57, float test58, float test59, float test60, float test61, float test62, float test63, float test64, float test65, float test66, float test67, float test68, float test69, float test70, float test71, float test72, float test73, float test74, float test75) {
		if (_multiplayerReady) {
			theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (0).GetComponentInChildren<Text>().text = b1.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (1).GetComponentInChildren<Text>().text = b2.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (2).GetComponentInChildren<Text>().text = b3.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (3).GetComponentInChildren<Text>().text = b4.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (4).GetComponentInChildren<Text>().text = b5.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (0).GetComponentInChildren<Text>().text = i1.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (1).GetComponentInChildren<Text>().text = i2.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (2).GetComponentInChildren<Text>().text = i3.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (3).GetComponentInChildren<Text>().text = i4.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (4).GetComponentInChildren<Text>().text = i5.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (0).GetComponentInChildren<Text>().text = n1.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (1).GetComponentInChildren<Text>().text = n2.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (2).GetComponentInChildren<Text>().text = "Free";
			theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (3).GetComponentInChildren<Text>().text = n4.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (4).GetComponentInChildren<Text>().text = n5.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (0).GetComponentInChildren<Text>().text = g1.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (1).GetComponentInChildren<Text>().text = g2.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (2).GetComponentInChildren<Text>().text = g3.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (3).GetComponentInChildren<Text>().text = g4.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (4).GetComponentInChildren<Text>().text = g5.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (0).GetComponentInChildren<Text>().text = o1.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (1).GetComponentInChildren<Text>().text = o2.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (2).GetComponentInChildren<Text>().text = o3.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (3).GetComponentInChildren<Text>().text = o4.ToString();
			theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (4).GetComponentInChildren<Text>().text = o5.ToString();
			b1 = colb1;
			b2 = colb2;
			b3 = colb3;
			b4 = colb4;
			b5 = colb5;
			i1 = coli1;
			i2 = coli2;
			i3 = coli3;
			i4 = coli4;
			i5 = coli5;
			n1 = coln1;
			n2 = coln2;
			n3 = coln3;
			n4 = coln4;
			n5 = coln5;
			g1 = colg1;
			g2 = colg2;
			g3 = colg3;
			g4 = colg4;
			g5 = colg5;
			o1 = colo1;
			o2 = colo2;
			o3 = colo3;
			o4 = colo4;
			o5 = colo5;
			_lastUpdateTime2 = _lastUpdateTime;
			bothPlayersReady2 = bothPlayersReady;

			if(onlyOnce3 == 0){
				tests1 = (int)test1;tests2 = (int)test2;tests3 = (int)test3;tests4 = (int)test4;tests5 = (int)test5;tests6 = (int)test6;tests7 = (int)test7;tests8 = (int)test8;tests9 = (int)test9;tests10 = (int)test10;tests11 = (int)test11;tests12 = (int)test12;tests13 = (int)test13;tests14 = (int)test14;tests15 = (int)test15;tests16 = (int)test16;tests17 = (int)test17;tests18 = (int)test18;tests19 = (int)test19;tests20 = (int)test20;tests21 = (int)test21;tests22 = (int)test22;tests23 = (int)test23;tests24 = (int)test24;tests25 = (int)test25;tests26 = (int)test26;tests27 = (int)test27;tests28 = (int)test28;tests29 = (int)test29;tests30 = (int)test30;tests31 = (int)test31;tests32 = (int)test32;tests33 = (int)test33;tests34 = (int)test34;tests35 = (int)test35;tests36 = (int)test36;tests37 = (int)test37;tests38 = (int)test38;tests39 = (int)test39;tests40 = (int)test40;tests41 = (int)test41;tests42 = (int)test42;tests43 = (int)test43;tests44 = (int)test44;tests45 = (int)test45;tests46 = (int)test46;tests47 = (int)test47;tests48 = (int)test48;tests49 = (int)test49;tests50 = (int)test50;tests51 = (int)test51;tests52 = (int)test52;tests53 = (int)test53;tests54 = (int)test54;tests55 = (int)test55;tests56 = (int)test56;tests57 = (int)test57;tests58 = (int)test58;tests59 = (int)test59;tests60 = (int)test60;tests61 = (int)test61;tests62 = (int)test62;tests63 = (int)test63;tests64 = (int)test64;tests65 = (int)test65;tests66 = (int)test66;tests67 = (int)test67;tests68 = (int)test68;tests69 = (int)test69;tests70 = (int)test70;tests71 = (int)test71;tests72 = (int)test72;tests73 = (int)test73;tests74 = (int)test74;tests75 = (int)test75;
				onlyOnce3++;
			}

			if (theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (0).GetComponentInChildren<Image> ().color.a != b1) {
				theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (0).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (1).GetComponentInChildren<Image> ().color.a != b2) {
				theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (1).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (2).GetComponentInChildren<Image> ().color.a != b3) {
				theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (2).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (3).GetComponentInChildren<Image> ().color.a != b4) {
				theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (3).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (4).GetComponentInChildren<Image> ().color.a != b5) {
				theOpponentCard.transform.GetChild (0).GetChild (0).GetChild (4).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (0).GetComponentInChildren<Image> ().color.a != i1) {
				theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (0).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (1).GetComponentInChildren<Image> ().color.a != i2) {
				theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (1).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (2).GetComponentInChildren<Image> ().color.a != i3) {
				theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (2).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (3).GetComponentInChildren<Image> ().color.a != i4) {
				theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (3).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (4).GetComponentInChildren<Image> ().color.a != i5) {
				theOpponentCard.transform.GetChild (0).GetChild (1).GetChild (4).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (0).GetComponentInChildren<Image> ().color.a != n1) {
				theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (0).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (1).GetComponentInChildren<Image> ().color.a != n2) {
				theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (1).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (2).GetComponentInChildren<Image> ().color.a != n3) {
				theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (2).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (3).GetComponentInChildren<Image> ().color.a != n4) {
				theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (3).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (4).GetComponentInChildren<Image> ().color.a != n5) {
				theOpponentCard.transform.GetChild (0).GetChild (2).GetChild (4).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (0).GetComponentInChildren<Image> ().color.a != g1) {
				theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (0).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (1).GetComponentInChildren<Image> ().color.a != g2) {
				theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (1).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (2).GetComponentInChildren<Image> ().color.a != g3) {
				theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (2).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (3).GetComponentInChildren<Image> ().color.a != g4) {
				theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (3).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (4).GetComponentInChildren<Image> ().color.a != g5) {
				theOpponentCard.transform.GetChild (0).GetChild (3).GetChild (4).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (0).GetComponentInChildren<Image> ().color.a != o1) {
				theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (0).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (1).GetComponentInChildren<Image> ().color.a != o2) {
				theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (1).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (2).GetComponentInChildren<Image> ().color.a != o3) {
				theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (2).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (3).GetComponentInChildren<Image> ().color.a != o4) {
				theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (3).GetComponentInChildren<Button> ().onClick.Invoke ();
			} else if (theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (4).GetComponentInChildren<Image> ().color.a != o5) {
				theOpponentCard.transform.GetChild (0).GetChild (4).GetChild (4).GetComponentInChildren<Button> ().onClick.Invoke ();
			}
		}
	}

/*  use these for "Recent app" button on new Samsung Galaxy phones */
	void OnApplicationPause( bool pauseStatus )
	{
		if (multiplayerGameStarted) {
			UIController.UICon.loadDisconnectedGamePlay ();
			blocker.SetActive (true);
			MultiplayerController.Instance.LeaveGame ();
		}
	}
//
//	void OnApplicationFocus( bool hasFocus )
//	{
//		isPaused = !hasFocus;
//	}
	void Awake(){
		Application.targetFrameRate = 30;
	}

	void Start () 
	{
		MultiplayerController.Instance.updateListener = this;
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (GameCon == null)
		{
			GameCon = this;
		}
		Load ();
		UIController.UICon.MM_CurCardCountInd.text = GameController.GameCon.remainingBingoCards.ToString ();
		UIController.UICon.MM_MaxCardCountInd.text = GameController.GameCon.maxRemainingBingoCards.ToString();
		assignWonPrizes ();
		backgroundUpdater ();
		bingocardsUpdater ();
		SetMoodRingText ();

		if (premiumAccount == 0) {
			UpdateInfiniteSigns ();
		} else {
			UpdateThankYouPremium ();
		}

		if (tierTwoPrizeMoodRing == 1) {
			moodRingBonusButton.SetActive (true);
			for (int i = 0; i < moodRingBonusText.Count; i++) {
				moodRingBonusText [i].SetActive (true);
			}
		}

		if (userName == null) {
			UIController.UICon.loadUserName ();
		}

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		MultiplayerController.Instance.SignInAndStartMPGame ();
		MultiplayerController.Instance.TrySilentSignIn();

		playerCurrentBingoCard = playerBingoCards [bingoCardCounter];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			UIController.UICon.hideScreens ();
			UIController.UICon.loadLeaderboardsIOS ();
//			Debug.Log ("One: " + tierThreePrizePuzzlePieceOne);
//			Debug.Log ("Two: " + tierThreePrizePuzzlePieceTwo);
//			Debug.Log ("Three: " + tierThreePrizePuzzlePieceThree);
//			Debug.Log ("Four: " + tierThreePrizePuzzlePieceFour);
//			if (remainingBingoCards != 0) {
//				remainingBingoCards--;
//				updatePlayerBingoCards ();
//				Save ();
//			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!exitGame) {
				UIController.UICon.loadPressAgainToExit ();
				exitGame = true;
			} else {
				Application.Quit();
			}
		}

		if (_multiplayerReady) {
			DoMultiplayerUpdate();	
		}

		if (bothPlayersReady2 == 2) {
			if (onlyOnce == 0) {
				onlyOnce++;
				for (int i = 0; i < 2; i++) {
					playerReadyScreen [i].gameObject.SetActive (false);
				}
				if (firstPlayer != "firstPlayer") {
					GenerateMultiplayerBallNumbers ();
				}
				ButtonController.BtnCon.GameoplayStart();
				startTime = Time.time;
				_lastUpdateTime = Time.time - startTime;
				multiplayerGameStarted = true;
			}
		}

		if (remainingBingoCards > maxRemainingBingoCards) {
			remainingBingoCards = maxRemainingBingoCards;
			updatePlayerBingoCards();
		}
	}

	public void GenerateMultiplayerBallNumbers(){
		MultiplayerUndrawnBallNumbers = new List<int> ();
		MultiplayerUndrawnBallNumbers.Add (tests1);
		MultiplayerUndrawnBallNumbers.Add (tests2);
		MultiplayerUndrawnBallNumbers.Add (tests3);
		MultiplayerUndrawnBallNumbers.Add (tests4);
		MultiplayerUndrawnBallNumbers.Add (tests5);
		MultiplayerUndrawnBallNumbers.Add (tests6);
		MultiplayerUndrawnBallNumbers.Add (tests7);
		MultiplayerUndrawnBallNumbers.Add (tests8);
		MultiplayerUndrawnBallNumbers.Add (tests9);
		MultiplayerUndrawnBallNumbers.Add (tests10);
		MultiplayerUndrawnBallNumbers.Add (tests11);
		MultiplayerUndrawnBallNumbers.Add (tests12);
		MultiplayerUndrawnBallNumbers.Add (tests13);
		MultiplayerUndrawnBallNumbers.Add (tests14);
		MultiplayerUndrawnBallNumbers.Add (tests15);
		MultiplayerUndrawnBallNumbers.Add (tests16);
		MultiplayerUndrawnBallNumbers.Add (tests17);
		MultiplayerUndrawnBallNumbers.Add (tests18);
		MultiplayerUndrawnBallNumbers.Add (tests19);
		MultiplayerUndrawnBallNumbers.Add (tests20);
		MultiplayerUndrawnBallNumbers.Add (tests21);
		MultiplayerUndrawnBallNumbers.Add (tests22);
		MultiplayerUndrawnBallNumbers.Add (tests23);
		MultiplayerUndrawnBallNumbers.Add (tests24);
		MultiplayerUndrawnBallNumbers.Add (tests25);
		MultiplayerUndrawnBallNumbers.Add (tests26);
		MultiplayerUndrawnBallNumbers.Add (tests27);
		MultiplayerUndrawnBallNumbers.Add (tests28);
		MultiplayerUndrawnBallNumbers.Add (tests29);
		MultiplayerUndrawnBallNumbers.Add (tests30);
		MultiplayerUndrawnBallNumbers.Add (tests31);
		MultiplayerUndrawnBallNumbers.Add (tests32);
		MultiplayerUndrawnBallNumbers.Add (tests33);
		MultiplayerUndrawnBallNumbers.Add (tests34);
		MultiplayerUndrawnBallNumbers.Add (tests35);
		MultiplayerUndrawnBallNumbers.Add (tests36);
		MultiplayerUndrawnBallNumbers.Add (tests37);
		MultiplayerUndrawnBallNumbers.Add (tests38);
		MultiplayerUndrawnBallNumbers.Add (tests39);
		MultiplayerUndrawnBallNumbers.Add (tests40);
		MultiplayerUndrawnBallNumbers.Add (tests41);
		MultiplayerUndrawnBallNumbers.Add (tests42);
		MultiplayerUndrawnBallNumbers.Add (tests43);
		MultiplayerUndrawnBallNumbers.Add (tests44);
		MultiplayerUndrawnBallNumbers.Add (tests45);
		MultiplayerUndrawnBallNumbers.Add (tests46);
		MultiplayerUndrawnBallNumbers.Add (tests47);
		MultiplayerUndrawnBallNumbers.Add (tests48);
		MultiplayerUndrawnBallNumbers.Add (tests49);
		MultiplayerUndrawnBallNumbers.Add (tests50);
		MultiplayerUndrawnBallNumbers.Add (tests51);
		MultiplayerUndrawnBallNumbers.Add (tests52);
		MultiplayerUndrawnBallNumbers.Add (tests53);
		MultiplayerUndrawnBallNumbers.Add (tests54);
		MultiplayerUndrawnBallNumbers.Add (tests55);
		MultiplayerUndrawnBallNumbers.Add (tests56);
		MultiplayerUndrawnBallNumbers.Add (tests57);
		MultiplayerUndrawnBallNumbers.Add (tests58);
		MultiplayerUndrawnBallNumbers.Add (tests59);
		MultiplayerUndrawnBallNumbers.Add (tests60);
		MultiplayerUndrawnBallNumbers.Add (tests61);
		MultiplayerUndrawnBallNumbers.Add (tests62);
		MultiplayerUndrawnBallNumbers.Add (tests63);
		MultiplayerUndrawnBallNumbers.Add (tests64);
		MultiplayerUndrawnBallNumbers.Add (tests65);
		MultiplayerUndrawnBallNumbers.Add (tests66);
		MultiplayerUndrawnBallNumbers.Add (tests67);
		MultiplayerUndrawnBallNumbers.Add (tests68);
		MultiplayerUndrawnBallNumbers.Add (tests69);
		MultiplayerUndrawnBallNumbers.Add (tests70);
		MultiplayerUndrawnBallNumbers.Add (tests71);
		MultiplayerUndrawnBallNumbers.Add (tests72);
		MultiplayerUndrawnBallNumbers.Add (tests73);
		MultiplayerUndrawnBallNumbers.Add (tests74);
		MultiplayerUndrawnBallNumbers.Add (tests75);
	}

	public void GenerateBallNumbers() // Creates a list of non-repeating numbers 1-75 in a random order to be used for drawn balls.  
	{
		List<int> tempList = new List<int>();
		UndrawnBallNumbers = new List<int> ();
		for(int i = 1; i < 76; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 75; i ++)
		{
			int ranNum = tempList[UnityEngine.Random.Range(0,tempList.Count)];
			UndrawnBallNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	public void LeftRoomConfirmed() {
		MultiplayerController.Instance.updateListener = null;
		if (!gameWon && UIController.UICon.GameplayPlayGroup.activeSelf) {
			ButtonController.BtnCon.GameplayQuitYes ();
		} else {
			return;
		}
	}

	public void PlayerLeftRoom(string participantId) {
		if (!gameWon && UIController.UICon.GameplayPlayGroup.activeSelf) {
			MultiplayerController.Instance.LeaveGame ();
			didPlayerLeft = true;
		} else {
			return;
		}
	}

	public void DoMultiplayerUpdate(){
		if (Time.time > _nextTimeoutCheck) {
			CheckForTimeOuts();
			_nextTimeoutCheck = Time.time + _timeOutCheckInterval;
		}
		if (Time.time > _nextBroadcastTime) {
			MultiplayerController.Instance.SendMyUpdate (float.Parse (myCard.transform.GetChild (0).GetChild (0).GetChild (0).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (0).GetChild (1).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (0).GetChild (2).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (0).GetChild (3).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (0).GetChild (4).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (1).GetChild (0).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (1).GetChild (1).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (1).GetChild (2).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (1).GetChild (3).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (1).GetChild (4).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (2).GetChild (0).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (2).GetChild (1).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (2).GetChild (3).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (2).GetChild (4).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (3).GetChild (0).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (3).GetChild (1).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (3).GetChild (2).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (3).GetChild (3).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (3).GetChild (4).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (4).GetChild (0).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (4).GetChild (1).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (4).GetChild (2).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (4).GetChild (3).GetComponentInChildren<Text> ().text),
				float.Parse (myCard.transform.GetChild (0).GetChild (4).GetChild (4).GetComponentInChildren<Text> ().text),
				myCard.transform.GetChild (0).GetChild (0).GetChild (0).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (0).GetChild (1).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (0).GetChild (2).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (0).GetChild (3).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (0).GetChild (4).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (1).GetChild (0).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (1).GetChild (1).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (1).GetChild (2).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (1).GetChild (3).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (1).GetChild (4).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (2).GetChild (0).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (2).GetChild (1).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (2).GetChild (2).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (2).GetChild (3).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (2).GetChild (4).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (3).GetChild (0).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (3).GetChild (1).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (3).GetChild (2).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (3).GetChild (3).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (3).GetChild (4).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (4).GetChild (0).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (4).GetChild (1).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (4).GetChild (2).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (4).GetChild (3).GetComponentInChildren<Image> ().color,
				myCard.transform.GetChild (0).GetChild (4).GetChild (4).GetComponentInChildren<Image> ().color,
				bothPlayersReady,
				(float)UndrawnBallNumbers [0],
				_lastUpdateTime,
				(float)UndrawnBallNumbers [1],
				(float)UndrawnBallNumbers [2],
				(float)UndrawnBallNumbers [3],
				(float)UndrawnBallNumbers [4],
				(float)UndrawnBallNumbers [5],
				(float)UndrawnBallNumbers [6],
				(float)UndrawnBallNumbers [7],
				(float)UndrawnBallNumbers [8],
				(float)UndrawnBallNumbers [9],
				(float)UndrawnBallNumbers [10],
				(float)UndrawnBallNumbers [11],
				(float)UndrawnBallNumbers [12],
				(float)UndrawnBallNumbers [13],
				(float)UndrawnBallNumbers [14],
				(float)UndrawnBallNumbers [15],
				(float)UndrawnBallNumbers [16],
				(float)UndrawnBallNumbers [17],
				(float)UndrawnBallNumbers [18],
				(float)UndrawnBallNumbers [19],
				(float)UndrawnBallNumbers [20],
				(float)UndrawnBallNumbers [21],
				(float)UndrawnBallNumbers [22],
				(float)UndrawnBallNumbers [23],
				(float)UndrawnBallNumbers [24],
				(float)UndrawnBallNumbers [25],
				(float)UndrawnBallNumbers [26],
				(float)UndrawnBallNumbers [27],
				(float)UndrawnBallNumbers [28],
				(float)UndrawnBallNumbers [29],
				(float)UndrawnBallNumbers [30],
				(float)UndrawnBallNumbers [31],
				(float)UndrawnBallNumbers [32],
				(float)UndrawnBallNumbers [33],
				(float)UndrawnBallNumbers [34],
				(float)UndrawnBallNumbers [35],
				(float)UndrawnBallNumbers [36],
				(float)UndrawnBallNumbers [37],
				(float)UndrawnBallNumbers [38],
				(float)UndrawnBallNumbers [39],
				(float)UndrawnBallNumbers [40],
				(float)UndrawnBallNumbers [41],
				(float)UndrawnBallNumbers [42],
				(float)UndrawnBallNumbers [43],
				(float)UndrawnBallNumbers [44],
				(float)UndrawnBallNumbers [45],
				(float)UndrawnBallNumbers [46],
				(float)UndrawnBallNumbers [47],
				(float)UndrawnBallNumbers [48],
				(float)UndrawnBallNumbers [49],
				(float)UndrawnBallNumbers [50],
				(float)UndrawnBallNumbers [51],
				(float)UndrawnBallNumbers [52],
				(float)UndrawnBallNumbers [53],
				(float)UndrawnBallNumbers [54],
				(float)UndrawnBallNumbers [55],
				(float)UndrawnBallNumbers [56],
				(float)UndrawnBallNumbers [57],
				(float)UndrawnBallNumbers [58],
				(float)UndrawnBallNumbers [59],
				(float)UndrawnBallNumbers [60],
				(float)UndrawnBallNumbers [61],
				(float)UndrawnBallNumbers [62],
				(float)UndrawnBallNumbers [63],
				(float)UndrawnBallNumbers [64],
				(float)UndrawnBallNumbers [65],
				(float)UndrawnBallNumbers [66],
				(float)UndrawnBallNumbers [67],
				(float)UndrawnBallNumbers [68],
				(float)UndrawnBallNumbers [69],
				(float)UndrawnBallNumbers [70],
				(float)UndrawnBallNumbers [71],
				(float)UndrawnBallNumbers [72],
				(float)UndrawnBallNumbers [73],
				(float)UndrawnBallNumbers [74]);
			_nextBroadcastTime = Time.time + .16f;
		}
	}

	void CheckForInternetConnection() {
		string HtmlText = GetHtmlFromUri("http://google.com");
		if(HtmlText == "")
		{
			internetConnIsOn = false;
			//No connection
		}
//		else if(!HtmlText.Contains("schema.org/WebPage"))
//		{
//			//Redirecting since the beginning of googles html contains that 
//			//phrase and it was not found
//		}
		else
		{
			//success
			internetConnIsOn = true;
		}
	}

	public string GetHtmlFromUri(string resource)
	{
		string html = string.Empty;
		HttpWebRequest req = (HttpWebRequest)WebRequest.Create(resource);
		try
		{
			using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
			{
				bool isSuccess = (int)resp.StatusCode < 299 && (int)resp.StatusCode >= 200;
				if (isSuccess)
				{
					using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
					{
						//We are limiting the array to 80 so we don't have
						//to parse the entire html document feel free to 
						//adjust (probably stay under 300)
						char[] cs = new char[80];
						reader.Read(cs, 0, cs.Length);
						foreach(char ch in cs)
						{
							html +=ch;
						}
					}
				}
			}
		}
		catch
		{
			return "";
		}
		return html;
	}
		
	void CheckForTimeOuts() {
		if (multiplayerGameStarted) {
			_lastUpdateTime = Time.time - startTime;
			if(Mathf.Abs(_lastUpdateTime - _lastUpdateTime2) > 15.0f) {
				CheckForInternetConnection ();
				MultiplayerController.Instance.LeaveGame ();
			}
		}
	}

	public void AssignBallInfo() // Assigns a number, based on the drawn ball count, from the ball number list along with the appropriate letter to a designated ball.  
	{

		if (!isMultiplayerGame) {
			if (UndrawnBallNumbers [drawnBallCount] < 16 && UndrawnBallNumbers [drawnBallCount] > 0) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "B";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];

				for (int i = 0; i < 5; i++) {
					
					if (PlayerCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						PlayerCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
					if (OpponentCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().onClick.Invoke ();
					}

				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 31 && UndrawnBallNumbers [drawnBallCount] > 15) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "I";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 5; i < 10; i++) {

					if (PlayerCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						PlayerCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
					if (OpponentCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().onClick.Invoke ();
					}

				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 46 && UndrawnBallNumbers [drawnBallCount] > 30) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "N";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 10; i < 15; i++) {

					if (PlayerCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						PlayerCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
					if (OpponentCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().onClick.Invoke ();
					}

				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 61 && UndrawnBallNumbers [drawnBallCount] > 45) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "G";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 15; i < 20; i++) {

					if (PlayerCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						PlayerCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
					if (OpponentCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().onClick.Invoke ();
					}

				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 76 && UndrawnBallNumbers [drawnBallCount] > 60) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "O";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 20; i < 25; i++) {

					if (PlayerCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						PlayerCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
					if (OpponentCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);
						OpponentCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().onClick.Invoke ();
					}

				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			}

			drawnBallCount++;
		} 
		else if(firstPlayer == "firstPlayer") {
			if (UndrawnBallNumbers [drawnBallCount] < 16 && UndrawnBallNumbers [drawnBallCount] > 0) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "B";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];

				for (int i = 0; i < 5; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 31 && UndrawnBallNumbers [drawnBallCount] > 15) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "I";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 5; i < 10; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 46 && UndrawnBallNumbers [drawnBallCount] > 30) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "N";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 10; i < 15; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 61 && UndrawnBallNumbers [drawnBallCount] > 45) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "G";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 15; i < 20; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			} else if (UndrawnBallNumbers [drawnBallCount] < 76 && UndrawnBallNumbers [drawnBallCount] > 60) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "O";
				Balls [ballCounter2].GetComponent<BallController> ().number = UndrawnBallNumbers [drawnBallCount];
				for (int i = 20; i < 25; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == UndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (UndrawnBallNumbers [drawnBallCount]);
			}
			drawnBallCount++;
		} 
		else{
			if (MultiplayerUndrawnBallNumbers [drawnBallCount] < 16 && MultiplayerUndrawnBallNumbers [drawnBallCount] > 0) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "B";
				Balls [ballCounter2].GetComponent<BallController> ().number = MultiplayerUndrawnBallNumbers [drawnBallCount];

				for (int i = 0; i < 5; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == MultiplayerUndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (MultiplayerUndrawnBallNumbers [drawnBallCount]);
			} 
			else if (MultiplayerUndrawnBallNumbers [drawnBallCount] < 31 && MultiplayerUndrawnBallNumbers [drawnBallCount] > 15) 
			{
				Balls [ballCounter2].GetComponent<BallController> ().letter = "I";
				Balls [ballCounter2].GetComponent<BallController> ().number = MultiplayerUndrawnBallNumbers [drawnBallCount];
				for (int i = 5; i < 10; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == MultiplayerUndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (MultiplayerUndrawnBallNumbers [drawnBallCount]);
			} 
			else if (MultiplayerUndrawnBallNumbers [drawnBallCount] < 46 && MultiplayerUndrawnBallNumbers [drawnBallCount] > 30) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "N";
				Balls [ballCounter2].GetComponent<BallController> ().number = MultiplayerUndrawnBallNumbers [drawnBallCount];
				for (int i = 10; i < 15; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == MultiplayerUndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (MultiplayerUndrawnBallNumbers [drawnBallCount]);
			} else if (MultiplayerUndrawnBallNumbers [drawnBallCount] < 61 && MultiplayerUndrawnBallNumbers [drawnBallCount] > 45) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "G";
				Balls [ballCounter2].GetComponent<BallController> ().number = MultiplayerUndrawnBallNumbers [drawnBallCount];
				for (int i = 15; i < 20; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == MultiplayerUndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (MultiplayerUndrawnBallNumbers [drawnBallCount]);
			} else if (MultiplayerUndrawnBallNumbers [drawnBallCount] < 76 && MultiplayerUndrawnBallNumbers [drawnBallCount] > 60) {
				Balls [ballCounter2].GetComponent<BallController> ().letter = "O";
				Balls [ballCounter2].GetComponent<BallController> ().number = MultiplayerUndrawnBallNumbers [drawnBallCount];
				for (int i = 20; i < 25; i++) {
					if (myCard.GetComponent<CardController> ().cardNumbers [i] == MultiplayerUndrawnBallNumbers [drawnBallCount]) {
						myCard.GetComponent<CardController> ().numCells [i].GetComponent<Button> ().interactable = (true);

					}
				}
				DrawnBallNumbers.Add (MultiplayerUndrawnBallNumbers [drawnBallCount]);
			}
			drawnBallCount++;
		}
	}



	public void UpdateBallUI()
	{

		Balls [ballCounter2].GetComponentInChildren<Text> ().text = Balls [ballCounter2].GetComponent<BallController> ().letter + Balls [ballCounter2].GetComponent<BallController> ().number.ToString ();
		if (englishCalls == 0) {
			if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B1")
				bingoDrawSounds [0].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B2")
				bingoDrawSounds [1].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B3")
				bingoDrawSounds [2].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B4")
				bingoDrawSounds [3].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B5")
				bingoDrawSounds [4].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B6")
				bingoDrawSounds [5].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B7")
				bingoDrawSounds [6].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B8")
				bingoDrawSounds [7].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B9")
				bingoDrawSounds [8].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B10")
				bingoDrawSounds [9].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B11")
				bingoDrawSounds [10].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B12")
				bingoDrawSounds [11].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B13")
				bingoDrawSounds [12].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B14")
				bingoDrawSounds [13].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B15")
				bingoDrawSounds [14].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I16")
				bingoDrawSounds [15].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I17")
				bingoDrawSounds [16].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I18")
				bingoDrawSounds [17].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I19")
				bingoDrawSounds [18].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I20")
				bingoDrawSounds [19].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I21")
				bingoDrawSounds [20].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I22")
				bingoDrawSounds [21].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I23")
				bingoDrawSounds [22].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I24")
				bingoDrawSounds [23].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I25")
				bingoDrawSounds [24].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I26")
				bingoDrawSounds [25].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I27")
				bingoDrawSounds [26].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I28")
				bingoDrawSounds [27].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I29")
				bingoDrawSounds [28].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I30")
				bingoDrawSounds [29].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N31")
				bingoDrawSounds [30].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N32")
				bingoDrawSounds [31].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N33")
				bingoDrawSounds [32].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N34")
				bingoDrawSounds [33].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N35")
				bingoDrawSounds [34].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N36")
				bingoDrawSounds [35].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N37")
				bingoDrawSounds [36].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N38")
				bingoDrawSounds [37].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N39")
				bingoDrawSounds [38].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N40")
				bingoDrawSounds [39].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N41")
				bingoDrawSounds [40].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N42")
				bingoDrawSounds [41].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N43")
				bingoDrawSounds [42].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N44")
				bingoDrawSounds [43].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N45")
				bingoDrawSounds [44].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G46")
				bingoDrawSounds [45].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G47")
				bingoDrawSounds [46].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G48")
				bingoDrawSounds [47].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G49")
				bingoDrawSounds [48].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G50")
				bingoDrawSounds [49].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G51")
				bingoDrawSounds [50].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G52")
				bingoDrawSounds [51].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G53")
				bingoDrawSounds [52].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G54")
				bingoDrawSounds [53].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G55")
				bingoDrawSounds [54].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G56")
				bingoDrawSounds [55].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G57")
				bingoDrawSounds [56].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G58")
				bingoDrawSounds [57].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G59")
				bingoDrawSounds [58].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G60")
				bingoDrawSounds [59].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O61")
				bingoDrawSounds [60].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O62")
				bingoDrawSounds [61].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O63")
				bingoDrawSounds [62].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O64")
				bingoDrawSounds [63].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O65")
				bingoDrawSounds [64].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O66")
				bingoDrawSounds [65].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O67")
				bingoDrawSounds [66].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O68")
				bingoDrawSounds [67].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O69")
				bingoDrawSounds [68].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O70")
				bingoDrawSounds [69].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O71")
				bingoDrawSounds [70].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O72")
				bingoDrawSounds [71].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O73")
				bingoDrawSounds [72].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O74")
				bingoDrawSounds [73].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O75")
				bingoDrawSounds [74].Play ();
		} else {
			if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B1")
				bingoDrawSoundsSpanish [0].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B2")
				bingoDrawSoundsSpanish [1].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B3")
				bingoDrawSoundsSpanish [2].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B4")
				bingoDrawSoundsSpanish [3].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B5")
				bingoDrawSoundsSpanish [4].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B6")
				bingoDrawSoundsSpanish [5].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B7")
				bingoDrawSoundsSpanish [6].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B8")
				bingoDrawSoundsSpanish [7].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B9")
				bingoDrawSoundsSpanish [8].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B10")
				bingoDrawSoundsSpanish [9].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B11")
				bingoDrawSoundsSpanish [10].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B12")
				bingoDrawSoundsSpanish [11].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B13")
				bingoDrawSoundsSpanish [12].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B14")
				bingoDrawSoundsSpanish [13].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "B15")
				bingoDrawSoundsSpanish [14].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I16")
				bingoDrawSoundsSpanish [15].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I17")
				bingoDrawSoundsSpanish [16].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I18")
				bingoDrawSoundsSpanish [17].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I19")
				bingoDrawSoundsSpanish [18].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I20")
				bingoDrawSoundsSpanish [19].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I21")
				bingoDrawSoundsSpanish [20].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I22")
				bingoDrawSoundsSpanish [21].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I23")
				bingoDrawSoundsSpanish [22].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I24")
				bingoDrawSoundsSpanish [23].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I25")
				bingoDrawSoundsSpanish [24].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I26")
				bingoDrawSoundsSpanish [25].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I27")
				bingoDrawSoundsSpanish [26].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I28")
				bingoDrawSoundsSpanish [27].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I29")
				bingoDrawSoundsSpanish [28].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "I30")
				bingoDrawSoundsSpanish [29].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N31")
				bingoDrawSoundsSpanish [30].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N32")
				bingoDrawSoundsSpanish [31].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N33")
				bingoDrawSoundsSpanish [32].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N34")
				bingoDrawSoundsSpanish [33].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N35")
				bingoDrawSoundsSpanish [34].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N36")
				bingoDrawSoundsSpanish [35].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N37")
				bingoDrawSoundsSpanish [36].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N38")
				bingoDrawSoundsSpanish [37].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N39")
				bingoDrawSoundsSpanish [38].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N40")
				bingoDrawSoundsSpanish [39].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N41")
				bingoDrawSoundsSpanish [40].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N42")
				bingoDrawSoundsSpanish [41].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N43")
				bingoDrawSoundsSpanish [42].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N44")
				bingoDrawSoundsSpanish [43].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "N45")
				bingoDrawSoundsSpanish [44].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G46")
				bingoDrawSoundsSpanish [45].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G47")
				bingoDrawSoundsSpanish [46].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G48")
				bingoDrawSoundsSpanish [47].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G49")
				bingoDrawSoundsSpanish [48].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G50")
				bingoDrawSoundsSpanish [49].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G51")
				bingoDrawSoundsSpanish [50].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G52")
				bingoDrawSoundsSpanish [51].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G53")
				bingoDrawSoundsSpanish [52].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G54")
				bingoDrawSoundsSpanish [53].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G55")
				bingoDrawSoundsSpanish [54].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G56")
				bingoDrawSoundsSpanish [55].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G57")
				bingoDrawSoundsSpanish [56].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G58")
				bingoDrawSoundsSpanish [57].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G59")
				bingoDrawSoundsSpanish [58].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "G60")
				bingoDrawSoundsSpanish [59].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O61")
				bingoDrawSoundsSpanish [60].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O62")
				bingoDrawSoundsSpanish [61].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O63")
				bingoDrawSoundsSpanish [62].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O64")
				bingoDrawSoundsSpanish [63].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O65")
				bingoDrawSoundsSpanish [64].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O66")
				bingoDrawSoundsSpanish [65].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O67")
				bingoDrawSoundsSpanish [66].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O68")
				bingoDrawSoundsSpanish [67].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O69")
				bingoDrawSoundsSpanish [68].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O70")
				bingoDrawSoundsSpanish [69].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O71")
				bingoDrawSoundsSpanish [70].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O72")
				bingoDrawSoundsSpanish [71].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O73")
				bingoDrawSoundsSpanish [72].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O74")
				bingoDrawSoundsSpanish [73].Play ();
			else if (Balls [ballCounter2].GetComponentInChildren<Text> ().text == "O75")
				bingoDrawSoundsSpanish [74].Play ();
		}
		ballCounter2++;
		if (ballCounter2 == 6) {
			ballCounter2 = 0;
		}
	}

	public void resetBallUI(){
		for (int i = 0; i < Balls.Length; i++) {
			Balls[i].GetComponentInChildren<Text> ().text = "";
		}
	}

	public void resetBallsToStartPosition(){
		for (int i = 0; i < Balls.Length; i++) {
			Balls [i].gameObject.SetActive (false);
		}
	}

	public void resetBallCounters(){
		wonTheGame = false;
		blocker.SetActive (false);
		didPlayerLeft = false;
		multiplayerGameStarted = false;
		gameWon = false;
		ballCounter2 = 0;
		onlyOnce = 0;
		onlyOnce2 = 0;
		onlyOnce3 = 0;
		onlyOnce4 = 0;
		onlyOnce5 = 0;
		bothPlayersReady = 0;
		bothPlayersReady2 = 0;
		drawnBallCount = 0;
		gameOver = 0;
		_lastUpdateTime2 = 0;
		isGameStarted = false;
		ComputerOpponent.CompOpp.gameOverCounter = 0;
		BingoButton.BingoBtn.gameOverCounterBingo = 0;
		BingoButton.BingoBtn.isFourCorners = false;
		UIController.UICon.GameplayBallStopper.SetActive (true);
		for (int i = 0; i < playerStamps.Length; i++) {
			playerStamps [i].gameObject.SetActive (false);
			playerStamps [i].gameObject.GetComponent<Image> ().sprite = playerStampSprites [stampChoice];
			playerStamps [i].gameObject.GetComponent<Image> ().color = Color.white;
		}
		for (int i = 0; i < opponentStamps.Length; i++) {
			opponentStamps [i].gameObject.SetActive (false);
			opponentStamps [i].gameObject.GetComponent<Image> ().sprite = opponentStampSprites [stampChoice];
			opponentStamps [i].gameObject.GetComponent<Image> ().color = Color.white;
		}
	}
	//changing the background to backgrounds[] aray elements
	public void changeBackgroundRight(){
		if (backgroundCounter != backgrounds.Count - 1) {
			backgroundCounter++;
			backgroundChoice++;
			background.sprite = backgrounds [backgroundCounter];
			backgroundText.sprite = backgroundTexts [backgroundCounter];
		}
	}

	public void changeBackgroundLeft(){
		if (backgroundCounter != 0) {
			backgroundCounter--;
			backgroundChoice--;
			background.sprite = backgrounds [backgroundCounter];
			backgroundText.sprite = backgroundTexts [backgroundCounter];
		}
	}

	//function that is going through available card designs and assigning it to every player(at the moment) card on every scene
	//all player cards are in playerBingoCard[] array
	public void changeCardDesignsRight(){
		if (bingoCardCounter != playerBingoCards.Count - 1) {
			bingoCardCounter++;
			stampChoice++;
			for (int i = 0; i < playerBingoCard.Length; i++) {
				playerBingoCard[i].sprite = playerBingoCards [bingoCardCounter];
				playerCurrentBingoCard = playerBingoCards [bingoCardCounter];
			}
			playerBingoCardText.sprite = playerBingoCardTexts [bingoCardCounter];
			for (int i = 0; i < opponentBingoCard.Length; i++) {
				opponentBingoCard[i].sprite = opponentBingoCards [bingoCardCounter];
				opponentCurrentBingoCard = opponentBingoCards [bingoCardCounter];
			}
		}
	}

	public void changeCardDesignsLeft(){
		if (bingoCardCounter != 0) {
			bingoCardCounter--;
			stampChoice--;
			for (int i = 0; i < playerBingoCard.Length; i++) {
				playerBingoCard[i].sprite = playerBingoCards [bingoCardCounter];
				playerCurrentBingoCard = playerBingoCards [bingoCardCounter];
			}
			playerBingoCardText.sprite = playerBingoCardTexts [bingoCardCounter];
			for (int i = 0; i < opponentBingoCard.Length; i++) {
				opponentBingoCard[i].sprite = opponentBingoCards [bingoCardCounter];
				opponentCurrentBingoCard = opponentBingoCards [bingoCardCounter];
			}
		}
	}

	public void cardDesignUpdate(){
		bingoCardCounter = stampChoice;
		for (int i = 0; i < playerBingoCard.Length; i++) {
			playerBingoCard[i].sprite = playerBingoCards [bingoCardCounter];
			playerCurrentBingoCard = playerBingoCards [bingoCardCounter];
		}
		playerBingoCardText.sprite = playerBingoCardTexts [bingoCardCounter];
		for (int i = 0; i < opponentBingoCard.Length; i++) {
			opponentBingoCard[i].sprite = opponentBingoCards [bingoCardCounter];
			opponentCurrentBingoCard = opponentBingoCards [bingoCardCounter];
		}
	}

	public void flipCardDesigns(){
		Sprite player = PlayerCard.GetComponent<Image> ().sprite;
		Sprite opponent = OpponentCard.GetComponent<Image> ().sprite;

		flipped = !flipped;

		PlayerCard.GetComponent<Image> ().sprite = opponent;
		OpponentCard.GetComponent<Image> ().sprite = player;

		if (flipped) {
			playerTextPositions [1].gameObject.SetActive (true);
			playerTextPositions [0].gameObject.SetActive (false);
		} else {
			playerTextPositions [1].gameObject.SetActive (false);
			playerTextPositions [0].gameObject.SetActive (true);
		}
	}

	public void backgroundUpdater(){
		backgroundCounter = backgroundChoice;
		background.sprite = backgrounds [backgroundCounter];
		backgroundText.sprite = backgroundTexts [backgroundCounter];
	}

	public void bingocardsUpdater(){
		for (int i = 0; i < playerBingoCard.Length; i++) {
			playerBingoCard[i].sprite = playerBingoCards [stampChoice];
		}
		for (int i = 0; i < opponentBingoCard.Length; i++) {
			opponentBingoCard[i].sprite = opponentBingoCards [stampChoice];
		}
	}

	//same system for prizes as for backgrounds
	public void changePrizeRight(){
		if (prizeCounter != wonPrizes.Count - 1) {
			prizeCounter++;
			ChangePrizesLeftAndRight ();
		}
	}

	public void changePrizeLeft(){
		if (prizeCounter != 0) {
			prizeCounter--;
			ChangePrizesLeftAndRight ();
		}
	}

	public void updatePrizes(){
		prizeCounter = 0;
		UIController.UICon.Prizes_PrizeImage.sprite = wonPrizes[0];
		ChangePrizesLeftAndRight ();
	}

	public void ChangePrizesLeftAndRight(){
			UIController.UICon.Prizes_PrizeImage.sprite = wonPrizes [prizeCounter];
			if (wonPrizes [prizeCounter] == tierOnePrizes [0]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [1]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [1].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [2]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [2].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [3]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [3].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [4]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [4].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [5]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [5].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [6]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [6].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [7]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [7].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [8]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [8].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [9]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [9].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [10]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [10].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [11]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [11].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [12]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [12].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [13]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [13].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [14]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [14].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [15]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [15].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [16]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [16].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [17]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [17].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [18]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [18].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [19]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [19].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [20]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [20].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [21]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [21].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [22]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [22].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [23]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [23].ToString ();
			} else if (wonPrizes [prizeCounter] == tierOnePrizes [24]) {
				UIController.UICon.Prizes_PrizeText.text = tierOnePrizesText [24].ToString ();
			} else if (wonPrizes [prizeCounter] == tierTwoPrizes [0]) {
				UIController.UICon.Prizes_PrizeText.text = tierTwoPrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierTwoPrizes [6]) {
				UIController.UICon.Prizes_PrizeText.text = moodRingText.ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [0]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [1].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [1]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [2]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [3]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [2].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [4]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [5]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [6]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [3].ToString ();
			} else if (wonPrizes [prizeCounter] == tierThreePrizes [7]) {
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
			} else {
				UIController.UICon.Prizes_PrizeText.text = "";
			}
			if (UIController.UICon.Prizes_PrizeImage.sprite == tierTwoPrizes [0]) {
				if (tierTwoPrizeCharmOne == 1) {
					charmOne.gameObject.SetActive (true);
				}
				if (tierTwoPrizeCharmTwo == 1) {
					charmTwo.gameObject.SetActive (true);
				}
				if (tierTwoPrizeCharmThree == 1) {
					charmThree.gameObject.SetActive (true);
				}
				if (tierTwoPrizeCharmFour == 1) {
					charmFour.gameObject.SetActive (true);
				}
				if (tierTwoPrizeCharmFive == 1) {
					charmFive.gameObject.SetActive (true);
				}
			} else {
				charmOne.gameObject.SetActive (false);
				charmTwo.gameObject.SetActive (false);
				charmThree.gameObject.SetActive (false);
				charmFour.gameObject.SetActive (false);
				charmFive.gameObject.SetActive (false);
			}
			if (UIController.UICon.Prizes_PrizeImage.sprite == tierThreePrizes [7]) {
				if (tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 0 && tierThreePrizePuzzlePieceThree == 0 && tierThreePrizePuzzlePieceFour == 0) {
					UIController.UICon.Prizes_PrizeImage.sprite = tierThreePrizes [13];
				} else if (tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 0 && tierThreePrizePuzzlePieceFour == 0) {
					UIController.UICon.Prizes_PrizeImage.sprite = tierThreePrizes [14];
				} else if (tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 0) {
					UIController.UICon.Prizes_PrizeImage.sprite = tierThreePrizes [15];
				} else if (tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 1) {
					UIController.UICon.Prizes_PuzzlePiece.SetActive (true);
					UIController.UICon.Prizes_BckgrdUnlockBtn.SetActive (true);
				}
			} else {
				UIController.UICon.Prizes_BckgrdUnlockBtn.SetActive (false);
				UIController.UICon.Prizes_PuzzlePiece.SetActive (false);
			}
			for (int i = 0; i < allBackgrounds.Count; i++) {
				if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [i]) {
					UIController.UICon.Prizes_PrizeText.text = backgroundsTexts [i];
				}
			}
			if (UIController.UICon.Prizes_PrizeImage.sprite == tierThreePrizes [11]) {
				UIController.UICon.Prizes_CardSet.SetActive (true);
				UIController.UICon.Prizes_CardSetUnlockBtn.SetActive (true);
			} else {
				UIController.UICon.Prizes_CardSet.SetActive (false);
				UIController.UICon.Prizes_CardSetUnlockBtn.SetActive (false);
			}
			if (UIController.UICon.Prizes_PrizeImage.sprite == cardDesignPrizes [0]) {
				UIController.UICon.Prizes_CardSetUseBtn.SetActive (true);
				UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [0].ToString ();
			} else if (UIController.UICon.Prizes_PrizeImage.sprite == cardDesignPrizes [1]) {
				UIController.UICon.Prizes_CardSetUseBtn.SetActive (true);
				UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [1].ToString ();
			} else if (UIController.UICon.Prizes_PrizeImage.sprite == cardDesignPrizes [2]) {
				UIController.UICon.Prizes_CardSetUseBtn.SetActive (true);
				UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [2].ToString ();
			} else if (UIController.UICon.Prizes_PrizeImage.sprite == cardDesignPrizes [3]) {
				UIController.UICon.Prizes_CardSetUseBtn.SetActive (true);
				UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [3].ToString ();
			} else {
				UIController.UICon.Prizes_CardSetUseBtn.SetActive (false);
			}
		if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [0]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [1]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [2]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [3]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [4]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [5]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [6]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else if (UIController.UICon.Prizes_PrizeImage.sprite == allBackgrounds [7]) {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (true);
		} else {
			UIController.UICon.Prizes_BckgrdUseBtn.SetActive (false);
		}
	}

	public void hideUnneededPrizes(){
		UIController.UICon.Prizes_CardSetUseBtn.SetActive (false);
		UIController.UICon.Prizes_BckgrdUseBtn.SetActive (false);
		UIController.UICon.Prizes_BckgrdUnlockBtn.SetActive (false);
		UIController.UICon.Prizes_CardSetUnlockBtn.SetActive (false);
		UIController.UICon.Prizes_PuzzlePiece.SetActive (false);
		UIController.UICon.Prizes_CardSet.SetActive (false);
		charmOne.gameObject.SetActive (false);
		charmTwo.gameObject.SetActive (false);
		charmThree.gameObject.SetActive (false);
		charmFour.gameObject.SetActive (false);
		charmFive.gameObject.SetActive (false);
	}

	public void findMoodRing(){
		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierTwoPrizes [6]) {
				UIController.UICon.Prizes_PrizeImage.sprite = wonPrizes[i];
				UIController.UICon.Prizes_PrizeText.text = moodRingText.ToString();
				prizeCounter = i;
			}
		}
		UpdateWonTotalPrizes ();
		hideUnneededPrizes ();
	}

	public void findPuzzlePieces(){
		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [7]) {
				UIController.UICon.Prizes_PrizeImage.sprite = wonPrizes[i];
				UIController.UICon.Prizes_PrizeText.text = tierThreePrizesText [0].ToString ();
				prizeCounter = i;
			}
		}
		UpdateWonTotalPrizes ();
		hideUnneededPrizes ();
		UIController.UICon.Prizes_BckgrdUnlockBtn.SetActive (true);
		UIController.UICon.Prizes_PuzzlePiece.SetActive (true);
	}

	public void findCardSet(){
		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [11]) {
				UIController.UICon.Prizes_PrizeImage.sprite = wonPrizes[i];
				UIController.UICon.Prizes_PrizeText.text = "";
				prizeCounter = i;
			}
		}
		UpdateWonTotalPrizes ();
		hideUnneededPrizes ();
		UIController.UICon.Prizes_CardSetUnlockBtn.SetActive (true);
		UIController.UICon.Prizes_CardSet.SetActive (true);
	}

	public bool UnlockBackgroundOrCardset(){
		if(tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 1 ){
			return true;
		}else{
			return false;
		}
	}

	public bool HasFivePuzzlePiecesOrCardSets(){
		if(tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 1 ){
			if (tierThreePrizeInterestingDesignPattern == 1 && tierThreePrizeBlankCard == 1) {
				return true;
			} else {
				return false;
			}
		}else{
			return false;
		}
	}
//	public bool hasFivePuzzlePiecesOrCardSets{
//		if(tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 1){
//			return true;
//		}else{
//			return false;
//		}
//	}

	public void claimBackgroundButton(){
		int whatBackgroundWasUnlocked = 0;
		if (!backgrounds.Contains (allBackgrounds [0])) {
			backgrounds.Add (allBackgrounds [0]);
			backgroundOne = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 0;
		} else if (!backgrounds.Contains (allBackgrounds [1]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [1]);
			backgroundTwo = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 1;
		} else if (!backgrounds.Contains (allBackgrounds [2]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [2]);
			backgroundThree = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 2;
		} else if (!backgrounds.Contains (allBackgrounds [3]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [3]);
			backgroundFour = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 3;
		} else if (!backgrounds.Contains (allBackgrounds [4]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [4]);
			backgroundFive = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 4;
		} else if (!backgrounds.Contains (allBackgrounds [5]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [5]);
			backgroundSix = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 5;
		} else if (!backgrounds.Contains (allBackgrounds [6]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [6]);
			backgroundSeven = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 6;
		} else if (!backgrounds.Contains (allBackgrounds [7]) && onlyOnce4 == 0) {
			backgrounds.Add (allBackgrounds [7]);
			backgroundEight = 1;
			backgroundsUnlocked++;
			whatBackgroundWasUnlocked = 7;
		}
		prizesCollectedCounter ();
		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [7]) {
				wonPrizes [i] = allBackgrounds [whatBackgroundWasUnlocked];
				}
		}
		UIController.UICon.Prizes_PrizeImage.sprite = backgrounds[backgrounds.Count - 1];
		UIController.UICon.Prizes_PrizeText.text = backgroundsTexts[whatBackgroundWasUnlocked];

		if (tierThreePrizePuzzlePieceOne == 1 && tierThreePrizePuzzlePieceTwo == 1 && tierThreePrizePuzzlePieceThree == 1 && tierThreePrizePuzzlePieceFour == 1) {
			tierThreePrizePuzzlePieceOne = 0;
			tierThreePrizePuzzlePieceTwo = 0;
			tierThreePrizePuzzlePieceThree = 0;
			tierThreePrizePuzzlePieceFour = 0;
			for (int i = 0; i < wonPrizes.Count; i++) {
				if (wonPrizes [i] == tierThreePrizes [7])
					wonPrizes.Remove (wonPrizes [i]);
			}
		}
		Save ();
	}

	public void setBackgroundPrizes(){
		int y = 0;
		for (int i = 1; i < backgrounds.Count; i++) {
			if (UIController.UICon.Prizes_PrizeImage.sprite == backgrounds [i]) {
				background.sprite = backgrounds [i];
				y = i;
			}
		}
		backgroundCounter = y;
		backgroundChoice = y;
	}
		
	public void UpdateCardDesignText(){
		
	}

	public void UnlockCardDesign(){
		int whatCardWasUnlocked = 0;

		if (playerBingoCards.Count != allPlayerBingoCards.Count + 1) {
			if (!playerBingoCards.Contains (allPlayerBingoCards [0])) {
				playerBingoCards.Add (allPlayerBingoCards [0]);
				opponentBingoCards.Add (allOpponentBingoCards [0]);
				cardDesignOne = 1;
				whatCardWasUnlocked = 0;
			} else if (!playerBingoCards.Contains (allPlayerBingoCards [1])) {
				playerBingoCards.Add (allPlayerBingoCards [1]);
				opponentBingoCards.Add (allOpponentBingoCards [1]);
				cardDesignTwo = 1;
				whatCardWasUnlocked = 1;
			} else if (!playerBingoCards.Contains (allPlayerBingoCards [2])) {
				playerBingoCards.Add (allPlayerBingoCards [2]);
				opponentBingoCards.Add (allOpponentBingoCards [2]);
				cardDesignThree = 1;
				whatCardWasUnlocked = 2;
			} else if (!playerBingoCards.Contains (allPlayerBingoCards [3])) {
				playerBingoCards.Add (allPlayerBingoCards [3]);
				opponentBingoCards.Add (allOpponentBingoCards [3]);
				cardDesignFour = 1;
				whatCardWasUnlocked = 3;
			}
		}
		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [11]) {
				wonPrizes [i] = cardDesignPrizes [whatCardWasUnlocked];
			}
		}
		if (whatCardWasUnlocked == 0) {
			UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [0].ToString ();
			UIController.UICon.Prizes_PrizeImage.sprite = cardDesignPrizes [0];
		} else if (whatCardWasUnlocked == 1) {
			UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [1].ToString ();
			UIController.UICon.Prizes_PrizeImage.sprite = cardDesignPrizes [1];
		} else if (whatCardWasUnlocked == 2) {
			UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [2].ToString ();
			UIController.UICon.Prizes_PrizeImage.sprite = cardDesignPrizes [2];
		} else if (whatCardWasUnlocked == 3) {
			UIController.UICon.Prizes_PrizeText.text = cardDesignTexts [3].ToString ();
			UIController.UICon.Prizes_PrizeImage.sprite = cardDesignPrizes [3];
		}

		tierThreePrizeBlankCard = 0;
		tierThreePrizeInterestingDesignPattern = 0;

		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [11])
				wonPrizes.Remove (wonPrizes [i]);
		}

		bingoCardsUnlocked = bingoCardsTotal;
		Save ();
	}

	public void SetCardDesign(){
		int y = 0;
		for (int i = 0; i < cardDesignPrizes.Count; i++) {
			if (UIController.UICon.Prizes_PrizeImage.sprite == cardDesignPrizes [i]) {
				y = i;
			}
		}
		for (int i = 0; i < playerBingoCard.Length; i++) {
			playerBingoCard[i].sprite = allPlayerBingoCards [y];
			playerCurrentBingoCard = allPlayerBingoCards [y];
		}
		for (int i = 0; i < opponentBingoCard.Length; i++) {
			opponentBingoCard[i].sprite = allOpponentBingoCards [y];
			opponentCurrentBingoCard = allOpponentBingoCards [y];
		}
		bingoCardCounter = y + 1;
		stampChoice = y + 1;
	}

	public void assignTierPrize(){
		if (tierThreePrizeMaxCardExtender == 1 && playerBingoCards.Count > allPlayerBingoCards.Count && backgrounds.Count > allBackgrounds.Count) {
			randomNumber = UnityEngine.Random.Range (1, 10);
		} else if (gamesWonCount >= 10) {
			randomNumber = 10;
			gamesWonCount = 0;
		} else {
			if (tierTwoPrizeCharmOne == 1 && tierTwoPrizeCharmTwo == 1 && tierTwoPrizeCharmThree == 1 && tierTwoPrizeCharmFour == 1 && tierTwoPrizeCharmFive == 1) {
				randomNumber = UnityEngine.Random.Range (1, 12);
			} else {
				randomNumber = UnityEngine.Random.Range (1, 11);
			}
		}

  		int randomRewardTierOne = UnityEngine.Random.Range(0,25);
		int randomRewardTierTwo = UnityEngine.Random.Range(0,2);
		if (tierThreePrizeMaxCardExtender == 0) {
			randomRewardTierThree = 2;
		} else if (tierThreePrizeMaxCardExtender == 0 && playerBingoCards.Count <= allPlayerBingoCards.Count && backgrounds.Count <= allBackgrounds.Count) {
			randomRewardTierThree = UnityEngine.Random.Range (0, 3);
		} else if (playerBingoCards.Count <= allPlayerBingoCards.Count && backgrounds.Count <= allBackgrounds.Count) {
			randomRewardTierThree = UnityEngine.Random.Range (0, 2);
		} else if (backgrounds.Count <= allBackgrounds.Count) {
			randomRewardTierThree = 1;
		} else if (playerBingoCards.Count <= allPlayerBingoCards.Count) {
			randomRewardTierThree = 0;
		}

		if (randomNumber <= 7) {
			UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierOnePrizes [randomRewardTierOne];
			UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierOnePrizesText [randomRewardTierOne].ToString ();
			if (!wonPrizes.Contains (tierOnePrizes [randomRewardTierOne])) {
				prizesCollectedCounter ();
				wonPrizes.Add (tierOnePrizes [randomRewardTierOne]);
				if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [0]) {
					tierOnePrizePaperclip = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [1]) {
					tierOnePrizeBagOfMarbles = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [2]) {
					tierOnePrizeMylarBalloon = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [3]) {
					tierOnePrizeChocolateBar = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [4]) {
					tierOnePrizePen = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [5]) {
					tierOnePrizeKeychain = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [6]) {
					tierOnePrizeBeanieHat = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [7]) {
					tierOnePrizeCoffeeMug = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [8]) {
					tierOnePrizePicTriviaToken = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [9]) {
					tierOnePrizeStandardSolitaireDeckOfCards = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [10]) {
					tierOnePrizeSetOfHighRollersDice = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [11]) {
					tierOnePrizeChineseFingerTrap = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [12]) {
					tierOnePrizeBearFeetSlippers = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [13]) {
					tierOnePrizeGiantGummyBear = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [14]) {
					tierOnePrizeKazoo = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [15]) {
					tierOnePrizeTeddyBear = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [16]) {
					tierOnePrizeRubberDuck = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [17]) {
					tierOnePrizeMegaSharkTooth = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [18]) {
					tierOnePrizeSunglasses = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [19]) {
					tierOnePrizeSlinky = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [20]) {
					tierOnePrizePetRock = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [21]) {
					tierOnePrizeILoveBingoTShirt = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [22]) {
					tierOnePrizeStressBall = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [23]) {
					tierOnePrizeRubiksCube = 1;
				} else if (tierOnePrizes [randomRewardTierOne] == tierOnePrizes [24]) {
					tierOnePrizeWinnersTrophy = 1;
				}
			}

		} else if (randomNumber == 8 || randomNumber == 9) {
			if (randomRewardTierTwo == 0) {
				if (tierTwoPrizeEmptyCharmBracelet == 0) {
					prizesCollectedCounter ();
					UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [0];
					UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [randomRewardTierTwo].ToString ();
					tierTwoPrizeEmptyCharmBracelet = 1;
					wonPrizes.Add (tierTwoPrizes [0]);
				} else {
					int randomRewardCharms = UnityEngine.Random.Range(0,5);
					if (randomRewardCharms == 0) {
						UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [1];
						UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [1].ToString ();
						if (tierTwoPrizeCharmOne == 0) {
							prizesCollectedCounter ();
							tierTwoPrizeCharmOne = 1;
						}
					} else if (randomRewardCharms == 1) {
						UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [2];
						UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [2].ToString ();
						if (tierTwoPrizeCharmTwo == 0) {
							prizesCollectedCounter ();
							tierTwoPrizeCharmTwo = 1;
						}
					} else if (randomRewardCharms == 2) {
						UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [3];
						UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [3].ToString ();
						if (tierTwoPrizeCharmThree == 0) {
							prizesCollectedCounter ();
							tierTwoPrizeCharmThree = 1;
							maxRemainingBingoCards += 5;
							updatePlayerBingoCards ();
						}
					} else if (randomRewardCharms == 3) {
						UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [4];
						UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [4].ToString ();
						if (tierTwoPrizeCharmFour == 0) {
							prizesCollectedCounter ();
							tierTwoPrizeCharmFour = 1;
						}
					} else if (randomRewardCharms == 4) {
						UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [5];
						UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [5].ToString ();
						if (tierTwoPrizeCharmFive == 0) {
							prizesCollectedCounter ();
							tierTwoPrizeCharmFive = 1;
						}
					}
				}
			} else if (randomRewardTierTwo == 1) {
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierTwoPrizes [6];
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierTwoPrizesText [6].ToString ();
				if (tierTwoPrizeMoodRing == 0) {
					prizesCollectedCounter ();
					tierTwoPrizeMoodRing = 1;
					wonPrizes.Add (tierTwoPrizes [6]);
					MoodRing.MoodCon.ChestClickMoodRing ();
					moodRingBonusButton.SetActive (true);
					for (int i = 0; i < moodRingBonusText.Count; i++) {
						moodRingBonusText [i].SetActive (true);
					}
				}
			}
		} else if (randomNumber == 10 || randomNumber == 11) {
			
			if (tierThreePrizeBlankCard == 0 && randomRewardTierThree == 0) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [1].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [0];
				tierThreePrizeBlankCard = 1;
				wonPrizes.Add (tierThreePrizes [0]);
			} else if (tierThreePrizeInterestingDesignPattern == 0 && randomRewardTierThree == 0) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [2].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [3];
				tierThreePrizeInterestingDesignPattern = 1;
				wonPrizes.Add (tierThreePrizes [3]);
			} 
			if(tierThreePrizePuzzlePieceOne == 0 && randomRewardTierThree == 1){
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [0].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [1];
				tierThreePrizePuzzlePieceOne = 1;
				wonPrizes.Add (tierThreePrizes [7]);
			} else if (tierThreePrizePuzzlePieceTwo == 0 && randomRewardTierThree == 1) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [0].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [2];
				tierThreePrizePuzzlePieceTwo = 1;
			} else if (tierThreePrizePuzzlePieceThree == 0 && randomRewardTierThree == 1) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [0].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [4];
				tierThreePrizePuzzlePieceThree = 1;
			} else if (tierThreePrizePuzzlePieceFour == 0 && randomRewardTierThree == 1) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [0].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [5];
				tierThreePrizePuzzlePieceFour = 1;
			}
			if (tierThreePrizeMaxCardExtender == 0 && randomRewardTierThree == 2) {
				UIController.UICon.GameplayPrizeText.GetComponent<Text>().text = tierThreePrizesText [3].ToString ();
				UIController.UICon.GameplayPrize.GetComponent<Image>().sprite = tierThreePrizes [6];
				tierThreePrizeMaxCardExtender = 1;
				wonPrizes.Add (tierThreePrizes [6]);
				maxRemainingBingoCards += 5;
				updatePlayerBingoCards ();
			}
			if (tierThreePrizeBlankCard == 1 && tierThreePrizeInterestingDesignPattern == 1 && !wonPrizes.Contains(tierThreePrizes [11])) {
				wonPrizes.Add (tierThreePrizes [11]);
				for (int i = 0; i < wonPrizes.Count; i++) {
					if (wonPrizes [i] == tierThreePrizes [0])
						wonPrizes.Remove (wonPrizes [i]);
					if (wonPrizes [i] == tierThreePrizes [3])
						wonPrizes.Remove (wonPrizes [i]);
				}
			}
		}
		Save ();
	}

	public void addAllBackgroundsCardDesigns(){
		if (backgrounds.Count != allBackgrounds.Count) {
			if (!backgrounds.Contains (allBackgrounds [0])) {
				backgrounds.Add (allBackgrounds [0]);
				backgroundOne = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [1])) {
				backgrounds.Add (allBackgrounds [1]);
				backgroundTwo = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [2])) {
				backgrounds.Add (allBackgrounds [2]);
				backgroundThree = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [3])) {
				backgrounds.Add (allBackgrounds [3]);
				backgroundFour = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [4])) {
				backgrounds.Add (allBackgrounds [4]);
				backgroundFive = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [5])) {
				backgrounds.Add (allBackgrounds [5]);
				backgroundSix = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [6])) {
				backgrounds.Add (allBackgrounds [6]);
				backgroundSeven = 1;
			}
			if (!backgrounds.Contains (allBackgrounds [7])) {
				backgrounds.Add (allBackgrounds [7]);
				backgroundEight = 1;
			}
		}
		if (playerBingoCards.Count != allPlayerBingoCards.Count) {
			if (!playerBingoCards.Contains (allPlayerBingoCards [0])) {
				playerBingoCards.Add (allPlayerBingoCards [0]);
				opponentBingoCards.Add (allOpponentBingoCards [0]);
				cardDesignOne = 1;
			}
			if (!playerBingoCards.Contains (allPlayerBingoCards [1])) {
				playerBingoCards.Add (allPlayerBingoCards [1]);
				opponentBingoCards.Add (allOpponentBingoCards [1]);
				cardDesignTwo = 1;
			}
			if (!playerBingoCards.Contains (allPlayerBingoCards [2])) {
				playerBingoCards.Add (allPlayerBingoCards [2]);
				opponentBingoCards.Add (allOpponentBingoCards [2]);
				cardDesignThree = 1;
			}
			if (!playerBingoCards.Contains (allPlayerBingoCards [3])) {
				playerBingoCards.Add (allPlayerBingoCards [3]);
				opponentBingoCards.Add (allOpponentBingoCards [3]);
				cardDesignFour = 1;
			}
		}

		for (int i = 0; i < wonPrizes.Count; i++) {
			if (wonPrizes [i] == tierThreePrizes [0])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [3])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [7])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [11])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [13])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [14])
				wonPrizes.Remove (wonPrizes [i]);
			if (wonPrizes [i] == tierThreePrizes [15])
				wonPrizes.Remove (wonPrizes [i]);
		}

		backgroundsUnlocked = backgroundsTotal;
		bingoCardsUnlocked = bingoCardsTotal;
		Save ();
	}

	public void assignWonPrizes(){
		if (tierOnePrizePaperclip == 1)
			wonPrizes.Add (tierOnePrizes [0]);
		if (tierOnePrizeBagOfMarbles == 1)
			wonPrizes.Add (tierOnePrizes [1]);
		if (tierOnePrizeMylarBalloon == 1)
			wonPrizes.Add (tierOnePrizes [2]);
		if (tierOnePrizeChocolateBar == 1)
			wonPrizes.Add (tierOnePrizes [3]);
		if (tierOnePrizePen == 1)
			wonPrizes.Add (tierOnePrizes [4]);
		if (tierOnePrizeKeychain == 1)
			wonPrizes.Add (tierOnePrizes [5]);
		if (tierOnePrizeBeanieHat == 1)
			wonPrizes.Add (tierOnePrizes [6]);
		if (tierOnePrizeCoffeeMug == 1)
			wonPrizes.Add (tierOnePrizes [7]);
		if (tierOnePrizePicTriviaToken == 1)
			wonPrizes.Add (tierOnePrizes [8]);
		if (tierOnePrizeStandardSolitaireDeckOfCards == 1)
			wonPrizes.Add (tierOnePrizes [9]);
		if (tierOnePrizeSetOfHighRollersDice == 1)
			wonPrizes.Add (tierOnePrizes [10]);
		if (tierOnePrizeChineseFingerTrap == 1)
			wonPrizes.Add (tierOnePrizes [11]);
		if (tierOnePrizeBearFeetSlippers == 1)
			wonPrizes.Add (tierOnePrizes [12]);
		if (tierOnePrizeGiantGummyBear == 1)
			wonPrizes.Add (tierOnePrizes [13]);
		if (tierOnePrizeKazoo == 1)
			wonPrizes.Add (tierOnePrizes [14]);
		if (tierOnePrizeTeddyBear == 1)
			wonPrizes.Add (tierOnePrizes [15]);
		if (tierOnePrizeRubberDuck == 1)
			wonPrizes.Add (tierOnePrizes [16]);
		if (tierOnePrizeMegaSharkTooth == 1)
			wonPrizes.Add (tierOnePrizes [17]);
		if (tierOnePrizeSunglasses == 1)
			wonPrizes.Add (tierOnePrizes [18]);
		if (tierOnePrizeSlinky == 1)
			wonPrizes.Add (tierOnePrizes [19]);
		if (tierOnePrizePetRock == 1)
			wonPrizes.Add (tierOnePrizes [20]);
		if (tierOnePrizeILoveBingoTShirt == 1)
			wonPrizes.Add (tierOnePrizes [21]);
		if (tierOnePrizeStressBall == 1)
			wonPrizes.Add (tierOnePrizes [22]);
		if (tierOnePrizeRubiksCube == 1)
			wonPrizes.Add (tierOnePrizes [23]);
		if (tierOnePrizeWinnersTrophy == 1)
			wonPrizes.Add (tierOnePrizes [24]);
		if (tierTwoPrizeEmptyCharmBracelet == 1)
			wonPrizes.Add (tierTwoPrizes [0]);
		if (tierTwoPrizeMoodRing == 1)
			wonPrizes.Add (tierTwoPrizes [6]);
		if (cardDesignOne == 0 || cardDesignTwo == 0 || cardDesignThree == 0 || cardDesignFour == 0) {
			if (tierThreePrizeBlankCard == 1)
				wonPrizes.Add (tierThreePrizes [0]);
			if (tierThreePrizeInterestingDesignPattern == 1)
				wonPrizes.Add (tierThreePrizes [3]);
		}
		if(backgroundOne == 0 || backgroundTwo == 0 || backgroundThree == 0 || backgroundFour == 0 || backgroundFive == 0 || backgroundSix == 0 || backgroundSeven == 0 || backgroundEight == 0){
			if (tierThreePrizePuzzlePieceOne == 1){
				wonPrizes.Add (tierThreePrizes [7]);
			}
		}
		if (tierThreePrizeMaxCardExtender == 1)
			wonPrizes.Add (tierThreePrizes [6]);
		
		if (!backgrounds.Contains (allBackgrounds [0]) && backgroundOne == 1) {
			backgrounds.Add (allBackgrounds [0]);
			wonPrizes.Add (allBackgrounds [0]);
		}
		if (!backgrounds.Contains (allBackgrounds [1]) && backgroundTwo == 1) {
			backgrounds.Add (allBackgrounds [1]);
			wonPrizes.Add (allBackgrounds [1]);
		}
		if (!backgrounds.Contains (allBackgrounds [2])  && backgroundThree == 1) {
			backgrounds.Add (allBackgrounds [2]);
			wonPrizes.Add (allBackgrounds [2]);
		}
		if (!backgrounds.Contains (allBackgrounds [3])  && backgroundFour == 1) {
			backgrounds.Add (allBackgrounds [3]);
			wonPrizes.Add (allBackgrounds [3]);
		}
		if (!backgrounds.Contains (allBackgrounds [4])  && backgroundFive == 1) {
			backgrounds.Add (allBackgrounds [4]);
			wonPrizes.Add (allBackgrounds [4]);
		}
		if (!backgrounds.Contains (allBackgrounds [5])  && backgroundSix == 1) {
			backgrounds.Add (allBackgrounds [5]);
			wonPrizes.Add (allBackgrounds [5]);
		}
		if (!backgrounds.Contains (allBackgrounds [6])  && backgroundSeven == 1) {
			backgrounds.Add (allBackgrounds [6]);
			wonPrizes.Add (allBackgrounds [6]);
		}
		if (!backgrounds.Contains (allBackgrounds [7])  && backgroundEight == 1) {
			backgrounds.Add (allBackgrounds [7]);
			wonPrizes.Add (allBackgrounds [7]);
		}

		if (!playerBingoCards.Contains (allPlayerBingoCards [0]) && cardDesignOne == 1) {
			playerBingoCards.Add (allPlayerBingoCards [0]);
			opponentBingoCards.Add (allOpponentBingoCards [0]);
			wonPrizes.Add (cardDesignPrizes [0]);
		}
		if (!playerBingoCards.Contains (allPlayerBingoCards [1]) && cardDesignTwo == 1) {
			playerBingoCards.Add (allPlayerBingoCards [1]);
			opponentBingoCards.Add (allOpponentBingoCards [1]);
			wonPrizes.Add (cardDesignPrizes [1]);
		}
		if (!playerBingoCards.Contains (allPlayerBingoCards [2])  && cardDesignThree == 1) {
			playerBingoCards.Add (allPlayerBingoCards [2]);
			opponentBingoCards.Add (allOpponentBingoCards [2]);
			wonPrizes.Add (cardDesignPrizes [2]);
		}
		if (!playerBingoCards.Contains (allPlayerBingoCards [3])  && cardDesignFour == 1) {
			playerBingoCards.Add (allPlayerBingoCards [3]);
			opponentBingoCards.Add (allOpponentBingoCards [3]);
			wonPrizes.Add (cardDesignPrizes [3]);
		}
		if (tierThreePrizeInterestingDesignPattern == 1 && tierThreePrizeBlankCard == 1) {
			wonPrizes.Add (tierThreePrizes [11]);
			for (int i = 0; i < wonPrizes.Count; i++) {
				if (wonPrizes [i] == tierThreePrizes [0])
					wonPrizes.Remove (wonPrizes [i]);
				if (wonPrizes [i] == tierThreePrizes [3])
					wonPrizes.Remove (wonPrizes [i]);
			}
		}

	}

	//remaining cards check function
	public bool bingoCardsRemaining(){
		if (remainingBingoCards != 0)
			return true;
		else
			return false;
	}

	public void reducePlayersBingoCards(){
		remainingBingoCards--;
	}

	public void updatePlayerBingoCards()
	{
		for (int i = 0; i < remainingBingoCardsNumber.Length; i++) 
		{
			//remainingBingoCardsNumber [i].text = remainingBingoCards.ToString () + "/" + maxRemainingBingoCards.ToString ();
		}
	}

	public void moreGamesButton(){
		Application.OpenURL("https://play.google.com/store/apps/developer?id=Love%20Apps%20LLC&hl=en");
	}

	public void muteDrawSounds(){
		if (calloutsToggle[0].isOn == true || calloutsToggle[1].isOn == true) {
			for(int i=0;i<bingoDrawSounds.Length;i++){
				bingoDrawSounds [i].mute = false;
			}
			for(int i=0;i<bingoDrawSoundsSpanish.Length;i++){
				bingoDrawSoundsSpanish [i].mute = false;
			}
		}
		if (calloutsToggle[0].isOn == false || calloutsToggle[1].isOn == false) {
			for(int i=0;i<bingoDrawSounds.Length;i++){
				bingoDrawSounds [i].mute = true;
			}
			for(int i=0;i<bingoDrawSoundsSpanish.Length;i++){
				bingoDrawSoundsSpanish [i].mute = true;
			}
		}
	}

	public void muteAudio(){
		if (audioToggle[0].isOn == true || audioToggle[1].isOn == true) {
			menuMusic.mute = false;
		}

		if (audioToggle[0].isOn == false || audioToggle[1].isOn == false) {
			menuMusic.mute = true;
		}
	}

	public void muteSfx(){
		if (sfxToggle [0].isOn == true || sfxToggle [1].isOn == true) {
			buttonClickMusic.mute = false;
			levelStartMusic.mute = false;
			levelWonMusic.mute = false;
			stampSound.mute = false;
			gameOverMusic.mute = false;
		}
		if (sfxToggle[0].isOn == false || sfxToggle[1].isOn == false) {
			buttonClickMusic.mute = true;
			levelStartMusic.mute = true;
			levelWonMusic.mute = true;
			stampSound.mute = true;
			gameOverMusic.mute = true;
		}
	}

	public void muteMusicPlayer(){
		if (!source.mute)
			source.mute = true;
		else
			source.mute = false;
	}

	public void playMenuMusic(){
		menuMusic.Play ();
	}

	public void stopMenuMusic(){
		menuMusic.Stop ();
	}

	public void stopBackgroundMusic(){
		source.Stop();
	}

	public void dailyRewardMusic(){
		dailyRewardSound.Play ();
	}

	public void buttonClickSound(){
		buttonClickMusic.Play ();
	}

	public void levelStartSound(){
		levelStartMusic.Play ();
	}

	public void levelWonSound(){
		levelWonMusic.Play ();
	}

	public void stampingSound(){
		stampSound.Play ();
	}

	public void gameOverSound(){
		gameOverMusic.Play ();
	}

	public void dailyRewardSfxSound(){
		dailyRewardSfx.Play ();
	}

	public void freeCardRewardSfxSound(){
		freeCardRewardSfx.Play ();
	}

	public void bingoWinSfxSound(){
		bingoWinSfx.Play ();
	}

	public void cardSetUnlockSound(){
		cardSetUnlockSfx.Play ();
	}
		
	public void backgroundSetUnlockSound(){
		backgroundSetUnlockSfx.Play ();
	}

	public void gamesWonCounter(){
		gamesWon++;
	}
	public void prizesCollectedCounter(){
		prizesCollected++;
	}

	public void userNameOk(){
		userName = userNamePlaceholder.text;
		Save ();
	}

	public void winStreakCalculations(){
		totalGamesPlayed++;
		gamesWon++;
		gamesWonCount++;
		gamesWonCountTwo++;
		winStreak++;
		loseStreak = 0;
		#if UNITY_ANDROID
			Social.ReportScore(totalGamesPlayed, "CgkI8NeUtIUMEAIQBg", (bool success) => {
			});
			Social.ReportScore(gamesWon, "CgkI8NeUtIUMEAIQCA", (bool success) => {
			});
			if (winStreakTotal < winStreak) {
				winStreakTotal = winStreak;
				Social.ReportScore(winStreakTotal, "CgkI8NeUtIUMEAIQBw", (bool success) => {
				});
			}
		#endif

		Highscores.AddNewHighscore (userName,totalGamesPlayed);
		Highscores.AddNewHighscoreTotalWins (userName, gamesWon);
		Highscores.AddNewHighscoreWinStreak (userName, winStreakTotal);

		#if UNITY_IOS
			Highscores.AddNewHighscore (userName,totalGamesPlayed);
			Highscores.AddNewHighscoreTotalWins (userName, gamesWon);
			Highscores.AddNewHighscoreWinStreak (userName, winStreakTotal);
		#endif
		Save ();
	}

	public void loseStreakCalculations(){
		totalGamesPlayed++;
		loseStreak++;
		winStreak = 0;
		#if UNITY_ANDROID
			Social.ReportScore(totalGamesPlayed, "CgkI8NeUtIUMEAIQBg", (bool success) => {
			});
			Social.ReportScore(totalGamesPlayed - gamesWon, "CgkI8NeUtIUMEAIQCg", (bool success) => {
			});
			if (loseStreakTotal < loseStreak) {
				loseStreakTotal = loseStreak;
				Social.ReportScore(loseStreakTotal, "CgkI8NeUtIUMEAIQCQ", (bool success) => {
				});
			}
		#endif

		Highscores.AddNewHighscore (userName,totalGamesPlayed);
		Highscores.AddNewHighscoreTotalLoses (userName, totalGamesPlayed - gamesWon);
		Highscores.AddNewHighscoreLoseStreak (userName, loseStreakTotal);

		#if UNITY_IOS
			Highscores.AddNewHighscore (userName,totalGamesPlayed);
			Highscores.AddNewHighscoreTotalLoses (userName, totalGamesPlayed - gamesWon);
			Highscores.AddNewHighscoreLoseStreak (userName, loseStreakTotal);
		#endif

		Save ();
	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady ("rewardedVideo")) {
			var options = new ShowOptions { resultCallback = HandleShowResult };
			UIController.UICon.FCButtonBar.GetComponent<Animator>().SetTrigger("Hide");
			UIController.UICon.WatchVideoTxt.GetComponent<Animator> ().SetTrigger ("Reduce");
			UIController.UICon.WatchAd.GetComponent<Button> ().interactable = false;
			Advertisement.Show ("rewardedVideo", options);
		} else if (AdColonyScript.AdColonyCon.IsAdColonyReady()) {
			UIController.UICon.FCButtonBar.GetComponent<Animator>().SetTrigger("Hide");
			UIController.UICon.WatchVideoTxt.GetComponent<Animator> ().SetTrigger ("Reduce");
			UIController.UICon.WatchAd.GetComponent<Button> ().interactable = false;
			AdColonyScript.AdColonyCon.PlayAd ();
			if (premiumAccount == 0) {
				howManyAdsWatched++;
			}
			adWatched = true;
			UIController.UICon.showClaimAdRewardButton ();
			UpdateWatchedAds ();
			if (IsInfiniteBonusReady ()) {
				InfiniteCardBonus.InfiniteCtrl.AddTime ();
			}
			Save();
		} else{
			UIController.UICon.loadCantWatchAd2 ();
		}
  	}

	private void HandleShowResult(ShowResult result){
		switch (result) {
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
        	// YOUR CODE TO REWARD THE GAMER
        	// Give coins etc.
			adWatched = true;
			UIController.UICon.showClaimAdRewardButton ();
			if (premiumAccount == 0) {
				howManyAdsWatched++;
			}
			UpdateWatchedAds ();
			if (IsInfiniteBonusReady ()) {
				InfiniteCardBonus.InfiniteCtrl.AddTime ();
			}
			Save ();
			//UIController.UICon.WatchVideoTxt.GetComponent<Animator> ().SetTrigger ("Reduce");
			break;
		case ShowResult.Skipped:
			Debug.Log ("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			UIController.UICon.WatchVideoTxt.GetComponent<Animator> ().SetTrigger ("Reset");
			Debug.LogError ("The ad failed to be shown.");
			break;
		}
	}

  public void adRewardClaim(){
  		if(adWatched == true){
			if (moodRingBonus != 2) {
				randomNumber3 = UnityEngine.Random.Range (1, 11);
			} else {
				randomNumber3 = UnityEngine.Random.Range (8, 11);
			}
  	    //int i = UnityEngine.Random.Range(1,11);
			if (randomNumber3 <= 7) {
				howManyCardsWon = 1;
				if (moodRingBonus != 4) {
					remainingBingoCards++;
				} else {
					remainingBingoCards += 2;
				}
			}
			else if (randomNumber3 == 8 || randomNumber3 == 9){
				howManyCardsWon = 2;
				remainingBingoCards += 2;
			}
			else if (randomNumber3 == 10) {
				howManyCardsWon = 3;
				if (moodRingBonus != 3){
					remainingBingoCards += 3;
				}
				else{
					remainingBingoCards += 4;
				}
			}
			if (isExtraCardsPurchased == 1)
				remainingBingoCards++;
        adWatched = false;
    }
  }

  public void dailyRewardSpin(){
		if (moodRingBonus != 1) {
			randomNumber2 = UnityEngine.Random.Range (1, 101);
		} else {
			randomNumber2 = UnityEngine.Random.Range (51, 101);
		}
  	  	//int i = UnityEngine.Random.Range(1,101);
		if (randomNumber2 <= 50) {
			remainingBingoCards++;
			howManyCardsWonDR = 1;
		} else if (randomNumber2 > 50 && randomNumber2 <= 70) {
			remainingBingoCards += 2;
			howManyCardsWonDR = 2;
		} else if (randomNumber2 > 70 && randomNumber2 <= 85) {
			remainingBingoCards += 3;
			howManyCardsWonDR = 3;
		} else if (randomNumber2 > 85 && randomNumber2 <= 95) {
			remainingBingoCards += 4;
			howManyCardsWonDR = 4;
		} else if (randomNumber2 > 95 && randomNumber2 <= 100) {
			remainingBingoCards += 5;
			howManyCardsWonDR = 5;
		}

		if (tierTwoPrizeCharmTwo == 1) {
			remainingBingoCards++;
		}
		if (tierTwoPrizeCharmFive == 1) {
			remainingBingoCards++;
		}

		UIController.UICon.LeftIndicator.GetComponentInChildren<Text> ().text = howManyCardsWonDR.ToString ();
		UIController.UICon.RightIndicator.GetComponentInChildren<Text> ().text = howManyCardsWonDR.ToString ();
		UIController.UICon.DRResultsText.GetComponent<Text> ().text = "You got " + howManyCardsWonDR.ToString () + " cards!";
  }

	public void toLeaderboards(){
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI();
		} else {
			Debug.Log ("Failed to open Leaderboards");
		}
	}

	public void playerReadyButtonClick(){
		bothPlayersReady++;
		for (int i = 0; i < 2; i++) {
			imReady [i].gameObject.SetActive (false);
			waitingForOpponent [i].gameObject.SetActive (true);
		}
		if (bothPlayersReady2 == 1) {
			bothPlayersReady2 = 2;
			bothPlayersReady++;
		}
	}

	public void stampColorPicker(){
		int i = UnityEngine.Random.Range(1,10);
		if (i == 1) {
			stampColor = Color.red;
		} else if (i == 2) {
			stampColor = Color.black;
		}else if (i == 3) {
			stampColor = Color.yellow;
		}else if (i == 4) {
			stampColor = Color.blue;
		}else if (i == 5) {
			stampColor = Color.green;
		}else if (i == 6) {
			stampColor = Color.cyan;
		}else if (i == 7) {
			stampColor = Color.gray;
		}else if (i == 8) {
			stampColor = Color.white;
		}else if (i == 9) {
			stampColor = Color.magenta;
		}
	}

	public void enableClaimFreeCards(){
		claimFreeCards.SetActive (true);
	}

	public void PlayCurrent(){
		CancelInvoke ();
		source.clip = clips[currentIndex];
		source.Play();
		Invoke( "PlayNext", source.clip.length);
	}

	public void Seek(SeekDirection d)
	{
		if (d == SeekDirection.Forward){
			currentIndex = (currentIndex + 1) % clips.Count;
			clipName.text = clipNames [currentIndex].ToString ();
		}else {
			currentIndex--;
			if (currentIndex < 0) currentIndex = clips.Count - 1;
			clipName.text = clipNames [currentIndex].ToString ();
		}
	}

	public void PlayNext(){
		currentIndex++;
		clipName.text = clipNames [currentIndex].ToString ();
		PlayCurrent ();
	}

	public void ChangeLeaderboardNameRight(){
		if (leaderboardCounter != leaderboardNames.Length -1) {
			leaderboardCounter++;
			leaderboardName.text = leaderboardNames [leaderboardCounter];
		} else {
			leaderboardCounter = 0;
			leaderboardName.text = leaderboardNames [leaderboardCounter];
		}
		if (leaderboardCounter == 0) {
			HideAllLeaderboardTables ();
			leaderboardTotalGamesL.SetActive(true);
			leaderboardTotalGamesR.SetActive(true);
		} else if(leaderboardCounter == 1){
			HideAllLeaderboardTables ();
			leaderboardTotalWinsL.SetActive(true);
			leaderboardTotalWinsR.SetActive(true);
		} else if(leaderboardCounter == 2){
			HideAllLeaderboardTables ();
			leaderboardWinStreakL.SetActive(true);
			leaderboardWinStreakR.SetActive(true);
		} else if(leaderboardCounter == 3){
			HideAllLeaderboardTables ();
			leaderboardTotalLosesL.SetActive(true);
			leaderboardTotalLosesR.SetActive(true);
		} else if(leaderboardCounter == 4){
			HideAllLeaderboardTables ();
			leaderboardLoseStreakL.SetActive(true);
			leaderboardLoseStreakR.SetActive(true);
		}
	}

	public void ChangeLeaderboardNameLeft(){
		if (leaderboardCounter != 0) {
			leaderboardCounter--;
			leaderboardName.text = leaderboardNames [leaderboardCounter];
		} else {
			leaderboardCounter = 4;
			leaderboardName.text = leaderboardNames [leaderboardCounter];
		}
		if (leaderboardCounter == 0) {
			HideAllLeaderboardTables ();
			leaderboardTotalGamesL.SetActive(true);
			leaderboardTotalGamesR.SetActive(true);
		} else if(leaderboardCounter == 1){
			HideAllLeaderboardTables ();
			leaderboardTotalWinsL.SetActive(true);
			leaderboardTotalWinsR.SetActive(true);
		} else if(leaderboardCounter == 2){
			HideAllLeaderboardTables ();
			leaderboardWinStreakL.SetActive(true);
			leaderboardWinStreakR.SetActive(true);
		} else if(leaderboardCounter == 3){
			HideAllLeaderboardTables ();
			leaderboardTotalLosesL.SetActive(true);
			leaderboardTotalLosesR.SetActive(true);
		} else if(leaderboardCounter == 4){
			HideAllLeaderboardTables ();
			leaderboardLoseStreakL.SetActive(true);
			leaderboardLoseStreakR.SetActive(true);
		}
	}

	public void HideAllLeaderboardTables(){
		leaderboardTotalGamesL.SetActive(false);
		leaderboardTotalGamesR.SetActive(false);
		leaderboardTotalWinsL.SetActive(false);
		leaderboardTotalWinsR.SetActive(false);
		leaderboardWinStreakL.SetActive(false);
		leaderboardWinStreakR.SetActive(false);
		leaderboardTotalLosesL.SetActive(false);
		leaderboardTotalLosesR.SetActive(false);
		leaderboardLoseStreakL.SetActive(false);
		leaderboardLoseStreakR.SetActive(false);
	}

	public void SetRightStamps(){
		if (!flipped) {
			if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [0]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = playerStampSprites [1];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = opponentStampSprites [1];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [1]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = playerStampSprites [2];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = opponentStampSprites [2];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [2]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = playerStampSprites [3];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = opponentStampSprites [3];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [3]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = playerStampSprites [4];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = opponentStampSprites [4];
				}
			} else {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = playerStampSprites [0];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = opponentStampSprites [0];
				}
			}
		} else {
			if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [0]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = opponentStampSprites [1];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = playerStampSprites [1];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [1]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = opponentStampSprites [2];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = playerStampSprites [2];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [2]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = opponentStampSprites [3];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = playerStampSprites [3];
				}
			} else if (playerBingoCard [0].GetComponent<Image> ().sprite == allPlayerBingoCards [3]) {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = opponentStampSprites [4];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = playerStampSprites [4];
				}
			} else {
				for (int i = 0; i < allPlayerStamps.Count; i++) {
					allPlayerStamps [i].sprite = opponentStampSprites [0];
				}
				for (int i = 0; i < allOpponentStamps.Count; i++) {
					allOpponentStamps [i].sprite = playerStampSprites [0];
				}
			}
		}
	}

	public void SetMoodRingText(){
		if (moodRingBonus == 1)
			moodRingText = moodRingTexts [0];
		else if (moodRingBonus == 2)
			moodRingText = moodRingTexts [1];
		else if (moodRingBonus == 3)
			moodRingText = moodRingTexts [2];
		else if (moodRingBonus == 4)
			moodRingText = moodRingTexts [3];
	}

	public void StampFreeButton(){
		OpponentCard.GetComponent<CardController> ().numCells [12].GetComponent<Button> ().onClick.Invoke ();
	}

	public void UpdateWonTotalPrizes(){
		String wonTotalPrizes = wonPrizes.Count.ToString () + "/" + totalPrizes.ToString ();
		prizesUnlockedTotal.text = wonTotalPrizes;
	}
	public void UpdateWonTotalBackgrounds(){
		String wonTotalBackgrounds = backgrounds.Count.ToString () + "/" + backgroundsTotal.ToString ();
		backgroundsUnlockedTotal.text = wonTotalBackgrounds;
		for (int i = 0; i < backgrounds.Count; i++) {
			if (background.sprite == backgrounds [i]) {
				backgroundText.sprite = backgroundTexts [i];
				backgroundChoice = i;
				backgroundCounter = i;
			}
		}
	}
	public void UpdateWonTotalBingoCards(){
		String wonTotalBingoCards = playerBingoCards.Count.ToString () + "/" + bingoCardsTotal.ToString ();
		UIController.UICon.BingoCards_UnlockedInd.text = wonTotalBingoCards;
		for (int i = 0; i < playerBingoCards.Count; i++) {
			if (playerBingoCard[0].sprite == playerBingoCards [i]) {
				playerBingoCardText.sprite = playerBingoCardTexts [i];
				stampChoice = i;
				bingoCardCounter = i;
			}
		}
	}

	public void OpenBasicBingoTwo(){
		Application.OpenURL("https://goo.gl/sOZnGZ");
	}

	public void checkForBingoCallsLanguage(){
		if (englishCalls == 0) {
			UIController.UICon.englishBingoCalls.isOn = true;
		} else {
			UIController.UICon.spanishBingoCalls.isOn = true;
		}
	}

	public void UpdateWatchedAds(){
		UIController.UICon.FCWatchedAdCountInd.text = howManyAdsWatched.ToString() + "/10";
	}

	public bool IsInfiniteBonusReady(){
		if (howManyAdsWatched >= 10) {
			howManyAdsWatched = 0;
			infiniteBonusIsOn = 1;
			UIController.UICon.loadInfiniteSigns ();
			Save ();
			return true;
		} else {
			return false;
		}
	}

	public bool InfiniteBonusNoteShow(){
		if (infiniteBonusNote == 0) {
			infiniteBonusNote = 1;
			Save ();
			return true;
		} else {
			return false;
		}
	}

	public void UpdateInfiniteSigns(){
		if (infiniteBonusIsOn == 1) {
			UIController.UICon.loadInfiniteSigns ();
		} else {
			UIController.UICon.hideInfiniteSigns ();
		}
	}

	public void UpdateThankYouPremium(){
		if (thankYou == 0) {
			UIController.UICon.loadThankYou ();
			thankYou++;
		}
		UIController.UICon.hideDailyRewardButton ();
		UIController.UICon.hideCardCounters ();
		UIController.UICon.loadInfiniteSigns ();
		UIController.UICon.hideCardsAdsCounters ();
		UIController.UICon.MM_BonusIcon.SetActive (false);
		UIController.UICon.MM_BonusTimerInd.gameObject.SetActive (false);
		Save ();
	}

	public void UpdateSignInSignOut(){
		if (MultiplayerController.Instance.CheckSignInSignOut ()) {
			UIController.UICon.loadSignOut ();
		} else {
			UIController.UICon.loadSignIn ();
		}
	}

	public void PurchaseInfiniteBonus(){
		GameController.GameCon.premiumAccount = 1;
		GameController.GameCon.UpdateThankYouPremium ();
		InfiniteCardBonus.InfiniteCtrl.RemoveTimer ();
		GameController.GameCon.Save ();
	}

	public void PurchaseInfiniteBonusSevenDays(){
		InfiniteCardBonus.InfiniteCtrl.AddTimeSevenDays();
		GameController.GameCon.infiniteBonusSevenDaysIsOn = 1;
		GameController.GameCon.Save ();
	}

	public void SetupMultiplayerGame(){
		startButton.SetActive (false);
		for (int y = 0; y < 2; y++) {
			blockers [y].gameObject.SetActive (true);
			playerReadyScreen [y].gameObject.SetActive (true);
//			bothBingoButtons [y].gameObject.SetActive (true);
			imReady [y].gameObject.SetActive (true);
			waitingForOpponent [y].gameObject.SetActive (false);
		}
		MultiplayerController.Instance.updateListener = this;
		_myParticipantId = MultiplayerController.Instance.GetMyParticipantId();
		List<Participant> allPlayers = MultiplayerController.Instance.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++) {
			string nextParticipantId = allPlayers [i].ParticipantId;
			Debug.Log ("Setting up card for " + nextParticipantId);
			if (nextParticipantId == _myParticipantId) {
				blockers[i].gameObject.SetActive (false);
				myCard = allCards [i];
				firstPlayer = players [i];
				//myBingoButton = bothBingoButtons [i];
			}else{
				theOpponentCard = allCards [i];
				//bothBingoButtons [i].gameObject.SetActive (false);
				playerReadyScreen [i].gameObject.SetActive (false);
			}
		}
		_multiplayerReady = true;
	}

	//Save and Load functions from official Unity live training tutorial "PERSISTENCE - SAVING AND LOADING DATA"
	public void Save(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/ppplayerInfoTest17.dat");

		PlayerData data = new PlayerData ();
		data.gamesWon = gamesWon;
		data.prizesCollected = prizesCollected;
		data.remainingBingoCards = remainingBingoCards;
		data.tierOnePrizePaperclip = tierOnePrizePaperclip;
		data.tierOnePrizeWinnersTrophy = tierOnePrizeWinnersTrophy;
		data.tierOnePrizeRubiksCube = tierOnePrizeRubiksCube;
		data.tierOnePrizeChocolateBar = tierOnePrizeChocolateBar;
		data.tierOnePrizePen = tierOnePrizePen;
		data.tierOnePrizeKeychain = tierOnePrizeKeychain;
		data.tierOnePrizeBeanieHat = tierOnePrizeBeanieHat;
		data.tierOnePrizeBagOfMarbles = tierOnePrizeBagOfMarbles;
		data.tierOnePrizePicTriviaToken = tierOnePrizePicTriviaToken;
		data.tierOnePrizeStandardSolitaireDeckOfCards = tierOnePrizeStandardSolitaireDeckOfCards;
		data.tierOnePrizeSetOfHighRollersDice = tierOnePrizeSetOfHighRollersDice;
		data.tierOnePrizeCoffeeMug = tierOnePrizeCoffeeMug;
		data.tierOnePrizeBearFeetSlippers = tierOnePrizeBearFeetSlippers;
		data.tierOnePrizeGiantGummyBear = tierOnePrizeGiantGummyBear;
		data.tierOnePrizeMylarBalloon = tierOnePrizeMylarBalloon;
		data.tierOnePrizeTeddyBear = tierOnePrizeTeddyBear;
		data.tierOnePrizeRubberDuck = tierOnePrizeRubberDuck;
		data.tierOnePrizeMegaSharkTooth = tierOnePrizeMegaSharkTooth;
		data.tierOnePrizeSunglasses = tierOnePrizeSunglasses;
		data.tierOnePrizeSlinky = tierOnePrizeSlinky;
		data.tierOnePrizeChineseFingerTrap = tierOnePrizeChineseFingerTrap;
		data.tierOnePrizeILoveBingoTShirt = tierOnePrizeILoveBingoTShirt;
		data.tierOnePrizeKazoo = tierOnePrizeKazoo;
		data.tierOnePrizePetRock = tierOnePrizePetRock;
		data.tierOnePrizeStressBall = tierOnePrizeStressBall;
		data.tierTwoPrizeEmptyCharmBracelet = tierTwoPrizeEmptyCharmBracelet;
		data.tierTwoPrizeCharmOne = tierTwoPrizeCharmOne;
		data.tierTwoPrizeCharmTwo = tierTwoPrizeCharmTwo;
		data.tierTwoPrizeCharmThree = tierTwoPrizeCharmThree;
		data.tierTwoPrizeCharmFour = tierTwoPrizeCharmFour;
		data.tierTwoPrizeCharmFive = tierTwoPrizeCharmFive;
		data.tierTwoPrizeMoodRing = tierTwoPrizeMoodRing;
		data.tierThreePrizePuzzlePieceOne = tierThreePrizePuzzlePieceOne;
		data.tierThreePrizePuzzlePieceTwo = tierThreePrizePuzzlePieceTwo;
		data.tierThreePrizePuzzlePieceThree = tierThreePrizePuzzlePieceThree;
		data.tierThreePrizePuzzlePieceFour = tierThreePrizePuzzlePieceFour;
		data.tierThreePrizeBlankCard = tierThreePrizeBlankCard;
		data.tierThreePrizeInterestingDesignPattern = tierThreePrizeInterestingDesignPattern;
		data.tierThreePrizeMaxCardExtender = tierThreePrizeMaxCardExtender;
		data.stampChoice = stampChoice;
		data.backgroundChoice = backgroundChoice;
		data.maxRemainingBingoCards = maxRemainingBingoCards;
		data.moodRingBonus = moodRingBonus;
		data.isExtraCardsPurchased = isExtraCardsPurchased;
		data.isMasterKeyPurchased = isMasterKeyPurchased;
		data.backgroundOne = backgroundOne;
		data.backgroundTwo = backgroundTwo;
		data.backgroundThree = backgroundThree;
		data.backgroundFour = backgroundFour;
		data.backgroundFive = backgroundFive;
		data.backgroundSix = backgroundSix;
		data.backgroundSeven = backgroundSeven;
		data.backgroundEight = backgroundEight;
		data.cardDesignOne = cardDesignOne;
		data.cardDesignTwo = cardDesignTwo;
		data.cardDesignThree = cardDesignThree;
		data.cardDesignFour = cardDesignFour;
		data.totalGamesPlayed = totalGamesPlayed;
		data.winStreak = winStreak;
		data.loseStreak = loseStreak;
		data.winStreakTotal = winStreakTotal;
		data.loseStreakTotal = loseStreakTotal;
		data.gamesWonCount = gamesWonCount;
		data.neverShowPopup = neverShowPopup;
		data.gamesWonCountTwo = gamesWonCountTwo;
		data.englishCalls = englishCalls;
		data.howManyAdsWatched = howManyAdsWatched;
		data.infiniteBonusNote = infiniteBonusNote;
		data.infiniteBonusIsOn = infiniteBonusIsOn;
		data.infiniteBonusSevenDaysIsOn = infiniteBonusSevenDaysIsOn;
		data.premiumAccount = premiumAccount;
		data.thankYou = thankYou;
		data.userName = userName;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/ppplayerInfoTest17.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/ppplayerInfoTest17.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			gamesWon = data.gamesWon;
			prizesCollected = data.prizesCollected;
			remainingBingoCards = data.remainingBingoCards;
			tierOnePrizePaperclip = data.tierOnePrizePaperclip;
			tierOnePrizeWinnersTrophy = data.tierOnePrizeWinnersTrophy;
			tierOnePrizeRubiksCube = data.tierOnePrizeRubiksCube;
			tierOnePrizeChocolateBar = data.tierOnePrizeChocolateBar;
			tierOnePrizePen = data.tierOnePrizePen;
			tierOnePrizeKeychain = data.tierOnePrizeKeychain;
			tierOnePrizeBeanieHat = data.tierOnePrizeBeanieHat;
			tierOnePrizeBagOfMarbles = data.tierOnePrizeBagOfMarbles;
			tierOnePrizePicTriviaToken = data.tierOnePrizePicTriviaToken;
			tierOnePrizeStandardSolitaireDeckOfCards = data.tierOnePrizeStandardSolitaireDeckOfCards;
			tierOnePrizeSetOfHighRollersDice = data.tierOnePrizeSetOfHighRollersDice;
			tierOnePrizeCoffeeMug = data.tierOnePrizeCoffeeMug;
			tierOnePrizeBearFeetSlippers = data.tierOnePrizeBearFeetSlippers;
			tierOnePrizeGiantGummyBear = data.tierOnePrizeGiantGummyBear;
			tierOnePrizeMylarBalloon = data.tierOnePrizeMylarBalloon;
			tierOnePrizeTeddyBear = data.tierOnePrizeTeddyBear;
			tierOnePrizeRubberDuck = data.tierOnePrizeRubberDuck;
			tierOnePrizeMegaSharkTooth = data.tierOnePrizeMegaSharkTooth;
			tierOnePrizeSunglasses = data.tierOnePrizeSunglasses;
			tierOnePrizeSlinky = data.tierOnePrizeSlinky;
			tierOnePrizeChineseFingerTrap = data.tierOnePrizeChineseFingerTrap;
			tierOnePrizeILoveBingoTShirt = data.tierOnePrizeILoveBingoTShirt;
			tierOnePrizeKazoo = data.tierOnePrizeKazoo;
			tierOnePrizePetRock = data.tierOnePrizePetRock;
			tierOnePrizeStressBall = data.tierOnePrizeStressBall;
			tierTwoPrizeEmptyCharmBracelet = data.tierTwoPrizeEmptyCharmBracelet;
			tierTwoPrizeCharmOne = data.tierTwoPrizeCharmOne;
			tierTwoPrizeCharmTwo = data.tierTwoPrizeCharmTwo;
			tierTwoPrizeCharmThree = data.tierTwoPrizeCharmThree;
			tierTwoPrizeCharmFour = data.tierTwoPrizeCharmFour;
			tierTwoPrizeCharmFive = data.tierTwoPrizeCharmFive;
			tierTwoPrizeMoodRing = data.tierTwoPrizeMoodRing;
			tierThreePrizePuzzlePieceOne = data.tierThreePrizePuzzlePieceOne;
			tierThreePrizePuzzlePieceTwo = data.tierThreePrizePuzzlePieceTwo;
			tierThreePrizePuzzlePieceThree = data.tierThreePrizePuzzlePieceThree;
			tierThreePrizePuzzlePieceFour = data.tierThreePrizePuzzlePieceFour;
			tierThreePrizeBlankCard = data.tierThreePrizeBlankCard;
			tierThreePrizeInterestingDesignPattern = data.tierThreePrizeInterestingDesignPattern;
			tierThreePrizeMaxCardExtender = data.tierThreePrizeMaxCardExtender;
			stampChoice = data.stampChoice;
			backgroundChoice = data.backgroundChoice;
			maxRemainingBingoCards = data.maxRemainingBingoCards;
			moodRingBonus = data.moodRingBonus;
			isExtraCardsPurchased = data.isExtraCardsPurchased;
			isMasterKeyPurchased = data.isMasterKeyPurchased;
			backgroundOne = data.backgroundOne;
			backgroundTwo = data.backgroundTwo;
			backgroundThree = data.backgroundThree;
			backgroundFour = data.backgroundFour;
			backgroundFive = data.backgroundFive;
			backgroundSix = data.backgroundSix;
			backgroundSeven = data.backgroundSeven;
			backgroundEight = data.backgroundEight;
			cardDesignOne = data.cardDesignOne;
			cardDesignTwo = data.cardDesignTwo;
			cardDesignThree = data.cardDesignThree;
			cardDesignFour = data.cardDesignFour;
			totalGamesPlayed = data.totalGamesPlayed;
			winStreak = data.winStreak;
			loseStreak = data.loseStreak;
			winStreakTotal = data.winStreakTotal;
			loseStreakTotal = data.loseStreakTotal;
			gamesWonCount = data.gamesWonCount;
			neverShowPopup = data.neverShowPopup;
			gamesWonCountTwo = data.gamesWonCountTwo;
			englishCalls = data.englishCalls;
			howManyAdsWatched = data.howManyAdsWatched;
			infiniteBonusNote = data.infiniteBonusNote;
			infiniteBonusIsOn = data.infiniteBonusIsOn;
			infiniteBonusSevenDaysIsOn = data.infiniteBonusSevenDaysIsOn;
			premiumAccount = data.premiumAccount;
			thankYou = data.thankYou;
			userName = data.userName;
		}
	}
}
[Serializable]
class PlayerData{
	public int gamesWon;
	public int prizesCollected;
	public int remainingBingoCards;
	public int tierOnePrizePaperclip;
	public int tierOnePrizeWinnersTrophy;
	public int tierOnePrizeRubiksCube;
	public int tierOnePrizeChocolateBar;
	public int tierOnePrizePen;
	public int tierOnePrizeKeychain;
	public int tierOnePrizeBeanieHat;
	public int tierOnePrizeBagOfMarbles;
	public int tierOnePrizePicTriviaToken;
	public int tierOnePrizeStandardSolitaireDeckOfCards;
	public int tierOnePrizeSetOfHighRollersDice;
	public int tierOnePrizeCoffeeMug;
	public int tierOnePrizeBearFeetSlippers;
	public int tierOnePrizeGiantGummyBear;
	public int tierOnePrizeMylarBalloon;
	public int tierOnePrizeTeddyBear;
	public int tierOnePrizeRubberDuck;
	public int tierOnePrizeMegaSharkTooth;
	public int tierOnePrizeSunglasses;
	public int tierOnePrizeSlinky;
	public int tierOnePrizeChineseFingerTrap;
	public int tierOnePrizeILoveBingoTShirt;
	public int tierOnePrizeKazoo;
	public int tierOnePrizePetRock;
	public int tierOnePrizeStressBall;
	public int tierTwoPrizeEmptyCharmBracelet;
	public int tierTwoPrizeCharmOne;
	public int tierTwoPrizeCharmTwo;
	public int tierTwoPrizeCharmThree;
	public int tierTwoPrizeCharmFour;
	public int tierTwoPrizeCharmFive;
	public int tierTwoPrizeMoodRing;
	public int tierThreePrizePuzzlePieceOne;
	public int tierThreePrizePuzzlePieceTwo;
	public int tierThreePrizePuzzlePieceThree;
	public int tierThreePrizePuzzlePieceFour;
	public int tierThreePrizeBlankCard;
	public int tierThreePrizeInterestingDesignPattern;
	public int tierThreePrizeMaxCardExtender;
	public int stampChoice;
	public int backgroundChoice;
	public int maxRemainingBingoCards;
	public int moodRingBonus;
	public int isExtraCardsPurchased;
	public int isMasterKeyPurchased;
	public int backgroundOne;
	public int backgroundTwo;
	public int backgroundThree;
	public int backgroundFour;
	public int backgroundFive;
	public int backgroundSix;
	public int backgroundSeven;
	public int backgroundEight;
	public int cardDesignOne;
	public int cardDesignTwo;
	public int cardDesignThree;
	public int cardDesignFour;
	public int totalGamesPlayed;
	public int winStreak;
	public int loseStreak;
	public int winStreakTotal;
	public int loseStreakTotal;
	public int gamesWonCount;
	public int neverShowPopup;
	public int gamesWonCountTwo;
	public int englishCalls;
	public int howManyAdsWatched;
	public int infiniteBonusNote;
	public int infiniteBonusIsOn;
	public int infiniteBonusSevenDaysIsOn;
	public int premiumAccount;
	public int thankYou;
	public string userName;
}
