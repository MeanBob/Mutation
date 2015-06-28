using UnityEngine;
using System.Collections;
using UnityEngine.UI;

struct Point
{
    public int x, y;
}

public class MapControl : MonoBehaviour {    
    
	CharacterPage playerCharacter;
	ExplorationText explorationText;
    UIControl ui;

    CombatControl combat;
    Point playerLocation;
    int xSize = 10;
    int ySize = 11;
    Zone currentZone;
	float currentMonsterReadiness = 0;
	Monster[] sensedMonsters;

	public Button northButton;
	public Button southButton;
	public Button eastButton;
	public Button westButton;
	bool tryingToFlee;

	// Use this for initialization poop
	void Start () {


		explorationText = ScriptableObject.CreateInstance<ExplorationText>();
		explorationText.Start();
		tryingToFlee = false;
		//Debug.Log(Constants.dialogue(0,0));
		playerCharacter = GameObject.Find("Avatar").GetComponent<CharacterPage>();
		currentZone = ScriptableObject.CreateInstance<Zone>();
        currentZone.SetZoneSize(xSize, ySize);
        ui = GetComponent<UIControl>();
        combat = GetComponent<CombatControl>();

        //Map setup that will change
        playerLocation.x = 8;
        playerLocation.y = 5;

        for (int i = 0; i < xSize; i++)
        {
            Node[] tempNodeArray = new Node[ySize];
            for (int j = 0; j < ySize; j++)
            {
                Node newNode = ScriptableObject.CreateInstance<Node>();
				newNode.AddDescription(explorationText.dialogue[i,j]);
                tempNodeArray[j] = newNode;
            }
            currentZone.AddNodeColumn(tempNodeArray, i);
        }
		GenerateZoneMonsters();
        
	}
	void GenerateZoneMonsters()
	{
		Monster temp = ScriptableObject.CreateInstance<RabbitMonster>();
		currentZone.AddMonster(9,4,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(9,9, ScriptableObject.CreateInstance<GoatMonster>());

		currentZone.AddMonster(8,0,ScriptableObject.CreateInstance<DogMonster>());
		currentZone.AddMonster(8,3,ScriptableObject.CreateInstance<BirdMonster>());
		currentZone.AddMonster(8,9,ScriptableObject.CreateInstance<SkunkMonster>());

		currentZone.AddMonster(7,8,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(7,6,ScriptableObject.CreateInstance<RabbitMonster>());

		currentZone.AddMonster(6,2,ScriptableObject.CreateInstance<WolfMonster>());
		currentZone.AddMonster(6,5,ScriptableObject.CreateInstance<WolfMonster>());

		currentZone.AddMonster(5,1,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(5,4,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(5,7,ScriptableObject.CreateInstance<WolfMonster>());

		currentZone.AddMonster(4,6,ScriptableObject.CreateInstance<BearMonster>());

		currentZone.AddMonster(3,1,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(3,1,ScriptableObject.CreateInstance<RabbitMonster>());

		currentZone.AddMonster(2,8,ScriptableObject.CreateInstance<WolfMonster>());
		currentZone.AddMonster(2,2,ScriptableObject.CreateInstance<WolfMonster>());

		currentZone.AddMonster(1,2,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(1,8,ScriptableObject.CreateInstance<RabbitMonster>());

		currentZone.AddMonster(0,5,ScriptableObject.CreateInstance<BearMonster>());




//		int rStart	= Random.Range(1,99);
//		currentMonsterReadiness = rStart;
	}

	void Update()
	{
		if (combat.currentPlayerReadiness < combat.maxReadiness)
		{
			northButton.interactable = false;
			southButton.interactable = false;
			eastButton.interactable = false;
			westButton.interactable = false;
		}
		else if(!ui.hasPopUp){
			northButton.interactable = true;
			southButton.interactable = true;
			eastButton.interactable =  true;
			westButton.interactable =  true;
		}
	}


	
	void CombatCheck()
	{

		combat.currentPlayerReadiness = 50;
		//Fight chance ensures whether you will encounter a monster or not
//		int fightChance = Random.Range(1,5);

		if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y)){
			Debug.Log("Monster exists at player's current location"+"("+playerLocation.x+","+playerLocation.y+")");
			combat.InitiateCombat(currentZone.returnMonsterAtLocation(playerLocation.x,playerLocation.y));
		}
		else{
			Debug.Log("No Monster here");
		}
//		if (fightChance > 3 && !tryingToFlee)
//		{
//			combat.InitiateCombat();
//		}
	}

	//
	//  FIX ME PLEASE
	//
	//
	public void Flee(int x, int y)
	{
		if (combat.combatOn)
		{
			combat.combatLogText.text = "You are starting your attempt to flee!\n\n";
			tryingToFlee = true;

			int fleeChance = Random.Range (0,9);
			if (playerCharacter.GetIntelligence() > fleeChance)
			{
				combat.combatLogText.text = "You attempted to Flee!\n\n";
				//combat.combatOn = false;
				GoDirection(x, y);
				playerCharacter.DoEnergyDamage(1);
//				combat.characterButton.enabled = true;
//				combat.exploreButton.enabled = true;
//				combat.inventoryButton.enabled = true;
//				combat.mapButton.enabled = true;
				combat.combatOn = false;
				ui.RemovePanelFromTop();
				ui.EndCombat();				
			}
			else 
			{
				combat.combatLogText.text = "You trip as you try to run away!\n\n";
				ui.RemovePanelFromTop();
				combat.currentPlayerReadiness = 30;
			}
			return;
		}
	}


    public void MoveNorth()
    {

		Flee(-1,0);
		if(!tryingToFlee)
		{
	        GoDirection(-1, 0);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

    public void MoveSouth()
    {

		Flee(1,0);
		if(!tryingToFlee)
		{
			GoDirection(1, 0);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

    public void MoveEast()
{		
		Flee(0,1);
		if(!tryingToFlee)
		{
			GoDirection(0, 1);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

    public void MoveWest()
{		
		Flee(0,-1);
		if(!tryingToFlee)
		{
			GoDirection(0, -1);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;
    }




    public void GoDirection(int xDir, int yDir)
    {
        //Move Direction
        string nodeDescription = "";
        string oldDescription = "";
		string sensoryDescription = "";

		string direction1 = "";
		string direction2 = "";
		string direction3 = "";
		string direction4 = "";

		int intelligenceCategory=0;

		//currentZone has the description of each position
        if (currentZone.AttemptPlayerMove(playerLocation.x + xDir, playerLocation.y + yDir, ref nodeDescription))
        {
            playerLocation.x += xDir;
            playerLocation.y += yDir;
        }
        else
        {
            currentZone.AttemptPlayerMove(playerLocation.x, playerLocation.y, ref oldDescription);
        }


		if(playerCharacter.GetIntelligence()>=1 && playerCharacter.GetIntelligence()<=25)
			intelligenceCategory = 0;
		if(playerCharacter.GetIntelligence()>=26 && playerCharacter.GetIntelligence()<=50)
			intelligenceCategory = 1;
		if(playerCharacter.GetIntelligence()>=51 && playerCharacter.GetIntelligence()<=75)
			intelligenceCategory = 2;
		if(playerCharacter.GetIntelligence()>=76)
			intelligenceCategory = 3;
		if ((currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x-1,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x+2,playerLocation.y)|| currentZone.doesMonsterExist(playerLocation.x+1,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-2) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y -1)|| currentZone.doesMonsterExist(playerLocation.x,playerLocation.y + 1) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+2)) == false)
		{
			sensoryDescription ="";
		}
		else {
			if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+2) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+1)){
				direction1 = "east\n";
			}

			if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-2) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-1)){
				direction2 = "west\n";
			}
			if(currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x-1,playerLocation.y)){
				direction3 = "north\n";
			}
			if(currentZone.doesMonsterExist(playerLocation.x+2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x+1,playerLocation.y)){
				direction4 = "south\n";
			}
			sensoryDescription = SetSensoryDescription(intelligenceCategory, direction1, direction2, direction3, direction4);

		}


		//	Debug.Log(playerLocation.x +","+ playerLocation.y);
		
		nodeDescription += "\n\n" + oldDescription;
		ui.GoToDescription(nodeDescription,sensoryDescription);

		
	}

	public string SetSensoryDescription(int intelligenceCategory,string direction1, string direction2,string direction3, string direction4)
	{		
		string sensoryDescription = "";

		switch (intelligenceCategory)
		{
		case 0:	
			sensoryDescription = "You sense something nearby";
			break;
		case 1:
			sensoryDescription = "You sense something in the following directions :\n" + direction1 + direction2  + direction3 + direction4;
			break;
		case 2:
			sensoryDescription = "You sense an animal in the following directions :\n" + direction1 + direction2  + direction3 + direction4;
			break;
		case 3:
			//sensoryDescription = "You sense an "+currentZone.returnMonsterAtLocation() + " nearby to the "+direction;
			break;
		}
		return sensoryDescription;
	}
}
