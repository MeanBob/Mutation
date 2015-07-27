using UnityEngine;
using System.Collections;


public class BeaverMeat : Item {
	
	void Awake()
	{
		itemName = "Beaver Meat";
		itemImage = "Enemies/Beaver";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 9;


	}
	
}