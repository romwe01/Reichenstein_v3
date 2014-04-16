using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;




public class guiTest : MonoBehaviour {

	bool showQuest = true;

	int cWirt, cBev, cNat;


	public int pWirt = 60;
	public int pBev = 60;
	public int pNat = 60;
	bool castleBuilt = true;


	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("pWirt", 60);
		PlayerPrefs.SetInt("pBev", 60);
		PlayerPrefs.SetInt("pNat", 60);
		PlayerPrefs.SetInt("round", 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("space")) 
		{
			showQuest = !showQuest;
		}



	}

	void OnGUI() 
	{
		//SOLL NUR AUSGEFÜHRT WERDEN WENN DES FENSTER OFFEN IS
		if(showQuest) 
		{
			if (castleBuilt)
			{

				XmlDocument xmlDoc = new XmlDocument();

				string line = "";
				using (StreamReader sr = new StreamReader(Application.dataPath + "/" + "Quests" + "/" + "randomQuestList.txt"))
				for (int i = 0; i < 20; i++)
				{
					line = sr.ReadLine();
					if (i == PlayerPrefs.GetInt("round"))
						break;
				}

				xmlDoc.Load(line);

				//INHALTE VO DEM FILE
				XmlNodeList questName = xmlDoc.GetElementsByTagName("name");
				XmlNodeList desc = xmlDoc.GetElementsByTagName("desc");
				XmlNodeList begr = xmlDoc.GetElementsByTagName("begr");
				XmlNodeList umwelt = xmlDoc.GetElementsByTagName("umwelt");
				XmlNodeList bev = xmlDoc.GetElementsByTagName("bevoelk");
				XmlNodeList wirt = xmlDoc.GetElementsByTagName("wirtschaft");



				//---------GUI STUFF----------

				GUILayout.Space(20);
				GUI.skin.textField.wordWrap = true;


				//DIE BUTTONS FÜR QUESTAUSWAHL
				if (GUI.Button(new Rect(Screen.width / 4 +20, Screen.height/6 + Screen.height / 2, Screen.width/7, 25), "A")) 
				{
					if (PlayerPrefs.GetInt("round") == 4 || PlayerPrefs.GetInt("round") == 9 || PlayerPrefs.GetInt("round") == 14 || PlayerPrefs.GetInt("round") == 19)
					{
						castleBuilt = false;
					}
					calculatePoints(int.Parse(wirt[0].InnerText), int.Parse(bev[0].InnerText), int.Parse(umwelt[0].InnerText));
					int round = PlayerPrefs.GetInt("round");
					round++;
					PlayerPrefs.SetInt("round", round);
				}
				
				if (GUI.Button(new Rect(Screen.width/5 * 2 +30, Screen.height/6 + Screen.height / 2, Screen.width/7, 25), "B")) 
				{
					if (PlayerPrefs.GetInt("round") == 4 || PlayerPrefs.GetInt("round") == 9 || PlayerPrefs.GetInt("round") == 14 || PlayerPrefs.GetInt("round") == 19)
					{
						castleBuilt = false;
					}

					calculatePoints(int.Parse(wirt[1].InnerText), int.Parse(bev[1].InnerText), int.Parse(umwelt[1].InnerText));
					int round = PlayerPrefs.GetInt("round");
					round++;
					PlayerPrefs.SetInt("round", round);
				}
				if (GUI.Button(new Rect(Screen.width/7*4 +20, Screen.height/6 + Screen.height / 2, Screen.width/7, 25), "C")) 
				{
					if (PlayerPrefs.GetInt("round") == 4 || PlayerPrefs.GetInt("round") == 9 || PlayerPrefs.GetInt("round") == 14 || PlayerPrefs.GetInt("round") == 19)
					{
						castleBuilt = false;
					}
					calculatePoints(int.Parse(wirt[2].InnerText), int.Parse(bev[2].InnerText), int.Parse(umwelt[2].InnerText));
					int round = PlayerPrefs.GetInt("round");
					round++;
					PlayerPrefs.SetInt("round", round);
				}

				//RIESENBOX MIT BESCHREIBUNG
				GUI.TextField(new Rect(Screen.width/4 , Screen.height/4, Screen.width/2, Screen.height/2), desc[0].InnerText);
				//TITEL
				GUI.TextField(new Rect(Screen.width/4, Screen.height/4 - 35, 200, 29), questName[0].InnerText);

				//DIE KLEINEN TEXTBOXEN MIT KURZBESCHREIBUNGEN 
				GUI.TextField(new Rect(Screen.width/ 4 +20, Screen.height/2, Screen.width/7, Screen.height/6), desc[1].InnerText);
				GUI.TextField(new Rect(Screen.width/5 * 2 +30, Screen.height/2, Screen.width/7, Screen.height/6), desc[2].InnerText);
				GUI.TextField(new Rect(Screen.width/7*4 +20, Screen.height/2, Screen.width/7, Screen.height/6), desc[3].InnerText);

			}
			else 
			{
				if (PlayerPrefs.GetInt ("round") != 20)
				{
					if (GUI.Button(new Rect(Screen.width/7*4 +20, Screen.height/6 + Screen.height / 2, Screen.width/7, 25), "OK")) 
					{
						castleBuilt = true;
					}
					GUI.TextField(new Rect(Screen.width/4 , Screen.height/4, Screen.width/2, Screen.height/2), "castleBuilt");
				}
				//FINISH GUI

				if (PlayerPrefs.GetInt("round") == 20 )
				{
					if (GUI.Button(new Rect(Screen.width/7*4 +20, Screen.height/6 + Screen.height / 2, Screen.width/7, 25), "OK")) 
					{

						Application.LoadLevel(Application.loadedLevel);
					}
					GUI.TextField(new Rect(Screen.width/4 , Screen.height/4, Screen.width/2, Screen.height/2), "Hurraaa! Du hast gewonnen!");
					
					print (PlayerPrefs.GetInt("round"));
				}

			}

		}

		//ANZEIGETAFELN AM UNTEREN BILDSCHIRMRAND
		string pWirt = PlayerPrefs.GetInt("pWirt").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 200, Screen.height -60, 100, 50), "Wirtschaft\n" + pWirt);

		string pBev = PlayerPrefs.GetInt("pBev").ToString();
		GUI.TextField(new Rect((Screen.width / 2) - 50, Screen.height -60, 100, 50), "Bevölkerung\n" + pBev);

		string pNat = PlayerPrefs.GetInt("pNat").ToString();
		GUI.TextField(new Rect((Screen.width / 2) + 100, Screen.height -60, 100, 50), "Natur\n" + pNat);

	}

	//INSIDE BOUNDARIES UND NEUBERECHNUNG DER PUNKTE BEIM KLICKEN DER BUTTONS
	void calculatePoints(int xmlData1, int xmlData2, int xmlData3)
	{
		if  ((PlayerPrefs.GetInt("pWirt") + xmlData1) >= 0 && (PlayerPrefs.GetInt("pWirt") + xmlData1) <= 100)
		{
			cWirt = PlayerPrefs.GetInt("pWirt");
			cWirt += xmlData1;
			PlayerPrefs.SetInt("pWirt", cWirt);
		}

		if  ((PlayerPrefs.GetInt("pBev") + xmlData2) >= 0 && (PlayerPrefs.GetInt("pBev") + xmlData2) <= 100)
		{
			cBev = PlayerPrefs.GetInt("pBev");
			cBev += xmlData2;
			PlayerPrefs.SetInt("pBev", cBev);
		}

		if  ((PlayerPrefs.GetInt("pNat") + xmlData3) >= 0 && (PlayerPrefs.GetInt("pNat") + xmlData3) <= 100)
		{
			cNat = PlayerPrefs.GetInt("pNat");
			cNat += xmlData3;
			PlayerPrefs.SetInt("pNat", cNat);
		}
	}



}
