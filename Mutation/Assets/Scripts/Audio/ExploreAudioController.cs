using UnityEngine;
using System.Collections;

public class ExploreAudioController : MonoBehaviour {
	
	public AudioClip explore1;
	public AudioSource exploreSong;

	
	
	
	void Start () {
		exploreSong = GetComponent<AudioSource>();
		PlayExploreLoop ();
	}
	
	public void PlayExploreLoop()
	{

		exploreSong.loop = true;
		exploreSong.clip = explore1;
		exploreSong.Play ();

	}

	public void QuietExplore()
	{
		exploreSong.loop = false;
		exploreSong.clip = explore1;
		exploreSong.Stop ();
	}

	
	
}
