using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class InventoryControl : MonoBehaviour {
	CharacterPage characterScript;
	List<Item> listOfItems;
	UnityEngine.UI.Button button;
	Item tempItem;

	public void useItem(int buttonValue)
	{
		tempItem = listOfItems[buttonValue];
		characterScript.SetStrength(tempItem.getStrength());
		characterScript.SetSpeed(tempItem.getSpeed());
		characterScript.SetAccuracy(tempItem.getAccuracy());
		characterScript.SetIntelligence(tempItem.getIntelligence());
		characterScript.SetEnergy(tempItem.getEnergy());
		characterScript.SetEnergyPoints(tempItem.getEnergyHealed());
		characterScript.SetHitPoints(tempItem.getHitPointsHealed());
	}


	public void callButton()
	{
		characterScript = GameObject.Find("Avatar").GetComponent<CharacterPage>();
		listOfItems = characterScript.returnList();
		for (int i = 0; i < listOfItems.Count; i++)
		{
			tempItem = listOfItems[i];
			string tempString = string.Concat("Buttons/Button ", i);
			button = transform.FindChild(tempString).GetComponent<UnityEngine.UI.Button>();
			button.GetComponentInChildren<Text>().text = tempItem.getName();
		}
	}
}
