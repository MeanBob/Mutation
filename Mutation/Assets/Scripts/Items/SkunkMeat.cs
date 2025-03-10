﻿using UnityEngine;
using System.Collections;


public class SkunkMeat : Item {
	
	void Awake()
	{
		itemName = "Skunk Meat";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		energyHealed = 50;
		hitPointsHealed = 30;
		tag = 5;

		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};


	}
	
}