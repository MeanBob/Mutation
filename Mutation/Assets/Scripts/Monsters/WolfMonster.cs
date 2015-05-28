using UnityEngine;
using System.Collections;

public class WolfMonster : Monster {

	public override void Init()
	{
		monsterName = "Wolf";
		strength = 2;
		speed = 80;
		intelligence = 5;
		
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 6;
		legMinDamage = 1;
		legMaxDamage = 6;
		expPointsGained = 45;

		bonusDamage = strength;
		
		base.Init();
	}
}
