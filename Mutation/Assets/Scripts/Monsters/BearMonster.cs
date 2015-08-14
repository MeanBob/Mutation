using UnityEngine;
using System.Collections;

public class BearMonster : Monster {


	string [] monsterText = new string[5];



	public override void Start()
	{

		//meeting the bear
		monsterText[0] = "A sudden blast of hot air and the disgusting stench of foul breath alert your senses. Before you know it, a hulking bear is standing on its hind legs, growling at you. \n\n";
		monsterText[1] = "You make out the haunches of a large beast up ahead. Suddenly the beast turns and holds you in its gaze. It's a bear, and as it rears around it stands up on its back legs.\n\n";
		monsterText[2] = "A bear stands in your path, its long sharp claws and glistening fangs make your stomach feel uneasy. When it roars at you, a blast of hot steam catches the afternoon light just so.\n\n";
		//hiding from the bear
		monsterText[3] = " You hit the dirt and play dead, holding still until the bear loses interst and moves on.";

		monsterText[4] = "The bear roars in terror as you deliver the final blow. Mighty defeat!";
	}

	public override void Init()
	{
		monsterName = "Bear";
		setMonsterImage(Resources.Load <Sprite>("Enemies/Bear"));

		monsterMeatID = 4;

		strength = Random.Range (60,65);

		speed = Random.Range (35,50);
		intelligence = 5;

		energy = 10;

		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];

		headMinDamage = 15;
		headMaxDamage = 30;

		armMinDamage = 20;
		armMaxDamage = 25;

		legMinDamage = 15;
		legMaxDamage = 30;

		expPointsGained = Random.Range(250, 350);

		bonusDamage = 0;
		
		base.Init();
	}
}
