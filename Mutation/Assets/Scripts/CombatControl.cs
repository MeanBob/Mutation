using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatControl : MonoBehaviour {
   
	UIControl ui;
    CharacterPage playerCharacter;
    Monster currentMonster;

    UnityEngine.UI.Slider enemySlider;
	UnityEngine.UI.Slider playerSlider;

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

	public bool combatPause=false;
	public bool MonsterAttackPause = false;
    public bool combatOn = false;
	
	void Start () {
        ui = GetComponent<UIControl>();
		playerCharacter = GameObject.Find("Avatar").GetComponent<CharacterPage>();
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
	}
	

	void Update () {
		//Debug.Log("Combat on value ::::"+combatOn);
        if (combatOn)
        {
			characterButton.interactable = false;
			exploreButton.interactable = false;
			inventoryButton.interactable = false;
			mapButton.interactable = false;
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
                        combatLogText.text += "claw ";
                        monsterDamage = currentMonster.RollArmDamage();
						currentMonster.DoEnergyDamage(1);
					enemyEnergySlider.value = currentMonster.GetEnergy();

						
                        break;
                    case 3:
                    case 4:
                        combatLogText.text += "kick ";
                        monsterDamage = currentMonster.RollLegDamage();
						currentMonster.DoEnergyDamage(1);
					enemyEnergySlider.value = currentMonster.GetEnergy();

						
                        break;
                }
                currentMonsterReadiness = 0;
                combatLogText.text += "did " + monsterDamage + " damage.\n\n";
                playerCharacter.DoDamage(monsterDamage);

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
       //	Monster tempMonster = GenerateMonster();
		currentMonster = encounteredMonster;
		int readiness = Random.Range (2,89);
		currentPlayerReadiness = readiness;

		int rStart	= Random.Range(1,99);
		currentMonsterReadiness = rStart;


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
	}

	public void CanAttack(int attackId)
	{
		int accuracy = playerCharacter.getPlayerAccuracy();
		if (currentPlayerReadiness >= 100)
		{
			int chanceToHit = Random.Range (0,100);

			switch(attackId)
			{
			case 0 :
				if (chanceToHit > (30 - accuracy))
					PlayerAttackHead();
				else {
					combatLogText.text += "You miss! \n \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
				}
				break;
			case 1 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackLeftArm();
				else {
					combatLogText.text += "You miss! \n \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
				}
				break;
			case 2 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackRightArm();
				else {
					combatLogText.text += "You miss! \n \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
				}
				break;
			case 3 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackLeftLeg();
				else {
					combatLogText.text += "You miss! \n \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
				}
				break;
			case 4 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackRightLeg();
				else {
					combatLogText.text += "You miss! \n \n";
					currentPlayerReadiness = 80;
					playerCharacter.DoEnergyDamage(1);
				}
				break;
				
			}
		}
		else {combatLogText.text += "You are not ready.\n\n";}
	}

    void PlayerAttackHead()
    {
		combatLogText.text += "Your headbutt";
        DoDamageToMonster(playerCharacter.AttackHead());
		currentPlayerReadiness = 30;
		playerCharacter.DoEnergyDamage(5);
    }

    void PlayerAttackLeftArm()
    {

		combatLogText.text += "Your left punch";
        DoDamageToMonster(playerCharacter.AttackLeftArm());
		currentPlayerReadiness = 70;
		playerCharacter.DoEnergyDamage(1);
    }

    void PlayerAttackRightArm()
    {
        combatLogText.text += "Your right punch";
        DoDamageToMonster(playerCharacter.AttackRightArm());
		currentPlayerReadiness = 70;
		playerCharacter.DoEnergyDamage(1);
    }
	
    void PlayerAttackLeftLeg()
    {
        combatLogText.text += "Your left kick";
        DoDamageToMonster(playerCharacter.AttackLeftLeg());
		currentPlayerReadiness = 50;
		playerCharacter.DoEnergyDamage(3);
    }

    void PlayerAttackRightLeg()
    {
        combatLogText.text += "Your right kick";
        DoDamageToMonster(playerCharacter.AttackRightLeg());
		currentPlayerReadiness = 50;
		playerCharacter.DoEnergyDamage(3);
    }


	public bool DoSpeedDamageForExploring(int damage)
	{
		currentPlayerReadiness -= 16;
		if (currentPlayerReadiness <= 0)
		{
			return true;
		}
		return false;
	}

    void DoDamageToMonster(int damage)
    {
        if (currentMonster.DoDamage(damage))
        {
            ui.EndCombat();
        }
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
		enemyCurrentEnergyText.text = currentMonster.GetEnergy().ToString();

		if(currentMonster.GetHealth() <= 0 || currentMonster.GetEnergy() <=0 )
		{
			playerCharacter.UpdateExpPoints(currentMonster.GetExpPointsGained());
			combatOn = false;
			DestroyObject(currentMonster);
		}
        enemyHealthSlider.value = currentMonster.GetHealth();
		enemyEnergySlider.value = currentMonster.GetEnergy();
        ui.DisablePlayerActionPanel();
        combatLogText.text += " did " + damage + " damage.\n\n";

    }

    public void DEBUGKILLENEMY()
    {
        ui.EndCombat();
    }

    public void DEBUGKILLPLAYER()
    {

    }

    Monster GenerateMonster()
    {
        //Randomly choose a monster in the future based on player level?
		int rMonster = Random.Range(1,4);
		//int rMonster = 1;

//		if(rMonster == 1)
//		{
//			//Always create instance of monster and then call start
//			currentMonster = ScriptableObject.CreateInstance<RabbitMonster>();
//			currentMonster.Start();
//
//			int rStart	= Random.Range(1,99);
//			currentMonsterReadiness = rStart;
//		}
//
//		else if(rMonster == 2)
//		{
//			//Always create instance of monster and then call start
//			currentMonster = ScriptableObject.CreateInstance<WolfMonster>();
//			currentMonster.Start();
//			int rStart	= Random.Range(1,99);
//			currentMonsterReadiness = rStart;
//
//		}
//		else {
//			//Always create instance of monster and then call start
//			currentMonster = ScriptableObject.CreateInstance<BearMonster>();
//			currentMonster.Start();
//			int rStart	= Random.Range(1,99);
//			currentMonsterReadiness = rStart;
//
//		}
        currentMonster.Init();

        //If we want to introduce a "surprised" or "ambush" mechanic,
        //we can adjust the readiness values.
        
        
//		int readiness = Random.Range (2,89);
//		currentPlayerReadiness = readiness;
//
//		enemyEnergySlider.maxValue = currentMonster.GetMaxEnergy();
//		enemyCurrentEnergyText.text = currentMonster.GetEnergy().ToString();
//		enemyMaxHealthText.text= currentMonster.GetMaxEnergy().ToString();
//		enemyEnergySlider.value=currentMonster.GetEnergy();
//
//        enemyHealthSlider.maxValue = currentMonster.GetMaxHealth();
//        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
//        enemyMaxHealthText.text = currentMonster.GetMaxHealth().ToString();
//        enemyHealthSlider.value = currentMonster.GetHealth();

		return currentMonster;
        //combatLogText.text = "";
    }
}
