using UnityEngine;
using System.Collections;

public class Chloroform : Item {
	
	void Awake()
	{
		itemName = "Chloroform";

		strength = 0;
		speed = -5;
		intelligence = -5;
		energy = 0;
		accuracy = -5;
		count = 1;
		tag = 0;
//		base.Init();
	}
	
}
