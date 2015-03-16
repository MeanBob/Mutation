using UnityEngine;
using System.Collections;

public class WolfMutation : MonoBehaviour {

	// Use this for initialization
	public override void Init() {
		mutationName = "Wolf";
		headMinDamage = 1;
		headMaxDamage = 8;
		armMinDamage = 1;
		armMaxDamage = 6;
		legMinDamage = 1;
		legMaxDamage = 6;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
