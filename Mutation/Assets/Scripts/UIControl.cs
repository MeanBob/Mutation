using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
    //If we decided we want a bit more control
	//GameObject explorationDescription;

	GameObject explorationPanel;
	GameObject mapPanel;
    GameObject inventoryPanel;
    GameObject characterSheetPanel;
	GameObject preCombatPanel;
    GameObject avatarPanel;
    GameObject fightPanel;
	GameObject deathPanel;
	public GameObject victoryPanel;
	GameObject levelUpPanel;
	GameObject introPanel;
	GameObject introStoryPanel;
    
    GameObject playerActionPanel;
	GameObject statInfoPanel;
	GameObject stanInfoButton;

	GameObject questPanel;
	GameObject nashDeadPanel;
	GameObject exploringPanel;

	GameObject lastPanel;
	


	CharacterPage playerCharacter;
	ButtonSoundControler sounds;


	Monster selectedMonster;
	CombatControl combat;
	GameObject temp;
	public UnityEngine.UI.Button[] explorationButtons;
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


		playerCharacter = GameObject.Find("Canvas").GetComponent<CharacterPage>();
		//Buttons
		hide = GameObject.Find("PreCombatPanel/ChooseHide").gameObject;
		fight = GameObject.Find("PreCombatPanel/ChooseFight").gameObject;
		close = GameObject.Find("PreCombatPanel/Close").gameObject;

		explorationButtons = transform.FindChild("ExplorationPanel").GetComponentsInChildren<Button>();
		avatarButtons = transform.FindChild("AvatarPanel").GetComponentsInChildren<Button>();

		chooseHideRemoveChoice = explorationDescription = GameObject.Find("PreCombatPanel/ChoiceDescription").gameObject.GetComponent<UnityEngine.UI.Text>();

		combat = GameObject.Find("Canvas").GetComponent<CombatControl>();
		sounds = GameObject.Find("Canvas/ButtonSound").GetComponent<ButtonSoundControler>();
		preCombatPanel = transform.FindChild("PreCombatPanel").gameObject;
		playerSlider = transform.FindChild("PlayerReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
		deathPanel = transform.FindChild("DeathPanel").gameObject;

		victoryPanel = transform.FindChild ("VictoryPanel").gameObject;

		//mapPanel = transform.FindChild("IntroPanel").gameObject;
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
		introPanel = transform.FindChild("IntroPanel").gameObject;
		//introStoryPanel = transform.FindChild("IntroStoryPanel").gameObject;
		levelUpPanel = transform.FindChild("LevelUp").gameObject;
		questPanel = transform.FindChild ("QuestPanel").gameObject;
		exploringPanel = transform.Find ("ExploringPanel").gameObject;

		nashDeadPanel = transform.FindChild ("NashIsDeadPanel").gameObject;
		statInfoPanel = transform.Find ("CharacterSheetPanel/InfoPanel").gameObject;
		statInfoPanel.SetActive (false);
		stanInfoButton = transform.Find ("CharacterSheetPanel/StatsInfoButton").gameObject;

        panelStack = new Stack();

        //Don't turn anything off until the game is loaded or else it makes it a pain to find anything :p
        mapPanel.SetActive(false);
        explorationPanel.SetActive(false);
		fightPanel.SetActive(false);
		inventoryPanel.SetActive(false);
		deathPanel.SetActive(false);
		preCombatPanel.SetActive(false);
		//hide.SetActive(false);
		levelUpPanel.SetActive(false);
		//introStoryPanel.SetActive(false);
		victoryPanel.SetActive (false);
		questPanel.SetActive (false);
		nashDeadPanel.SetActive (false);
		exploringPanel.SetActive (false);
		characterSheetPanel.SetActive(true);
		introPanel.SetActive (true);
		ChangePanel(introPanel);


	}


	//CHANGE TO ANIMATIoN
	void Update()
	{
		if (playerCharacter.leveledUp == true)
		{
			AddPanelOnTop(levelUpPanel);
		}
	}

	public void PlayNormalState()
	{
	
	}

	public void CloseInfoPanel()
	{
		statInfoPanel.SetActive (false);
	}
	public void ShowInfoPanel ()
	{
		statInfoPanel.SetActive (true);
	}


	public void CloseInfoButton()
	{
		stanInfoButton.SetActive (false);
	}
	public void ShowInfoButton()
	{
		stanInfoButton.SetActive (true);
	}


	public void CloseProgram()
	{
		Application.Quit();
	}

	public void CloseInventory()
	{ inventoryPanel.SetActive(false);

	}
	public void OpenInventory()
	{ inventoryPanel.SetActive(true);
	}

	public void CloseCharacter()
	{ characterSheetPanel.SetActive(false);

	}
	public void CloseIntro()
	{
		introPanel.SetActive (false);
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
		//Null reference here
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
