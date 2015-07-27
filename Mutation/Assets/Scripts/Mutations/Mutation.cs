using UnityEngine;
using System.Collections;

public class Mutation : ScriptableObject {
    protected string mutationName;
    protected int accuracy;
    protected int intelligence;
    protected int strength;
    protected int speed;
    protected int energy;
	protected Sprite mutationImage;
	protected int mutationType;

	
	/*
	 * mutation type
	 * 	//Each mutation should have a type to represent its body part

		 * 0 - Ears
		 * 1 - Eyes
		 * 2 - Nose
		 * 3 - Mouth
		 * 4 - Crown
		 * 5 - Chest
		 * 6 - Tail
		 * 7 - Hand
		 * 8 - Foot
		 * 9 - Leg
		 */

	// Use this for initialization
    public virtual void Init()
    {
	
	}


	public Sprite GetMutationImage()
	{
		return mutationImage;
	}

	public void setMutationImage(Sprite MutationImage)
	{
		
		mutationImage = MutationImage; 
		
	}
	
    public string GetName()
    {
        return mutationName;
    }


	public int GetAccuracy()
	{
		return accuracy;
	}
		public int GetEnergy()
	{
		return energy;
	}
	public int GetStrength()
	{
		return strength;
	}
	public int GetIntelligence()
	{
		return intelligence;
	}
	public int GetSpeed()
	{
		return speed;
	}


	public int getMutationType()
	{
		return mutationType;
	}
}
