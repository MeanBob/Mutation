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

    UnityEngine.UI.Text currentHPText;
    UnityEngine.UI.Text maxHPText;
    UnityEngine.UI.Slider healthSlider;

	// Use this for initialization
	void Start () {
        //We'll want to have this customizeable, once character creation is in
        strength = 10;
        speed = 10;
        intelligence = 10;
        maxHP = 10 * strength;
        currentHP = maxHP;

        head = ScriptableObject.CreateInstance<NoMutation>();
        head.Init();
        body = ScriptableObject.CreateInstance<NoMutation>();
        body.Init();
        leftArm = ScriptableObject.CreateInstance<NoMutation>();
        leftArm.Init();
        rightArm = ScriptableObject.CreateInstance<NoMutation>();
        rightArm.Init();
        leftLeg = ScriptableObject.CreateInstance<NoMutation>();
        leftLeg.Init();
        rightLeg = ScriptableObject.CreateInstance<NoMutation>();
        rightLeg.Init();

        currentHPText = GameObject.Find("HPCurrentText").GetComponent<UnityEngine.UI.Text>();
        maxHPText = GameObject.Find("HPMaxText").GetComponent<UnityEngine.UI.Text>();
        currentHPText.text = currentHP.ToString();
        maxHPText.text = maxHP.ToString();
        healthSlider = GameObject.Find("PlayerHealthSlider").GetComponent<UnityEngine.UI.Slider>();
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
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
        currentHPText.text = currentHP.ToString();
        healthSlider.value = currentHP;
    }

    public void HealDamage(int heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        currentHPText.text = currentHP.ToString();
    }

    public int AttackHead()
    {
        return head.RollHeadDamage() + strength;
    }

    public int AttackLeftArm()
    {
        return leftArm.RollArmDamage() + strength;
    }

    public int AttackRightArm()
    {
        return rightArm.RollArmDamage() + strength;
    }

    public int AttackLeftLeg()
    {
        return leftLeg.RollLegDamage() + strength;
    }

    public int AttackRightLeg()
    {
        return rightLeg.RollLegDamage() + strength;
    }

    public int GetSpeed()
    {
        return speed;
    }
}
