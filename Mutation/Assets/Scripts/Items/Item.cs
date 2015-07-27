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
	public int numberOfItemTypes;
	public int tag;
	public Mutation[] mutationList;
	protected int numberOfMutations;
	protected string itemImage;
	
//	public virtual void Init()
//	{
//		//hitPointsHealed = 2 * intelligence;
//	}
	void Start()
	{
		numberOfItemTypes = 17;
		Debug.Log("Start for Item called");
	}

	public string getName()
	{
		return itemName;
	}



//	public void setItemImage(Sprite Item)
//	{		
//		itemImage = Item; 		
//	}
//
//	public Sprite GetItemImage()
//	{
//		return itemImage;
//	}



	public int getNumberOfMutations()
	{
		return numberOfMutations;
	}

	public int getCount()
	{
		return count;
	}

	public void setCount(int value)
	{
//		count = count + value;
//		if(count <= 0)
//			count = 0;
		count = value;
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
