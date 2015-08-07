using UnityEngine;
using System.Collections;

public class CatMonster : Monster {
	
	string[] monsterText = new string[5];


	
	public override void Start()
	{

		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "An freaky cat jumps out at you!";
		monsterText[1] = "A cat lurks on top of an old VW.";
		monsterText[2] = "Your eyes catch the glimmer of something mutated.";

		// index 3 is for hiding
		monsterText[3] = "You scream and run in circles, confusing the cat and making a lot of noise.";

		//used for victory
		monsterText[4] = "You rend the feline’s flesh! Its life depletes before your eyes. You killed it!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		moneyGained = 4;
		monsterMeatID = 10;
		monsterName = "Stinking Cat";
		expPointsGained = Random.Range(40,60);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Car")); ///KEEP IN MIND THE TYPO

		strength = Random.Range(4,7);
		speed = Random.Range(65, 85);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 8;
		headMaxDamage = 9;
		armMinDamage = 5;
		armMaxDamage = 6;
		legMinDamage = 6;
		legMaxDamage = 9;
		bonusDamage = 0;
		
		base.Init();
	}
	
}
