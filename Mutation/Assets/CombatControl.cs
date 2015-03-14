using UnityEngine;
using System.Collections;

public class CombatControl : MonoBehaviour {
    UIControl ui;

	// Use this for initialization
	void Start () {
        ui = GetComponent<UIControl>();
	
	}
	
	// Update is called once per frame
	void Update () {
	    //We'll need to do something that involves the combat timers here
        //as well as enemy attacks.
	}

    public void DEBUGKILLENEMY()
    {
        ui.EndCombat();
    }

    public void DEBUGKILLPLAYER()
    {
    }
}
