using UnityEngine;
using System.Collections;

public class CombatSFXAudioController : MonoBehaviour {

	public AudioClip monsterAttacking1;
	public AudioClip monsterHurt;
	public AudioClip playerSwinging;
	public AudioClip playerHitting;
	public AudioClip playerMissing;

	public AudioSource cSFX;

	// Use this for initialization
	void Start () {
		cSFX = GetComponent<AudioSource>();
	
	}

	public void PlayerHitting()
	{

		cSFX.PlayOneShot(playerHitting, 0.4f);
	}
	public void MonsterAttacking1()
	{
		cSFX.PlayOneShot(monsterAttacking1, 0.6f);
	}

	public void PlayerPlayerSwinging()
	{
		cSFX.PlayOneShot(playerSwinging, 0.9f);
	}

	public void PlayerPlayerMissing()
	{
		cSFX.PlayOneShot(playerMissing, 0.6f);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
