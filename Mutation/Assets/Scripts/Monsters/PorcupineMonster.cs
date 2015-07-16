using UnityEngine;
using System.Collections;

public class PorcupineMonster : Monster {
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "You make out snorting just off to the left. You crane your head just in time to see an spiked animal jump at you. Stepping back, you dodge the animals attack! But not for long… This porcupine seems pissed!\n\n";
		monsterText[1] = "You notice the distinct black and white spines of porcupine quills. It’s not long before the porcupine smells you and starts running in your direction.\n\n";
		monsterText[2] = "Up ahead, you see dirt being flung into the air- something is digging! You crouch down, so as not to draw attention to yourself, but you’re too clumsy! Beady porcupine eyes fix you in their gaze.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "";

		monsterText[4] = "You deliver the final blow and the porcupine shakes violently before dieing.";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		monsterMeatID = 16;
		monsterName = "Porcupine";
		expPointsGained = Random.Range(75,90);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));

		strength = Random.Range(12,30);
		speed = Random.Range(45, 65);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 5;
		headMaxDamage = 10;
		armMinDamage = 13;
		armMaxDamage = 19;
		legMinDamage = 15;
		legMaxDamage = 18;
		bonusDamage = 0;
		
		base.Init();
	}
	
}