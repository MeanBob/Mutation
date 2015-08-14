using UnityEngine;
using System.Collections;

public class CatMonster : Monster {
	
	string[] monsterText = new string[5];


	
	public override void Start()
	{

		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "Up in the distance something catches your eye. As it draws near, you see the sharp fangs and glinting eyes of a large feline beast.\n\n";
		monsterText[1] = "You suddenly hear a crooning roar. Before you know it, a large cat with matted tufts and pointed ears pounces on you from a tree.\n\n";
		monsterText[2] = "Your eyes catch the glimmer of something mysterious to your left. It steps forth and boasts paws laden with sharp claws. It doesn’t take long for you to deduce, it is a cat!\n\n";

		// index 3 is for hiding
		monsterText[3] = "You scream and run in circles, confusing the cat and making a lot of noise.";

		//used for victory
		monsterText[4] = "You rend the feline’s flesh! Its life depletes before your eyes. You killed it!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 10;
		monsterName = "Cat";
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
