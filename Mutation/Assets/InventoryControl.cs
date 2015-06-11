using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class InventoryControl : MonoBehaviour {
	CharacterPage characterScript;
	List<Item> listOfItems;
	UnityEngine.UI.Button button;
	Item tempItem;

	//Using item changes the attributes of the character
	public void useItem(int buttonValue)
	{
		tempItem = listOfItems[buttonValue];

		if(tempItem.getCount() > 0){
			tempItem.setCount(-1);
			characterScript.SetStrength(tempItem.getStrength());
			characterScript.SetSpeed(tempItem.getSpeed());
			characterScript.SetAccuracy(tempItem.getAccuracy());
			characterScript.SetIntelligence(tempItem.getIntelligence());
			characterScript.SetEnergy(tempItem.getEnergy());
			characterScript.SetEnergyPoints(tempItem.getEnergyHealed());
			characterScript.SetHitPoints(tempItem.getHitPointsHealed());
//			button[buttonValue].text = tempItem.getCount().ToString();
			string tempString = string.Concat("Buttons/Inventory Item ", buttonValue);
			button = transform.FindChild(tempString).GetComponent<UnityEngine.UI.Button>();
			UnityEngine.UI.Text[] buttonText = button.GetComponentsInChildren<Text>();
			buttonText[1].text = tempItem.getCount().ToString();
		} else {
			button.enabled = false;
		}
	}

	//Turns button in inventory panel to a particular item
	public void callButton()
	{
		characterScript = GameObject.Find("Avatar").GetComponent<CharacterPage>();
		listOfItems = characterScript.returnList();
		for (int i = 0; i < listOfItems.Count; i++)
		{
			tempItem = listOfItems[i];
			string tempString = string.Concat("Buttons/Inventory Item ", i);
			button = transform.FindChild(tempString).GetComponent<UnityEngine.UI.Button>();
			UnityEngine.UI.Text[] buttonText = button.GetComponentsInChildren<Text>();
			buttonText[0].text = tempItem.getName();
			buttonText[1].text = tempItem.getCount().ToString();
		}
	}
}
