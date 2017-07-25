using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardController : MonoBehaviour {
	public static CardController CardCon;
	public List<int> cardNumbers; // List of the 25 numbers assigned to a card
	public GameObject[] numCells = new GameObject[25]; // Array of the 25 game objects that represent the numbers on a card
	public Button bingoButton;
	public Button bingoButton2;

	// Use this for initialization
//	void Start () 
//	{
//		GenerateCardNumbers (); 
//		UpdateCardUI ();
//	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateCardNumbers() // Creates the list of 25 numbers the card will use. The first 5 numbers are Column B, second are I, third are N, etc.
	{
		//if (GameController.GameCon.myCard == gameObject) {
			cardNumbers = new List<int> ();
			GenerateBColumn ();
			GenerateIColumn ();
			GenerateNColumn ();
			GenerateGColumn ();
			GenerateOColumn ();
		//}
	}

	void GenerateBColumn() // Creates 5 random non-repeating numbers ranging from 1-15 for the B-Column of the card.
	{
		List<int> tempList = new List<int>();

		for(int i = 1; i < 16; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 5; i ++)
		{
			int ranNum = tempList[Random.Range(0,tempList.Count)];
			cardNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	void GenerateIColumn()// Creates 5 random non-repeating numbers ranging from 16-30 for the I-Column of the card.
	{
		List<int> tempList = new List<int> ();

		for(int i = 16; i < 31; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 5; i++)
		{
			int ranNum = tempList[Random.Range(0,tempList.Count)];
			cardNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	void GenerateNColumn()// Creates 5 random non-repeating numbers ranging from 31-45 for the N-Column of the card.
	{
		List<int> tempList = new List<int> ();

		for(int i = 31; i < 46; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 5; i++)
		{
			int ranNum = tempList[Random.Range(0,tempList.Count)];
			cardNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	void GenerateGColumn()// Creates 5 random non-repeating numbers ranging from 46-60 for the G-Column of the card.
	{
		List<int> tempList = new List<int> ();

		for(int i = 46; i < 61; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 5; i++)
		{
			int ranNum = tempList[Random.Range(0,tempList.Count)];
			cardNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	void GenerateOColumn()// Creates 5 random non-repeating numbers ranging from 61-75 for the O-Column of the card.
	{
		List<int> tempList = new List<int> ();

		for(int i = 61; i < 76; i++)
		{
			tempList.Add(i);
		}

		for(int i = 0; i< 5; i++)
		{
			int ranNum = tempList[Random.Range(0,tempList.Count)];
			cardNumbers.Add(ranNum);
			tempList.Remove (ranNum);
		}
	}

	public void UpdateCardUI()// Updates the cards Text Objects to reflect the associated number.
	{
		for (int i = 0; i < 25; i++) 
		{
			numCells [i].GetComponentInChildren<Text> ().text = cardNumbers [i].ToString ();
		}
		numCells [12].GetComponentInChildren<Text> ().text = "Free";
	}
	//resets all the button images and making them uninteractable from the start, except the free one in the middle
	public void resetButtons(){
		for (int i = 0; i < 25; i++) {
			Color tmp = numCells [i].GetComponent<Image> ().color;
			tmp.a = .01f;
		
			numCells [i].GetComponent<Button> ().interactable = false;
			numCells [i].GetComponent<Image> ().color = tmp;
		}
		if (GameController.GameCon.isMultiplayerGame == false) {
			if (gameObject.tag == "Player")
				numCells [12].GetComponent<Button> ().interactable = true;
		} else {
			numCells [12].GetComponent<Button> ().interactable = true;
		}
			
	}

//	public void StampFreeButton(){
//		if (gameObject.tag == "Opponent") {
//			numCells [12].GetComponent<Button> ().onClick.Invoke ();
//		}
//	}


}
