using UnityEngine;
using System.Collections;

public class BearMonster : Monster {

	public override void Init()
	{
		monsterName = "Bear";
		strength = 2;
		speed = 10;
		intelligence = 5;
		
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 10;
		legMinDamage = 1;
		legMaxDamage = 8;
		expPointsGained = 100;
		bonusDamage = strength;
		
		base.Init();
	}
}
