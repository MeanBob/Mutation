using UnityEngine;
using System.Collections;


public class WolfMeat : Item {
	
	void Awake()
	{
		itemName = "Wolf Meat";
		strength = 0;
		speed = -5;
		intelligence = -5;
		energy = 0;
		accuracy = -5;
		count = 1;
	}
	
}