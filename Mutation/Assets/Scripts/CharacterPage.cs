using UnityEngine;
using System.Collections;

public class CharacterPage : MonoBehaviour {

	//stats
    int strength;
	int tempStrength;
	int oldStrength;
	int currentHP;
	int maxHP;

	int speed;
	int tempSpeed;
    int oldSpeed;

	int accuracy;
	int tempaccuracy;
	int oldaccuracy;	

	int intelligence;
    int tempIntelligence;
    int oldIntelligence;

	int energy;
	int tempEnergy;
	int oldEnergy;
    

    
    Mutation head;
    Mutation body;
    Mutation leftArm;
    Mutation rightArm;
    Mutation leftLeg;
    Mutation rightLeg;

    UnityEngine.UI.Text currentHPText;
    UnityEngine.UI.Text maxHPText;
    UnityEngine.UI.Slider healthSlider;

    UnityEngine.UI.Text strengthText;
    UnityEngine.UI.Text speedText;
    UnityEngine.UI.Text intelligenceText;
    UnityEngine.UI.Text headText;
    UnityEngine.UI.Text bodyText;
    UnityEngine.UI.Text leftArmText;
    UnityEngine.UI.Text rightArmText;
    UnityEngine.UI.Text leftLegText;
    UnityEngine.UI.Text rightLegText;
    UnityEngine.UI.Text allocatablePointsText;

    int currentNumberOfAllocatablePoints = 0;
    int numberOfPointsPerLevel = 10;

	// Use this for initialization
	void Start () {
        //We'll want to have this customizeable, once character creation is in
        strength = 10;
        speed = 10;
        intelligence = 10;
        maxHP = 10 * strength;
        tempStrength = strength;
        tempSpeed = speed;
        tempIntelligence = intelligence;
        oldStrength = 5;
        oldSpeed = 5;
        oldIntelligence = 5;
        currentHP = maxHP;
        currentNumberOfAllocatablePoints = numberOfPointsPerLevel;

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
        UpdateHealthMeter();

        strengthText = GameObject.Find("StrengthValueText").GetComponent<UnityEngine.UI.Text>();
        speedText = GameObject.Find("SpeedValueText").GetComponent<UnityEngine.UI.Text>();
        intelligenceText = GameObject.Find("IntelligenceValueText").GetComponent<UnityEngine.UI.Text>();
        headText = GameObject.Find("HeadValueText").GetComponent<UnityEngine.UI.Text>();
        bodyText = GameObject.Find("BodyValueText").GetComponent<UnityEngine.UI.Text>();
        leftArmText = GameObject.Find("LeftArmValueText").GetComponent<UnityEngine.UI.Text>();
        rightArmText = GameObject.Find("RightArmValueText").GetComponent<UnityEngine.UI.Text>();
        leftLegText = GameObject.Find("LeftLegValueText").GetComponent<UnityEngine.UI.Text>();
        rightLegText = GameObject.Find("RightLegValueText").GetComponent<UnityEngine.UI.Text>();
        allocatablePointsText = GameObject.Find("AllocatablePointsValueText").GetComponent<UnityEngine.UI.Text>();

        strengthText.text = strength.ToString();
        speedText.text = speed.ToString();
        intelligenceText.text = intelligence.ToString();
        headText.text = head.GetName();
        bodyText.text = body.GetName();
        leftArmText.text = leftArm.GetName();
        rightArmText.text = rightArm.GetName();
        leftLegText.text = leftLeg.GetName();
        rightLegText.text = rightLeg.GetName();
        allocatablePointsText.text = currentNumberOfAllocatablePoints.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateHealthMeter()
    {
        maxHPText.text = maxHP.ToString();
        healthSlider.maxValue = maxHP;
        currentHPText.text = currentHP.ToString();
        healthSlider.value = currentHP;
    }

    public void DoDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Debug.Log("You died.");
            //trigger death
        }
        UpdateHealthMeter();
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

    public void AddStrength()
    {
        if (currentNumberOfAllocatablePoints > 0)
        {
            tempStrength++;
            currentNumberOfAllocatablePoints--;
        }
        UpdateStats();
    }

    public void RemoveStrength()
    {
        if (tempStrength > oldStrength)
        {
            tempStrength--;
            currentNumberOfAllocatablePoints++;
        }
        UpdateStats();
    }

    public void AddSpeed()
    {
        if (currentNumberOfAllocatablePoints > 0)
        {
            tempSpeed++;
            currentNumberOfAllocatablePoints--;
        }
        UpdateStats();
    }

    public void RemoveSpeed()
    {
        if (tempSpeed > oldSpeed)
        {
            tempSpeed--;
            currentNumberOfAllocatablePoints++;
        }
        UpdateStats();
    }

    public void AddIntelligence()
    {
        if (currentNumberOfAllocatablePoints > 0)
        {
            tempIntelligence++;
            currentNumberOfAllocatablePoints--;
        }
        UpdateStats();
    }

    public void RemoveIntelligence()
    {
        if (tempIntelligence > oldIntelligence)
        {
            tempIntelligence--;
            currentNumberOfAllocatablePoints++;
        }
        UpdateStats();
    }

    public void UpdateStats()
    {
        strengthText.text = tempStrength.ToString();
        speedText.text = tempSpeed.ToString();
        intelligenceText.text = tempIntelligence.ToString();
        allocatablePointsText.text = currentNumberOfAllocatablePoints.ToString();
    }

    public void CommitPoints()
    {
        strength = tempStrength;
        speed = tempSpeed;
        intelligence = tempIntelligence;
        oldStrength = strength;
        oldSpeed = speed;
        oldIntelligence = intelligence;
        float healthRatio = (float)currentHP / maxHP;
        maxHP = strength * 10;
        currentHP = Mathf.RoundToInt(maxHP * healthRatio);
        UpdateStats();
        UpdateHealthMeter();
    }

    public void ResetPoints()
    {
        int strengthDif = tempStrength - strength;
        int speedDif = tempSpeed - speed;
        int intelligenceDif = tempIntelligence - intelligence;

        currentNumberOfAllocatablePoints += strengthDif + speedDif + intelligenceDif;
        tempStrength = strength;
        tempSpeed = speed;
        tempIntelligence = intelligence;
        UpdateStats();
    }
}
