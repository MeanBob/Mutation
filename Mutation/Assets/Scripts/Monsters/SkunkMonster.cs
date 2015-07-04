using UnityEngine;
using System.Collections;

public class SkunkMonster : Monster {
	
	string[] monsterText = new string[5];
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "Snorting sounds catch your attention. What could it be? You follow the snorting around and before long, discover a skunk. It halts when it sees you and stares through beady, black eyes. Suddenly it turns around!\n\n";
		monsterText[1] = "You make out a bushy, black and white tail wavering in the air. Before you know what to do, a skunk is running in your direction.\n\n";
		monsterText[2] = "As night descends and swallows your ability to see, the patter-patter of a creature’s soft feet grows louder. Your curiosity gives way to panic as beady little eyes produce a fast-moving skunk!\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You play a round of your favorite game Stand Still, knowing that skunks probably only detect movement.";

		//index 4 is for victory
		monsterText [4] = "The skunk shrieks as only skunks can. You have definitely killed it!";

		//droppedItemsList = new Item[]{ new Daffodil(),new Chloroform(),new RabbitMeat()};
	}
	public override void Init()
	{
		
		monsterName = "Skunk";
		expPointsGained = Random.Range(20,44);
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		
		strength = Random.Range(4,11);
		speed = Random.Range(10, 35);
		intelligence = 5;
		energy = 10;
		

		headMinDamage = 3;
		headMaxDamage = 6;

		armMinDamage = 1;
		armMaxDamage = 3;

		legMinDamage = 1;
		legMaxDamage = 4;

		bonusDamage = 0;
		
		base.Init();
	}
	
}