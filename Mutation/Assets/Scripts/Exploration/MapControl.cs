using UnityEngine;
using System.Collections;
using UnityEngine.UI;

struct Point
{
    public int x, y;
}

public class MapControl : MonoBehaviour {    

	public bool showCurrentLocation = false;

	CharacterPage playerCharacter;
	ExplorationText explorationText;
    UIControl ui;

	ExplorationImage explorationImage;
	Canvas canvas;

	UnityEngine.UI.Image backgroundImage;

	public UnityEngine.UI.Text movingText;

	UnityEngine.UI.Text mapLocation;
	UnityEngine.UI.Text mapMission;

    CombatControl combat;
    Point playerLocation;
    int xSize = 30;
    int ySize = 29;
    Zone currentZone;
	float currentMonsterReadiness = 0;
	Monster[] sensedMonsters;

	public Button northButton;
	public bool canMoveNorth = true;
	public Button southButton;
	bool canMoveSouth = true;
	public Button eastButton;
	bool canMoveEast = true;
	public Button westButton;
	bool canMoveWest = true;

	bool tryingToFlee;

	string[] verbs;
	string[] adverbs;

	public bool noMission;
	public bool introMission;


	GameObject healButton;

	// Use this for initialization
	void Start () {
		noMission = false;
		introMission = true;
	

		//For SetMovement Description
		adverbs = new string[6];
		verbs = new string[6];
		
		verbs [0] = " walk";
		verbs [1] = " tread";
		verbs [2] = " stride";
		verbs [3] = " continue";
		verbs [4] = " advance";
		verbs [5] = " march";
		
		adverbs [0] = " ahead.";
		adverbs [1] = " forward.";
		adverbs [2] = " forth.";
		adverbs [3] = " along.";
		adverbs [4] = " onward.";
		adverbs [5] = " on.";
	
		mapMission = transform.Find ("MapPanel/Quest").GetComponent<UnityEngine.UI.Text> ();
		mapLocation = transform.Find ("MapPanel/Location").GetComponent<UnityEngine.UI.Text> ();
		movingText = transform.Find ("ExploringPanel/Text").GetComponent<UnityEngine.UI.Text> ();

		healButton = transform.FindChild ("HealButton").gameObject;
		//For SetMovement Description
		


		//lootGained = transform.Find ("VictoryPanel/LootGained").GetComponent<UnityEngine.UI.Text> ();

		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

		backgroundImage = canvas.GetComponent<UnityEngine.UI.Image>();
		explorationImage = ScriptableObject.CreateInstance<ExplorationImage>();
		explorationImage.Start();
		//backgroundImage.sprite = Resources.Load <Sprite>("Backgrounds/CastleWallTest");


		explorationText = ScriptableObject.CreateInstance<ExplorationText>();
		explorationText.Start();
		tryingToFlee = false;
		//Debug.Log(Constants.dialogue(0,0));
		playerCharacter = canvas.GetComponent<CharacterPage>();
		currentZone = ScriptableObject.CreateInstance<Zone>();

        currentZone.SetZoneSize(xSize, ySize);
        

		ui = GetComponent<UIControl>();
        combat = GetComponent<CombatControl>();

        //Map setup 
        playerLocation.x = 15;
        playerLocation.y = 26;

        for (int i = 0; i < xSize; i++)
        {
            Node[] tempNodeArray = new Node[ySize];
            for (int j = 0; j < ySize; j++)
            {
                Node newNode = ScriptableObject.CreateInstance<Node>();
				newNode.AddDescription(explorationText.dialogue[i,j]);

				newNode.AddBackgroundImage(explorationImage.backgroundImage[i,j]);


                tempNodeArray[j] = newNode;
            }
            currentZone.AddNodeColumn(tempNodeArray, i);
        }
		GenerateZoneMonsters();

	}

	void SetBackgroundImage(string temp)
	{
		backgroundImage.sprite = Resources.Load <Sprite>(temp);	
	}


	/// <summary>
	/// Should Spawn NASH
	/// </summary>
	public void MakeQuestMonster()
	{
		//currentZone.GeneratePlaceMonster ();
		currentZone.questIsActive = true;
		noMission = false;
		introMission = false;
	}

	void GenerateZoneMonsters()
	{
		//Monster temp = ScriptableObject.CreateInstance<RabbitMonster>();
		//level 1-4, rabbit, snake, frog
		currentZone.AddMonster(14,27,ScriptableObject.CreateInstance<SnakeMonster>());
		currentZone.AddMonster(16,27,ScriptableObject.CreateInstance<FrogMonster>());
		currentZone.AddMonster(16,24,ScriptableObject.CreateInstance<CatMonster>());

		//currentZone.AddMonster(28,7,ScriptableObject.CreateInstance<FrogMonster>());
		//currentZone.AddMonster(28,10,ScriptableObject.CreateInstance<RabbitMonster>());
		
		//currentZone.AddMonster(27,6,ScriptableObject.CreateInstance<FrogMonster>());
		//currentZone.AddMonster(27,9,ScriptableObject.CreateInstance<SnakeMonster>());
		//currentZone.AddMonster(27,12,ScriptableObject.CreateInstance<RabbitMonster>());

		//currentZone.AddMonster(26,7,ScriptableObject.CreateInstance<SnakeMonster>());
		//currentZone.AddMonster(26,8,ScriptableObject.CreateInstance<FrogMonster>());
		//currentZone.AddMonster(26,11,ScriptableObject.CreateInstance<RabbitMonster>());

		//currentZone.AddMonster(25,5,ScriptableObject.CreateInstance<CatMonster>());
		//currentZone.AddMonster(25,8,ScriptableObject.CreateInstance<SnakeMonster>());
		//currentZone.AddMonster(25,12,ScriptableObject.CreateInstance<CatMonster>());



		//beaver, cat, dog, goat, skunk, wolf, bird


		//currentZone.AddMonster(24,6,ScriptableObject.CreateInstance<GiantAntMonster>());
//	currentZone.AddMonster(24,8,ScriptableObject.CreateInstance<PorcupineMonster>());
//	currentZone.AddMonster(24,10,ScriptableObject.CreateInstance<BeaverMonster>());
//	currentZone.AddMonster(24,13,ScriptableObject.CreateInstance<BirdMonster>());
//
//	currentZone.AddMonster(23,5,ScriptableObject.CreateInstance<MooseMonster>());
//	currentZone.AddMonster(23,8,ScriptableObject.CreateInstance<BirdMonster>());
//	currentZone.AddMonster(23,11,ScriptableObject.CreateInstance<SkunkMonster>());
//	currentZone.AddMonster(23,12,ScriptableObject.CreateInstance<DogMonster>());
//
//	currentZone.AddMonster(22,6,ScriptableObject.CreateInstance<BirdMonster>());
//	currentZone.AddMonster(22,7,ScriptableObject.CreateInstance<SnakeMonster>());
//	currentZone.AddMonster(22,8,ScriptableObject.CreateInstance<FrogMonster>());
//	currentZone.AddMonster(22,12,ScriptableObject.CreateInstance<PorcupineMonster>());
	//maybe up for 16  anteater, moose, porcupine



		// from 15- 6 bear, guant ant


	}

	public void NavButtonsOn()
	{
		if (canMoveNorth) {
			northButton.interactable = true;

		}
		if (canMoveSouth) {
			southButton.interactable = true;
		}
		if (canMoveEast) {
			eastButton.interactable = true;
		}
		if (canMoveWest) {
			westButton.interactable = true;
		}
	}

	//CCHEK HERE!!

	public void PressedHealedTurnedOffBool()
	{
		currentZone.onHealer = false;
	}

	void Update()
	{

		if (showCurrentLocation) 
		{
			Debug.Log(playerLocation.x +","+ playerLocation.y);

			showCurrentLocation=false;
		}

		if (currentZone.startQuest1) {
			PlayQuest1();
			currentZone.startQuest1 = false;
		}

		if (currentZone.startQuest2) {
			PlayQuest2();
			currentZone.startQuest2 = false;
		}

		if (currentZone.GenerateQuestMonster) {
		
			currentZone.GeneratePlaceMonster();
		}


		if (currentZone.onHealer == true) {
			healButton.SetActive (true);
		} else
			healButton.SetActive (false);



		//USED IN ZONE for Access!
		if (playerCharacter.getPlayerMoney () >= 6) {
			currentZone.canEnterDT = true;
		}
		else {currentZone.canEnterDT = false;}

		if (playerCharacter.getPlayerMoney () >= 15) {
			currentZone.canCrossBridge = true;
		} else { currentZone.canCrossBridge = false;}



	if (combat.currentPlayerReadiness >= combat.maxReadiness && canMoveNorth) 
		{
			northButton.interactable = true;
		} 
		else {
			northButton.interactable = false;
		}
	if (combat.currentPlayerReadiness >= combat.maxReadiness && canMoveSouth) 
		{
			southButton.interactable = true;
		} 
		else {
			southButton.interactable = false;
		}
	if (combat.currentPlayerReadiness >= combat.maxReadiness && canMoveEast) 
		{
			eastButton.interactable = true;
		} 
		else {
			eastButton.interactable = false;
		}
	if (combat.currentPlayerReadiness >= combat.maxReadiness && canMoveWest) 
		{
			westButton.interactable = true;
		} 
		else {
			westButton.interactable = false;
		}
	}

	






	//generateQuestMonster?
	public void PlayQuest1()
	{

			combat.shake.SetTrigger ("Quest1");

		//playerCharacter.AddMoney (50);
		//playerCharacter.UpdateMoney ();

	}

	public void PlayQuest2()
	{
		combat.shake.SetTrigger ("Quest2");
	}


	public void SetQuestInactive()
	{
		currentZone.questIsActive = false;
		currentZone.quest2IsActive = false;
	
	}



	public void UpdateMap()
	{
		mapLocation.text = "Your current location is: " + playerLocation.x + ", " + playerLocation.y+ "."; 

		if (currentZone.questIsActive||currentZone.quest2IsActive) {
			mapMission.text = "Target is " + currentZone.randomXSpawn + ", " + currentZone.randomYSpawn + ".";
		
		} else if (noMission) {
			mapMission.text = "Get a job.";
		} else if (introMission) {
			mapMission.text = "Head Downtown: 19, 19.";
		} else { mapMission.text = "You need to earn some money.";
		}


	}


	//??!! for QUEST1
	public void ReturnToQuest1Start()
	{
		//Determine a place inside the town!
		playerLocation.x = 28;
		playerLocation.y = 7;
		currentZone.questIsActive = false;
	}



	void CombatCheck()
	{

		combat.currentPlayerReadiness = 50;


		if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y)){
			Debug.Log("Monster exists at player's current location"+"("+playerLocation.x+","+playerLocation.y+")");
			combat.InitiateCombat(currentZone.returnMonsterAtLocation(playerLocation.x,playerLocation.y));
			ui.CloseInventory();
			ui.OpenInventory();
		
		}
		else{
			Debug.Log(playerLocation.x +","+ playerLocation.y);
		}

	}


	public void Flee(int x, int y)
	{
		if (combat.combatOn)
		{
			combat.combatLogText.text = "You are starting your attempt to flee!\n";
			tryingToFlee = true;

			int fleeChance = Random.Range (0,99);
			if (playerCharacter.GetIntelligence()+50 > fleeChance)
			{
				combat.combatLogText.text = "You attempted to flee!\n";

				GoDirection(x, y);
				playerCharacter.DoEnergyDamage(1);
//				
				combat.combatOn = false;
				ui.RemovePanelFromTop();
				ui.EndCombat();				
			}
			else 
			{
				combat.combatLogText.text = "You trip as you try to run away!\n";
				ui.RemovePanelFromTop();
				combat.currentPlayerReadiness = 30;
			}
			return;
		}
	}


    public void MoveNorth()
    {
		//currentZone.description += "You move North. \n";
		//explorationText.dialogue += "You move North. \n";
		
		Flee(-1,0);
		if(!tryingToFlee)
		{
			//SetMoveDescription();
	        GoDirection(-1, 0);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

    public void MoveSouth()
    {

		Flee(1,0);
		if(!tryingToFlee)
		{
			combat.GenerateMonster();
			//SetMoveDescription();
			GoDirection(1, 0);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

    public void MoveEast()
{		
		Flee(0,1);
		if(!tryingToFlee)
		{

			//SetMoveDescription();
			GoDirection(0, 1);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;

    }

	public void QuestIsNotActive()
	{
		currentZone.questIsActive = false;
	}

    public void MoveWest()
{		
		Flee(0,-1);
		if(!tryingToFlee)
		{
			//SetMoveDescription();

			GoDirection(0, -1);
			CombatCheck();
			playerCharacter.DoEnergyDamage(1);
		}
		tryingToFlee = false;
    }

	public string SetMoveDescription()
	{
		string tempSentence = "";
		int rV = Random.Range (0, 6);
		int rAV = Random.Range (0, 6);
		tempSentence = "You" +verbs[rV] + adverbs[rAV];
		movingText.text = tempSentence;
		combat.ShowExploring();
		return tempSentence;
	}


    public void GoDirection(int xDir, int yDir)
    {
		//used to check if there is a random monster spawn when you move
		int tempCombatCheck = Random.Range (1, 99);

		if ( tempCombatCheck < 10) {
			combat.InitiateCombat (combat.GenerateMonster ());
		}
		

		//SetMoveDescription ();
		

        //Move Direction
        string nodeDescription = "";
        string oldDescription = "";
		string sensoryDescription = "";

		

		string direction1 = "";
		string direction2 = "";
		string direction3 = "";
		string direction4 = "";

		int intelligenceCategory=0;

		//currentZone has the description of each position
        if (currentZone.AttemptPlayerMove(playerLocation.x + xDir, playerLocation.y + yDir, ref nodeDescription))
        {
            playerLocation.x += xDir;
            playerLocation.y += yDir;

			//MTWA
			if (currentZone.MtWaInThatDirection (playerLocation.x, playerLocation.y - 1) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "Hills to the left.\n";}
				else if (rN==1)
				{nodeDescription += "A steep hill is to the left.\n";}
				else if (rN==2)
				{nodeDescription += "The hills to the left look like a little mountian.\n";}
				else if (rN==3)
				{nodeDescription += "Hills on the left.\n";}
			}
			if (currentZone.MtWaInThatDirection (playerLocation.x, playerLocation.y + 1) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "Hills to the right.\n";}
				else if (rN==1)
				{nodeDescription += "A steep hill is to the right.\n";}
				else if (rN==2)
				{nodeDescription += "The hills to the right look like a little mountian.\n";}
				else if (rN==3)
				{nodeDescription += "Hills on the right.\n";}
			}
			if (currentZone.MtWaInThatDirection (playerLocation.x+1, playerLocation.y) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "Hills behind you.\n";}
				else if (rN==1)
				{nodeDescription += "A steep hill is behind you.\n";}
				else if (rN==2)
				{nodeDescription += "The hills behind you look like a little mountian.\n";}
				else if (rN==3)
				{nodeDescription += "Hills roll out behind you.\n";}
			}
			if (currentZone.MtWaInThatDirection (playerLocation.x-1, playerLocation.y) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "Hills up ahead.\n";}
				else if (rN==1)
				{nodeDescription += "A steep hill is in front of you.\n";}
				else if (rN==2)
				{nodeDescription += "The hills ahead look like a little mountian.\n";}
				else if (rN==3)
				{nodeDescription += "You are approaching hills.\n";}
			}
			//ROAD
			if (currentZone.RoadInThatDirection (playerLocation.x, playerLocation.y - 1) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "A road is to your left.\n";}
				else if (rN==1)
				{nodeDescription += "A dirty street is left.\n";}
				else if (rN==2)
				{nodeDescription += "To your left is a road.\n";}
				else if (rN==3)
				{nodeDescription += "Left of you is a road.\n";}
			}
			if (currentZone.RoadInThatDirection (playerLocation.x, playerLocation.y + 1) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "A road is to your right.\n";}
				else if (rN==1)
				{nodeDescription += "A dirty street is right.\n";}
				else if (rN==2)
				{nodeDescription += "To your right is a road.\n";}
				else if (rN==3)
				{nodeDescription += "Right of you is a road.\n";}
			}
			if (currentZone.RoadInThatDirection (playerLocation.x-1, playerLocation.y) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "A road is up ahead.\n";}
				else if (rN==1)
				{nodeDescription += "A dirty street is ahead.\n";}
				else if (rN==2)
				{nodeDescription += "Up ahead is a road.\n";}
				else if (rN==3)
				{nodeDescription += "Ahead of you is a road.\n";}
			}
			if (currentZone.RoadInThatDirection (playerLocation.x+1, playerLocation.y) == true) {
				int rN = Random.Range(0,4);
				if (rN==0)
				{nodeDescription += "A road is behind you.\n";}
				else if (rN==1)
				{nodeDescription += "A dirty street is behind you.\n";}
				else if (rN==2)
				{nodeDescription += "Behind you is a road.\n";}
				else if (rN==3)
				{nodeDescription += "Behind is a street.\n";}
			}




				//FOR BLOCKING
				if (currentZone.ChasmInThatDirection (playerLocation.x + 1, playerLocation.y) == true) 
					{
						canMoveSouth = false;
						southButton.interactable = false;
				
						if(currentZone.ChasmInThatDirection(playerLocation.x + 1, playerLocation.y))
						{
							int rN = Random.Range(0,4);
							if (rN==0)
							{nodeDescription += "South is blocked by a chasm.\n";}
							else if (rN==1)
							{nodeDescription += "A chasm spans the south.\n";}
							else if (rN==2)
							{nodeDescription += "A large hole to the south is too dangerous to cross.\n";}
							else if (rN==3)
							{nodeDescription += "Going south is impossible because of a large chasm.\n";}
						}	
					} 
					else {
						canMoveSouth = true;
						southButton.interactable=true;
					}

				if (currentZone.ChasmInThatDirection (playerLocation.x - 1, playerLocation.y)
				    == true) {
					canMoveNorth = false;
					northButton.interactable = false;
					
					if(currentZone.ChasmInThatDirection(playerLocation.x - 1, playerLocation.y)){
					int rN = Random.Range(0,4);
					if (rN==0)
					{nodeDescription += "North is blocked by a chasm.\n";}
					else if (rN==1)
					{nodeDescription += "A chasm spans the north.\n";}
					else if (rN==2)
					{nodeDescription += "A large hole to the north is too dangerous to cross.\n";}
					else if (rN==3)
					{nodeDescription += "Going north is impossible because of a large chasm.\n";}
				}
					
				} else {
					canMoveNorth = true;
					northButton.interactable=true;
				}

				if (currentZone.ChasmInThatDirection (playerLocation.x, playerLocation.y+1)
				    == true) {
					canMoveEast = false;
					eastButton.interactable = false;
				if(currentZone.ChasmInThatDirection(playerLocation.x, playerLocation.y+1)){
					int rN = Random.Range(0,4);
					if (rN==0)
					{nodeDescription += "East is blocked by a chasm.\n";}
					else if (rN==1)
					{nodeDescription += "A chasm spans the east.\n";}
					else if (rN==2)
					{nodeDescription += "A large hole to the east is too dangerous to cross.\n";}
					else if (rN==3)
					{nodeDescription += "Going east is impossible because of a large chasm.\n";}
				}
					
				} else {
					canMoveEast=true;
					eastButton.interactable=true;
				}
				if (currentZone.ChasmInThatDirection (playerLocation.x, playerLocation.y-1)
				    == true) {
					canMoveWest=false;
					westButton.interactable=false;
				if(currentZone.ChasmInThatDirection(playerLocation.x , playerLocation.y- 1)){
					int rN = Random.Range(0,4);
					if (rN==0)
					{nodeDescription += "West is blocked by a chasm.\n";}
					else if (rN==1)
					{nodeDescription += "A chasm spans the west.\n";}
					else if (rN==2)
					{nodeDescription += "A large hole to the west is too dangerous to cross.\n";}
					else if (rN==3)
					{nodeDescription += "Going west is impossible because of a large chasm.\n";}
				}					
				} else {
					canMoveWest=true;
					westButton.interactable=true;
				}
        }
        else
        {
            currentZone.AttemptPlayerMove(playerLocation.x, playerLocation.y, ref oldDescription);
        }




		//FOR MOVE TEXT
		if (currentZone.MtWaInThatDirection (playerLocation.x, playerLocation.y) == true) {
			//MAKE MANY
			int tempNumber = Random.Range(0,8);
			if (tempNumber==0)
			{movingText.text = "<color=#06A124>You move through some vines and bushes</color>\n";}
			else if (tempNumber==1)
				movingText.text = "<color=#06A124>The gravel is loose as you walk.</color>\n";
			else if (tempNumber==2)
				movingText.text = "<color=#06A124>You head up the hill.</color>\n";
			else if (tempNumber==3)
				movingText.text = "<color=#06A124>You head down the hillside.</color>\n";
			else if (tempNumber==4)
				movingText.text = "<color=#06A124>You push aside some branches.</color>\n";
			else if (tempNumber==5)
				movingText.text = "<color=#06A124>You hop over a bush.</color>\n";
			else if (tempNumber==6)
				movingText.text = "<color=#06A124>You slip a bit on the loose dirt.</color>\n";
			else if (tempNumber==7)
				movingText.text = "<color=#06A124>The heat of the day is relentless.</color>\n";
			else
				movingText.text ="<color=#06A124>A palm tree looks like it's been cut by claws.</color>\n";
		}

		if (currentZone.RoadInThatDirection (playerLocation.x, playerLocation.y) == true) {
			//MAKE MANY
			int tempNumber = Random.Range(0,8);
			if (tempNumber==0)
			{movingText.text = "<color=#FFFBD8>You stick to the sidewalk.</color>\n";}
			else if (tempNumber==1)
				movingText.text = "<color=#FFFBD8>The gravel is loose as you walk.</color>\n";
			else if (tempNumber==2)
				movingText.text = "<color=#FFFBD8>You avoid a trash pile.</color>\n";
			else if (tempNumber==3)
				movingText.text = "<color=#FFFBD8>You step up a curb.</color>\n";
			else if (tempNumber==4)
				movingText.text = "<color=#FFFBD8>Trash flutters by.</color>\n";
			else if (tempNumber==5)
				movingText.text = "<color=#FFFBD8>You hop over a pothole.</color>\n";
			else if (tempNumber==6)
				movingText.text = "<color=#FFFBD8>You slip a bit on the loose dirt.</color>\n";
			else if (tempNumber==7)
				movingText.text = "<color=#FFFBD8>The heat of the day is relentless.</color>\n";
			else
				movingText.text ="<color=#FFFBD8>A palm tree looks like it's been cut by claws.</color>\n";
		}








		//For INT TRACKING
		if(playerCharacter.GetIntelligence()>=1 && playerCharacter.GetIntelligence()<=25)
			intelligenceCategory = 0;
		if(playerCharacter.GetIntelligence()>=26 && playerCharacter.GetIntelligence()<=50)
			intelligenceCategory = 1;
		if(playerCharacter.GetIntelligence()>=51 && playerCharacter.GetIntelligence()<=75)
			intelligenceCategory = 2;
		if(playerCharacter.GetIntelligence()>=76)
			intelligenceCategory = 3;

		if ((currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) 
		     || currentZone.doesMonsterExist(playerLocation.x-1,playerLocation.y) 
		     || currentZone.doesMonsterExist(playerLocation.x+2,playerLocation.y)
		     || currentZone.doesMonsterExist(playerLocation.x+1,playerLocation.y) 
		     || currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) 
		     || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-2) 
		     || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y -1)
		     || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y + 1) 
		     || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+2)) == false)
		{
			int tempSenceNumber = Random.Range(0,10);
			if (tempSenceNumber == 0)
			{
			sensoryDescription = "You hear a branch snap in the distance.";
			}
			else if (tempSenceNumber == 1)
			{
				sensoryDescription = "A low hum resonates.";
			}
			else if (tempSenceNumber == 2)
			{
				sensoryDescription = "You brush dirt off your shoulder.";
			}
			else if (tempSenceNumber == 3)
			{
				sensoryDescription = "You stretch you arms.";
			}
			else
				sensoryDescription = "";
		}
		else {
			if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+2) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y+1)){
				direction1 = "east\n";
			}

			if(currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-2) || currentZone.doesMonsterExist(playerLocation.x,playerLocation.y-1)){
				direction2 = "west\n";
			}
			if(currentZone.doesMonsterExist(playerLocation.x-2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x-1,playerLocation.y)){
				direction3 = "north\n";
			}
			if(currentZone.doesMonsterExist(playerLocation.x+2,playerLocation.y) || currentZone.doesMonsterExist(playerLocation.x+1,playerLocation.y)){
				direction4 = "south\n";
			}
			sensoryDescription = SetSensoryDescription(intelligenceCategory, direction1, direction2, direction3, direction4);
		}

		//REVIEW
		string temp = currentZone.returnImageAtLocation(playerLocation.x,playerLocation.y);
		SetBackgroundImage(temp);
		nodeDescription += "\n" + oldDescription;
		ui.GoToDescription(nodeDescription,sensoryDescription);

		
	}



	void CheckingForMtWaEast(string hills)
	{

	}









	public string SetSensoryDescription(int intelligenceCategory,string direction1, string direction2,string direction3, string direction4)
	{		
		string sensoryDescription = "";
		switch (intelligenceCategory)
		{
		case 0:	
			int temp = Random.Range(0,4);
			if (temp==0){
				sensoryDescription = "Something scurries nearby.";}
			else if (temp == 1)
			{	sensoryDescription = "You feel a wave of heat.";}
			else if (temp == 2)
			{	sensoryDescription = "You feel a tingle in your neck.";}
			else if (temp == 3)
			{	sensoryDescription = "A shadow suddenly shifts.";}

			break;
		case 1:
			sensoryDescription = "You sense something in the following directions :\n" + direction1 + direction2  + direction3 + direction4;
			break;
		case 2:
			sensoryDescription = "You sense an animal in the following directions :\n" + direction1 + direction2  + direction3 + direction4;
			break;
		case 3:
			//sensoryDescription = "You sense an "+currentZone.returnMonsterAtLocation() + " nearby to the "+direction;
			break;
		}
		
		return sensoryDescription;
	}
}
