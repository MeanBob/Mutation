using UnityEngine;
using System.Collections;

public class IntroPlay : MonoBehaviour {
	public bool introOneActive;
	Animator start;
	// Use this for initialization


	void Start () {
		start = GameObject.Find("Canvas").GetComponent<Animator> ();

		start.Play ("StartPulse");
	}
	public void BeginIntro()
	{

		start.Play ("Intro1");
	}
	public void PlayIntro2()
	{
		start.Play ("Intro2");
	}
	public void PlayIntroEnd()
	{
		start.Play ("None");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
