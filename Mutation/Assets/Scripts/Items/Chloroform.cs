using UnityEngine;
using System.Collections;

public class Chloroform : Item {
	
	public override void Init()
	{
		itemName = "Chloroform";

		strength = 0;
		speed = -5;
		intelligence = -5;
		energy = 0;
		accuracy = -5;
		
		base.Init();
	}
	
}
