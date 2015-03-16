using UnityEngine;
using System.Collections;

public class WolfMonster : MonoBehaviour {

	// Use this for initialization
	public override void Init()
	{
		monsterName = "Wolf";
		strength = 10;
		speed = 15;
		intelligence = 5;
		
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 6;
		legMinDamage = 1;
		legMaxDamage = 6;
		
		bonusDamage = strength;
		
		base.Init();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
