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
	GameObject deathPanel;
	GameObject preCombatPanel;
	Monster selectedMonster;
	CombatControl combat;
	GameObject temp;
	UnityEngine.UI.Button[] explorationButtons;
	UnityEngine.UI.Button[] avatarButtons;
	public bool hasPopUp;
	//Buttons
	GameObject hide;
	GameObject fight;
	GameObject close;

	UnityEngine.UI.Text explorationDescription;
	UnityEngine.UI.Text sensesText;

	Stack panelStack;
	UnityEngine.UI.Text preCombatDescription;

	UnityEngine.UI.Text chooseHideRemoveChoice;

	UnityEngine.UI.Slider playerSlider;
	float currentPlayerReadiness = 0;

	// Use this for initialization
	void Start () {
        
		//Buttons
		hide = GameObject.Find("PreCombatPanel/ChooseHide").gameObject;
		fight = GameObject.Find("PreCombatPanel/ChooseFight").gameObject;
		close = GameObject.Find("PreCombatPanel/Close").gameObject;

		explorationButtons = transform.FindChild("ExplorationPanel").GetComponentsInChildren<Button>();
		avatarButtons = transform.FindChild("AvatarPanel").GetComponentsInChildren<Button>();

		chooseHideRemoveChoice = explorationDescription = GameObject.Find("PreCombatPanel/ChoiceDescription").gameObject.GetComponent<UnityEngine.UI.Text>();

		combat = GameObject.Find("Canvas").GetComponent<CombatControl>();
		preCombatPanel = transform.FindChild("PreCombatPanel").gameObject;
		playerSlider = transform.FindChild("PlayerReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
		deathPanel = transform.FindChild("DeathPanel").gameObject;

		mapPanel = transform.FindChild("MapPanel").gameObject;
        explorationPanel = transform.FindChild("ExplorationPanel").gameObject;
        fightPanel = transform.FindChild("FightPanel").gameObject;
        characterSheetPanel = transform.FindChild("CharacterSheetPanel").gameObject;
        playerActionPanel = fightPanel.transform.FindChild("ActionPanel").gameObject;
        inventoryPanel = transform.FindChild("InventoryPanel").gameObject;
        avatarPanel = transform.FindChild("AvatarPanel").gameObject;
		sensesText =  GameObject.Find("DescriptionPanel/TextSense").gameObject.GetComponent<UnityEngine.UI.Text>();
		explorationDescription = GameObject.Find("DescriptionPanel/Text").gameObject.GetComponent<UnityEngine.UI.Text>();
		preCombatDescription = GameObject.Find("PreCombatPanel/PreCombatDescriptionText").gameObject.GetComponent<UnityEngine.UI.Text>();

        panelStack = new Stack();

        //Don't turn anything off until the game is loaded or else it makes it a pain to find anything :p
        mapPanel.SetActive(false);
        explorationPanel.SetActive(false);
        fightPanel.SetActive(false);
        inventoryPanel.SetActive(false);
		deathPanel.SetActive(false);
        ChangePanel(characterSheetPanel);
		preCombatPanel.SetActive(false);

		hide.SetActive(false);

	}

	void Update()
	{
	}

	public void CloseInventory()
	{ inventoryPanel.SetActive(false);

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

    public void GoToDescription(string description,string sensoryDescription)
    {
        explorationDescription.text = description;
		sensesText.text = sensoryDescription;
        ChangePanel(explorationPanel);
    }

    public void AddPanelOnTop(GameObject newPanel)
    {
        if (newPanel == null)
        {
            return;
        }

		foreach(Button b in explorationButtons)
		{
			b.interactable = false;
		}

		foreach(Button b in avatarButtons)
		{
			b.interactable = false;
		}
		hasPopUp = true;
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
		hasPopUp = false;
    }

    public void InitiateCombat(Monster monster)
    {
        //ChangePanel(fightPanel);
		AddPanelOnTop(preCombatPanel);
		selectedMonster = monster;
		preCombatDescription.text = monster.GetDescription();

		chooseHideRemoveChoice.text = "What will you do?";

		hide.SetActive(true);
		fight.SetActive(true);
		close.SetActive(false);
    }

    public void EndCombat()
    {
        ChangePanel(explorationPanel);
    }

    public void EnablePlayerActionPanel()
    {
        AddPanelOnTop(playerActionPanel);
    }

	public void ChooseHide()
	{
		//RemovePanelFromTop();
		combat.combatOn = false;
		preCombatDescription.text = selectedMonster.GetHideDescription();
		hide.SetActive(false);
		fight.SetActive(false);
		close.SetActive(true);
		chooseHideRemoveChoice.text = "";

	}

	public void ChooseFight()
	{
		RemovePanelFromTop();
		ChangePanel(fightPanel);
	}

    public void DisablePlayerActionPanel()
    {
        RemovePanelFromTop();
        RemovePanelFromTop();
    }
}
