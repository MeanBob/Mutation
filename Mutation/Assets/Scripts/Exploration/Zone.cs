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

	//Image healButton;

	//for Enterance to DownTown  Used in MapControl Update
	public bool canEnterDT = false;

	//for Crossing Bridge at Mnt WA  Used in MapControl Update
	public bool canCrossBridge = false;

	//For Healer!
	public bool onHealer = false;

	void Start()
	{
		//healButton = GameObject.Find ("Canvas/HealButton").GetComponent<Image> ();
		//healButton.interactable = false;
		//healButton.IsActive ();
			//transform.Find ("CharacterSheetPanel/StatsInfoButton").gameObject;
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

		//BLOCKS
		else if (pass == "Chasm")
		{onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0){
				description+= 

					"<color=#3B0E15>Blocked Chasm</color>\nThe chasm is full of radiation.\n";}
			else if (tempNumber==1){
				description+=  

					"<color=#3B0E15>Blocked Chasm</color>\nThe earth was torn and out came radiation.\n";}
			else{
				description+=

					"<color=#3B0E15>Blocked Chasm</color>\nIt's not worth the repercussions.\n";}
			return false;
		}


		else if (pass == "Freeway")
		{onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "<color=#3B0E15>Blocked Freeway</color>\nBroken concrete and wild rebar make for a dangerous path.\n";}
			else if (tempNumber==1)
				description = "<color=#3B0E15>Blocked Freeway</color>\nThis freeway is falling apart.\n";
			else
				description="<color=#3B0E15>Blocked Freeway</color>\nLarge, concrete blocks impede travel.\n";
			return false;
		}
		else if (pass == "CarStack")
		{
			onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "<color=#3B0E15>Blocked</color>\nNo getting over this wall of cars.\n";}
			else if (tempNumber==1)
				description = "<color=#3B0E15>Blocked</color>\nToo many cars.\n";
			else
				description="<color=#3B0E15>Blocked</color>\nA wall of cars.\n";
			return false;
		}


		//PLACES
		else if (pass == "MtWa")
		{
			onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "<color=#06A124>Mt. Washington</color>\nYou tear through foliage growing from rubble.";}
			else if (tempNumber==1)
				description = "<color=#06A124>Mt. Washington</color>\nYou are always close to lost around here.";
			else
				description="<color=#06A124>Mt. Washington</color>\nYou duck under wires and vines.";
			return true;
		}

		else if (pass == "Road")
		{
			onHealer = false;
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
		{onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "<color=#625F21>Bridge</color>\nYou carefully walk on.";}
			else if (tempNumber==1)
				description = "<color=#625F21>Bridge</color>\nSlow and steady.";
			else
				description="<color=#625F21>Bridge</color>\nLittle rocks tumble into the green water below.";
			return true;
		}
		else if (pass == "DownTown")
		{
			onHealer = false;
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "A tree grows out from the roof of a building.";}
			else if (tempNumber==1)
				description = "Broken glass and debris litters the sidewalk.";
			else
				description="Everything is brown and ugly.";
			return true;
		}


		//EVENTS
		else if (pass == "BridgeToll") 
		{onHealer = false;
			//new bool canEnterDT  if(canEnterDT){description = "Welcome back, Jack. Here is the entrance to DownTown L.A."}else{"That will be "}
			if (!canCrossBridge) { 
				
				description = "<color=#1E79A1>Gondola</color>\nThe gondola is operated by a yellow and black person. <color=#625F21>\"It costs $15 to cross.\"</color>";
				return false;
				
			} else {
				//Propose Check!!!
				//PLAY ANIMATION
				//REMOVE $25
				//if left side, if right side??
				//RELOCATE TO 20, 10, or 22, 10
				//BOOL?
				//description = nodeArray [xDir] [yDir].GetDescription ();
				description += "<color=#1E79A1>Gondola</color>\nThe gondola properly operates. <color=#1E79A1>You cross the chasm.</color>";
				
				return true;
			}		 
			
		}
		else if (pass == "Healer")
		{
			onHealer = true;
			
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0){
				description+= 
					
					"<color=#1E79A1>Healer</color>\nWires and dim lights fill the room. The healer asks, \"Need something?\"";}
			else if (tempNumber==1){
				description+=  
					
					"<color=#1E79A1>Healer</color>\n\"Hurry up and talk.\"";}
			else{
				description+=
					
					"<color=#1E79A1>Healer</color>\n\"What do you want?\"";}
			return true;
		}

		else if (pass == "Quest1")
		{onHealer = false;
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
		{onHealer = false;
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

			randomXSpawn = Random.Range(14,15);
			randomYSpawn = Random.Range(24,25);
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
