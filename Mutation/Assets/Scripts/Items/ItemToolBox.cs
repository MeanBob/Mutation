using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemToolBox : MonoBehaviour 
{
	public static List<GameObject> listOfItems = new List<GameObject>();
	public static int count = 5;
	//We make a static variable to our MusicManager instance
	public static ItemToolBox instance { get; private set; }
	public static GameObject gameObjectItem;
	//When the object awakens, we assign the static variable
	void Awake() 
	{
		instance = this;
	}

	public static void AddItem(int monsterMeatID)
	{
		GameObject temp = new GameObject();
		switch (monsterMeatID)
		{

		case 0:
			temp.AddComponent<Daffodil>();
			listOfItems.Add(temp);

			break;
		case 1:
			temp.AddComponent<Chloroform>();
			listOfItems.Add(temp);
			break;
		case 2:
			temp.AddComponent<RabbitMeat>();
			listOfItems.Add(temp);
			break;
		case 3:
			temp.AddComponent<WolfMeat>();
			listOfItems.Add(temp);
			break;
		case 4:
			temp.AddComponent<BearMeat>();
			listOfItems.Add(temp);
			break;
		case 5:
			temp.AddComponent<SkunkMeat>();
			listOfItems.Add(temp);
			break;
		case 6:
			temp.AddComponent<SnakeMeat>();
			listOfItems.Add(temp);
			break;
		case 7:
			temp.AddComponent<GoatMeat>();
			listOfItems.Add(temp);
			break;
		case 8:
			temp.AddComponent<MooseMeat>();
			listOfItems.Add(temp);
			break;
		case 9:
			temp.AddComponent<BeaverMeat>();
			listOfItems.Add(temp);
			break;
		case 10:
			temp.AddComponent<CatMeat>();
			listOfItems.Add(temp);
			break;
		case 11:
			temp.AddComponent<DogMeat>();
			listOfItems.Add(temp);
			break;
		case 12:
			temp.AddComponent<BirdMeat>();
			listOfItems.Add(temp);
			break;
		case 13:
			temp.AddComponent<FrogMeat>();
			listOfItems.Add(temp);
			break;
		case 14:
			temp.AddComponent<AnteaterMeat>();
			listOfItems.Add(temp);
			break;
		case 15:
			temp.AddComponent<GiantAntMeat>();
			listOfItems.Add(temp);
			break;
		case 16:
			temp.AddComponent<PorcupineMeat>();
			listOfItems.Add(temp);
			break;
		}
	}

	public void Play()
	{
		//Play some audio!
	}
}