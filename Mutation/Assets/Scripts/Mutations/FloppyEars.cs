using UnityEngine;
using System.Collections;

public class FloppyEars : Mutation {

	public override void Init() {
        mutationName = "Floppy Ears +2 Acc";

		accuracy = 2;
		speed = 0;
		strength = 0;
		intelligence = 0;
		energy = 0;

		mutationType = 0;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/FloppyEars"));
		base.Init();
  
	}

}

