using UnityEngine;
using System.Collections;

public class BushyTail : Mutation {
	
	public override void Init() {
		mutationName = "Bushy Tail +2 E";
		
		accuracy = 0;
		speed = 5;
		strength = 0;
		intelligence = 0;
		energy = 2;
		
		mutationType = 6;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/BushyTail"));
		base.Init();
		
	}
	
}

