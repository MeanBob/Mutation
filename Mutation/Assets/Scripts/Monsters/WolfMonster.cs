using UnityEngine;
using System.Collections;

public class WolfMonster : Monster {
	string[] monsterText = new string[4];
	
	public override void Start()
	{
		monsterText[0] = "You first see the patchy grey and brown fur of an animal in your path. When its eyes lite upon you you notice pointed, dripping fangs. The wolf growls and you sense the beast must be hungry.\n\n";
		monsterText[1] = "You catch two glowing, yellow gems in your site. They are quickly followed by the lurking, open-mouthed face of a true beast. This wolf’s fur is matted and patchy. You must have stumbled upon a true wolf warrior!\n\n";
		monsterText[2] = "You hear the sharp howl of a hungry wolf not far away. Before you have time to retreat, a wolf leaps onto your path and stares you straight in the eyes.\n\n";

		monsterText[3] = "You jump into the nearest ruffage and cover yourself with the natural debris.";
	}
	public override void Init()
	{
		monsterName = "Wolf";
		strength = Random.Range(9,15);
		speed = 80;
		intelligence = 5;

		energy = 10;

		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		headMinDamage = 15;
		headMaxDamage =  18;
		armMinDamage = 15;
		armMaxDamage = 16;
		legMinDamage = 15;
		legMaxDamage = 16;
		expPointsGained = 66;

		bonusDamage = - strength;
		
		base.Init();
	}
}
