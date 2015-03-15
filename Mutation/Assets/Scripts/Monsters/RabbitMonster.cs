using UnityEngine;
using System.Collections;

public class RabbitMonster : Monster {

	// Use this for initialization
    public override void Init()
    {
        monsterName = "Rabbit";
        strength = 5;
        speed = 15;
        intelligence = 5;

        headMinDamage = 1;
        headMaxDamage = 4;
        armMinDamage = 1;
        armMaxDamage = 2;
        legMinDamage = 1;
        legMaxDamage = 6;

        bonusDamage = strength;

        base.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
