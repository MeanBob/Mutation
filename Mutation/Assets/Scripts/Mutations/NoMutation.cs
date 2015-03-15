using UnityEngine;
using System.Collections;

public class NoMutation : Mutation {

	// Use this for initialization
    void Start()
    {
        mutationName = "None";
        headMinDamage = 1;
        headMaxDamage = 2;
        armMinDamage = 1;
        armMaxDamage = 6;
        legMinDamage = 1;
        legMaxDamage = 6;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
