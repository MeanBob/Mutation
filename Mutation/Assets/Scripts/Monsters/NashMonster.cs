using UnityEngine;
using System.Collections;

public class NashMonster : Monster {
	string[] monsterText = new string[5];
	
	//public bool KilledNash;
	
	public override void Start()
	{
		//KilledNash = false;
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "The man who imprisioned you.\n\n";
		monsterText[1] = "Nash!\n\n";
		monsterText[2] = "One big mother fucker. \n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You run in terror.";
		
		monsterText[4] = "Nash is down!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 17;
		monsterName = "Nash";
		expPointsGained = Random.Range(100,130);
		moneyGained = 300;
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Porcupine"));
		
		strength = Random.Range(2,3);
		speed = Random.Range(30, 45);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 1;
		headMaxDamage = 1;
		armMinDamage = 1;
		armMaxDamage = 2;
		legMinDamage = 2;
		legMaxDamage = 2;
		bonusDamage = 0;
		
		base.Init();
	}
	
}