using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
    //If we decided we want a bit more control
    //GameObject mapPanel;
    GameObject explorationPanel;
    GameObject fightPanel;
    //GameObject inventoryPanel;
    //GameObject avatarPanel;
    GameObject lastPanel;
    UnityEngine.UI.Text explorationDescription;
    Stack panelStack;

	// Use this for initialization
	void Start () {
        //mapPanel = transform.FindChild("MapPanel").gameObject;
        explorationPanel = transform.FindChild("ExplorationPanel").gameObject;
        fightPanel = transform.FindChild("FightPanel").gameObject;
        //inventoryPanel = transform.FindChild("InventoryPanel").gameObject;
        //avatarPanel = transform.FindChild("AvatarPanel").gameObject;
        panelStack = new Stack();
        ChangePanel(explorationPanel);
        explorationDescription = GameObject.Find("DescriptionPanel/Text").gameObject.GetComponent<UnityEngine.UI.Text>();
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

    public void GoToDescription(string description)
    {
        explorationDescription.text = description;
        ChangePanel(explorationPanel);
    }

    public void AddPanelOnTop(GameObject newPanel)
    {
        if (newPanel == null)
        {
            return;
        }
        panelStack.Push(newPanel);
        newPanel.SetActive(true);
    }

    public void RemovePanelFromTop()
    {
        if (panelStack.Count <= 0)
        {
            return;
        }
        GameObject oldPanel = (GameObject)panelStack.Pop();
        oldPanel.SetActive(false);
    }

    public void InitiateCombat()
    {
        ChangePanel(fightPanel);
    }

    public void EndCombat()
    {
        ChangePanel(explorationPanel);
    }
}
