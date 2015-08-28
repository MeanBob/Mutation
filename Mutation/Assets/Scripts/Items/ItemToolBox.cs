using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ItemToolBox : MonoBehaviour 
{
	public static List<GameObject> listOfItems = new List<GameObject>();
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
			temp.name = "Daffodil";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("SnakeMeat")))
				listOfItems.Add(temp);
			break;
		case 1:
			temp.AddComponent<Chloroform>();
			temp.name = "Chloroform";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("Chloroform")))
				listOfItems.Add(temp);
			break;
		case 2:
			temp.AddComponent<RabbitMeat>();
			temp.name = "RabbitMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("RabbitMeat")))
				listOfItems.Add(temp);
			break;
		case 3:
			temp.AddComponent<WolfMeat>();
			temp.name = "WolfMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("WolfMeat")))
				listOfItems.Add(temp);
			break;
		case 4:
			temp.AddComponent<BearMeat>();
			temp.name = "BearMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("BearMeat")))
				listOfItems.Add(temp);
			break;
		case 5:
			temp.AddComponent<SkunkMeat>();
			temp.name = "SkunkMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("SkunkMeat")))
				listOfItems.Add(temp);
			break;
		case 6:
			temp.AddComponent<SnakeMeat>();
			temp.name = "SnakeMeat";
			//If item already exists as part of the array, then only count of the item is increased
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("SnakeMeat")))
			   listOfItems.Add(temp);
			break;
		case 7:
			temp.AddComponent<GoatMeat>();
			temp.name = "GoatMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("GoatMeat")))
				listOfItems.Add(temp);

			break;
		case 8:
			temp.AddComponent<MooseMeat>();
			temp.name = "MooseMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("MooseMeat")))
				listOfItems.Add(temp);

			break;
		case 9:
			temp.AddComponent<BeaverMeat>();
			temp.name = "BeaverMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("BeaverMeat")))
				listOfItems.Add(temp);

			break;
		case 10:
			temp.AddComponent<CatMeat>();
			temp.name = "CatMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("CatMeat")))
				listOfItems.Add(temp);

			break;
		case 11:
			temp.AddComponent<DogMeat>();
			temp.name = "DogMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("DogMeat")))
				listOfItems.Add(temp);

			break;
		case 12:
			temp.AddComponent<BirdMeat>();
			temp.name = "BirdMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("BirdMeat")))
				listOfItems.Add(temp);

			break;
		case 13:
			temp.AddComponent<FrogMeat>();
			temp.name = "FrogMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("FrogMeat")))
				listOfItems.Add(temp);

			break;
		case 14:
			temp.AddComponent<AnteaterMeat>();
			temp.name = "AnteaterMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("AnteaterMeat")))
				listOfItems.Add(temp);

			break;
		case 15:
			temp.AddComponent<GiantAntMeat>();
			temp.name = "GiantAntMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("GiantAntMeat")))
				listOfItems.Add(temp);

			break;
		case 16:
			temp.AddComponent<PorcupineMeat>();
			temp.name = "PorcupineMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("PorcupineMeat")))
				listOfItems.Add(temp);

			break;

		case 17:
			temp.AddComponent<NashMeat>();
			temp.name = "NashMeat";
			if(!(ItemToolBox.CheckIfItemExistsAtIndex("NashMeat")))
				listOfItems.Add(temp);
			
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