using UnityEngine;
using System.Collections;

public class BearMonster : Monster {

	// Use this for initialization
	public override void Init()
	{
		monsterName = "Bear";
		strength = 40;
		speed = 10;
		intelligence = 5;
		
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 10;
		legMinDamage = 1;
		legMaxDamage = 8;
		
		bonusDamage = strength;
		
		base.Init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
