using UnityEngine;
using System.Collections;

public class GoatMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You hear the sharp clack of hooves grating hard rock. Before you have time to react, a large, horned goat is making right for you.\n\n";
		monsterText[1] = "In the near-distance you make out the lean, sturdy figure of a horned goat staring at you but not moving. It bows slowly and then suddenly it charges!\n\n";
		monsterText[2] = "As you come into a clearing, a horned goat fixes you in its drawn-out gaze. Your gut aches as you realize you are about to fight.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "Stomping and kicking up dirt scares off the goat.";

		//used for victory
		monsterText[4] = "The goat staggers back, blinks twice, keels over and then dies!";


		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 7;
		monsterName = "Goat";
		expPointsGained = Random.Range(18,50);
		setMonsterImage(Resources.Load <Sprite>("Enemies/Goat"));
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];

		strength = Random.Range(8,22);
		speed = Random.Range(35, 55);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 8;
		headMaxDamage = 13;
		armMinDamage = 2;
		armMaxDamage = 8;
		legMinDamage = 3;
		legMaxDamage = 10;
		bonusDamage = 0;
		
		base.Init();
	}
	
}
