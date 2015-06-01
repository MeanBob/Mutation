using UnityEngine;
using System.Collections;

public class RabbitMonster : Monster {

    public override void Init()
    {
        monsterName = "Rabbit";
        strength = Random.Range(1,5);
        speed = Random.Range(50, 80);
        intelligence = 5;

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
