using UnityEngine;
using System.Collections;

public class PorcupineMonster : Monster {
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You make out snorting just off to the left. You crane your head just in time to see an spiked animal jump at you.\n\n";
		monsterText[1] = "You notice the distinct black and white spines of porcupine quills.\n\n";
		monsterText[2] = "Up ahead dirt is flung into the air. \n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You hide from the porcupine.";

		monsterText[4] = "You deliver the final blow and the porcupine shakes violently before dieing.";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 16;
		monsterName = "Porcupine";
		expPointsGained = Random.Range(100,130);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Porcupine"));

		strength = Random.Range(25,27);
		speed = Random.Range(30, 45);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 5;
		headMaxDamage = 10;
		armMinDamage = 15;
		armMaxDamage = 20;
		legMinDamage = 20;
		legMaxDamage = 25;
		bonusDamage = 0;
		
		base.Init();
	}
	
}