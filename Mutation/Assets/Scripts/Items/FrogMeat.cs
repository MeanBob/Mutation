using UnityEngine;
using System.Collections;


public class FrogMeat : Item {
	
	void Awake()
	{
		itemName = "Frog Meat";
		itemImage = "Enemies/Frog";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 13;


	}
	
}