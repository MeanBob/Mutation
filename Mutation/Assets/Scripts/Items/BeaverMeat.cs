using UnityEngine;
using System.Collections;


public class BeaverMeat : Item {
	
	void Awake()
	{
		itemName = "Beaver Meat";
		itemImage = "Enemies/Beaver";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		energyHealed = 50;
		hitPointsHealed = 35;
		tag = 9;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};


	}
	
}