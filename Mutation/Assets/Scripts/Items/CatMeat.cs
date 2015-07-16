using UnityEngine;
using System.Collections;


public class CatMeat : Item {
	
	void Awake()
	{
		itemName = "Cat Meat";
		itemImage = "Enemies/Cat";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		count = 1;
		tag = 10;


	}
	
}