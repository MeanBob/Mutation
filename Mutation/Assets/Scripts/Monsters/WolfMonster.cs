using UnityEngine;
using System.Collections;

public class WolfMonster : Monster {

	public override void Init()
	{
		monsterName = "Wolf";
		strength = Random.Range(9,15);
		speed = 80;
		intelligence = 5;
		
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
