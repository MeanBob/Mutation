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

	ExplorationImage explorationImage;

	Canvas canvas;

	UnityEngine.UI.Image backgroundImage;


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

		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

		backgroundImage = canvas.GetComponent<UnityEngine.UI.Image>();
		explorationImage = ScriptableObject.CreateInstance<ExplorationImage>();
		explorationImage.Start();
		//backgroundImage.sprite = Resources.Load <Sprite>("Backgrounds/CastleWallTest");


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

				newNode.AddBackgroundImage(explorationImage.backgroundImage[i,j]);


                tempNodeArray[j] = newNode;
            }
            currentZone.AddNodeColumn(tempNodeArray, i);
        }
		GenerateZoneMonsters();
	}

	void SetBackgroundImage(string temp)
	{
		backgroundImage.sprite = Resources.Load <Sprite>(temp);	
	}


	void GenerateZoneMonsters()
	{
		//Monster temp = ScriptableObject.CreateInstance<RabbitMonster>();

		currentZone.AddMonster(7,4,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(7,7,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(8,1,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(3,0,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(0,1,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(1,8,ScriptableObject.CreateInstance<SnakeMonster>());

		currentZone.AddMonster(8,8,ScriptableObject.CreateInstance<GoatMonster>());
		currentZone.AddMonster(6,10,ScriptableObject.CreateInstance<GoatMonster>());
		currentZone.AddMonster(4,8,ScriptableObject.CreateInstance<GoatMonster>());
		currentZone.AddMonster(2,10,ScriptableObject.CreateInstance<GoatMonster>());

		currentZone.AddMonster(6,9,ScriptableObject.CreateInstance<BearMonster>());
		currentZone.AddMonster(1,4,ScriptableObject.CreateInstance<BearMonster>());

		currentZone.AddMonster(5,6,ScriptableObject.CreateInstance<FrogMonster>());
		currentZone.AddMonster(6,7,ScriptableObject.CreateInstance<FrogMonster>());
		currentZone.AddMonster(7,9,ScriptableObject.CreateInstance<FrogMonster>());
		currentZone.AddMonster(5,2,ScriptableObject.CreateInstance<FrogMonster>());
		

		currentZone.AddMonster(1,3,ScriptableObject.CreateInstance<BeaverMonster>());
		currentZone.AddMonster(2,2,ScriptableObject.CreateInstance<BeaverMonster>());

		currentZone.AddMonster(9,4,ScriptableObject.CreateInstance<CatMonster>());
		currentZone.AddMonster(1,8,ScriptableObject.CreateInstance<CatMonster>());
		currentZone.AddMonster(2,7,ScriptableObject.CreateInstance<CatMonster>());

		currentZone.AddMonster(3,4,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(4,6,ScriptableObject.CreateInstance<RabbitMonster>());
		currentZone.AddMonster(2,8,ScriptableObject.CreateInstance<RabbitMonster>());

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


		if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y)){
			Debug.Log("Monster exists at player's current location"+"("+playerLocation.x+","+playerLocation.y+")");
			combat.InitiateCombat(currentZone.returnMonsterAtLocation(playerLocation.x,playerLocation.y));
		}
		else{
			Debug.Log("No Monster here");
		}

	}


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

				GoDirection(x, y);
				playerCharacter.DoEnergyDamage(1);
//				
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


		string temp = currentZone.returnImageAtLocation(playerLocation.x,playerLocation.y);
		SetBackgroundImage(temp);
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
