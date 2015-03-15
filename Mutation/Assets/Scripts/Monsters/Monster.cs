using UnityEngine;
using System.Collections;

public class Monster : ScriptableObject {
    protected string monsterName;
    protected int strength;
    protected int speed;
    protected int intelligence;
    protected int currentHP;
    protected int maxHP;

    protected int headMinDamage;
    protected int headMaxDamage;
    protected int armMinDamage;
    protected int armMaxDamage;
    protected int legMinDamage;
    protected int legMaxDamage;
    protected int bonusDamage;

	// Use this for initialization
    public virtual void Init()
    {
        currentHP = 10 * strength;
        maxHP = currentHP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool DoDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            return true;
        }
        return false;
    }

    public void HealDamage(int heal)
    {
        currentHP += heal;
        if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }
    }

    public int RollHeadDamage()
    {
        return RollDamage(headMinDamage, headMaxDamage);
    }

    public int RollArmDamage()
    {
        return RollDamage(armMinDamage, armMaxDamage);
    }

    public int RollLegDamage()
    {
        return RollDamage(legMinDamage, legMaxDamage);
    }

    int RollDamage(int minDamage, int maxDamage)
    {
        int baseDamage = Random.Range(minDamage, maxDamage);
        baseDamage += bonusDamage;
        return baseDamage;
    }

    public int GetSpeed()
    {
        return speed;
    }
}
