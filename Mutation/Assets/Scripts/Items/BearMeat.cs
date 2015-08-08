using UnityEngine;
using System.Collections;


public class BearMeat : Item {
	
	void Awake()
	{
		itemName = "Bear Meat";

		itemName = "Bear Meat";
		itemImage = "Enemies/Bear";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		count = 1;
		tag = 4;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};



	}
	
}