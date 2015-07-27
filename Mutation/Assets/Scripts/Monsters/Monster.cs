using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Monster : ScriptableObject {

	protected Sprite monsterImage;


	protected int monsterMeatID;
	//used in combat
	protected string monsterName;

	//used in victory
	protected int expPointsGained;
	protected Item[] droppedItemsList;
	protected Item itemReleased;
	protected string victoryText;
	protected Mutation[] mutationList;
	//used in initiation
	protected string monsterDescription;
	protected string hideDescription;

    //monsters combat stats
    protected int speed;
    protected int intelligence;
   
	protected int energy;
	protected int currentEnergy;
	protected int maxEnergy;

	protected int strength;
	protected int currentHP;
    protected int maxHP;

    protected int headMinDamage;
    protected int headMaxDamage;
    protected int armMinDamage;
    protected int armMaxDamage;
    protected int legMinDamage;
    protected int legMaxDamage;
    
	protected int bonusDamage;



	public virtual void Start()
	{
	}

	public virtual void Init()
    {
        currentHP = 10 * strength;
        maxHP = currentHP;
		//monsterImage = Enemy;
		currentEnergy = 10 * energy;
		maxEnergy = currentEnergy;
	}

	public Sprite GetMonsterImage()
	{
		return monsterImage;
	}

	public string GetHideDescription()
	{
		return hideDescription;
	}

	public void setMonsterImage(Sprite Enemy)
	{

		monsterImage = Enemy; 

	}

	public string GetDescription()
	{
		return monsterDescription;
	}

	public int GetMonsterMeat()
	{
		return monsterMeatID;
	}

    public string GetName()
    {
        return monsterName;
    }

	
	public int GetExpPointsGained()
	{
		return expPointsGained;
	}

	public string GetVictoryText()
	{
		return victoryText;
	}



    public int GetMaxHealth()
    {
        return maxHP;
    }
	public int GetHealth()
    {
        return currentHP;
    }



	public int GetMaxEnergy()
	{
		return maxEnergy;
	}
	public int GetEnergy()
	{
		return currentEnergy;
	}

	public bool DoEnergyDamage(int energyDamage)
	{
		currentEnergy -= energyDamage;
		if (currentEnergy <= 0)
		{
			return true;
		}
		return false;
	}

	public void HealEnergyDamage(int healEnergy)
	{
		currentEnergy += healEnergy;
		if (currentEnergy >= maxEnergy)
		{
			currentEnergy = maxEnergy;
		}
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
