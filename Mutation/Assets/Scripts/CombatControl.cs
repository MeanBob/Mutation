using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CombatControl : MonoBehaviour {
   
	UIControl ui;
    CharacterPage playerCharacter;
    Monster currentMonster;
    UnityEngine.UI.Slider enemySlider;
    UnityEngine.UI.Slider playerSlider;
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

	// Use this for initialization
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
	}
	

	void Update () {

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
		else
		{
			characterButton.interactable = true;
			exploreButton.interactable = true;
			inventoryButton.interactable = true;
			mapButton.interactable = true;
			if (currentPlayerReadiness < maxReadiness)
			{
			currentPlayerReadiness += playerCharacter.GetSpeed() * readinessMultiplier * Time.deltaTime;
			}
			playerSlider.value = currentPlayerReadiness;

		}
	}


    public void InitiateCombat()
    {
        //Generate monster
        GenerateMonster();
		combatOn = true;
		ui.InitiateCombat();
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
//            combatOn = false;
            ui.EndCombat();
        }
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
		if(currentMonster.GetHealth() <= 0)
		{
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
			currentMonster = ScriptableObject.CreateInstance<BearMonster>();
			int rStart	= Random.Range(1,4);
			if (rStart == 1){
				combatLogText.text = "As you are looking down at where you are walks a small, white rabbit zips across your path in quick hops. Its bushy tail is adorable, you think.\n\n";
				currentMonsterReadiness = 20;
			}
			else if (rStart ==2)
			{
				combatLogText.text = "While you are resting and catching your breath a small, brown bunny pops its head out of a hole. You notice its pink, twitching nose and relentless, bugging eyes. How cute!\n\n";
				currentMonsterReadiness = 60;
			}
			else if (rStart == 3)
			{
				combatLogText.text = "Two white ears protrude from the landscapes ahead. You can’t be certain, but if you were betting, you'd be putting your money on rabbits right about now.\n\n";
				currentMonsterReadiness = 2;
			}
		}

		else if(rMonster == 2)
		{
			currentMonster = ScriptableObject.CreateInstance<BearMonster>();
			int rStart	= Random.Range(1,4);
			if (rStart == 1){
				combatLogText.text = "You first see the patchy grey and brown fur of an animal in your path. When its eyes lite upon you you notice pointed, dripping fangs. The wolf growls and you sense the beast must be hungry. \n\n";
				currentMonsterReadiness = 20;
			}
			else if (rStart ==2)
			{
				combatLogText.text = "You hear the sharp howl of a hungry wolf not far away. Before you have time to retreat, a wolf leaps onto your path and stares you straight in the eyes.\n\n";
				currentMonsterReadiness = 60;
			}
			else if (rStart == 3)
			{
				combatLogText.text = "You catch two glowing, yellow gems in your site. They are quickly followed by the lurking, open-mouthed face of a true beast. This wolf’s fur is matted and patchy. You must have stumbled upon a true wolf warrior!\n\n";
				currentMonsterReadiness = 2;
			}
		}
		else {
			currentMonster = ScriptableObject.CreateInstance<BearMonster>();
			int rStart	= Random.Range(1,4);
			if (rStart == 1){
				combatLogText.text = "A sudden blast of hot air and the disgusting stench of foul breath alert your senses. Before you know it, a hulking bear is standing on its hind legs, growling at you. \n\n";
				currentMonsterReadiness = 20;
			}
			else if (rStart ==2)
			{
				combatLogText.text = "You make out the haunches of a large beast up ahead. Suddenly the beast turns and holds you in its gaze. Its a bear, and as it rears around it stands up on its back legs.\n\n";
				currentMonsterReadiness = 60;
			}
			else if (rStart == 3)
			{
				combatLogText.text = "A bear stands in your path, its long sharp claws and glistening fangs make your stomach feel uneasy. When it roars at you, a blast of hot steam catches the afternoon light just so.\n\n";
				currentMonsterReadiness = 2;
			}
		}
        currentMonster.Init();

        //If we want to introduce a "surprised" or "ambush" mechanic,
        //we can adjust the readiness values.
        
        
		int rEeadiness = Random.Range (2,89);
		currentPlayerReadiness = rEeadiness;

        enemyHealthSlider.maxValue = currentMonster.GetMaxHealth();
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
        enemyMaxHealthText.text = currentMonster.GetMaxHealth().ToString();
        enemyHealthSlider.value = currentMonster.GetHealth();

        //combatLogText.text = "";
    }
}
