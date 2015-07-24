using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemToolBox : MonoBehaviour 
{
	public static List<GameObject> listOfItems = new List<GameObject>();
	public static int count = 0;
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
			ItemToolBox.CheckIfItemExistsAtIndex("Daffodil");
			listOfItems.Add(temp);
			temp.name = "Daffodil";

			break;
		case 1:
			temp.AddComponent<Chloroform>();
			listOfItems.Add(temp);
			temp.name = "Chloroform";
			break;
		case 2:
			temp.AddComponent<RabbitMeat>();
			listOfItems.Add(temp);
			temp.name = "RabbitMeat";
			break;
		case 3:
			temp.AddComponent<WolfMeat>();
			listOfItems.Add(temp);
			temp.name = "WolfMeat";
			break;
		case 4:
			temp.AddComponent<BearMeat>();
			listOfItems.Add(temp);
			temp.name = "BearMeat";
			break;
		case 5:
			temp.AddComponent<SkunkMeat>();
			listOfItems.Add(temp);
			temp.name = "SkunkMeat";
			break;
		case 6:
			temp.AddComponent<SnakeMeat>();
			temp.name = "SnakeMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("SnakeMeat")))
			   listOfItems.Add(temp);
			break;
		case 7:
			temp.AddComponent<GoatMeat>();
			listOfItems.Add(temp);
			temp.name = "GoatMeat";
			break;
		case 8:
			temp.AddComponent<MooseMeat>();
			listOfItems.Add(temp);
			temp.name = "MooseMeat";
			break;
		case 9:
			temp.AddComponent<BeaverMeat>();
			listOfItems.Add(temp);
			temp.name = "BeaverMeat";
			break;
		case 10:
			temp.AddComponent<CatMeat>();
			listOfItems.Add(temp);
			temp.name = "CatMeat";
			break;
		case 11:
			temp.AddComponent<DogMeat>();
			listOfItems.Add(temp);
			temp.name = "DogMeat";
			break;
		case 12:
			temp.AddComponent<BirdMeat>();
			listOfItems.Add(temp);
			temp.name = "BirdMeat";
			break;
		case 13:
			temp.AddComponent<FrogMeat>();
//			temp.tag = "FrogMeat";
			temp.name = "FrogMeat";
			listOfItems.Add(temp);
			break;
		case 14:
			temp.AddComponent<AnteaterMeat>();
			listOfItems.Add(temp);
			temp.name = "AnteaterMeat";
			break;
		case 15:
			temp.AddComponent<GiantAntMeat>();
			listOfItems.Add(temp);
			temp.name = "GiantAntMeat";
			break;
		case 16:
			temp.AddComponent<PorcupineMeat>();
			listOfItems.Add(temp);
			temp.name = "PorcupineMeat";
			break;
		}
	}

	public static bool CheckIfItemExistsAtIndex(string itemName)
	{
		foreach( GameObject o in ItemToolBox.listOfItems )
		{
			if(o.name == itemName)
			{
				Item t = o.GetComponent<Item>();
				t.setCount(t.getCount()+1);
				Debug.Log("Item frickin count:::::"+t.getCount());
				return true;
			}

		}
				return false;

	}
	public void Play()
	{
		//Play some audio!
	}
}