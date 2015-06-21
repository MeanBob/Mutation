using UnityEngine;
using System.Collections;

public class Node : ScriptableObject {
    string description;
	Monster nodeMonster;
    //Special event?
    //Random chance?

	void Start () 
	{
		
	}
	
	void Update () 
	{
	
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
