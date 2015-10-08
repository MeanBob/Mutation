using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zone : ScriptableObject {
    string zoneName;
    Node[][] nodeArray;
	public string description;
	Canvas canvas;
	MapControl mapControl;
	UnityEngine.UI.Image backgroundColor;
	public string pass;
	public string passBlock;
	//MapControl mapControl;
	//CombatControl combatScript;

	//for Bounty Quest1
	public bool GenerateQuestMonster;
	public bool startQuest1;
	public bool questIsActive;

	public bool GenerateQuest2Monster;
	public bool startQuest2;
	public bool quest2IsActive;

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
		pass = nodeArray [xDir] [yDir].GetDescription();


		if (xDir < 0 || xDir > nodeArray.Length - 1
			|| yDir < 0 || yDir > nodeArray [xDir].Length - 1) {
			description += "You cannot travel beyond this point... The radiation is too strong.";
			return false;
		} 

		//BLOCKS
		else if (pass == "Fence")
		{onHealer = false;
			return false;
		}


		else if (pass == "Wall")
		{onHealer = false;

			return false;
		}
		else if (pass == "Building")
		{onHealer = false;

			return false;
		}
		else if (pass == "Stack") //carstack
		{
			onHealer = false;
			return false;
		}


		//PLACES
		else if (pass == "Alleyway") //MtWa
		{
			onHealer = false;
			description += "<color=#FFFBD8><size=130>Downtown Alley\n</size></color>";
			return true;
		}

		else if (pass == "Street") //road
		{
			onHealer = false;//add road names??
			description += "<color=#FFFBD8><size=130>City Streets\n</size></color>";
			return true;
		}
		else if (pass == "Bridge")//bridge
		{onHealer = false;
			description="<color=#625F21>Bridge</color>\n";
			return true;
		}
		else if (pass == "DownTown")//downtown
		{
			onHealer = false;
			description="<color=#625F21>Downtown</color>\n";
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
			if (!questIsActive && !quest2IsActive){
			
				//Add this to the Accept button
			startQuest1=true;
				//ADD AN ANIMATION TO TALK?? OR A TIMER OR SOMETHIONG SO IT DOESN:T POP UP EVERY TIME
			description = "Ankel's bar is a mess, but it feels like home.";
				int tempCatCallNumer = Random.Range(1,3);
				if (tempCatCallNumer ==1)
				{description += "\"You look busier than a mole,\" says one of the locals.";}
				else if (tempCatCallNumer ==2){
					description += "\"Fuck off, but return when you are no so busy,\" says one of the locals.";
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
		else if (pass == "Quest2")
		{onHealer = false;
			if (!questIsActive && !quest2IsActive){
				
				//Add this to the Accept button
				startQuest2=true;
				//ADD AN ANIMATION TO TALK?? OR A TIMER OR SOMETHIONG SO IT DOESN:T POP UP EVERY TIME
				description = "A Diva approaches you!";

				int tempCatCallNumer = Random.Range(1,3);
				if (tempCatCallNumer ==1)
				{description += "\"Come back when you are not so busy,\" says one of the locals.";}
				else if (tempCatCallNumer ==2){
					description += "\"Fuck off, but keep me in mind when you are not so busy,\" says one of the locals.";
				}

				//goes down to the generateplacedmonster 
				GenerateQuest2Monster = true;
				quest2IsActive=true;
				
			}
			else {
				description = "Just a cloud of smoke.  \nYou walk on.";
				
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
		else if (pass == "NeatBen")
		{onHealer = false;
			//new bool canEnterDT  if(canEnterDT){description = "Welcome back, Jack. Here is the entrance to DownTown L.A."}else{"That will be "}

				description = "A fence!";
				return false;

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

	//PLACES
	public bool MtWaInThatDirection (int xD, int yD)
	{
		if( nodeArray[xD][yD].GetDescription()=="MtWa")
			return true;
		else 
			return false;
	}
	public bool RoadInThatDirection (int xD, int yD)
	{
		if( nodeArray[xD][yD].GetDescription()=="Road")
			return true;
		else 
			return false;
	}

	//BLOCKS
	public bool FenceInThatDirection (int xD, int yD)
	{
		if(nodeArray[xD][yD].GetDescription()=="Fence")
			return true;
		else 
			return false;
	}

	public bool WallInThatDirection (int xD, int yD)
	{
		if(nodeArray[xD][yD].GetDescription()=="Wall")
			return true;
		else 
			return false;
	}

	public bool StackInThatDirection (int xD, int yD)
	{
		if(nodeArray[xD][yD].GetDescription()=="Stack")
			return true;
		else 
			return false;
	}

	public bool BuildingInThatDirection (int xD, int yD)
	{
		if(nodeArray[xD][yD].GetDescription()=="Building")
			return true;
		else 
			return false;
	}




	//Used for Quest1  Adjust random numbers for the spawn location
	public void GeneratePlaceMonster()
	{
		if (GenerateQuestMonster){ 

			randomXSpawn = Random.Range(14,15);
			randomYSpawn = Random.Range(24,25);
			AddRandomMonster (randomXSpawn, randomYSpawn);
		}
	}

	public void GeneratePlace2Monster()
	{	if (GenerateQuest2Monster) 
		{
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

	void AddRandomMonster2(int xMLoc, int yMLoc)
	{
		string locdes = nodeArray [xMLoc] [yMLoc].GetDescription ();
		if (locdes == "Impassable") {
			//return false;
			Debug.Log("Didn't spawn Monster at:" +randomXSpawn + " "+ randomYSpawn);
			GeneratePlaceMonster();
			GenerateQuest2Monster=false;
		} 
		else {
			//return true;
			AddMonster(randomXSpawn,randomYSpawn,ScriptableObject.CreateInstance<NashMonster>());
			Debug.Log("Spawned Monster at:" +randomXSpawn + " "+ randomYSpawn);
			GenerateQuest2Monster=false;
			
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
