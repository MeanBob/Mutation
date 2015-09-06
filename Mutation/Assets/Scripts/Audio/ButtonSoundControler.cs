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
	public AudioClip openBook;
	public AudioClip closeBook;
	public AudioClip compasOpen;
	public AudioClip footsteps;

	public AudioSource buttons;

	public bool bookIsOpen = false;



	void Start () {
		buttons = GetComponent<AudioSource>();
	}

	public void OpenBook(float volume)
	{
			buttons.PlayOneShot (openBook, volume);
	}

	public void FootSteps(float volume)
	{
		buttons.PlayOneShot (footsteps, volume);
	}

	public void CompasOpen(float volume)
	{
		buttons.PlayOneShot (compasOpen, volume);
	}

	public void CloseBook(float volume)
	{
		buttons.PlayOneShot (closeBook, volume);
	}


	public void PlayFlute2(float volume)
	{
		buttons.PlayOneShot(flute2, volume);
	}
	public void PlayFlute3()
	{
		buttons.PlayOneShot(flute3, 0.4f);
	}
	public void PlayOpenBP()
	{
		buttons.PlayOneShot(openBP, 1.0f);
	}

	public void PlayFlute1(float volume)
	{
		buttons.PlayOneShot(flute1, volume);
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
