using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPage : MonoBehaviour {
	
	
	UIControl ui;
	GameObject levelPanel;
	Button stealLifeButton;
	Button stunButton;
	GameObject powerUpPanel;
	GameObject winPopUpPanel;
	GameObject StubButtonObject;
	GameObject LifeStealButtonObject;
	public bool hasStun;
	public bool hasStealLife;

	public GameObject Death;
	//stats
	int strength;
	int tempStrength;
	int oldStrength;
	int currentHP; 
	int maxHP;
	
	int energy;
	int tempEnergy;
	int oldEnergy;  
	int maxEnergy;
	int currentEnergy;

	int money;
	UnityEngine.UI.Text currentMoney;
	
	int currentExpPoints;
	public int currentLevel;
	
	int speed;
	int tempSpeed;
	int oldSpeed;
	
	int accuracy;
	int tempAccuracy;
	int oldAccuracy;	
	
	int intelligence;
	int tempIntelligence;
	int oldIntelligence;
	
	//	int increment = 0;
	//	int currExpPoints;
	//	int currtLevel ;
	int nextLevelExpPoints;


	public int skillTrainingLevel1;
	public int skillTrainingLevel2;
	public int skillTrainingLevel3;
	public int skillTrainingLevel4;
	public int skillTrainingLevel5;
	
	public bool canTrack;
	public bool canForage;
	public bool canRepair;
	
	public Mutation ears;
	public Mutation eyes;
	public Mutation nose;
	public Mutation mouth;
	public Mutation crown;
	public Mutation chest;
	public Mutation tail;
	public Mutation hands;
	public Mutation feet;
	public Mutation legs;
	
	
	public UnityEngine.UI.Image earsImage;
	public UnityEngine.UI.Image eyesImage;
	public UnityEngine.UI.Image noseImage;
	public UnityEngine.UI.Image mouthImage;
	public UnityEngine.UI.Image crownImage;
	public UnityEngine.UI.Image chestImage;
	public UnityEngine.UI.Image tailImage;
	public UnityEngine.UI.Image handsImage;
	public UnityEngine.UI.Image feetImage;
	public UnityEngine.UI.Image legsImage;
	
	public Mutation[] currentMutationList;

	public UnityEngine.UI.Text skillsList;

	UnityEngine.UI.Text currentHPText; 
	UnityEngine.UI.Text maxHPText;
	UnityEngine.UI.Slider healthSlider;
	
	UnityEngine.UI.Text currentEnergyText;
	UnityEngine.UI.Text maxEnergyText;
	UnityEngine.UI.Slider energySlider;
	UnityEngine.UI.Text nextLevelExpPointsText;
	
	UnityEngine.UI.Text expText;
	UnityEngine.UI.Text levelText;
	
	UnityEngine.UI.Text energyText;
	UnityEngine.UI.Text strengthText;
	UnityEngine.UI.Text speedText;
	UnityEngine.UI.Text intelligenceText;
	UnityEngine.UI.Text accuracyText;
	UnityEngine.UI.Text allocatablePointsText;
	

	
	public UnityEngine.UI.Text earsText;
	public UnityEngine.UI.Text eyesText;
	public UnityEngine.UI.Text noseText;
	public UnityEngine.UI.Text mouthText;
	public UnityEngine.UI.Text crownText;
	public UnityEngine.UI.Text chestText;
	public UnityEngine.UI.Text tailText;
	public UnityEngine.UI.Text handsText;
	public UnityEngine.UI.Text feetText;
	public UnityEngine.UI.Text legsText;
	
	
	int currentNumberOfAllocatablePoints = 5;
	int numberOfPointsPerLevel = 5;
	
	Item tempItem;

	public bool YouHaveDied ;

	public bool leveledUp;
	bool IncreasedLevel = false;
	int previous= 0;

	CombatControl combatControl;

	
	public Button learnForageButton;
	public Button learnTrapButton;
	public Button learnRepairButton;

	void Start ()
	{

		hasStun = false;
		hasStealLife = false;

		nextLevelExpPoints = 64;

		stealLifeButton = transform.Find ("LevelUp/PowerUpPanel/StealLife").GetComponent<Button> ();
		stunButton = transform.Find ("LevelUp/PowerUpPanel/StealLife").GetComponent<Button> ();
		powerUpPanel = transform.Find ("LevelUp/PowerUpPanel").gameObject;
		StubButtonObject = transform.Find ("LevelUp/PowerUpPanel/Stun").gameObject;
		LifeStealButtonObject = transform.Find ("LevelUp/PowerUpPanel/StealLife").gameObject;
		winPopUpPanel = transform.Find ("LevelUp/WinPopup").gameObject;
		combatControl = GetComponent<CombatControl>();
		//transform.FindChild("FightPanel").gameObject;

		leveledUp = false;
			//We'll want to have this customizeable, once character creation is in
		energy = 6;
		maxEnergy = 10 * energy;
		tempEnergy = energy;
		oldEnergy = 1;
		currentEnergy = maxEnergy;

		money = 3;
		currentMoney = GameObject.Find("CurrentMoney").GetComponent<UnityEngine.UI.Text>();
		//currentMoney.text = money.ToString();

		skillsList = GameObject.Find ("CharacterSheetPanel/Skills/Text").GetComponent<UnityEngine.UI.Text> ();


		strength = 7;
		maxHP = 10 * strength;
		tempStrength = strength;
		oldStrength = 1;
		currentHP = maxHP;
		
		accuracy = 3;
		tempAccuracy = accuracy;
		oldAccuracy = 1;
		speed = 25;
		intelligence = 10;
		
		tempSpeed = speed;
		tempIntelligence = intelligence;
		
		oldSpeed = 1;
		oldIntelligence = 1;
		
		currentNumberOfAllocatablePoints = numberOfPointsPerLevel;
		currentExpPoints = 9;
		currentLevel = 1;
		
		initializeMutation ();
		
		eyesText = GameObject.Find("EyesValueText").GetComponent<UnityEngine.UI.Text>();
		earsText = GameObject.Find("EarsValueText").GetComponent<UnityEngine.UI.Text>();
		noseText = GameObject.Find("NoseValueText").GetComponent<UnityEngine.UI.Text>();
		mouthText = GameObject.Find("MouthValueText").GetComponent<UnityEngine.UI.Text>();
		crownText = GameObject.Find("CrownValueText").GetComponent<UnityEngine.UI.Text>();
		tailText = GameObject.Find("TailValueText").GetComponent<UnityEngine.UI.Text>();
		chestText = GameObject.Find("ChestValueText").GetComponent<UnityEngine.UI.Text>();
		handsText = GameObject.Find("HandsValueText").GetComponent<UnityEngine.UI.Text>();
		feetText = GameObject.Find("FeetValueText").GetComponent<UnityEngine.UI.Text>();
		legsText = GameObject.Find("LegsValueText").GetComponent<UnityEngine.UI.Text>();
		
		eyesText.text = eyes.GetName();
		earsText.text = ears.GetName();
		noseText.text = nose.GetName();
		mouthText.text = mouth.GetName();
		crownText.text = crown.GetName();
		chestText.text = chest.GetName();
		tailText.text = tail.GetName();
		handsText.text = hands.GetName();
		feetText.text = feet.GetName();
		legsText.text = legs.GetName();
		
		currentHPText = GameObject.Find("HPCurrentText").GetComponent<UnityEngine.UI.Text>();
		maxHPText = GameObject.Find("HPMaxText").GetComponent<UnityEngine.UI.Text>();
		currentHPText.text = currentHP.ToString();
		maxHPText.text = maxHP.ToString();
		
		healthSlider = GameObject.Find("PlayerHealthSlider").GetComponent<UnityEngine.UI.Slider>();
		energySlider = GameObject.Find("PlayerEnergySlider").GetComponent<UnityEngine.UI.Slider>();
		
		currentEnergyText = GameObject.Find("EnergyCurrentText").GetComponent<UnityEngine.UI.Text>();
		maxEnergyText = GameObject.Find("EnergyMaxText").GetComponent<UnityEngine.UI.Text>();
		currentEnergyText.text = currentEnergy.ToString();
		maxEnergyText.text = maxEnergy.ToString();
		
		UpdateHealthMeter();
		UpdateEnergyMeter();
		
		levelText = GameObject.Find("LevelValueText").GetComponent<UnityEngine.UI.Text>();
		expText = GameObject.Find("ExpValueText").GetComponent<UnityEngine.UI.Text>();
		
		nextLevelExpPointsText = GameObject.Find("ExpToLevelValueText").GetComponent<UnityEngine.UI.Text>();
		
		accuracyText = GameObject.Find("AccuracyValueText").GetComponent<UnityEngine.UI.Text>();
		strengthText = GameObject.Find("StrengthValueText").GetComponent<UnityEngine.UI.Text>();
		energyText = GameObject.Find("EnergyValueText").GetComponent<UnityEngine.UI.Text>();
		speedText = GameObject.Find("SpeedValueText").GetComponent<UnityEngine.UI.Text>();
		intelligenceText = GameObject.Find("IntelligenceValueText").GetComponent<UnityEngine.UI.Text>();
		
		allocatablePointsText = GameObject.Find("AllocatablePointsValueText").GetComponent<UnityEngine.UI.Text>();
		
		nextLevelExpPointsText.text = nextLevelExpPoints.ToString();
		levelText.text = currentLevel.ToString();
		expText.text = currentExpPoints.ToString();
		strengthText.text = strength.ToString();
		energyText.text = energy.ToString();
		accuracyText.text = accuracy.ToString();
		//currentEnergyText.text = energy.ToString();
		
		speedText.text = speed.ToString();
		intelligenceText.text = intelligence.ToString();
		allocatablePointsText.text = currentNumberOfAllocatablePoints.ToString();

		UpdateMoney (money);
		UpdateExpPoints (9);
		LevelUp ();
		//previous = currentLevel;


		combatControl.shake.ResetTrigger ("HasLeveledUp");
		
	}
	
	void initializeMutation()
	{/*
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
		currentMutationList = new Mutation[]{ScriptableObject.CreateInstance<HumanEars>(),ScriptableObject.CreateInstance<HumanEyes>(),ScriptableObject.CreateInstance<HumanNose>()
			,ScriptableObject.CreateInstance<HumanMouth>(),ScriptableObject.CreateInstance<HumanCrown>(),ScriptableObject.CreateInstance<HumanChest>(),
			ScriptableObject.CreateInstance<HumanTail>(),ScriptableObject.CreateInstance<HumanHands>(),ScriptableObject.CreateInstance<HumanFeet>()
			,ScriptableObject.CreateInstance<HumanLegs>()};
		
		
		earsImage = transform.FindChild("AvatarPanel/Ears").GetComponent<UnityEngine.UI.Image>();
		eyesImage = transform.FindChild("AvatarPanel/Eyes").GetComponent<UnityEngine.UI.Image>();
		noseImage = transform.FindChild("AvatarPanel/Nose").GetComponent<UnityEngine.UI.Image>();
		mouthImage = transform.FindChild("AvatarPanel/Mouth").GetComponent<UnityEngine.UI.Image>();
		crownImage = transform.FindChild("AvatarPanel/Crown").GetComponent<UnityEngine.UI.Image>();
		chestImage = transform.FindChild("AvatarPanel/Chest").GetComponent<UnityEngine.UI.Image>();
		tailImage = transform.FindChild("AvatarPanel/Tail").GetComponent<UnityEngine.UI.Image>();
		handsImage = transform.FindChild("AvatarPanel/Hands").GetComponent<UnityEngine.UI.Image>();
		feetImage = transform.FindChild("AvatarPanel/Feet").GetComponent<UnityEngine.UI.Image>();
		legsImage = transform.FindChild("AvatarPanel/Legs").GetComponent<UnityEngine.UI.Image>();
		ears = currentMutationList[0];
		ears.Init();
		
		eyes = currentMutationList[1];
		eyes.Init();
		
		nose =  currentMutationList[2];
		nose.Init();
		
		mouth =  currentMutationList[3];
		mouth.Init();
		
		crown =  currentMutationList[4];
		crown.Init();
		
		chest =  currentMutationList[5];
		chest.Init();
		
		tail =  currentMutationList[6];
		tail.Init();
		
		hands =  currentMutationList[7];
		hands.Init();
		
		feet =  currentMutationList[8];
		feet.Init();
		
		legs =  currentMutationList[9];
		legs.Init();
	}
	


	public void learnForage()
	{
		canForage = true;
		combatControl.shake.Play ("FadeFromWhite");
		combatControl.forageButton.gameObject.SetActive (true);
		learnForageButton.gameObject.SetActive(false);
		powerUpPanel.SetActive (false);
	}


	public void LearnTrap()
	{
		canTrack = true;

		combatControl.shake.Play ("FadeFromWhite");
		combatControl.trapButton.gameObject.SetActive (true);
		learnTrapButton.gameObject.SetActive(false);
		powerUpPanel.SetActive (false);
	}

	public void LearnRepair()
	{
		canRepair = true;
		combatControl.shake.Play ("FadeFromWhite");
		combatControl.repairButton.gameObject.SetActive (true);
		learnRepairButton.gameObject.SetActive(false);
		powerUpPanel.SetActive (false);
	}
	public void LearnLifeSteal()
	{
		hasStealLife = true;
		combatControl.shake.Play ("FadeFromWhite");
		stealLifeButton.gameObject.SetActive(false);
		powerUpPanel.SetActive (false);
	}
	public void LearnStun()
	{
		hasStun = true;
		combatControl.shake.Play ("FadeFromWhite");
		stunButton.gameObject.SetActive(false);
		powerUpPanel.SetActive (false);
	}


	//HEALER BUTTON  ADD ANIMATION
	public void PayForHealing()
	{
		if (getPlayerMoney() > 1) {
		
			currentEnergy += 20;
			HealDamage(50);
			RemoveMoney(1);

			UpdateHealthMeter();
			UpdateEnergyMeter();
		}
	}


	void CheckForAbilitiesWhenLeveledUp()
	{
		if (hasStealLife)
		{LifeStealButtonObject.SetActive(false);}
		else if (hasStun){
			StubButtonObject.SetActive(false);}
		else if (canForage)
		{
			combatControl.forageButton.gameObject.SetActive(false);
		}
		else if (canTrack)
		{
			combatControl.trapButton.gameObject.SetActive(false);
		}
		else if (canRepair)
		{
			combatControl.repairButton.gameObject.SetActive(false);
		}

	}
	 public void CheckToSeeIfYouKnowAnAbility()
	{

	}

	//INTS FOR LEVEL IP LEVELS

	public void AwareOfLevelUp()
	{
		//winPopUpPanel.SetActive (true);
		//powerUpPanel.SetActive(true);
		if (currentLevel != skillTrainingLevel1 || currentLevel!=skillTrainingLevel2 || currentLevel!=skillTrainingLevel3
		|| currentLevel!=skillTrainingLevel4 || currentLevel!=skillTrainingLevel5) {
			Debug.Log ("not level2");
			powerUpPanel.SetActive(false);
			//winPopUpPanel.SetActive (false);
			leveledUp = false;
			combatControl.shake.SetTrigger ("AwareOfLevel");
		} 
		else {
			winPopUpPanel.SetActive(false);
			powerUpPanel.SetActive(false);
			leveledUp = false;
			combatControl.shake.SetTrigger("AwareOfLevel");
		} 
		//combatControl.shake.SetTrigger ("AwareOfLevel");
		//winPopUpPanel.SetActive (true);
		
		//ui.winDescriptionPanel.SetActive (false);
		//Debug.Log ("PPressedCLose");
	}
	void LevelUp()
	{
		//levelPanel.SetActive (true);
		winPopUpPanel.SetActive (true);
		powerUpPanel.SetActive(false);

		//ADD ANIMATION FOR LEVEL UP
		if(currentLevel > previous)
		{
			//ui.winDescriptionPanel.SetActive (true);
			combatControl.shake.Play("LevelUp");
			//combatControl.shake.SetTrigger("HasLeveledUp");
			leveledUp = true;


			CheckForAbilitiesWhenLeveledUp();
			currentNumberOfAllocatablePoints += numberOfPointsPerLevel;
			allocatablePointsText.text = currentNumberOfAllocatablePoints.ToString();

			if (currentLevel==skillTrainingLevel1) {
				powerUpPanel.SetActive(true);
				CheckForAbilitiesWhenLeveledUp();
			}
			else if (currentLevel==skillTrainingLevel2) {
				powerUpPanel.SetActive(true);
				CheckForAbilitiesWhenLeveledUp();

			}
			else if (currentLevel==skillTrainingLevel3)
			{
				combatControl.tier1Monsters = false;
				combatControl.tier2Monsters = true;

				powerUpPanel.SetActive(true);
				CheckForAbilitiesWhenLeveledUp();
			}
			else if (currentLevel==skillTrainingLevel4)
			{
				
				//combatControl.tier2Monsters=false;
				//combatControl.tier3Monsters=true;
				powerUpPanel.SetActive(true);
				CheckForAbilitiesWhenLeveledUp();
			}
			else if (currentLevel==skillTrainingLevel5)
			{
				
				//combatControl.tier2Monsters=false;
				//combatControl.tier3Monsters=true;
				powerUpPanel.SetActive(true);
				CheckForAbilitiesWhenLeveledUp();
			}
			else 
			{powerUpPanel.SetActive(false);}
		}
			previous = currentLevel;
		
	}


	public void UpdateExpPoints(int monsterExpPoints)
	{
		currentExpPoints += monsterExpPoints;
		currentLevel = (int)(Mathf.Sqrt(currentExpPoints) * 0.25) ;
		nextLevelExpPoints =  (int)((currentLevel+1)*(currentLevel+1)*16.0f); 
		
		levelText.text = currentLevel.ToString();
		expText.text = currentExpPoints.ToString();
		nextLevelExpPointsText.text = nextLevelExpPoints.ToString();
		
		LevelUp();
	}
	
	public void UpdateMoney(int monsterMoney)
	{
		money += monsterMoney;

		currentMoney.text = money.ToString ();
	}
	public int getPlayerAccuracy()
	{
		return accuracy;
	}


	public void AddMoney(int addMoney)
	{
		money += addMoney;
	}
	
	public void RemoveMoney(int removeMoney)
	{
		money -= removeMoney;
		//(int)currentMoney = money;
		currentMoney.text = money.ToString ();
	}

	public int getPlayerMoney()
	{
		return money;
	}


	void UpdateHealthMeter()
	{
		maxHPText.text = maxHP.ToString();
		healthSlider.maxValue = maxHP;
		currentHPText.text = currentHP.ToString();
		healthSlider.value = currentHP;
	}
	void UpdateEnergyMeter()
	{
		if (GetEnergyPoints () > maxEnergy) {
			currentEnergy = maxEnergy;
		}
		maxEnergyText.text = maxEnergy.ToString();
		energySlider.maxValue = maxEnergy;
		currentEnergyText.text = currentEnergy.ToString();
		energySlider.value = currentEnergy;

	}
	
	
	public void DoDamage(int damage)
	{
		currentHP -= damage;
		if (currentHP <= 0)
		{
			Death.SetActive(true);
			
			//StartCoroutine("Death");
			
			//trigger death
		}
		UpdateHealthMeter();
	}
	
	public void RestartGame()
	{
		Application.LoadLevel(0);
	}



	public void DoEnergyDamage(int energyDamage)
	{
		currentEnergy -= energyDamage;
		if (currentEnergy <= 0)
		{
			Death.SetActive(true);
			Debug.Log("You died.");
			//trigger death
		}
		
		UpdateEnergyMeter();
	}

	public void HealEnergyDamage(int energyHeal)
	{
		currentEnergy += energyHeal;
		UpdateEnergyMeter ();
	}
	
	public void HealDamage(int heal)
	{
		currentHP += heal;
		if (currentHP > maxHP)
		{
			currentHP = maxHP;
		}
		currentHPText.text = currentHP.ToString();
		UpdateHealthMeter ();
	}
	
	public int AttackHead()
	{
		return  strength;
	}

	public int AttackRightArm()
	{
		return  strength;
	}

	
	public int AttackRightLeg()
	{
		return  strength;
	}






	
	//dont use
	public int AttackLeftArm()
	{
		return  strength;
	}
	//dont use
	public int AttackLeftLeg()
	{
		return  strength;
	}



	public void IncreaseEnergy()
	{
		if (currentNumberOfAllocatablePoints > 0)
		{
			tempEnergy++;
			currentNumberOfAllocatablePoints--;
		}
		UpdateStats();
	}
	
	public void IncreaseStrength()
	{
		if (currentNumberOfAllocatablePoints > 0)
		{
			tempStrength++;
			currentNumberOfAllocatablePoints--;
		}
		UpdateStats();
	}
	
	public void IncreaseAccuracy()
	{
		if (currentNumberOfAllocatablePoints > 0)
		{
			tempAccuracy++;
			currentNumberOfAllocatablePoints--;
		}
		UpdateStats();
	}
	
	public void DecreaseAccuracy()
	{
		if (tempAccuracy > oldAccuracy)
		{
			tempAccuracy--;
			currentNumberOfAllocatablePoints++;
		}
		UpdateStats();
	}
	
	public void DecreaseEnergy()
	{
		if (tempEnergy > oldEnergy)
		{
			tempEnergy--;
			currentNumberOfAllocatablePoints++;
		}
		UpdateStats();
	}
	
	public void DecreaseStrength()
	{
		if (tempStrength > oldStrength)
		{
			tempStrength--;
			currentNumberOfAllocatablePoints++;
		}
		UpdateStats();
	}
	
	public void IncreaseSpeed()
	{
		if (currentNumberOfAllocatablePoints > 0)
		{
			tempSpeed++;
			currentNumberOfAllocatablePoints--;
		}
		UpdateStats();
	}
	
	public void DecreaseSpeed()
	{
		if (tempSpeed > oldSpeed)
		{
			tempSpeed--;
			currentNumberOfAllocatablePoints++;
		}
		UpdateStats();
	}
	
	public void IncreaseIntelligence()
	{
		if (currentNumberOfAllocatablePoints > 0)
		{
			tempIntelligence++;
			currentNumberOfAllocatablePoints--;
		}
		UpdateStats();
	}
	
	public void DecreaseIntelligence()
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
		accuracyText.text = tempAccuracy.ToString();
		energyText.text = tempEnergy.ToString();
		allocatablePointsText.text = currentNumberOfAllocatablePoints.ToString();
	}
	
	public void CommitPoints()
	{
		strength = tempStrength;
		
		accuracy = tempAccuracy;
		oldAccuracy = accuracy;
		
		energy = tempEnergy;
		oldEnergy = energy;
		
		speed = tempSpeed;
		intelligence = tempIntelligence;
		oldStrength = strength;
		oldSpeed = speed;
		oldIntelligence = intelligence;
		
		float energyRatio = (float)currentEnergy / maxEnergy;
		maxEnergy = energy * 10;
		currentEnergy = Mathf.RoundToInt(maxEnergy * energyRatio);
		
		float healthRatio = (float)currentHP / maxHP;
		maxHP = strength * 10;
		currentHP = Mathf.RoundToInt(maxHP * healthRatio);
		
		UpdateStats();
		UpdateHealthMeter();
		UpdateEnergyMeter();
		
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
	public int GetStrength()
	{
		return strength;
	}
	public void SetStrength(int offSet)
	{
		strength +=  offSet;
		tempStrength = strength;
		CommitPoints();
	}
	public int GetSpeed()
	{
		return speed;
	}
	public void SetSpeed(int offSet)
	{
		speed += offSet;
		tempSpeed = speed;
		CommitPoints();
	}
	public int GetAccuracy()
	{
		return accuracy;
	}
	public void SetAccuracy(int offSet)
	{
		accuracy += offSet;
		tempAccuracy = accuracy;
		CommitPoints();
	}
	public int GetIntelligence()
	{
		return intelligence;
	}
	public void SetIntelligence(int offSet)
	{
		intelligence += offSet;
		tempIntelligence = intelligence;
		CommitPoints();
	}
	public int GetEnergy()
	{
		return energy;
	}
	public void SetEnergy(int offSet)
	{
		energy += offSet;
		tempEnergy = energy;
		CommitPoints();
	}
	public int GetEnergyPoints()
	{
		return currentEnergy;
	}
	public void SetEnergyPoints(int offSet)
	{
		currentEnergy += offSet;
		if (currentEnergy>maxEnergy)
			currentEnergy=maxEnergy;
		CommitPoints();
	}
	
	public int GetHitPoints()
	{
		return currentHP;
	}
	public void SetHitPoints(int offSet)
	{
		currentHP += offSet;
		if (currentHP>maxHP)
			currentHP=maxHP;
		CommitPoints();
	}
}