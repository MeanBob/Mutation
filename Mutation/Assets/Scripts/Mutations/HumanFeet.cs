using UnityEngine;
using System.Collections;

public class HumanFeet : Mutation {

	// Use this for initialization
	public override void Init() {
        mutationName = "Soft Feet";
		accuracy = 0;
		strength = 0;
		intelligence = 0;
		speed = 0;
		energy = 0;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/HumanFeet"));
		base.Init();
  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

