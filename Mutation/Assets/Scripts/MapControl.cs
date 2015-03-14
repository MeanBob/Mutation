using UnityEngine;
using System.Collections;

struct Point
{
    public int x, y;
}

public class MapControl : MonoBehaviour {    
    bool DEBUGtriggerMonster = false;
    UIControl ui;
    Point playerLocation;
    int xSize = 10;
    int ySize = 10;
    Zone currentZone;

	// Use this for initialization
	void Start () {
        currentZone = ScriptableObject.CreateInstance<Zone>();
        currentZone.SetZoneSize(xSize, ySize);
        ui = GetComponent<UIControl>();
        playerLocation.x = xSize / 2;
        playerLocation.y = ySize / 2;

        for (int i = 0; i < xSize; i++)
        {
            Node[] tempNodeArray = new Node[ySize];
            for (int j = 0; j < ySize; j++)
            {
                Node newNode = ScriptableObject.CreateInstance<Node>();
                newNode.AddDescription("A dirt path is here.");
                tempNodeArray[j] = newNode;
            }
            currentZone.AddNodeColumn(tempNodeArray, i);
        }
        
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void MoveNorth()
    {
        GoDirection(0, 1);
    }

    public void MoveSouth()
    {
        GoDirection(0, -1);
    }

    public void MoveEast()
    {
        GoDirection(1, 0);
    }

    public void MoveWest()
    {
        GoDirection(-1, 0);
    }

    public void DEBUGMonsterAttackNextMove()
    {
        DEBUGtriggerMonster = true;
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

        nodeDescription += "\n\n" + oldDescription;
        ui.GoToDescription(nodeDescription);

        //If we're triggering a monster, do that as well.
        if (DEBUGtriggerMonster)
        {
            ui.InitiateCombat();
            //TriggerMonster
            DEBUGtriggerMonster = false;
        }
    }
}
