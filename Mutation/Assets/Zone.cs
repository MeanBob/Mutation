using UnityEngine;
using System.Collections;

public class Zone : ScriptableObject {
    string zoneName;
    Node[][] nodeArray;

    public void SetZoneSize(int xSize, int ySize)
    {
        nodeArray = new Node[xSize][];
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddNodeColumn(Node[] nodeColumn, int xCoordinate)
    {
        if(xCoordinate >= 0 && xCoordinate < nodeArray.Length)
            nodeArray[xCoordinate] = nodeColumn;
    }

    public bool AttemptPlayerMove(int xDir, int yDir, ref string description)
    {
        if (xDir < 0 || xDir > nodeArray.Length - 1
            || yDir < 0 || yDir > nodeArray[xDir].Length - 1)
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
}
