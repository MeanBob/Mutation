using UnityEngine;
using System.Collections;

public class CombatControl : MonoBehaviour {
    UIControl ui;
    CharacterPage playerCharacter;
    Monster currentMonster;
    UnityEngine.UI.Slider enemySlider;
    UnityEngine.UI.Slider playerSlider;
    UnityEngine.UI.Slider enemyHealthSlider;
    UnityEngine.UI.Text enemyMaxHealthText;
    UnityEngine.UI.Text enemyCurrentHealthText;
    UnityEngine.UI.Text combatLogText;
    float currentPlayerReadiness = 0;
    float currentMonsterReadiness = 0;
    float maxReadiness = 100;
    float readinessMultiplier = 1;


    bool combatOn = false;

	// Use this for initialization
	void Start () {
        ui = GetComponent<UIControl>();
        playerCharacter = GameObject.Find("Avatar").GetComponent<CharacterPage>();

        enemySlider = transform.FindChild("FightPanel/EnemyScenePanel/EnemyReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
        playerSlider = transform.FindChild("FightPanel/PlayerReadinessSlider").GetComponent<UnityEngine.UI.Slider>();
        enemySlider.maxValue = maxReadiness;
        playerSlider.maxValue = maxReadiness;

        enemyCurrentHealthText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider/Handle Slide Area/EnemyHPCurrentText").GetComponent<UnityEngine.UI.Text>();
        enemyMaxHealthText = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider/EnemyHPMaxText").GetComponent<UnityEngine.UI.Text>();
        enemyHealthSlider = transform.FindChild("FightPanel/EnemyScenePanel/EnemyHealthSlider").GetComponent<UnityEngine.UI.Slider>();

        combatLogText = transform.FindChild("FightPanel/CombatLogPanel/CombatLogText/Text").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (combatOn)
        {
			ui.EnablePlayerActionPanel();
            currentPlayerReadiness += playerCharacter.GetSpeed() * readinessMultiplier * Time.deltaTime;
            currentMonsterReadiness += currentMonster.GetSpeed() * readinessMultiplier * Time.deltaTime;

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
                        break;
                    case 1:
                    case 2:
                        combatLogText.text += "claw ";
                        monsterDamage = currentMonster.RollArmDamage();
                        break;
                    case 3:
                    case 4:
                        combatLogText.text += "kick ";
                        monsterDamage = currentMonster.RollLegDamage();
                        break;
                }
                currentMonsterReadiness = 0;
                combatLogText.text += "did " + monsterDamage + " damage.\n\n";
                playerCharacter.DoDamage(monsterDamage);
            }
        }
	}


    public void InitiateCombat()
    {
        //Generate monster
        GenerateMonster();
        ui.InitiateCombat();
        combatOn = true;
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
				else 
					combatLogText.text += "You miss! \n \n";
				break;
			case 1 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackLeftArm();
				else 
					combatLogText.text += "You miss! \n \n";
				break;
			case 2 :
				if (chanceToHit > (60 - accuracy))
				PlayerAttackRightArm();
				else 
					combatLogText.text += "You miss! \n \n";
				break;
			case 3 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackLeftLeg();
				else 
					combatLogText.text += "You miss! \n \n";
				break;
			case 4 :
				if (chanceToHit > (40 - accuracy))
				PlayerAttackRightLeg();
				else 
					combatLogText.text += "You miss! \n \n";
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
		playerCharacter.DoEnergyDamage(25);


    }

    void PlayerAttackLeftArm()
    {

		combatLogText.text += "Your left punch";
        DoDamageToMonster(playerCharacter.AttackLeftArm());
		currentPlayerReadiness = 70;
		playerCharacter.DoEnergyDamage(10);
    }

    void PlayerAttackRightArm()
    {
        combatLogText.text += "Your right punch";
        DoDamageToMonster(playerCharacter.AttackRightArm());
		currentPlayerReadiness = 70;
		playerCharacter.DoEnergyDamage(10);

    }

    void PlayerAttackLeftLeg()
    {
        combatLogText.text += "Your left kick";
        DoDamageToMonster(playerCharacter.AttackLeftLeg());
		currentPlayerReadiness = 50;
		playerCharacter.DoEnergyDamage(18);
    }

    void PlayerAttackRightLeg()
    {
        combatLogText.text += "Your right kick";
        DoDamageToMonster(playerCharacter.AttackRightLeg());
		currentPlayerReadiness = 50;
		playerCharacter.DoEnergyDamage(18);
    }

    void DoDamageToMonster(int damage)
    {
        if (currentMonster.DoDamage(damage))
        {
//            combatOn = false;
            ui.EndCombat();
        }
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
		if(currentMonster.GetHealth() <= 0){
			playerCharacter.UpdateExpPoints(currentMonster.GetExpPointsGained());
			combatOn = false;
			
		}
        enemyHealthSlider.value = currentMonster.GetHealth();
        ui.DisablePlayerActionPanel();
        //currentPlayerReadiness = 0;
        combatLogText.text += " did " + damage + " damage.\n\n";

    }

    public void DEBUGKILLENEMY()
    {
        ui.EndCombat();
    }

    public void DEBUGKILLPLAYER()
    {
    }

    void GenerateMonster()
    {
        //Randomly choose a monster in the future based on player level?
		int rMonster = Random.Range(1,4);
		if(rMonster == 1)
		{
        currentMonster = ScriptableObject.CreateInstance<RabbitMonster>();
		}
		else if(rMonster == 2)
		{currentMonster = ScriptableObject.CreateInstance<WolfMonster>();}
		else {currentMonster = ScriptableObject.CreateInstance<BearMonster>();}
        currentMonster.Init();

        //If we want to introduce a "surprised" or "ambush" mechanic,
        //we can adjust the readiness values.
        currentMonsterReadiness = 0;
        currentPlayerReadiness = 0;

        enemyHealthSlider.maxValue = currentMonster.GetMaxHealth();
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
        enemyMaxHealthText.text = currentMonster.GetMaxHealth().ToString();
        enemyHealthSlider.value = currentMonster.GetHealth();

        combatLogText.text = "";
    }
}
