using UnityEngine;
using System.Collections;

public class CombatControl : MonoBehaviour {
    UIControl ui;
    CharacterPage playerCharacter;
    Monster currentMonster;
    UnityEngine.UI.Slider enemySlider;
    UnityEngine.UI.Slider playerSlider;
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
                switch (choice)
                {
                    case 0:
                        monsterDamage = currentMonster.RollHeadDamage();
                        break;
                    case 1:
                    case 2:
                        monsterDamage = currentMonster.RollArmDamage();
                        break;
                    case 3:
                    case 4:
                        monsterDamage = currentMonster.RollLegDamage();
                        break;
                }
                currentMonsterReadiness = 0;
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
        DoDamageToMonster(playerCharacter.AttackHead());
    }

    public void PlayerAttackLeftArm()
    {
        DoDamageToMonster(playerCharacter.AttackLeftArm());
    }

    public void PlayerAttackRightArm()
    {
        DoDamageToMonster(playerCharacter.AttackRightArm());
    }

    public void PlayerAttackLeftLeg()
    {
        DoDamageToMonster(playerCharacter.AttackLeftLeg());
    }

    public void PlayerAttackRightLeg()
    {
        DoDamageToMonster(playerCharacter.AttackRightLeg());
    }

    void DoDamageToMonster(int damage)
    {
        if (currentMonster.DoDamage(damage))
        {
            combatOn = false;
            ui.EndCombat();
        }
        ui.DisablePlayerActionPanel();
        currentPlayerReadiness = 0;
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
        currentMonster.Init();

        //If we want to introduce a "surprised" or "ambush" mechanic,
        //we can adjust the readiness values.
        currentMonsterReadiness = 0;
        currentPlayerReadiness = 0;
    }
}
