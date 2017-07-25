using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BallDraw : MonoBehaviour {

	public static int counter;
	private string columnLetter;
	private int maxNumbers = 75;

	private List<int> uniqueNumbers;
	public static List<int> finishedList1;
	private List<int> bColumnNumbers;
	private List<int> iColumnNumbers;
	private List<int> nColumnNumbers;
	private List<int> gColumnNumbers;
	private List<int> oColumnNumbers;
	public GameObject canvas;
	public Text drawNumber;

	private RandomNumberGeneratorB scriptB;
	private RandomNumberGeneratorI scriptI;
	private RandomNumberGeneratorN scriptN;
	private RandomNumberGeneratorG scriptG;
	private RandomNumberGeneratorO scriptO;

	void Start(){
		uniqueNumbers = new List<int>();
		finishedList1 = new List<int>();
		bColumnNumbers = new List<int>();
		iColumnNumbers = new List<int>();
		nColumnNumbers = new List<int>();
		gColumnNumbers = new List<int>();
		oColumnNumbers = new List<int>();
		counter = 0;
		GenerateRandomList ();
		PopulateColumnLists ();

		scriptB = canvas.GetComponent<RandomNumberGeneratorB>();
		scriptI = canvas.GetComponent<RandomNumberGeneratorI>();
		scriptN = canvas.GetComponent<RandomNumberGeneratorN>();
		scriptG = canvas.GetComponent<RandomNumberGeneratorG>();
		scriptO = canvas.GetComponent<RandomNumberGeneratorO>();

	}

	public void GenerateRandomList(){
		for(int i = 1; i < maxNumbers; i++){
			uniqueNumbers.Add(i);
		}
		for(int i = 1; i< maxNumbers; i ++){
			int ranNum = uniqueNumbers[Random.Range(0,uniqueNumbers.Count)];
			finishedList1.Add(ranNum);
			uniqueNumbers.Remove (ranNum);
		}
	}

	public void PopulateColumnLists(){
		for(int i = 1; i < 16; i++){
			bColumnNumbers.Add(i);
		}
		for(int i = 16; i < 31; i++){
			iColumnNumbers.Add(i);
		}
		for(int i = 31; i < 46; i++){
			nColumnNumbers.Add(i);
		}
		for(int i = 46; i < 61; i++){
			gColumnNumbers.Add(i);
		}
		for(int i = 61; i < 76; i++){
			oColumnNumbers.Add(i);
		}
	}

	public void GenerateColumnLetter(){
		if (counter < 76) {
			counter++;
			if (bColumnNumbers.Contains (finishedList1 [counter])) {
				columnLetter = "B";
			} else if (iColumnNumbers.Contains (finishedList1 [counter])) {
				columnLetter = "I";
			} else if (nColumnNumbers.Contains (finishedList1 [counter])) {
				columnLetter = "N";
			} else if (gColumnNumbers.Contains (finishedList1 [counter])) {
				columnLetter = "G";
			} else if (oColumnNumbers.Contains (finishedList1 [counter])) {
				columnLetter = "O";
			}
			drawNumber.text = columnLetter + finishedList1 [counter].ToString ();
		}
	}

	public void click() {
		GenerateColumnLetter();
		scriptB.ButtonClickChecker ();
		scriptI.ButtonClickChecker ();
		scriptN.ButtonClickChecker ();
		scriptG.ButtonClickChecker ();
		scriptO.ButtonClickChecker ();
	}
		
}