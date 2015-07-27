using UnityEngine;
using System.Collections;

public class NoMutation : Mutation {

	// Use this for initialization
    public override void Init()
    {
        mutationName = "None";
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
