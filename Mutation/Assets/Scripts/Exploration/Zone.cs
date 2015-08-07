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

	//for Enterance to DownTown
	public bool canEnterDT = false;

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
            || yDir < 0 || 	yDir > nodeArray[xDir].Length - 1)
        {
            description += "You cannot travel beyond this point... The radiation is too strong.";
            return false;
        }
		else if (pass == "Impassable")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description += "The streets of L.A. are a labyrinth.  \nYou are back where you started";}
			else if (tempNumber==1)
				description += "This looks familiar.  \nYou've looped back.";
			else
				description+="You begin to feel sick and disoriented.";

			return false;
		}
		else if (pass == "Embankment")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0){
				description+= 

						"Cold stones sit still amungsts the windblown trash flapping.";}
			else if (tempNumber==1){
				description+=  

					"You can hear a river.";}
			else{
				description+=

					"The air is crisp.";}
			return true;
		}
		else if (pass == "River")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "The current is strong.";}
			else if (tempNumber==1)
				description = "You are waist deep in water; a bottle floats by.";
			else
				description="The water is cold and smells acrid.";
			return true;
		}
		else if (pass == "River Bed")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Sand and water meet; plastic wrappers cling to mossy stones.";}
			else if (tempNumber==1)
				description = "Your feet are wet with dirty water.";
			else
				description="This riverbed is quiet; ruined debris rests.";
			return true;
		}
		else if (pass == "Pool")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "The gentle pool of water is brown.";}
			else if (tempNumber==1)
				description = "Little whirlpools form behind you.";
			else
				description="The pool is lifeless.";
			return true;
		}
		else if (pass == "Waterfall")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Rushing water falls from overhead.";}
			else if (tempNumber==1)
				description = "Water rages; it's hard to hear anything else.";
			else
				description="Wet moss is indifferent.";
			return true;
		}
		else if (pass == "Trail")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Trail 1";}
			else if (tempNumber==1)
				description = "Trail 2";
			else
				description="Trail 3";
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
			randomXSpawn = 28;
			randomYSpawn = Random.Range(10,11);
			startQuest1=true;
			description = "\"Nash was last seen at " +randomXSpawn +", "
				+ randomYSpawn + " on your map's grid.\"";
			//GenerateQuestMonster = true;
				//questIsActive=true;

			}
			else {
				description = "Akel's bar is a mess. " + "Nash was last seen at " +randomXSpawn +", "
					+ randomYSpawn + " on your map's grid.";

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



	public void GeneratePlaceMonster()
	{
		if (GenerateQuestMonster){ 
			
			AddRandomMonster (randomXSpawn, randomYSpawn);
		}
	}

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
