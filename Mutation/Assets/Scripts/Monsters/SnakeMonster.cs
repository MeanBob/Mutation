using UnityEngine;
using System.Collections;

public class SnakeMonster : Monster {
	
	string[] monsterText = new string[4];
	
	public override void Start()
	{
		monsterText[0] = "A rustle in the bushes grabs your attention.\n\n";
		monsterText[1] = "Snakes are common around here. It might have something to do with all the rabbits.\n\n";
		monsterText[2] = "You wonder if nature is evil, or if there is just a lot of death.  Is that pessimistic?\n\n";
		// index 3 is for hiding
		monsterText[3] = "You sense danger. Rather than fight, you decide to run away.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		monsterName = "Snake";
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
