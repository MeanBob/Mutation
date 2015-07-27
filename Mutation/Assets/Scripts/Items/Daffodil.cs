using UnityEngine;
using System.Collections;

public class Daffodil : Item {
	
//	public override void Init()
//	{
//		itemName = "Daffodil";
//
//		strength = 0;
//		speed = 0;
//		intelligence = 0;
//		energy = 0;
//		accuracy = 1;
//		energyHealed = 10;
//		hitPointsHealed = 10;
//		count = 10;
//		//base.Init();
//	}

	 void Awake()
	{
		itemName = "Daffodil";
//		setItemImage(Resources.Load <Sprite>("Enemies/Bear"));
		strength = 0;
		speed = 0;
		intelligence = 0;
		energy = 0;
		accuracy = 1;
		energyHealed = 10;
		hitPointsHealed = 10;
		tag = 1;
	}
	
}
