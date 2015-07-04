using UnityEngine;
using System.Collections;

public class MooseMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "The blasting snort of something massive makes you stop in your tracks. You look to the right as a set of antlers gives way to a lurking, wet-nosed moose!\n\n";
		monsterText[1] = "You first catch sight of a stubby, twitching tail. Before you can come to your senses, a huge buck moose is charging in your direction!\n\n";
		monsterText[2] = "Suddenly the ground shakes. Before you know it, a 7-point moose is reeling back on its hind legs and kicking its sharp hooves in the air! Something tells you this moose is mad.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You turn tail and take off, zigging and zagging until you escape the moose.";

		monsterText[4] = "The moose’s black nostrils flare as it succumbs to defeat! You killed it!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		
		monsterName = "Moose";
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));
		expPointsGained = Random.Range(85,130);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		
		strength = Random.Range(30,49);
		speed = Random.Range(25, 60);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 10;
		headMaxDamage = 25;
		armMinDamage = 2;
		armMaxDamage = 15;
		legMinDamage = 5;
		legMaxDamage = 13;
		bonusDamage = 0;
		
		base.Init();
	}
	
}
