using UnityEngine;
using System.Collections;

public class DogMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "At first you think the mangy dog you see looks nice. But when you put your hand out to pet him, it snarls and nips your fingers!\n\n";
		monsterText[1] = "A large black dog with thick fur growls at you from across afar. Before you know it, it’s barking and thrashing towards you at a clip.\n\n";
		monsterText[2] = "You first think you’ve spotted a bear, but in no time discover it’s just a dog. However, upon closer inspection, the dog is ravished and growling at you through slimy, yellow fangs.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "The dog backs off when you puff out your chest and bark ten times.";
		//for victory
		monsterText[4] = "The dog heaves in pain before going cross-eyed and passing out. You’ve killed it!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 11;
		monsterName = "Dog";
		setMonsterImage(Resources.Load <Sprite>("Enemies/Dog"));
		expPointsGained = Random.Range(50,75);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];

		strength = Random.Range(9,14);
		speed = Random.Range(65, 85);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 12;
		headMaxDamage = 17;
		armMinDamage = 3;
		armMaxDamage = 8;
		legMinDamage = 4;
		legMaxDamage = 8;
		bonusDamage = 0;
		
		base.Init();
	}
	
}