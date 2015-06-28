using UnityEngine;
using System.Collections;

public class BearMonster : Monster {

	CharacterPage playerCharacter;
	string [] monsterText = new string[4];
	public override void Start()
	{
		playerCharacter = GameObject.Find("Avatar").GetComponent<CharacterPage>();
		monsterText[0] = "A sudden blast of hot air and the disgusting stench of foul breath alert your senses. Before you know it, a hulking bear is standing on its hind legs, growling at you. \n\n";
		monsterText[1] = "You make out the haunches of a large beast up ahead. Suddenly the beast turns and holds you in its gaze. Its a bear, and as it rears around it stands up on its back legs.\n\n";
		monsterText[2] = "A bear stands in your path, its long sharp claws and glistening fangs make your stomach feel uneasy. When it roars at you, a blast of hot steam catches the afternoon light just so.\n\n";

		monsterText[3] = " You take hit the dirt and play dead, holding still until the bear loses interst and moves on.";
	}

	public override void Init()
	{
		monsterName = "Bear";

		strength = Random.Range (40,56);

		speed = Random.Range (14,60);
		intelligence = 5;

		energy = 10;

		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		headMinDamage = 57;
		headMaxDamage = 86;
		armMinDamage = 57;
		armMaxDamage = 77;
		legMinDamage = 57;
		legMaxDamage = 59;
		expPointsGained = 160;
		bonusDamage -= strength;
		
		base.Init();
	}
}
