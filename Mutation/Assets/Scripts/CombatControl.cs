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
            currentPlayerReadiness += playerCharacter.GetSpeed() * readinessMultiplier * Time.deltaTime;
            currentMonsterReadiness += currentMonster.GetSpeed() * readinessMultiplier * Time.deltaTime;

            playerSlider.value = currentPlayerReadiness;
            enemySlider.value = currentMonsterReadiness;

            if (currentPlayerReadiness >= maxReadiness)
            {
                //Enable screen
                ui.EnablePlayerActionPanel();
            }

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

    public void PlayerAttackHead()
    {
        combatLogText.text += "Your headbutt";
        DoDamageToMonster(playerCharacter.AttackHead());
    }

    public void PlayerAttackLeftArm()
    {
        combatLogText.text += "Your left punch";
        DoDamageToMonster(playerCharacter.AttackLeftArm());
    }

    public void PlayerAttackRightArm()
    {
        combatLogText.text += "Your right punch";
        DoDamageToMonster(playerCharacter.AttackRightArm());
    }

    public void PlayerAttackLeftLeg()
    {
        combatLogText.text += "Your left kick";
        DoDamageToMonster(playerCharacter.AttackLeftLeg());
    }

    public void PlayerAttackRightLeg()
    {
        combatLogText.text += "Your right kick";
        DoDamageToMonster(playerCharacter.AttackRightLeg());
    }

    void DoDamageToMonster(int damage)
    {
        if (currentMonster.DoDamage(damage))
        {
            combatOn = false;
            ui.EndCombat();
        }
        enemyCurrentHealthText.text = currentMonster.GetHealth().ToString();
        enemyHealthSlider.value = currentMonster.GetHealth();
        ui.DisablePlayerActionPanel();
        currentPlayerReadiness = 0;
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
        currentMonster = ScriptableObject.CreateInstance<RabbitMonster>();
		//currentMonster = ScriptableObject.CreateInstance<WolfMonster>();
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
