using UnityEngine;
using System.Collections;

public class PorcupineMonster : Monster {
	string[] monsterText = new string[4];
	
	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "\n\n";
		monsterText[1] = "\n\n";
		monsterText[2] = "\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Porcupine";
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