using UnityEngine;
using System.Collections;


public class GoatMeat : Item {
	
	void Awake()
	{
		itemName = "Goat Meat";

		itemImage = "Enemies/Goat";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		energyHealed = 10;
		hitPointsHealed = 10;

		tag = 7;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};



	}
	
}