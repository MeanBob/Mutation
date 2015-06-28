using UnityEngine;
using System.Collections;

public class BirdMonster : Monster {
	
	string[] monsterText = new string[4];
	
	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You hear the caw of a bird’s cry. When you look up, a large, feathered creature is descending upon you with sharp, outstretched talons.\n\n";
		monsterText[1] = "A deep whooshing suddenly catches your attention. The shadow of something passes over you and a strong wind crosses your body. In no time a large bird is bearing down on you.\n\n";
		monsterText[2] = "Up high in the sky you notice a bird circling. You feel like it’s watching you. Suddenly the large beast is diving right at you! Its hook-shaped beak looks terribly sharp!\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You lay flat on your back and kick and scream like a baby. \nThe bird is noticeably disgusted by your actions. It flaps away.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Bird";
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