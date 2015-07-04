using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	protected int strength;
	protected int speed;
	protected int intelligence;
	protected int accuracy;
	protected int energy;
	protected string itemName;
	protected int hitPointsHealed;
	protected int energyHealed;
	protected int count;
	
//	public virtual void Init()
//	{
//		//hitPointsHealed = 2 * intelligence;
//	}
	void Start()
	{
		Debug.Log("Start for Item called");
	}

	public string getName()
	{
		return itemName;
	}

	public int getCount()
	{
		return count;
	}

	public void setCount(int value)
	{
		count = count + value;
		if(count <= 0)
			count = 0;
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
