using UnityEngine;
using System.Collections;

public class HumanTail : Mutation {

	// Use this for initialization
	public override void Init() {
        mutationName = "Tail Bone";
		accuracy = 0;
		strength = 0;
		intelligence = 0;
		speed = 0;
		energy = 0;
		setMutationImage(Resources.Load <Sprite>("AvatarAndMutations/HumanBlank"));
		base.Init();
  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

