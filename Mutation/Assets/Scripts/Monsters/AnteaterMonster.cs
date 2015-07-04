using UnityEngine;
using System.Collections;

public class AnteaterMonster : Monster {
	
	string[] monsterText = new string[5];
	

	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "A trail of fleeing ants at your feet provides you with a curiosity. Following the trail in the direction of flight, a furry, snorting anteater, with foot long claws! It’s eyes grow wide upon seeing you. You think you see it mouth the words: Sport Kill, but you’re not sure.\n\n";
		monsterText[1] = "You make out a distinct, yet unidentifiable slurping noise. Following the noise you come upon a frantic, maddened Anteater. It rears up on its back legs when it sees you.\n\n";
		monsterText[2] = "You make out marks in the sand at your feet. Leaning down to inspect them, you are suddenly overcome by a roaring, clawed, snouted anteater. It appears to want to kill you for sport, and nothing more.\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "Knowing the value of your health, you decide it best to leave this Anteater alone.  You scurry off as quick as possible and hide under a rock.";

		monsterText[4] = "The giant anteater ceases to move. You sense its life force depleted. Nice work!";
		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		
		monsterName = "Anteater";
		expPointsGained = Random.Range(30,89);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];

		victoryText = monsterText[4];

		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));

		strength = Random.Range(13,40);
		speed = Random.Range(50, 70);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 8;
		headMaxDamage = 13;
		armMinDamage = 6;
		armMaxDamage = 9;
		legMinDamage = 5;
		legMaxDamage = 8;
		bonusDamage = 0;
		
		base.Init();
	}
	
}