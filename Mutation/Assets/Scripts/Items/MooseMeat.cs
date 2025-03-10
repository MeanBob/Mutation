﻿using UnityEngine;
using System.Collections;


public class MooseMeat : Item {
	
	void Awake()
	{
		itemName = "Moose Meat";
		itemImage = "Enemies/Moose";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 0;
		energyHealed = 60;
		hitPointsHealed = 50;
		tag = 8;
		numberOfMutations = 4;
		
		mutationList = new Mutation[]{ScriptableObject.CreateInstance<FloppyEars>(),ScriptableObject.CreateInstance<Whiskers>(),
			ScriptableObject.CreateInstance<BushyTail>(), ScriptableObject.CreateInstance<RabbitLegs>(),
		};

	}
	
}