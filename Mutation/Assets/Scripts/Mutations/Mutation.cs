using UnityEngine;
using System.Collections;

public class Mutation : ScriptableObject {
    protected string mutationName;
    protected int headMinDamage;
    protected int headMaxDamage;
    protected int armMinDamage;
    protected int armMaxDamage;
    protected int legMinDamage;
    protected int legMaxDamage;

	// Use this for initialization
    public virtual void Init()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
        return baseDamage;
    }
}
