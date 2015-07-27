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
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 14;


	}
	
}