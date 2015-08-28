using UnityEngine;
using System.Collections;


public class AnteaterMeat : Item {
	
	void Awake()
	{
		itemName = "Anteater Meat";
		itemImage = "Enemies/Anteater";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 50;
		hitPointsHealed = 60;
		tag = 14;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};



	}
	
}