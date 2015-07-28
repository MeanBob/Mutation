using UnityEngine;
using System.Collections;

public class CombatAudioController : MonoBehaviour {
	
	public AudioClip combat1;
	public AudioSource combatSong;

	void Start () {
		combatSong = GetComponent<AudioSource>();
		}
	
	public void PlayCombatLoop()
	{
		
		combatSong.loop = true;
		combatSong.clip = combat1;
		combatSong.Play ();
		
	}
	
	public void QuietCombat()
	{
		combatSong.loop = false;
		combatSong.clip = combat1;
		combatSong.Stop ();
	}
	
	
	
}
