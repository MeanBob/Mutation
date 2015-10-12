using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 1; i++){
			GameObject newDude = Instantiate(playerPrefab, Vector3.right * i * 2, Quaternion.identity) as GameObject;
			 if(i==0){
				newDude.name  = Game.current.currentCharacter.name;
			}

		}
	}

}
