using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class XMLFileLoader : MonoBehaviour {
	
	public string questsFolder = "Quests";
	public string sFileName = "questList.txt"; // Filename of List for Quests.
	public string rFileName = "randomQuestList.txt";
	public int questCount = 5;
	char[] timeZone = {'A', 'B', 'C', 'D'};
	static System.Random rnd = new System.Random();
	ArrayList aList = new ArrayList();
	ArrayList bList = new ArrayList();
	ArrayList cList = new ArrayList();
	ArrayList dList = new ArrayList();

	// Use this for initialization
	void Start () {

		generateQuestList();
		//getFixedQuests();
		getRandomQuests();

	}


	public int getQuestCount()
	{
		return questCount;
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	// Load all xml files from "questsFolder" and write path as strings to txt file
	void generateQuestList() {
		var list = new List<string>();
		var path = Application.dataPath + "/" + questsFolder;
		var info = new DirectoryInfo(path);
		var fileInfo = info.GetFiles();
	
		foreach(FileInfo file in fileInfo) {
			if(file.Extension == ".xml") {
				var filename = file.ToString();   
				list.Add(filename);
			}
		}

		var sFile = Application.dataPath + "/" + questsFolder + "/" + sFileName;

		using(var sData = new StreamWriter(sFile)) {

			foreach(string line in list) {
				var fileName = line.ToString(); 
				sData.WriteLine(fileName);
			}
		}
	}

	// Load and print out quests for each century
	void getFixedQuests() {
		string line;
		int check = 0;
		int addCent = 0;
		var sFile = Application.dataPath + "/" + questsFolder + "/" + sFileName;

		System.IO.StreamReader file = new System.IO.StreamReader(sFile);

		while((line = file.ReadLine()) != null) {
			string filename = Path.GetFileNameWithoutExtension(line);
			string century = Path.GetFileNameWithoutExtension(filename.Split('_')[0]); // Should work now via double string splitting.
			if(addCent < 4 && century.CompareTo(timeZone[check].ToString()) == 0) {
				print(line);
				addCent++;
			} else {
				if (check < 3) {
					check++;
					addCent = 0;
				}
				if(addCent < 4 && century.CompareTo(timeZone[check].ToString()) == 0) {
					print(line);
					addCent++;
				}
			}
		}
	}

	// TODO: Get randomly selected quests
	void getRandomQuests() {
		string line;
		var sFile = Application.dataPath + "/" + questsFolder + "/" + sFileName;

		System.IO.StreamReader file = new System.IO.StreamReader(sFile);

		while((line = file.ReadLine()) != null) {
			string filename = Path.GetFileNameWithoutExtension(line);
			string century = Path.GetFileNameWithoutExtension(filename.Split('_')[0]);

			// write all quests for each century in arraylist.
			if(century == "A") {
				aList.Add(line);
			} else if (century == "B") {
				bList.Add(line);
			} else if (century == "C") {
				cList.Add(line);
			} else {
				dList.Add(line);
			}
		}
		
		// randomize lists for each century.
		ArrayList aRand = randomize(aList);
		ArrayList bRand = randomize(bList);
		ArrayList cRand = randomize(cList);
		ArrayList dRand = randomize(dList);

		var rFile = Application.dataPath + "/" + questsFolder + "/" + rFileName;
		
		using(var sData = new StreamWriter(rFile)) {
			
			foreach(string rline in aRand) {
				var fileName = rline.ToString(); 
				sData.WriteLine(fileName);
			}
			foreach(string rline in bRand) {
				var fileName = rline.ToString(); 
				sData.WriteLine(fileName);
			}
			foreach(string rline in cRand) {
				var fileName = rline.ToString(); 
				sData.WriteLine(fileName);
			}
			foreach(string rline in dRand) {
				var fileName = rline.ToString(); 
				sData.WriteLine(fileName);
			}
		}





		// dirty output for testing purposes.

		/*foreach (string i in aRand)
		{
			print(i);
		}
		foreach (string i in bRand)
		{
			print(i);
		}
		foreach (string i in cRand)
		{
			print(i);
		}
		foreach (string i in dRand)
		{
			print(i);
		}
	*/
	}


	ArrayList randomize(ArrayList list) {
		ArrayList randomizedList = new ArrayList();
		while (randomizedList.Count <= questCount +2) { // TODO: Fix heavy workaround for boundaries.
			var index = rnd.Next (0, list.Count);
			randomizedList.Add(list[index]);
			list.RemoveAt(index);
		}
		return randomizedList;
	}

}
