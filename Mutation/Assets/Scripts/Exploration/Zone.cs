using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zone : ScriptableObject {
    string zoneName;
    Node[][] nodeArray;
	public string description;
	Canvas canvas;
	UnityEngine.UI.Image backgroundColor;
	public string pass;
	//MapControl mapControl;
	//CombatControl combatScript;

	//for Bounty Quest1
	public bool GenerateQuestMonster;
	public bool startQuest1;
	public bool questIsActive;
	public int randomXSpawn;
	public int randomYSpawn;

	//for Enterance to DownTown  Used in MapControl Update
	public bool canEnterDT = false;

	//for Crossing Bridge at Mnt WA  Used in MapControl Update
	public bool canCrossBridge = false;

	void Start()
	{
	}

    public void SetZoneSize(int xSize, int ySize)
    {
        nodeArray = new Node[xSize][];

    }
    public void AddNodeColumn(Node[] nodeColumn, int xCoordinate)
    {
		//Boundary check
        if(xCoordinate >= 0 && xCoordinate < nodeArray.Length)
            nodeArray[xCoordinate] = nodeColumn;
    }




	//________________________________
	//________________________________ All the descriptions of the Exploration Text
	//________________________________


    public bool AttemptPlayerMove(int xDir, int yDir, ref string description)
    {
		pass = nodeArray [xDir] [yDir].GetDescription ();
		if (xDir < 0 || xDir > nodeArray.Length - 1
			|| yDir < 0 || yDir > nodeArray [xDir].Length - 1) {
			description += "You cannot travel beyond this point... The radiation is too strong.";
			return false;
		} 

//else if (pass == "Impassable") {
//	int tempNumber = Random.Range (0, 3);
//	if (tempNumber == 0) {
//		description += "You cannot go that direction.";
//	} else if (tempNumber == 1)
//		description += "You've looped back.";
//	else
//		description += "You feel disoriented.";
//
//	return false;
//}
		//BridgeToll

		else if (pass == "BridgeToll") 
		{
			//new bool canEnterDT  if(canEnterDT){description = "Welcome back, Jack. Here is the entrance to DownTown L.A."}else{"That will be "}
			if (!canCrossBridge) { 
				
				description = "The gondola is operated by a yellow and black person. \"It costs $25 to cross the bridge.\"";
				return false;
				
			} else {
				//Propose Check!!!
				//PLAY ANIMATION
				//REMOVE $25
				//if left side, if right side??
				//RELOCATE TO 20, 10, or 22, 10
				//BOOL?
				//description = nodeArray [xDir] [yDir].GetDescription ();
				description += "The gondola properly operates. You cross the chasm.";
				return true;
			}		 

		}
		else if (pass == "Chasm")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0){
				description+= 

						"Fables tell of mole people.";}
			else if (tempNumber==1){
				description+=  

					"The earth was torn.";}
			else{
				description+=

					"You don't want to go down there.";}
			return false;
		}
		else if (pass == "Freeway")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "This used to be clean and clear.";}
			else if (tempNumber==1)
				description = "The freeway is too broken to navigate";
			else
				description="What a mess of rubble.";
			return false;
		}
		else if (pass == "MtWa")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Mt Wa";}
			else if (tempNumber==1)
				description = "Mt Wa";
			else
				description="Mt Wa";
			return true;
		}
		else if (pass == "CarStack")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "No getting over this wall of cars";}
			else if (tempNumber==1)
				description = "No getting over this wall of cars";
			else
				description="No getting over this wall of cars";
			return false;
		}
		else if (pass == "Road")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Blacktop";}
			else if (tempNumber==1)
				description = "Blacktop";
			else
				description="Blacktop";
			return true;
		}
		else if (pass == "Bridge")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Bridge is dangerous";}
			else if (tempNumber==1)
				description = "Bridge";
			else
				description="Bridge";
			return true;
		}
		else if (pass == "DownTown")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "A tree grows out from the roof of a building.";}
			else if (tempNumber==1)
				description = "Broken glass and debris litters the sidewalk.";
			else
				description="Everything is brown and ugly.";
			return true;
		}
		else if (pass == "Quest1")
		{
			if (!questIsActive){
			
			startQuest1=true;
				//ADD AN ANIMATION TO TALK?? OR A TIMER OR SOMETHIONG SO IT DOESN:T POP UP EVERY TIME
			description = "Ankel's bar is a mess, but it feels like home.";
				int tempCatCallNumer = Random.Range(1,3);
				if (tempCatCallNumer ==1)
				{description += "\"My tit has a face,\" says one of the locals.";}
				else if (tempCatCallNumer ==2){
					description += "\"Fuck off,\" says one of the locals.";
				}
				//goes down to the generateplacedmonster 
			GenerateQuestMonster = true;
				questIsActive=true;

			}
			else {
				description = "Ankles bar.  \nYou decide not to enter.";

				//description = "Akel's bar is a mess. " + "Nash was last seen at " +randomXSpawn +", "
				//	+ randomYSpawn + " on your map's grid.";

			}
			return true;
		}
		else if (pass == "DownTownEntrance")
		{
			//new bool canEnterDT  if(canEnterDT){description = "Welcome back, Jack. Here is the entrance to DownTown L.A."}else{"That will be "}
			if (!canEnterDT){ 

				description = "It costs $11 to enter downtown. \nCome back when you have more money.";
				return false;
				
			}
			else {
				description = "Come on in, buddy.";
			
				
			}
			return true;
		}
        else
        {
			description = nodeArray[xDir][yDir].GetDescription();
            return true;
        }
    }



	//________________________________
	//________________________________ Adding Monsters
	//________________________________


	public bool doesMonsterExist(int i, int j)
	{
		if (i < 0 || i > nodeArray.Length - 1
		    || j < 0 || 	j > nodeArray[i].Length - 1)
		{
			return false;
		}
		else {
			if(nodeArray[i][j].getMonster())
				return true;
			else 
				return false;
		}
	}


	//PIT RANDOME NiMBERS HERE
	public void GeneratePlaceMonster()
	{
		if (GenerateQuestMonster){ 

			randomXSpawn = Random.Range(26,29);
			randomYSpawn = Random.Range(6,12);
			AddRandomMonster (randomXSpawn, randomYSpawn);
		}
	}

	//DONT FORGET THE CHECKS!!!
	void AddRandomMonster(int xMLoc, int yMLoc)
	{
		string locdes = nodeArray [xMLoc] [yMLoc].GetDescription ();
		if (locdes == "Impassable") {
			//return false;
			Debug.Log("Didn't spawn Monster at:" +randomXSpawn + " "+ randomYSpawn);
			GeneratePlaceMonster();
			GenerateQuestMonster=false;
		} 
		else {
			//return true;
			AddMonster(randomXSpawn,randomYSpawn,ScriptableObject.CreateInstance<NashMonster>());
			Debug.Log("Spawned Monster at:" +randomXSpawn + " "+ randomYSpawn);
			GenerateQuestMonster=false;
			
			}
	}



	public void AddMonster(int i, int j, Monster nodeMonster)
	{
		nodeArray[i][j].AddMonster(nodeMonster);
		nodeMonster.Start();
		nodeMonster.Init();
	}

	public Monster returnMonsterAtLocation(int i, int j)
	{
		return nodeArray[i][j].getMonster();
	}

	//________________________________
	//________________________________ Image?
	//________________________________
	public string returnImageAtLocation(int i, int j)
	{
		return nodeArray[i][j].GetBackgroundImage();

	}
}
