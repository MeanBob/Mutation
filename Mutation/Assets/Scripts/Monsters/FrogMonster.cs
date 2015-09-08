using UnityEngine;
using System.Collections;

public class FrogMonster : Monster {

	string[] monsterText = new string[5];

	public override void Start()
	{
		
		// index 0,1,2 are for encuontering the monster when you make the fight or hide choice
		monsterText [0] = "Two bugging eyes catch your attention. Lo and behold, a giant, green frog!";
		monsterText [1] = "You suddenly feel a wet <i>thwat</i> against your neck! What could it be!?";
		monsterText [2] = "Suddenly a booming croak blasts right behind you!";	
		// index 3 is for hiding
		monsterText [3] = "You take a few step back and are suddenly very far from the frog.";
		monsterText [4] = "The frog collapses in exhaustion and defeat! You won!";
		//droppedItemsList = new Item[]{ new Daffodil (),new Chloroform (),new RabbitMeat ()};
	}
	public override void Init()
	{
		monsterMeatID = 13;
		monsterName = "Frog";
		expPointsGained = Random.Range(30 , 40);
		monsterDescription = monsterText[Random.Range(0,3)];
		hideDescription = monsterText[3];
		victoryText = monsterText[4];
		setMonsterImage(Resources.Load <Sprite>("Enemies/Frog"));
		strength = Random.Range(4,8);
		speed = Random.Range(20, 40);
		intelligence = 5;
		energy = 10;
		
		//itemReleased = droppedItemsList[Random.Range(0,3)];
		headMinDamage = 4;
		headMaxDamage = 6;
		armMinDamage = 1;
		armMaxDamage = 1;
		legMinDamage = 3;
		legMaxDamage = 4;
		bonusDamage = 0;
		
		base.Init();
	}
	
}