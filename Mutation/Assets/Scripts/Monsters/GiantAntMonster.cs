using UnityEngine;
using System.Collections;

public class GiantAntMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You hear odd scratching sounds, something you’ve never heard before. You peer around the thick trunk of a tree: A gigantic Ant!\n\n";
		monsterText[1] = "A shadow passes over you and you look up. Panicked, you behold the horrific sight of a giant Ant. It’s mandibles click at you as its long antennae wave sporadically.\n\n";
		monsterText[2] = "The sun glints off of something shinny up ahead. When you focus your eyes you make out the segmented body of a hairy, ferocious ant! It must be 4 feet long!\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You casually stroll away from the ant. It ignores you as it move a fallen tree branch out of its way.";

		monsterText[4] = "Squishy, green ooze emerges from the ant’s segmented body. Dead Ant Nasty!";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Giant Ant";
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));
		itemReleased = droppedItemsList[Random.Range(0,3)];
		
		expPointsGained = Random.Range(110,300);
		monsterDescription = monsterText[Random.Range(0,3)];

		hideDescription = monsterText[3];
		victoryText = monsterText[4];

		strength = Random.Range(50,66);
		speed = Random.Range(60, 80);
		intelligence = 5;
		energy = 10;
		
		headMinDamage = 30;
		headMaxDamage = 35;
		armMinDamage = 11;
		armMaxDamage = 21;
		legMinDamage = 10;
		legMaxDamage = 20;
		bonusDamage = 0;
		
		base.Init();
	}
	
}