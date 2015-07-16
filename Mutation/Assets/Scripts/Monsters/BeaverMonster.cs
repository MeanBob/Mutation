using UnityEngine;
using System.Collections;

public class BeaverMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You hear what at first you think is a chainsaw. How can that be, you wonder. Soon you find the source of the sound: it is not a chainsaw at all, but a fat beaver with sharp, bucked teeth and malicious eyes!\n\n";
		monsterText[1] = "Something brown lumbers across your path. You stop dead in your tracks. But the creature must have sensed you, for it stopped too! It’s a beaver!\n\n";
		monsterText[2] = "A leathery, flat tail catches your attention. Upon close inspection, you find a rather fat beaver mulling down a tree. It flinches when it sees you then turns and barks like a dog!\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You slap your hands on the ground, attempting an intimidating thud.  The beaver is reminded of home. It scurries off.";

		//used for victory
		monsterText[4] = "The beaver mutters something profane under its breath as its eyes shut forever";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 9;
		
		monsterName = "Beaver";
		expPointsGained = Random.Range(25,45);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Beaver"));
		strength = Random.Range(7,17);
		speed = Random.Range(11, 37);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 6;
		headMaxDamage = 16;
		armMinDamage = 2;
		armMaxDamage = 4;
		legMinDamage = 2;
		legMaxDamage = 6;
		bonusDamage = 0;
		
		base.Init();
	}
	
}
