using UnityEngine;
using System.Collections;

public class BearMonster : Monster {

	CharacterPage playerCharacter;

	void Start()
	{
		playerCharacter = GameObject.Find("Avatar").GetComponent<CharacterPage>();
	}

	public override void Init()
	{
		monsterName = "Bear";


		strength = Random.Range (40,56);


		speed = Random.Range (14,60);
		intelligence = 5;
		
		headMinDamage = 57;
		headMaxDamage = 86;
		armMinDamage = 57;
		armMaxDamage = 77;
		legMinDamage = 57;
		legMaxDamage = 59;
		expPointsGained = 160;
		bonusDamage = - strength;
		
		base.Init();
	}
}
