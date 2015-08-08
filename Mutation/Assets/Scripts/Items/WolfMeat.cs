using UnityEngine;
using System.Collections;


public class WolfMeat : Item {
	
	void Awake()
	{
		itemName = "Wolf Meat";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		tag = 3;
		hitPointsHealed = 10;
		energyHealed = 10;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};


	}
	
}