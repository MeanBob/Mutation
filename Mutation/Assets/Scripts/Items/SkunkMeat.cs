using UnityEngine;
using System.Collections;


public class SkunkMeat : Item {
	
	void Awake()
	{
		itemName = "Skunk Meat";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		count = 1;
		tag = 5;


	}
	
}