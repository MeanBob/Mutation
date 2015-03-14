using UnityEngine;
using System.Collections;

public class Node : ScriptableObject {
    string description;
    //Special event?
    //Random chance?

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddDescription(string newDescription)
    {
        description = newDescription;
    }

    public string GetDescription()
    {
        return description;
    }
}
