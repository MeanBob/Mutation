using UnityEngine;
using System.Collections;

public class GoatMonster : Monster {
	
	string[] monsterText = new string[4];
	
	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You hear the sharp clack of hooves grating hard rock. Before you have time to react, a large, horned goat is making right for you.\n\n";
		monsterText[1] = "In the near-distance you make out the lean, sturdy figure of a horned goat staring at you but not moving. It bows slowly and then suddenly it charges!\n\n";
		monsterText[2] = "As you come into a clearing, a horned goat fixes you in its drawn-out gaze. Your gut aches as you realize you are about to fight.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "Stomping and kicking up dirt scares off the goat.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Goat";
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
