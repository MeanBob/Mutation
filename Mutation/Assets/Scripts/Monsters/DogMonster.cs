using UnityEngine;
using System.Collections;

public class DogMonster : Monster {
	
	string[] monsterText = new string[4];
	
	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "At first you think the mangy dog you see looks nice. But when you put your hand out to pet him, it snarls and nips your fingers!\n\n";
		monsterText[1] = "A large black dog with thick fur growls at you from across afar. Before you know it, it’s barking and thrashing towards you at a clip.\n\n";
		monsterText[2] = "You first think you’ve spotted a bear, but in no time discover it’s just a dog. However, upon closer inspection, the dog is ravished and growling at you through slimy, yellow fangs.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "The dog backs off when you puff out your chest and bark ten times.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Dog";
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