using UnityEngine;
using System.Collections;

public class WolfMonster : Monster {
	string[] monsterText = new string[5];
	
	public override void Start()
	{
		monsterText[0] = "You first see the patchy grey and brown fur of an animal in your path. When its eyes lite upon you you notice pointed, dripping fangs. The wolf growls and you sense the beast must be hungry.\n\n";
		monsterText[1] = "You catch two glowing, yellow gems in your site. They are quickly followed by the lurking, open-mouthed face of a true beast. This wolf’s fur is matted and patchy. You must have stumbled upon a true wolf warrior!\n\n";
		monsterText[2] = "You hear the sharp howl of a hungry wolf not far away. Before you have time to retreat, a wolf leaps onto your path and stares you straight in the eyes.\n\n";

		monsterText[3] = "You jump into the nearest ruffage and cover yourself with the natural debris.";

		//used for victory
		monsterText[4] = "The wolf’s eyes grow dim and absent as his life is depleted! Victory is yours!";
	}
	public override void Init()
	{
		monsterName = "Wolf";
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bunny"));
		strength = Random.Range(15,42);
		speed = Random.Range (40,75);
		intelligence = 5;

		energy = 10;

		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];

		headMinDamage = 1;
		headMaxDamage =  25;

		armMinDamage = 5;
		armMaxDamage = 16;

		legMinDamage = 5;
		legMaxDamage = 20;

		expPointsGained = Random.Range(26, 94);

		bonusDamage = 0;
		
		base.Init();
	}
}
