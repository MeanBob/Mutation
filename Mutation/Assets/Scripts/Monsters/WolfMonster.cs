using UnityEngine;
using System.Collections;

public class WolfMonster : Monster {
	string[] monsterText = new string[4];
	
	public override void Start()
	{
		monsterText[0] = "wolf you are looking down at where you are walks a small, white rabbit zips across your path in quick hops. Its bushy tail is adorable, you think.\n\n";
		monsterText[1] = "Wolf you are resting and catching your breath a small, brown bunny pops its head out of a hole. You notice its pink, twitching nose and relentless, bugging eyes. How cute!\n\n";
		monsterText[2] = "Wolf white ears protrude from the landscapes ahead. You can’t be certain, but if you were betting, you'd be putting your money on rabbits right about now.\n\n";

		monsterText[3] = " I dodged the fucking rabbit and hid amazingly";
	}
	public override void Init()
	{
		monsterName = "Wolf";
		strength = Random.Range(9,15);
		speed = 80;
		intelligence = 5;
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
