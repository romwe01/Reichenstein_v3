using UnityEngine;
using System.Collections;

public class guiTest : MonoBehaviour {

	bool showQuest = true;
	int questX = (Screen.width / 2) - (Screen.width / 4);
	int questY = (Screen.height / 2) - (Screen.height / 4);
	int questWidth = (Screen.width / 2);
	int questHeight = (Screen.height / 2);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("space")) {
			showQuest = !showQuest;
		}

	}

	void OnGUI() {

		if(showQuest) {

			GUI.TextField(new Rect(questX , questY, questWidth, questHeight), "QuestText");
			GUI.TextField(new Rect(questX, questY - 35, 200, 29), "QuestTitel");

			/*if (GUI.Button(new Rect(Screen.width / 3, (Screen.height / 2) - 50, 100, 20), "Display 10")) {

			}*/
		}

		string pWirt = PlayerPrefs.GetInt("pWirt").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 200, Screen.height -60, 100, 50), "Wirtschaft\n" + pWirt);

		string pBev = PlayerPrefs.GetInt("pBev").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 50, Screen.height -60, 100, 50), "Bevölkerung\n" + pBev);

		string pNat = PlayerPrefs.GetInt("pNat").ToString();
		GUI.TextField(new Rect((Screen.width / 2) + 100, Screen.height -60, 100, 50), "Natur\n" + pNat);
	}


}
