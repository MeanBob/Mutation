using UnityEngine;
using System.Collections;

public class SkunkMonster : Monster {
	
	string[] monsterText = new string[4];
	
	Sprite monsterImage = new Sprite();
	
	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText[0] = "Snorting sounds catch your attention. What could it be? You follow the snorting around and before long, discover a skunk. It halts when it sees you and stares through beady, black eyes. Suddenly it turns around!\n\n";
		monsterText[1] = "You make out a bushy, black and white tail wavering in the air. Before you know what to do, a skunk is running in your direction.\n\n";
		monsterText[2] = "As night descends and swallows your ability to see, the patter-patter of a creature’s soft feet grows louder. Your curiosity gives way to panic as beady little eyes produce a fast-moving skunk!\n\n";
		
		// index 3 is for hiding
		monsterText[3] = "You play a round of your favorite game Stand Still, knowing that skunks probably only detect movement.";
		droppedItemsList = new Item[]{ ScriptableObject.CreateInstance<Daffodil>(),ScriptableObject.CreateInstance<Chloroform>(),ScriptableObject.CreateInstance<RabbitMeat>()};
	}
	public override void Init()
	{
		
		monsterName = "Skunk";
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