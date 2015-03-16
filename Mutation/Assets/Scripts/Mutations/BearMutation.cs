using UnityEngine;
using System.Collections;

public class BearMutation : MonoBehaviour {

	// Use this for initialization
	public override void Init() {
		mutationName = "Bear";
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 10;
		legMinDamage = 1;
		legMaxDamage = 8;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
