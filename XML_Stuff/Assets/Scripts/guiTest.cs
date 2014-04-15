using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;


public class guiTest : MonoBehaviour {

	bool showQuest = true;
	int questX = (Screen.width / 2);
	int questY = (Screen.height / 4);
	int questWidth = (Screen.width / 2);
	int questHeight = (Screen.height / 2);




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown("space")) {
			int round = PlayerPrefs.GetInt("round");
			round++;
			PlayerPrefs.SetInt("round", round);

			showQuest = !showQuest;
		}

	}

	void OnGUI() {

		if(showQuest) {

			XmlDocument xmlDoc = new XmlDocument();

			string line = "";
			using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "Quests" + "/" + "randomQuestList.txt"))
			for (int i = 0; i < 5; i++)
			{
				line = sr.ReadLine();
				if (i == PlayerPrefs.GetInt("round"))
					break;
			}


			xmlDoc.Load(line);

			print (line);

			XmlNodeList questName = xmlDoc.GetElementsByTagName("name");
			XmlNodeList desc = xmlDoc.GetElementsByTagName("desc");
			XmlNodeList begr = xmlDoc.GetElementsByTagName("begr");


			//GUI Stuff

			GUILayout.Space(20);
			GUI.skin.textField.wordWrap = true;
			//Beschreibung in da riesen box
			GUI.TextField(new Rect(questX , questY, questWidth, questHeight), desc[0].InnerText);
			//Titel
			GUI.TextField(new Rect(questX, questY - 35, 200, 29), questName[0].InnerText);


			if (GUI.Button(new Rect(questWidth / 2 + 15, questY + (questHeight / 2), 100, 50), "A")) {

			}
			if (GUI.Button(new Rect(questWidth/5 * 4 + 15, questY + (questHeight / 2), 100, 50), "B")) {
				
			}
			if (GUI.Button(new Rect(questX + questWidth/3 * 2 + 15, questY + (questHeight / 2), 100, 50), "C")) {
				
			}


		}

		string pWirt = PlayerPrefs.GetInt("pWirt").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 200, Screen.height -60, 100, 50), "Wirtschaft\n" + pWirt);

		string pBev = PlayerPrefs.GetInt("pBev").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 50, Screen.height -60, 100, 50), "Bevölkerung\n" + pBev);

		string pNat = PlayerPrefs.GetInt("pNat").ToString();
		GUI.TextField(new Rect((Screen.width / 2) + 100, Screen.height -60, 100, 50), "Natur\n" + pNat);
	}


}
