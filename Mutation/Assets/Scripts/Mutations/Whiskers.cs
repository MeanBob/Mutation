using UnityEngine;
using System.Collections;

public class Whiskers : Mutation {
	
	public override void Init() {
		mutationName = "Whiskers +5 Int";
		
		accuracy = 0;
		speed = 0;
		strength = 0;
		intelligence = 5;
		energy = 0;
		
		mutationType = 2;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/Whiskers"));
		base.Init();
		
	}
	
}

