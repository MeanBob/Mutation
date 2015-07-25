using UnityEngine;
using System.Collections;

public class Zone : ScriptableObject {
    string zoneName;
    Node[][] nodeArray;

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

    public bool AttemptPlayerMove(int xDir, int yDir, ref string description)
    {
        if (xDir < 0 || xDir > nodeArray.Length - 1
            || yDir < 0 || 	yDir > nodeArray[xDir].Length - 1)
        {
            description = "That way is impassable.";
            return false;
        }
        else
        {
            description = nodeArray[xDir][yDir].GetDescription();
            return true;
        }
    }

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

	public string returnImageAtLocation(int i, int j)
	{
		return nodeArray[i][j].GetBackgroundImage();

	}
}
