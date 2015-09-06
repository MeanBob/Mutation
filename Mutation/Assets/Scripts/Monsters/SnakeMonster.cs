using UnityEngine;
using System.Collections;

public class SnakeMonster : Monster {
	
	string[] monsterText = new string[5];
	
	public override void Start()
	{
		monsterText[0] = "You hear a hiss like a leaking tire.";
		monsterText[1] = "A double headed snake slithers nearby.";
		monsterText[2] = "You barely miss stepping on a snake.";
		// index 3 is for hiding
		monsterText[3] = "You sense danger. Rather than fight, you decide to run away.";
		//index 4 is for victory
		monsterText[4] = "You mangle the snake!";

		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		moneyGained = 3;
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
