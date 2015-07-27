using UnityEngine;
using System.Collections;

public class RabbitLegs : Mutation {

	public override void Init() {
        mutationName = "Springy Legs +5 Sp";

		accuracy = 0;
		speed = 5;
		strength = 0;
		intelligence = 0;
		energy = 0;

		mutationType = 9;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/RabbitLegs"));
		base.Init();
  
	}

}

