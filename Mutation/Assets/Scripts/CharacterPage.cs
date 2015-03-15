using UnityEngine;
using System.Collections;

public class CharacterPage : MonoBehaviour {
    int strength;
    int speed;
    int intelligence;
    int maxHP;
    int currentHP;
    
    Mutation head;
    Mutation body;
    Mutation leftArm;
    Mutation rightArm;
    Mutation leftLeg;
    Mutation rightLeg;

	// Use this for initialization
	void Start () {
        //We'll want to have this customizeable, once character creation is in
        strength = 10;
        speed = 10;
        intelligence = 10;
        maxHP = 10 * strength;
        currentHP = maxHP;

        head = ScriptableObject.CreateInstance<NoMutation>();
        body = ScriptableObject.CreateInstance<NoMutation>();
        leftArm = ScriptableObject.CreateInstance<NoMutation>();
        rightArm = ScriptableObject.CreateInstance<NoMutation>();
        leftLeg = ScriptableObject.CreateInstance<NoMutation>();
        rightLeg = ScriptableObject.CreateInstance<NoMutation>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("You died.");
            //trigger death
        }
    }

    public void HealDamage(int heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public int AttackHead()
    {
        return head.RollHeadDamage();
    }

    public int AttackLeftArm()
    {
        return leftArm.RollArmDamage();
    }

    public int AttackRightArm()
    {
        return rightArm.RollArmDamage();
    }

    public int AttackLeftLeg()
    {
        return leftLeg.RollLegDamage();
    }

    public int AttackRightLeg()
    {
        return rightLeg.RollLegDamage();
    }

    public int GetSpeed()
    {
        return speed;
    }
}
