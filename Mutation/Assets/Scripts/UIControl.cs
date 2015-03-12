using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
    //If we decided we want a bit more control
    //GameObject mapPanel;
    //GameObject explorationPanel;
    //GameObject fightPanel;
    //GameObject inventoryPanel;
    //GameObject avatarPanel;
    GameObject lastPanel;
    Stack panelStack;
    bool DEBUGtriggerMonster = false;

	// Use this for initialization
	void Start () {
        //mapPanel = transform.FindChild("MapPanel").gameObject;
        //explorationPanel = transform.FindChild("ExplorationPanel").gameObject;
        //fightPanel = transform.FindChild("FightPanel").gameObject;
        //inventoryPanel = transform.FindChild("InventoryPanel").gameObject;
        //avatarPanel = transform.FindChild("AvatarPanel").gameObject;
        panelStack = new Stack();
        ChangePanel(transform.FindChild("ExplorationPanel").gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangePanel(GameObject newPanel)
    {
        if (newPanel == null)
        {
            return;
        }

        if (lastPanel != null)
        {
            if (lastPanel == newPanel)
            {
                return;
            }
            lastPanel.SetActive(false);
        }
        newPanel.SetActive(true);
        lastPanel = newPanel;
        
        //If we need a stack of menus for different levels, maybe put this back :/
        //if (panelStack.Count > 0)
        //{
        //    GameObject currentPanel = (GameObject)panelStack.Peek();
        //    currentPanel.SetActive(false);
        //    if (newPanel == currentPanel)
        //    {
        //        panelStack.Pop();
        //        currentPanel = (GameObject)panelStack.Peek();
        //        currentPanel.SetActive(true);
        //        return;
        //    }
        //}
        //panelStack.Push(newPanel);
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

        //If we're triggering a monster, do that as well.
        if (DEBUGtriggerMonster)
        {
            //TriggerMonster
            DEBUGtriggerMonster = false;
        }
    }

}
