using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AutoType : MonoBehaviour {
	
	public float letterPause = 0.2f;
	//public AudioClip sound;
	
	public UnityEngine.UI.Text introStory;
	
	// Use this for initialization
	void Start () {
		introStory = GameObject.Find("IntroStoryPanel/Text").gameObject.GetComponent<UnityEngine.UI.Text>();
		introStory.text = "Many years ago the western United States were obliterated by the Nuclear weaponry of World War 4.\n\nBut that was many years ago. \n\nYou have lived in the Yosemite valley all your life. You love it, and call it your home. At least, you used to...\n\nThat is, until NASTY NASH, the pig-fucking cyborg swine farmer, banished your family, and outlawed your name from all forms of speech.\nNow you must wander the landscape of a mutated Yosemite - a blacktop of venomous, dangerous, even horrific things - and protect yourself from foreboding lurkers.\n\nOh, how your bones tremble at the thought of...\n\nREVENGE";
		StartCoroutine(TypeText ());

	}

	
	IEnumerator TypeText () {
		foreach (char letter in introStory.text.ToCharArray()) {
			introStory.text += letter;
			//if (sound)
				//audio.PlayOneShot (sound);
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
	}
}