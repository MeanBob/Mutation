using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
    //If we decided we want a bit more control
	//GameObject explorationDescription;
	GameObject mapPanel;
    GameObject explorationPanel;
    GameObject fightPanel;
    GameObject characterSheetPanel;
    GameObject inventoryPanel;
    GameObject avatarPanel;
    GameObject playerActionPanel;
    GameObject lastPanel;

	UnityEngine.UI.Text explorationDescription;
    Stack panelStack;

	UnityEngine.UI.Slider playerSlider;
	float currentPlayerReadiness = 0;

	// Use this for initialization
	void Start () {
        
		playerSlider = transform.FindChild("PlayerReadinessSlider").GetComponent<UnityEngine.UI.Slider>();


		mapPanel = transform.FindChild("MapPanel").gameObject;
        explorationPanel = transform.FindChild("ExplorationPanel").gameObject;
        fightPanel = transform.FindChild("FightPanel").gameObject;
        characterSheetPanel = transform.FindChild("CharacterSheetPanel").gameObject;
        playerActionPanel = fightPanel.transform.FindChild("ActionPanel").gameObject;
        inventoryPanel = transform.FindChild("InventoryPanel").gameObject;
        avatarPanel = transform.FindChild("AvatarPanel").gameObject;
        explorationDescription = GameObject.Find("DescriptionPanel/Text").gameObject.GetComponent<UnityEngine.UI.Text>();
        panelStack = new Stack();

        //Don't turn anything off until the game is loaded or else it makes it a pain to find anything :p
        mapPanel.SetActive(false);
        explorationPanel.SetActive(false);
        fightPanel.SetActive(false);
        inventoryPanel.SetActive(false);
        ChangePanel(characterSheetPanel);
	}


	public void ExplorationPause()
	{
		currentPlayerReadiness -= 15;
		playerSlider.value = currentPlayerReadiness;
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

    public void EnablePlayerActionPanel()
    {
        AddPanelOnTop(playerActionPanel);
    }

    public void DisablePlayerActionPanel()
    {
        RemovePanelFromTop();
        RemovePanelFromTop();
    }
}
