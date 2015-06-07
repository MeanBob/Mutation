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
		else {
			northButton.interactable = true;
			southButton.interactable = true;
			eastButton.interactable =  true;
			westButton.interactable =  true;
		}
	}


	
	void CombatCheck()
	{
		combat.currentPlayerReadiness = 50;
		//int fightChance = Random.Range(1,4);
		int fightChance = 3;

		if (fightChance > 2 && !tryingToFlee)
		{
			combat.InitiateCombat();
		}
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

		//Flee(1,0);
        GoDirection(1, 0);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }

    public void MoveEast()
{		
		//Flee(0,1);
		GoDirection(0, 1);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }

    public void MoveWest()
{		
		//Flee(0,-1);
		GoDirection(0, -1);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }




    public void GoDirection(int xDir, int yDir)
    {
        //Move Direction
        string nodeDescription = "";
        string oldDescription = "";
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
	//	Debug.Log(playerLocation.x +","+ playerLocation.y);

		nodeDescription += "\n\n" + oldDescription;
        ui.GoToDescription(nodeDescription);

    }
}
