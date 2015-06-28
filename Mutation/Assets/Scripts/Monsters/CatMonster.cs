using UnityEngine;
using System.Collections;

public class CatMonster : Monster {
	
	string[] monsterText = new string[4];

	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{

		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "Up in the distance something catches your eye. As it draws near, you see the sharp fangs and glinting eyes of a large feline beast.\n\n";
		monsterText[1] = "You suddenly hear a crooning roar. Before you know it, a large cat with matted tufts and pointed ears pounces on you from a tree.\n\n";
		monsterText[2] = "Your eyes catch the glimmer of something mysterious to your left. It steps forth and boasts paws laden with sharp claws. It doesn’t take long for you to deduce, it is a cat!\n\n";

		// index 3 is for hiding
		monsterText[3] = "You scream and run in circles, confusing the cat and making a lot of noise.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{

		monsterName = "Cat";
		expPointsGained = 30;
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		
		strength = Random.Range(1,5);
		speed = Random.Range(50, 80);
		intelligence = 5;
		energy = 10;
		
		itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 6;
		headMaxDamage = 7;
		armMinDamage = 5;
		armMaxDamage = 6;
		legMinDamage = 6;
		legMaxDamage = 7;
		bonusDamage = - strength;
		
		base.Init();
	}
	
}
