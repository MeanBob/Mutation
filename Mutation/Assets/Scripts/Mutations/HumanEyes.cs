using UnityEngine;
using System.Collections;

public class HumanEyes : Mutation {

	// Use this for initialization
	public override void Init() {
        mutationName = "Dull Eyes";
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

