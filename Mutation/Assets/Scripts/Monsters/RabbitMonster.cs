using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RabbitMonster : Monster {

	string[] monsterText = new string[5];

	public override void Start()
	{

		//used to initiate combat
		monsterText[0] = "Brown and matted fur flash before your eyes.";
		monsterText[1] = "Gnarled whiskers twitch at your approach.";
		monsterText[2] = "1 ear is perked. The other is a small hand.  This rabbit is messed up.";
		// index 3 is for hiding
		monsterText[3] = "You avoid getting too close to the disgusting rabbit.";

		//index 4 is for victory
		monsterText [4] = "The rabbit’s eyes roll up into its head and it goes limp.";

		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
    {
		moneyGained = 2;
		monsterMeatID = 2;
        monsterName = "Mutated Rabbit";
		expPointsGained = Random.Range(14,26);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		strength = Random.Range(2,5);
        speed = Random.Range(60, 90);
        intelligence = 5;
		energy = 10;
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));

		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 2;
        headMaxDamage = 4;
        armMinDamage = 1;
        armMaxDamage = 2;
        legMinDamage = 1;
        legMaxDamage = 3;
		bonusDamage = 0;

        base.Init();
	}

}
