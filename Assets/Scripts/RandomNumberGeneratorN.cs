using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomNumberGeneratorN : MonoBehaviour {

	private int maxNumbers = 45;
	private List<int> uniqueNumbers;
	private List<int> finishedList;
	public Text B1;
	public Text B2;
	public Text B3;
	public Text B4;
	public Text B5;
	public Button button1;
	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;

	void Start(){
		uniqueNumbers = new List<int>();
		finishedList = new List<int>();
		GenerateRandomList ();
		AssignNumbers ();
	}

	public void GenerateRandomList(){
		for(int i = 30; i < maxNumbers; i++){
			uniqueNumbers.Add(i);
		}
		for(int i = 30; i< maxNumbers; i ++){
			int ranNum = uniqueNumbers[Random.Range(0,uniqueNumbers.Count)];
			finishedList.Add(ranNum);
			uniqueNumbers.Remove (ranNum);
		}
	}

	public void AssignNumbers(){
		B1.text = finishedList [0].ToString();
		B2.text = finishedList [1].ToString();
		B3.text = finishedList [2].ToString();
		B4.text = finishedList [3].ToString();
		B5.text = finishedList [4].ToString();
	}	

	public void ButtonClickChecker(){
		if (finishedList[0] == BallDraw.finishedList1 [BallDraw.counter])
			button1.interactable = true;
		else if(finishedList[1] == BallDraw.finishedList1 [BallDraw.counter])
			button2.interactable = true;
		else if(finishedList[2] == BallDraw.finishedList1 [BallDraw.counter])
			button3.interactable = true;
		else if(finishedList[3] == BallDraw.finishedList1 [BallDraw.counter])
			button4.interactable = true;
		else if(finishedList[4] == BallDraw.finishedList1 [BallDraw.counter])
			button5.interactable = true;
	}

	public void OnButtonClick1(){
		button1.GetComponent<Image>().color = Color.red;
	}
	public void OnButtonClick2(){
		button2.GetComponent<Image>().color = Color.red;
	}
	public void OnButtonClick3(){
		button3.GetComponent<Image>().color = Color.red;
	}
	public void OnButtonClick4(){
		button4.GetComponent<Image>().color = Color.red;
	}
	public void OnButtonClick5(){
		button5.GetComponent<Image>().color = Color.red;
	}
}