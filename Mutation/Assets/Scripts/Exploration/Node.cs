using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Node : ScriptableObject {
    string description;
	Monster nodeMonster;
	string backgroundImage;


    //Special event?
    //Random chance?

	void Start () 
	{

	}
	
	void Update () 
	{
	
	}



	public void AddBackgroundImage(string newBackgroundImage)
	{
		backgroundImage = newBackgroundImage; 
	}

	public string GetBackgroundImage()
	{
		return backgroundImage; 
	}


    public void AddDescription(string newDescription)
    {
        description = newDescription;
    }



	public void AddMonster(Monster monster)
	{
		nodeMonster = monster;
	}

//	public bool DoesMonsterExistAtIndex(int i)
//	{
//		if(nodeMonster != null)
//			return true;
//		else
//			return false;
//	}

	public Monster getMonster()
	{
		return nodeMonster;
	}
    public string GetDescription()
    {
        return description;
    }
}
