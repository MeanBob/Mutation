using UnityEngine;
using System.Collections;

public class SnakeMonster : Monster {
	
	string[] monsterText = new string[5];
	
	public override void Start()
	{
		monsterText[0] = "A rustle in the bushes grabs your attention.\n\n";
		monsterText[1] = "Snakes are common around here. It might have something to do with all the rabbits.\n\n";
		monsterText[2] = "You walk and contemplate the cycles of nature... Oh! A snake!\n\n";
		// index 3 is for hiding
		monsterText[3] = "You sense danger. Rather than fight, you decide to run away.";
		//index 4 is for victory
		monsterText[4] = "You mangle the poor snake! It dies. Hoo-ray!";

		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterName = "Snake";
		expPointsGained = Random.Range(30 , 40);
		setMonsterImage(Resources.Load <Sprite>("Enemies/Snake"));
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		monsterMeatID = 6;
		strength = Random.Range(5,7);
		speed = Random.Range(16, 26);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 15;
		headMaxDamage = 20;
		armMinDamage = 6;
		armMaxDamage = 12;
		legMinDamage = 6;
		legMaxDamage = 12;

		bonusDamage = 0;
		
		base.Init();
	}
	
}
