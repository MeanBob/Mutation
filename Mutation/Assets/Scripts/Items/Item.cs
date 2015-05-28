using UnityEngine;
using System.Collections;

public class Item : ScriptableObject {

	protected int strength;
	protected int speed;
	protected int intelligence;
	protected int accuracy;
	protected int energy;
	protected string itemName;
	protected int hitPointsHealed;
	protected int energyHealed;

	
	public virtual void Init()
	{
		//hitPointsHealed = 2 * intelligence;
	}

	public string getName()
	{
		return itemName;
	}
	public int getStrength()
	{
		return strength;
	}
	public int getSpeed()
	{
		return speed;
	}
	public int getIntelligence()
	{
		return intelligence;
	}
	public int getAccuracy()
	{
		return accuracy;
	}
	public int getEnergy()
	{
		return energy;
	}
	public int getEnergyHealed()
	{
		return energyHealed;
	}
	public int getHitPointsHealed()
	{
		return hitPointsHealed;
	}
}
