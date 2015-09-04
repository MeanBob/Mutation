using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatControl : MonoBehaviour {
   
	public	Animator shake;
	public AudioSource combatSFX;

	CombatSFXAudioController combatSFXController;

	UIControl ui;
    CharacterPage playerCharacter;
    Monster currentMonster;

	string[] victoryVerbs;

    UnityEngine.UI.Slider enemySlider;
	UnityEngine.UI.Slider playerSlider;

	UnityEngine.UI.Image monsterImage;

	UnityEngine.UI.Slider enemyEnergySlider;
	UnityEngine.UI.Text enemyMaxEnergyText;
	UnityEngine.UI.Text enemyCurrentEnergyText;

	UnityEngine.UI.Slider enemyHealthSlider;
	UnityEngine.UI.Text enemyMaxHealthText;
	UnityEngine.UI.Text enemyCurrentHealthText;
	
    public UnityEngine.UI.Text combatLogText;
    public float currentPlayerReadiness = 0;
    float currentMonsterReadiness = 0;
    public float maxReadiness = 100;
    float readinessMultiplier = 1;

	public Button characterButton;
	public Button exploreButton;
	public Button inventoryButton;
	public Button mapButton;

	public Button armButton;
	public Button legButton;
	public Button headButton;

	public bool combatPause=false;
	public bool MonsterAttackPause = false;
    public bool combatOn = false;

	UnityEngine.UI.Text expEarned;
	UnityEngine.UI.Text monsterKilled;
	UnityEngine.UI.Text lootGained;
	public bool showVictory = false;

	public bool KilledNash = false;

	//MapControl mapControl;

	void Start () 
	{
		victoryVerbs = new string[5];
		VictoryVerbs ();
		
		expEarned = transform.Find ("VictoryPanel/ExpEarned").GetComponent<UnityEngine.UI.Text> ();
		monsterKilled = transform.Find ("VictoryPanel/MonsterKilled").GetComponent<UnityEngine.UI.Text> ();
		lootGained = transform.Find ("VictoryPanel/LootGained").GetComponent<UnityEngine.UI.Text> ();


		combatSFX = GetComponent<AudioSource>();


		//mapControl = GameObject.Find ("Canvas").GetComponent<MapControl> ();

		shake = GetComponent<Animator> ();
        ui = GetComponent<UIControl>();
		playerCharacter = GameObject.Find("Canvas").GetComponent<CharacterPage>();

		combatSFXController = GameObject.Find ("CombatSound").GetComponent<CombatSFXAudioController> ();

        enemySlider = transform.FindChild("FightPanel/EnemyScenePanel/EnemyReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
        playerSlider = transform.FindChild("PlayerReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
        enemySlider.maxValue = maxReadiness;
        playerSlider.maxValue = maxReadiness;
		combatLogText = transform.FindChild("FightPanel/ActionPanel/CombatLogPanel/CombatLogText/Text").GetComponent<UnityEngine.UI.Text>();
        enemyCurrentHealthText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider/Handle Slide Area/EnemyHPCurrentText").GetComponent<UnityEngine.UI.Text>();
        enemyMaxHealthText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider/EnemyHPMaxText").GetComponent<UnityEngine.UI.Text>();
        enemyHealthSlider = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider").GetComponent<UnityEngine.UI.Slider>();
		enemyCurrentEnergyText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyEnergySlider/HandleSlideArea/EnemyEnergyCurrentText").GetComponent<UnityEngine.UI.Text>();
		enemyMaxEnergyText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyEnergySlider/EnemyEnergyMaxText").GetComponent<UnityEngine.UI.Text>();
		enemyEnergySlider = transform.FindChild("FightPanel/EnemyScenePanel/EnemyEnergySlider").GetComponent<UnityEngine.UI.Slider>();
		monsterImage = transform.FindChild("FightPanel/EnemyScenePanel/EnemyImage").GetComponent<UnityEngine.UI.Image>();
	}

	void VictoryVerbs()
	{
		victoryVerbs[0] = "hack";
		victoryVerbs[1] = "cut";
		victoryVerbs[2] = "break";
		victoryVerbs[3] = "tear";
		victoryVerbs[4] = "rip";
	}

	public void PlayTurnInBounty()
	{
		shake.SetTrigger ("TurnInBounty");
		//mapControl.QuestIsNotActive ();

	}

	public void PlayFight()
	{
		shake.SetTrigger("Fight");
	}

	public void PlayAcceptQuest()
	{
		shake.SetTrigger ("AcceptQuest");

	}

	public void PlayExplore()
	{
		shake.Play ("ToExplorePanel");
	}

	public void ShowButtons()
	{
		if (!combatOn) {
			shake.SetTrigger ("ShowButtons");
		} else
			shake.SetTrigger ("Fight");
	}
	public void NoButtons()
	{
		shake.SetTrigger ("NoButtons");
	}

	public void Hide()
	{
		shake.SetTrigger ("Hide");
	}
	public void MutationPlay()
	{
		shake.Play("Mutations");
	}
	public void StatsPlay()
	{
		shake.Play("Stats");
	}
	public void ShowInventory()
	{shake.SetTrigger ("Inventory");
	}
	public void ShowExplore()
	{shake.SetTrigger ("Explore");
	}
	public void ShowExploring()
	{shake.SetTrigger ("Exploring");
	}
	public void ShowSelf()
	{shake.SetTrigger ("Stats");
	}
	public void ShowExplored()
	{shake.SetTrigger ("Explored");
	}
	public void PlayIntro1()
	{shake.SetTrigger ("Line1");
	}
	public void PlayIntro2()
	{shake.SetTrigger ("Line2");
	}
	public void PlayIntro3()
	{shake.SetTrigger ("Line3");
	}

	public void ShowMap()
	{shake.SetTrigger ("Map");
	}

	public void TurnCombatOff()
	{

	}
	public void ShowVictoryState()
	{ 
		//combatOn = false;
		shake.SetTrigger ("Victory");
		//ui.victoryPanel.SetActive (true);
			expEarned.text = "";
			monsterKilled.text = currentMonster.GetVictoryText ();
			
		int tempV = Random.Range (0,6);
		lootGained.text = "You "+ victoryVerbs[tempV] + " off " + currentMonster.GetName ().ToLower() + " meat, and stuff it in your bag.";
	}
	public void CloseVictoryState()
	{

		//ui.victoryPanel.SetActive (false);
		//foreach(Button b in ui.explorationButtons)
		//{			b.interactable = true;		}
	}



	void Update () {
		//Debug.Log("Combat on value ::::"+combatOn);
		//shake.Play ("None");

	if (playerCharacter.GetHitPoints () <= 0||playerCharacter.GetEnergyPoints()<=0 ){
			//Debug.Log("DEAD!");
			shake.Play("Death");
		
		}

		if (currentPlayerReadiness >= 100) {
			headButton.interactable = true;
			armButton.interactable = true;
			legButton.interactable = true;
		}

		if (combatOn)
        {
			//characterButton.interactable = false;
			//exploreButton.interactable = false;
			//inventoryButton.interactable = false;
			//mapButton.interactable = false;
			//**
			if (currentPlayerReadiness > maxReadiness)
			{
				currentMonsterReadiness = currentMonsterReadiness;
				return;
			}

			if (!combatPause){
            currentPlayerReadiness += playerCharacter.GetSpeed() * readinessMultiplier * Time.deltaTime;
            currentMonsterReadiness += currentMonster.GetSpeed() * readinessMultiplier * Time.deltaTime;
			}
	
            playerSlider.value = currentPlayerReadiness;
            enemySlider.value = currentMonsterReadiness;

           if (currentMonsterReadiness >= maxReadiness)
            {
                int monsterDamage = 0;
                int choice = Random.Range(0, 5);
                combatLogText.text += currentMonster.GetName() + "'s ";
                switch (choice)
                {
                    case 0:
                        combatLogText.text += "bite ";
                        monsterDamage = currentMonster.RollHeadDamage();
						currentMonster.DoEnergyDamage(2);


					enemyEnergySlider.value = currentMonster.GetEnergy();


                        break;
                    case 1:
                    case 2:
                        combatLogText.text += "strike ";
                        monsterDamage = currentMonster.RollArmDamage();
						currentMonster.DoEnergyDamage(1);
					enemyEnergySlider.value = currentMonster.GetEnergy();

						
                        break;
                    case 3:
                    case 4:
                        combatLogText.text += "attack ";
                        monsterDamage = currentMonster.RollLegDamage();
						currentMonster.DoEnergyDamage(1);
					enemyEnergySlider.value = currentMonster.GetEnergy();

						
                        break;
                }
                currentMonsterReadiness = 0;
                combatLogText.text += "did " + monsterDamage + " damage.\n";
				//shake.Play ("Hit");
                playerCharacter.DoDamage(monsterDamage);
				//shake.Play ("PlayetHit");
				combatSFXController.MonsterAttacking1();

            }
        }
		else
		{
			combatLogText.text = "";
			if(!ui.hasPopUp){
			characterButton.interactable = true;
			exploreButton.interactable = true;
			inventoryButton.interactable = true;
			mapButton.interactable = true;
			}
			if (currentPlayerReadiness < maxReadiness)
			{
			currentPlayerReadiness += playerCharacter.GetSpeed() * readinessMultiplier * Time.deltaTime;
			}
			playerSlider.value = currentPlayerReadiness;

		}
	}


    public void InitiateCombat(Monster encounteredMonster)
    {
        //Generate monster
        //Monster tempMonster = GenerateMonster();
		currentMonster = encounteredMonster;
		int readiness = Random.Range (2,89);
		currentPlayerReadiness = readiness;
		shake.SetTrigger("Fight");
		
		int rStart	= Random.Range(1,99);
		currentMonsterReadiness = rStart;

		monsterImage.sprite = currentMonster.GetMonsterImage();

		enemyEnergySlider.maxValue = currentMonster.GetMaxEnergy();
		enemyCurrentEnergyText.text = currentMonster.GetEnergy().ToString();
		enemyMaxHealthText.text= currentMonster.GetMaxEnergy().ToString();
		enemyEnergySlider.value=currentMonster.GetEnergy();
		
		enemyHealthSlider.maxValue = currentMonster.GetMaxHealth();
		enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
		enemyMaxHealthText.text = currentMonster.GetMaxHealth().ToString();
		enemyHealthSlider.value = currentMonster.GetHealth();

		ui.InitiateCombat(currentMonster);
    }



	public void WhenFightIsPressed()
	{

		combatOn = true;
		currentPlayerReadiness = playerCharacter.GetSpeed();
		shake.SetTrigger ("Fight");
	}

	public void CanAttack(int attackId)
	{
		int accuracy = playerCharacter.getPlayerAccuracy();
		if (currentPlayerReadiness >= 100)
		{

			headButton.interactable = true;
			armButton.interactable = true;
			legButton.interactable = true;

			//this makes the random number we will check our stats algorithm against. It's a 1d100 system...
			int chanceToHit = Random.Range (0,100);

			//Switch is called on the Buttons Arm, Leg, Head
			//Add better text??
			switch(attackId)
			{
				//head
			case 0 :
				if (chanceToHit > (30 - accuracy))
					PlayerAttackHead();
				else {
					combatLogText.text += "You miss! \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
					combatSFXController.PlayerPlayerMissing();

				}
				break;
				//arm
			case 1 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackLeftArm();
				else {
					combatLogText.text += "You miss! \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
					combatSFXController.PlayerPlayerMissing();
				}
				break;
				//arm
			case 2 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackRightArm();
				else {
					combatLogText.text += "You miss! \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
					combatSFXController.PlayerPlayerMissing();
				}
				break;
				//leg
			case 3 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackLeftLeg();
				else {
					combatLogText.text += "You miss! \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
					combatSFXController.PlayerPlayerMissing();
				}
				break;
				//leg
			case 4 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackRightLeg();
				else {
					combatLogText.text += "You miss! \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
					combatSFXController.PlayerPlayerMissing();
				}
				break;
				
			}
		}

		//Check if you are ready or not
		else {

			headButton.interactable = false;
			armButton.interactable = false;
			legButton.interactable = false;

			int waitTextNumber = Random.Range(1,5);

			if (waitTextNumber ==1){
			combatLogText.text += "You are not ready. \n";}
			else if (waitTextNumber ==2){
				combatLogText.text += "You need more time. \n";}
			else if (waitTextNumber ==3){
				combatLogText.text += "Wait. \n";}
			else{
				combatLogText.text += "Not yet. \n";}
	}
	}


	//special attacks
	void LifeSteal()
	{
		if (playerCharacter.hasStealLife) {

			int lifeStealChance = Random.Range (1, 3);
			if (lifeStealChance == 1) {
				playerCharacter.DoEnergyDamage (1);

				int rTemp = Random.Range (0, 4);
				int temp = playerCharacter.GetIntelligence () / 3 + rTemp;
				playerCharacter.HealDamage (temp);

				combatLogText.text += "Your punch steals " + temp + " life!\n";
			} else {
				combatLogText.text += ""; //Your punch fails to steal any life.\n
			}
		} 
	}



	void Stun()
	{

		if (playerCharacter.hasStun) { 
			int stunChance = Random.Range (1, 3);

			if (stunChance == 1) {
				currentMonsterReadiness = 0;
				enemySlider.value = currentMonsterReadiness;
				combatLogText.text += "Your headbutt stuns the " + currentMonster.GetName ().ToLower () + "!\n";
			} else {
				combatLogText.text += ""; //Your headbutt fails to stun.\n
			}
		}
	}

	//Basic Attacks  WORK ON TEXT
    void PlayerAttackHead()
    {
		Stun ();
		int temp = Random.Range (1, 10);
		combatLogText.text += "Your headbutt";
        
		DoDamageToMonster(playerCharacter.AttackHead()/ temp);

		currentPlayerReadiness = 70;


		playerCharacter.DoEnergyDamage(5);
    }
	//dont use
    void PlayerAttackLeftArm()
    {

		combatLogText.color = Color.red;
		combatLogText.text += "Your punch";
		combatLogText.color = Color.black;
        DoDamageToMonster(playerCharacter.AttackLeftArm());
		LifeSteal ();
		currentPlayerReadiness = 70;

    }

    void PlayerAttackRightArm()
    {
		LifeSteal ();
        combatLogText.text += "Your punch";
        DoDamageToMonster(playerCharacter.AttackRightArm());
		currentPlayerReadiness = 60;
		LifeSteal ();
		playerCharacter.DoEnergyDamage(1);
    }

	//dont use
    void PlayerAttackLeftLeg()
    {
        combatLogText.text += "Your kick";
        DoDamageToMonster(playerCharacter.AttackLeftLeg());
		currentPlayerReadiness = 45;
		playerCharacter.DoEnergyDamage(3);
    }

    void PlayerAttackRightLeg()
    {
		int temp = Random.Range (1, 10);
        combatLogText.text += "Your kick";
        DoDamageToMonster(playerCharacter.AttackRightLeg()+temp);
		currentPlayerReadiness = 45;
		playerCharacter.DoEnergyDamage(3);
    }


	//Exploring
	public bool DoSpeedDamageForExploring(int damage)
	{
		currentPlayerReadiness -= 96;
		if (currentPlayerReadiness <= 0)
		{
			return true;
		}
		return false;
	}

    void DoDamageToMonster(int damage)
    {
		//shake.Play ("Hitting");
		combatSFXController.PlayerHitting ();
        
		if (currentMonster.DoDamage(damage))
        {
            ui.EndCombat();
        }
        
		//for the bars
		enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
		enemyCurrentEnergyText.text = currentMonster.GetEnergy().ToString();

		//check for monster death
		if(currentMonster.GetHealth() <= 0 || currentMonster.GetEnergy() <=0 )
		{
			if (currentMonster.GetName()=="Nash")
			{
				KilledNash = true;
				playerCharacter.UpdateExpPoints(currentMonster.GetExpPointsGained());
				playerCharacter.UpdateMoney(currentMonster.GetMoneyGained());
				combatOn = false;
				ItemToolBox.AddItem(currentMonster.GetMonsterMeat());
				shake.SetTrigger("NashIsDead");
				DestroyObject(currentMonster);

			}
			else{ 
				playerCharacter.UpdateExpPoints(currentMonster.GetExpPointsGained());
				playerCharacter.UpdateMoney(currentMonster.GetMoneyGained());
				combatOn = false;
				//Update Inventory here
				ItemToolBox.AddItem(currentMonster.GetMonsterMeat());
				//VictoryWindow
				ShowVictoryState();
				
				
				//remove current monster
				DestroyObject(currentMonster);
			}




		}


        enemyHealthSlider.value = currentMonster.GetHealth();
		enemyEnergySlider.value = currentMonster.GetEnergy();
        ui.DisablePlayerActionPanel();

		//Damage done
        combatLogText.text += " did " + damage + " damage.\n";

		//Animal reactions to damage
		if (damage <= 10)
			combatLogText.text += "The " + currentMonster.GetName ().ToLower() + " is jarred.\n";
		else if (damage >= 11 && damage <= 29) {
			combatLogText.text += "The " + currentMonster.GetName ().ToLower() + " stumbles.\n";
		} else if (damage >= 30) {
			combatLogText.text += "The " + currentMonster.GetName ().ToLower() + " spasisms.\n";
		}


		//animal's reactions to loss of life
		if (currentMonster.GetHealth () <= currentMonster.GetMaxHealth () / 1.3  && currentMonster.GetHealth() > currentMonster.GetMaxHealth () / 2.4) {
			combatLogText.text += "The " + currentMonster.GetName ().ToLower() + " looks weakened.\n";
		
		} else if (currentMonster.GetHealth () < currentMonster.GetMaxHealth () / 2.4 && currentMonster.GetHealth() > currentMonster.GetMaxHealth () / 10) {
			combatLogText.text += "Pain wrecks the " + currentMonster.GetName ().ToLower() + "!\n";
			
		}else if (currentMonster.GetHealth () < currentMonster.GetMaxHealth () / 10) {
			combatLogText.text += "The " + currentMonster.GetName ().ToLower() + " bleeds everywhere.\n";
			
		}

    }

    public void DEBUGKILLENEMY()
    {
        ui.EndCombat();
    }

    public void DEBUGKILLPLAYER()
    {
		shake.ResetTrigger ("Victory");
		shake.ResetTrigger ("Exploring");
		//shake.ResetTrigger ("");
    }

    public Monster GenerateMonster()
    {
	int rMonster = Random.Range(1,4);
	Debug.Log ("Attempted monster generated... " + rMonster);
	if (rMonster == 1) {
			//Always create instance of monster and then call start
			currentMonster = ScriptableObject.CreateInstance<RabbitMonster> ();
			currentMonster.Start ();

			int rStart = Random.Range (1, 99);
			currentMonsterReadiness = rStart;
		} else if (rMonster == 2) {
			//Always create instance of monster and then call start
			currentMonster = ScriptableObject.CreateInstance<RabbitMonster> ();
			currentMonster.Start ();
			int rStart = Random.Range (1, 99);
			currentMonsterReadiness = rStart;

		} else if (rMonster == 3) {
			//Always create instance of monster and then call start
			currentMonster = ScriptableObject.CreateInstance<RabbitMonster> ();
			currentMonster.Start ();
			int rStart = Random.Range (1, 99);
			currentMonsterReadiness = rStart;
		} 
        currentMonster.Init();
		return currentMonster;

        //If we want to introduce a "surprised" or "ambush" mechanic,
        //we can adjust the readiness values.
        //int readiness = Random.Range (2,89);
//		currentPlayerReadiness = readiness;
//		enemyEnergySlider.maxValue = currentMonster.GetMaxEnergy();
//		enemyCurrentEnergyText.text = currentMonster.GetEnergy().ToString();
//		enemyMaxHealthText.text= currentMonster.GetMaxEnergy().ToString();
//		enemyEnergySlider.value=currentMonster.GetEnergy();
//        enemyHealthSlider.maxValue = currentMonster.GetMaxHealth();
//        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
//        enemyMaxHealthText.text = currentMonster.GetMaxHealth().ToString();
//        enemyHealthSlider.value = currentMonster.GetHealth();
        //combatLogText.text = "";
    }
}
