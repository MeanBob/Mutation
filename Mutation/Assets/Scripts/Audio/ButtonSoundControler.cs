using UnityEngine;
using System.Collections;

public class ButtonSoundControler : MonoBehaviour {

	public AudioClip drum1;
	public AudioClip drum2;
	public AudioClip drum3;
	public AudioClip flute1;
	public AudioClip flute2;
	public AudioClip flute3;
	public AudioClip openBP;


	public AudioSource buttons;



	void Start () {
		buttons = GetComponent<AudioSource>();
	}

	public void PlayFlute2()
	{
		buttons.PlayOneShot(flute2, 0.4f);
	}
	public void PlayFlute3()
	{
		buttons.PlayOneShot(flute3, 0.4f);
	}
	public void PlayOpenBP()
	{
		buttons.PlayOneShot(openBP, 1.0f);
	}

	public void PlayFlute1()
	{
		buttons.PlayOneShot(flute1, 0.4f);
	}

	public void PlayDrum3()
	{
		buttons.PlayOneShot(drum3);
	}

	public void PlayDrum2()
	{
		buttons.PlayOneShot(drum2);
	}

	public void PlayDrum1()
	{
		buttons.PlayOneShot(drum1);
	}


}
