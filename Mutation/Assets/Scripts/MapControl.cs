using UnityEngine;
using System.Collections;
using UnityEngine.UI;

struct Point
{
    public int x, y;
}

public class MapControl : MonoBehaviour {    
    
	CharacterPage playerCharacter;
	ExplorationText text;
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


	// Use this for initialization poop
	void Start () {


		text = ScriptableObject.CreateInstance<ExplorationText>();
		text.Start();

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
                newNode.AddDescription(text.dialogue[i,j]);
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
		int fightChance = Random.Range(1,4);
		//Debug.Log(fightChance);
		if (fightChance > 2)
		{
			combat.InitiateCombat();


		}

	}
    public void MoveNorth()
    {

        GoDirection(-1, 0);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);

    }

    public void MoveSouth()
    {
        GoDirection(1, 0);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }

    public void MoveEast()
    {
		GoDirection(0, 1);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }

    public void MoveWest()
    {
		GoDirection(0, -1);
		CombatCheck();
		playerCharacter.DoEnergyDamage(1);
    }

    public void GoDirection(int xDir, int yDir)
    {
        //Move Direction
        string nodeDescription = "";
        string oldDescription = "";
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
