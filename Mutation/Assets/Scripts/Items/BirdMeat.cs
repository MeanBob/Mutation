using UnityEngine;
using System.Collections;


public class BirdMeat : Item {
	
	void Awake()
	{
		itemName = "Bird Meat";
		itemImage = "Enemies/Bird";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 12;


	}
	
}