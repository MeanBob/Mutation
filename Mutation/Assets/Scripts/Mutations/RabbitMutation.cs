using UnityEngine;
using System.Collections;

public class RabbitMutation : Mutation {

	// Use this for initialization
	public override void Init() {
        mutationName = "Rabbit";
        headMinDamage = 1;
        headMaxDamage = 4;
        armMinDamage = 1;
        armMaxDamage = 2;
        legMinDamage = 1;
        legMaxDamage = 6;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
