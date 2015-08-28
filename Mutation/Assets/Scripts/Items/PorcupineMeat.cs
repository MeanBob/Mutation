using UnityEngine;
using System.Collections;


public class PorcupineMeat : Item {
	
	void Awake()
	{
		itemName = "Porcupine Meat";
		itemImage = "Enemies/Porcupine";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		energyHealed = 50;
		hitPointsHealed = 32;
		tag = 16;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};


	}
	
}