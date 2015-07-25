using UnityEngine;
using System.Collections;

public class SoundControler : MonoBehaviour {
	//[RequireComponent(typeof(AudioSource))]
	public AudioClip drum1;
	public AudioClip drum2;
	public AudioClip drum3;
	public AudioClip flute1;
	public AudioClip flute2;
	public AudioClip flute3;
	public AudioClip flute4;
	public AudioClip levelUp;


	public AudioClip singingLoop;
	AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
		audioPlayer = GetComponent<AudioSource>();
		//PlayVoice();

	}
	public void PlayLevelUp()
	{
		//audioPlayer.PlayOneShot(levelUp, 0.7f);
	}

	public void PlayFlute2()
	{
		audioPlayer.PlayOneShot(flute2, 0.4f);
	}
	public void PlayFlute3()
	{
		audioPlayer.PlayOneShot(flute3, 0.4f);
	}
	public void PlayFlute4()
	{
		audioPlayer.PlayOneShot(flute4, 0.4f);
	}




	public void PlayFlute1()
	{
		audioPlayer.PlayOneShot(flute1, 0.4f);
	}

	public void PlayDrum3()
	{
		audioPlayer.PlayOneShot(drum3);
	}

	public void PlayDrum2()
	{
		audioPlayer.PlayOneShot(drum2);
	}

	public void PlayDrum1()
	{
		audioPlayer.PlayOneShot(drum1);
	}
	public void PlayVoice()
	{
		audioPlayer.PlayOneShot(singingLoop, 0.4f);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
