using UnityEngine;
using System.Collections;

public class RabbitMonster : Monster {

	string[] monsterText = new string[4];

	public override void Start()
	{
		monsterText[0] = "As you are looking down at where you are walks a small, white rabbit zips across your path in quick hops. Its bushy tail is adorable, you think.\n\n";
		monsterText[1] = "While you are resting and catching your breath a small, brown bunny pops its head out of a hole. You notice its pink, twitching nose and relentless, bugging eyes. How cute!\n\n";
		monsterText[2] = "Two white ears protrude from the landscapes ahead. You can’t be certain, but if you were betting, you'd be putting your money on rabbits right about now.\n\n";
		// index 3 is for hiding
		monsterText[3] = " I dodged the fucking rabbit and hid amazingly";
	}
	public override void Init()
    {
        monsterName = "Rabbit";
        strength = Random.Range(1,5);
        speed = Random.Range(50, 80);
        intelligence = 5;

		energy = 10;

		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
        headMinDamage = 6;
        headMaxDamage = 7;
        armMinDamage = 5;
        armMaxDamage = 6;
        legMinDamage = 6;
        legMaxDamage = 7;
		expPointsGained = 30;

        bonusDamage = - strength;

        base.Init();
	}

}
