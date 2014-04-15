using UnityEngine;
using System.Collections;

public class gameTest : MonoBehaviour {

	public int pWirt = 60;
	public int pBev = 60;
	public int pNat = 60;
	int cWirt;
	int cBev;
	int cNat;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("pWirt", 60);
		PlayerPrefs.SetInt("pBev", 60);
		PlayerPrefs.SetInt("pNat", 60);
		PlayerPrefs.SetInt("round", 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		processInput();

	}

	//supergeil
	//megatittenaffengeil
	void processInput() {

		if(Input.GetKeyDown("w")) {
			cWirt = PlayerPrefs.GetInt("pWirt");
			cWirt += 10;
			PlayerPrefs.SetInt("pWirt", cWirt);
			cBev = PlayerPrefs.GetInt("pBev");
			cBev -= 5;
			PlayerPrefs.SetInt("pBev", cBev);
			cNat = PlayerPrefs.GetInt("pNat");
			cNat -= 5;
			PlayerPrefs.SetInt("pNat", cNat);
			//print("Wirt: " + PlayerPrefs.GetInt("pWirt") + " Bev: " + PlayerPrefs.GetInt("pBev") + " Nat: " + PlayerPrefs.GetInt("pNat"));
		}
		
		if(Input.GetKeyDown("b")) {
			cWirt = PlayerPrefs.GetInt("pWirt");
			cWirt -= 5;
			PlayerPrefs.SetInt("pWirt", cWirt);
			cBev = PlayerPrefs.GetInt("pBev");
			cBev += 10;
			PlayerPrefs.SetInt("pBev", cBev);
			cNat = PlayerPrefs.GetInt("pNat");
			cNat -= 5;
			PlayerPrefs.SetInt("pNat", cNat);
			//print("Wirt: " + PlayerPrefs.GetInt("pWirt") + " Bev: " + PlayerPrefs.GetInt("pBev") + " Nat: " + PlayerPrefs.GetInt("pNat"));
		}
		
		if(Input.GetKeyDown("n")) {
			cWirt = PlayerPrefs.GetInt("pWirt");
			cWirt -= 5;
			PlayerPrefs.SetInt("pWirt", cWirt);
			cBev = PlayerPrefs.GetInt("pBev");
			cBev -= 5;
			PlayerPrefs.SetInt("pBev", cBev);
			cNat = PlayerPrefs.GetInt("pNat");
			cNat += 10;
			PlayerPrefs.SetInt("pNat", cNat);
			//print("Wirt: " + PlayerPrefs.GetInt("pWirt") + " Bev: " + PlayerPrefs.GetInt("pBev") + " Nat: " + PlayerPrefs.GetInt("pNat"));
		}

	}
}
