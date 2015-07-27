using UnityEngine;
using System.Collections;

public class RabbitMeat : Item {
	
	void Awake()
	{
		itemName = "Rabbit Meat";

		itemImage = "Enemies/Rabbit";

		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 2;

		numberOfMutations = 4;

		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
			};


	}
	
}