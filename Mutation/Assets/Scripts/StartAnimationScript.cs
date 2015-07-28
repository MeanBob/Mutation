using UnityEngine;
using System.Collections;

public class StartAnimationScript : MonoBehaviour {
	public Animator start;
	// Use this for initialization
	void Start () {
		start = GetComponent<Animator> ();
	}
	void Awake()
	{
		start.Play ("StartAnimation");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
