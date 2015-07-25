using UnityEngine;
using System.Collections;


public class SnakeMeat : Item {
	
	void Awake()
	{
		itemName = "Snake Meat";
		itemImage = "Enemies/Snake";
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
//		count = 5;
		tag = 6;
	}
	
}