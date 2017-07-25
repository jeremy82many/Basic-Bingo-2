using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BingoButton : MonoBehaviour {
	public static BingoButton BingoBtn;
	// Use this for initialization
	void Start () 
	{
		// The first if statement effectively turns this script into a static script that can be used in non-static methods and also allowing it to be used
		// by other scripts without a reference to the object it is attached to. (Only do this if there will only be one copy of this script in the scene)
		if (BingoBtn == null)
		{
			BingoBtn = this;
		}


	}

	public Button bingoButton;
	public GameObject redCard;

	public Button buttonB1;
	public Button buttonB2;
	public Button buttonB3;
	public Button buttonB4;
	public Button buttonB5;

	public Button buttonI1;
	public Button buttonI2;
	public Button buttonI3;
	public Button buttonI4;
	public Button buttonI5;

	public Button buttonN1;
	public Button buttonN2;
	public Button buttonN3;
	public Button buttonN4;
	public Button buttonN5;

	public Button buttonG1;
	public Button buttonG2;
	public Button buttonG3;
	public Button buttonG4;
	public Button buttonG5;

	public Button buttonO1;
	public Button buttonO2;
	public Button buttonO3;
	public Button buttonO4;
	public Button buttonO5;

	public int gameOverCounterBingo = 0;
	public bool isFourCorners;

	public void gameOver(){
		if (gameOverCounterBingo == 0) {
			GameController.GameCon.Save ();
			GameController.GameCon.gameOverSound ();
			//GameController.GameCon.cancelDrawBallAuto ();
			LevelController.LvlCon.Gameplay_StopBalls ();
			UIController.UICon.hideGameplayPlayGroup ();
			if (!GameController.GameCon.isMultiplayerGame) {
				UIController.UICon.loadGameOverGroup ();
			} else {
				UIController.UICon.loadGameOverGroupMultiplayer ();
			}

			CancelInvoke();
			gameOverCounterBingo++;
		}
	}

	public void bingoButtonPress(){
		if (GameController.GameCon.isMultiplayerGame == false) {
			if (buttonB1.image.color.a == 0 && buttonB2.image.color.a == 0 && buttonB3.image.color.a == 0 && buttonB4.image.color.a == 0 && buttonB5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
					buttonB2.gameObject.transform.GetChild (1).gameObject, buttonB3.gameObject.transform.GetChild (1).gameObject, buttonB4.gameObject.transform.GetChild (1).gameObject,
					buttonB5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonI1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonI5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonI1.gameObject.transform.GetChild (1).gameObject,
					buttonI2.gameObject.transform.GetChild (1).gameObject, buttonI3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
					buttonI5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonN1.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonN5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonN1.gameObject.transform.GetChild (1).gameObject,
					buttonN2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject,
					buttonN5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonG1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonG5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonG1.gameObject.transform.GetChild (1).gameObject,
					buttonG2.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
					buttonG5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonO1.image.color.a == 0 && buttonO2.image.color.a == 0 && buttonO3.image.color.a == 0 && buttonO4.image.color.a == 0 && buttonO5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
					buttonO2.gameObject.transform.GetChild (1).gameObject, buttonO3.gameObject.transform.GetChild (1).gameObject, buttonO4.gameObject.transform.GetChild (1).gameObject,
					buttonO5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB1.image.color.a == 0 && buttonI1.image.color.a == 0 && buttonN1.image.color.a == 0 && buttonG1.image.color.a == 0 && buttonO1.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
					buttonI1.gameObject.transform.GetChild (1).gameObject, buttonN1.gameObject.transform.GetChild (1).gameObject, buttonG1.gameObject.transform.GetChild (1).gameObject,
					buttonO1.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB2.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonO2.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB2.gameObject.transform.GetChild (1).gameObject,
					buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN2.gameObject.transform.GetChild (1).gameObject, buttonG2.gameObject.transform.GetChild (1).gameObject,
					buttonO2.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB3.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonO3.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB3.gameObject.transform.GetChild (1).gameObject,
					buttonI3.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject,
					buttonO3.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB4.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO4.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB4.gameObject.transform.GetChild (1).gameObject,
					buttonI4.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
					buttonO4.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB5.image.color.a == 0 && buttonI5.image.color.a == 0 && buttonN5.image.color.a == 0 && buttonG5.image.color.a == 0 && buttonO5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB5.gameObject.transform.GetChild (1).gameObject,
					buttonI5.gameObject.transform.GetChild (1).gameObject, buttonN5.gameObject.transform.GetChild (1).gameObject, buttonG5.gameObject.transform.GetChild (1).gameObject,
					buttonO5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
					buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
					buttonO5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonO1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonB5.image.color.a == 0)
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
					buttonG2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
					buttonB5.gameObject.transform.GetChild (1).gameObject
				}));
			else if (buttonB1.image.color.a == 0 && buttonB5.image.color.a == 0 && buttonO1.image.color.a == 0 && buttonO5.image.color.a == 0) {
				isFourCorners = true;
				StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
					buttonB5.gameObject.transform.GetChild (1).gameObject, buttonO1.gameObject.transform.GetChild (1).gameObject, buttonO5.gameObject.transform.GetChild (1).gameObject
				}));
			}
		} else {
			if (GameController.GameCon.myCard == GameController.GameCon.allCards [0]) {
				if (buttonB1.image.color.a == 0 && buttonB2.image.color.a == 0 && buttonB3.image.color.a == 0 && buttonB4.image.color.a == 0 && buttonB5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
						buttonB2.gameObject.transform.GetChild (1).gameObject, buttonB3.gameObject.transform.GetChild (1).gameObject, buttonB4.gameObject.transform.GetChild (1).gameObject,
						buttonB5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonI1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonI5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonI1.gameObject.transform.GetChild (1).gameObject,
						buttonI2.gameObject.transform.GetChild (1).gameObject, buttonI3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
						buttonI5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonN1.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonN5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonN1.gameObject.transform.GetChild (1).gameObject,
						buttonN2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject,
						buttonN5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonG1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonG5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonG1.gameObject.transform.GetChild (1).gameObject,
						buttonG2.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
						buttonG5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonO1.image.color.a == 0 && buttonO2.image.color.a == 0 && buttonO3.image.color.a == 0 && buttonO4.image.color.a == 0 && buttonO5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
						buttonO2.gameObject.transform.GetChild (1).gameObject, buttonO3.gameObject.transform.GetChild (1).gameObject, buttonO4.gameObject.transform.GetChild (1).gameObject,
						buttonO5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB1.image.color.a == 0 && buttonI1.image.color.a == 0 && buttonN1.image.color.a == 0 && buttonG1.image.color.a == 0 && buttonO1.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
						buttonI1.gameObject.transform.GetChild (1).gameObject, buttonN1.gameObject.transform.GetChild (1).gameObject, buttonG1.gameObject.transform.GetChild (1).gameObject,
						buttonO1.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB2.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonO2.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB2.gameObject.transform.GetChild (1).gameObject,
						buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN2.gameObject.transform.GetChild (1).gameObject, buttonG2.gameObject.transform.GetChild (1).gameObject,
						buttonO2.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB3.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonO3.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB3.gameObject.transform.GetChild (1).gameObject,
						buttonI3.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject,
						buttonO3.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB4.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO4.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB4.gameObject.transform.GetChild (1).gameObject,
						buttonI4.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
						buttonO4.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB5.image.color.a == 0 && buttonI5.image.color.a == 0 && buttonN5.image.color.a == 0 && buttonG5.image.color.a == 0 && buttonO5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB5.gameObject.transform.GetChild (1).gameObject,
						buttonI5.gameObject.transform.GetChild (1).gameObject, buttonN5.gameObject.transform.GetChild (1).gameObject, buttonG5.gameObject.transform.GetChild (1).gameObject,
						buttonO5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonB1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
						buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
						buttonO5.gameObject.transform.GetChild (1).gameObject
					}));
				} else if (buttonO1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonB5.image.color.a == 0) {
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
						buttonG2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
						buttonB5.gameObject.transform.GetChild (1).gameObject
					}));
				}
				else if (buttonB1.image.color.a == 0 && buttonB5.image.color.a == 0 && buttonO1.image.color.a == 0 && buttonO5.image.color.a == 0) {
					isFourCorners = true;
					GameController.GameCon.wonTheGame = true;
					StartCoroutine (UIController.UICon.Gameplay_BingoAnimation (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
						buttonB5.gameObject.transform.GetChild (1).gameObject, buttonO1.gameObject.transform.GetChild (1).gameObject, buttonO5.gameObject.transform.GetChild (1).gameObject
					}));
				}
			} else {
				if (buttonB1.image.color.a == 0 && buttonB2.image.color.a == 0 && buttonB3.image.color.a == 0 && buttonB4.image.color.a == 0 && buttonB5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
							buttonB2.gameObject.transform.GetChild (1).gameObject, buttonB3.gameObject.transform.GetChild (1).gameObject, buttonB4.gameObject.transform.GetChild (1).gameObject,
							buttonB5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonI1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonI5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonI1.gameObject.transform.GetChild (1).gameObject,
							buttonI2.gameObject.transform.GetChild (1).gameObject, buttonI3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
							buttonI5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonN1.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonN5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonN1.gameObject.transform.GetChild (1).gameObject,
							buttonN2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject,
							buttonN5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonG1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonG5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonG1.gameObject.transform.GetChild (1).gameObject,
							buttonG2.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
							buttonG5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonO1.image.color.a == 0 && buttonO2.image.color.a == 0 && buttonO3.image.color.a == 0 && buttonO4.image.color.a == 0 && buttonO5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
							buttonO2.gameObject.transform.GetChild (1).gameObject, buttonO3.gameObject.transform.GetChild (1).gameObject, buttonO4.gameObject.transform.GetChild (1).gameObject,
							buttonO5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB1.image.color.a == 0 && buttonI1.image.color.a == 0 && buttonN1.image.color.a == 0 && buttonG1.image.color.a == 0 && buttonO1.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
							buttonI1.gameObject.transform.GetChild (1).gameObject, buttonN1.gameObject.transform.GetChild (1).gameObject, buttonG1.gameObject.transform.GetChild (1).gameObject,
							buttonO1.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB2.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN2.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonO2.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB2.gameObject.transform.GetChild (1).gameObject,
							buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN2.gameObject.transform.GetChild (1).gameObject, buttonG2.gameObject.transform.GetChild (1).gameObject,
							buttonO2.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB3.image.color.a == 0 && buttonI3.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG3.image.color.a == 0 && buttonO3.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB3.gameObject.transform.GetChild (1).gameObject,
							buttonI3.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG3.gameObject.transform.GetChild (1).gameObject,
							buttonO3.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB4.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonN4.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO4.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB4.gameObject.transform.GetChild (1).gameObject,
							buttonI4.gameObject.transform.GetChild (1).gameObject, buttonN4.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
							buttonO4.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB5.image.color.a == 0 && buttonI5.image.color.a == 0 && buttonN5.image.color.a == 0 && buttonG5.image.color.a == 0 && buttonO5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB5.gameObject.transform.GetChild (1).gameObject,
							buttonI5.gameObject.transform.GetChild (1).gameObject, buttonN5.gameObject.transform.GetChild (1).gameObject, buttonG5.gameObject.transform.GetChild (1).gameObject,
							buttonO5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB1.image.color.a == 0 && buttonI2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonG4.image.color.a == 0 && buttonO5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
							buttonI2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonG4.gameObject.transform.GetChild (1).gameObject,
							buttonO5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonO1.image.color.a == 0 && buttonG2.image.color.a == 0 && buttonN3.image.color.a == 0 && buttonI4.image.color.a == 0 && buttonB5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonO1.gameObject.transform.GetChild (1).gameObject,
							buttonG2.gameObject.transform.GetChild (1).gameObject, buttonN3.gameObject.transform.GetChild (1).gameObject, buttonI4.gameObject.transform.GetChild (1).gameObject,
							buttonB5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				} else if (buttonB1.image.color.a == 0 && buttonB5.image.color.a == 0 && buttonO1.image.color.a == 0 && buttonO5.image.color.a == 0) {
					if (!GameController.GameCon.wonTheGame) {
						BingoButton.BingoBtn.isFourCorners = true;
						StartCoroutine (UIController.UICon.Gameplay_BingoAnimation_Computer (new GameObject[] {buttonB1.gameObject.transform.GetChild (1).gameObject,
							buttonB5.gameObject.transform.GetChild (1).gameObject, buttonO1.gameObject.transform.GetChild (1).gameObject, buttonO5.gameObject.transform.GetChild (1).gameObject
						}));
						Invoke ("gameOver", 2);
					}
				}
			}
		}
	}
}