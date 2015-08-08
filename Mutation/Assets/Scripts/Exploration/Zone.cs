using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zone : ScriptableObject {
    string zoneName;
    Node[][] nodeArray;

	Canvas canvas;
	UnityEngine.UI.Image backgroundColor;
	//string colorStringGreen = "RGBA(1,1,0,1)";


	void Start()
	{
		//canvas = GameObject.Find("Canvas").GetComponent<UnityEngine.UI.Image>();
		//backgroundColor.color = canvas;
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
	//________________________________
	//________________________________


    public bool AttemptPlayerMove(int xDir, int yDir, ref string description)
    {
		string pass = nodeArray [xDir] [yDir].GetDescription ();
        if (xDir < 0 || xDir > nodeArray.Length - 1
            || yDir < 0 || 	yDir > nodeArray[xDir].Length - 1)
        {
            description = "You cannot travel beyond this point... The radiation is too strong.";
            return false;
        }
		else if (pass == "Impassable")
		{
			description = "The sheer mountain face is too steep to pass.";
			return false;
		}
		else if (pass == "Embankment")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Embankment 1";}
			else if (tempNumber==1)
				description = "Embankment 2";
			else
				description="Embankment 3";
			return true;
		}
		else if (pass == "River")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "River 1";}
			else if (tempNumber==1)
				description = "River 2";
			else
				description="River 3";
			return true;
		}
		else if (pass == "River Bed")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "River Bed 1";}
			else if (tempNumber==1)
				description = "River Bed 2";
			else
				description="River Bed 3";
			return true;
		}
		else if (pass == "Pool")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Pool 1";}
			else if (tempNumber==1)
				description = "Pool 2";
			else
				description="Pool 3";
			return true;
		}
		else if (pass == "Waterfall")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Waterfall 1";}
			else if (tempNumber==1)
				description = "Waterfall 2";
			else
				description="Waterfall 3";
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
		else if (pass == "Forest")
		{
			int tempNumber = Random.Range(0,3);
			if (tempNumber==0)
			{description = "Forest 1";}
			else if (tempNumber==1)
				description = "Forest 2";
			else
				description="Forest 3";
			return true;
		}
        else
        {
			description = nodeArray[xDir][yDir].GetDescription();
            return true;
        }
    }



	//________________________________
	//________________________________
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
