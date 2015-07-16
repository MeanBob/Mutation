using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DynamicScrollView : MonoBehaviour
{

    #region PUBLIC_VARIABLES
    public int noOfItems;

    public GameObject item;


    public GridLayoutGroup gridLayout;

    public RectTransform scrollContent;

    public ScrollRect scrollRect;

	public CharacterPage characterAttributes;
    #endregion

    #region PRIVATE_VARIABLES
    #endregion

    #region UNITY_CALLBACKS


    void OnEnable()
    {
		//Debug.Log("checking for inteventoryr singleton" + ItemToolBox.count);
        InitializeList();

    }
    #endregion

    #region PUBLIC_METHODS
    #endregion

    #region PRIVATE_METHODS



    private void ClearOldElement()
    {
        for (int i = 0; i < gridLayout.transform.childCount; i++)
        {
            Destroy(gridLayout.transform.GetChild(i).gameObject);
        }
    }


    public void SetContentHeight()
    {
        float scrollContentHeight = (gridLayout.transform.childCount * gridLayout.cellSize.y) + ((gridLayout.transform.childCount) * gridLayout.spacing.y) ;
        scrollContent.sizeDelta = new Vector2(400, scrollContentHeight);
    }

    private void InitializeList()
    {
        ClearOldElement();
		for(int i=0; i < ItemToolBox.listOfItems.Count; i++)
		{
			InitializeNewItem(ItemToolBox.listOfItems[i]);

		}

        SetContentHeight();
    }

    private void InitializeNewItem(GameObject selectedItem)
    {
		GameObject newItem = Instantiate(item) as GameObject;
		Item itemInsideGameObject = selectedItem.GetComponentInChildren<Item>();
		ScrollItem play = newItem.GetComponent<ScrollItem>();
		play.setCount(itemInsideGameObject.getCount());
		Button example;
		//Debug.Log("Count of scroll item ::::::"+itemInsideGameObject.getCount());

		switch (itemInsideGameObject.tag)
		{
		case 0:

			newItem.AddComponent<Daffodil> ();
			play.name = "Daffodil";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerDaffodil";
			//Setting the button name
			example.GetComponentInChildren<Text>().text = "Daffodil";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));

			//Add image for each item - make sure they are squares
			//example.image.sprite = Resources.Load <Sprite>("Enemies/Bunny");
			break;
		case 1:
			newItem.AddComponent<Chloroform> ();
			
			play.name = "Chloroform";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerChloroform";
			example.GetComponentInChildren<Text>().text = "Chloroform";
			
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			//example.image.sprite = Resources.Load <Sprite>("Items/Meat2");
			
			break;
		case 2:
			newItem.AddComponent<RabbitMeat> ();
			
			play.name = "RabbitMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerRabbitMeat";
			example.GetComponentInChildren<Text>().text = "RabbitMeat";
			
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat1");
			
			
			break;
		case 3:
			newItem.AddComponent<WolfMeat> ();
			play.name = "WolfMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerWoldMeat";
			example.GetComponentInChildren<Text>().text = "WolfMeat";
			example.image.sprite = Resources.Load <Sprite>("Items/Meat3");
			
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			break;
		case 4:
			newItem.AddComponent<BearMeat> ();

			play.name = "BearMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerBearMeat";
			example.GetComponentInChildren<Text>().text = "BearMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat2");

			break;

		case 5:
			newItem.AddComponent<SkunkMeat> ();
			
			play.name = "SkunkMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerSkunkMeat";
			example.GetComponentInChildren<Text>().text = "SkunkMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat2");
			break;
		case 6:
			newItem.AddComponent<SnakeMeat> ();
			
			play.name = "SnakeMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerSnakeMeat";
			example.GetComponentInChildren<Text>().text = "SnakeMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat1");
			break;


			
		case 7:
			newItem.AddComponent<GoatMeat> ();
			
			play.name = "GoatMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerGoatMeat";
			example.GetComponentInChildren<Text>().text = "GoatMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat3");
			break;

		case 8:
			newItem.AddComponent<MooseMeat> ();
			
			play.name = "MooseMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerMooseMeat";
			example.GetComponentInChildren<Text>().text = "MooseMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat3");
			break;
			////
		case 9:
			newItem.AddComponent<BeaverMeat> ();
			
			play.name = "BeaverMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerBeaverMeat";
			example.GetComponentInChildren<Text>().text = "BeaverMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat1");
			break;

		case 10:
			newItem.AddComponent<CatMeat> ();
			
			play.name = "CatMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerCatMeat";
			example.GetComponentInChildren<Text>().text = "CatMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat2");
			break;
		case 11:
			newItem.AddComponent<DogMeat> ();
			
			play.name = "DogMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerDogMeat";
			example.GetComponentInChildren<Text>().text = "DogMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat3");
			break;
		case 12:
			newItem.AddComponent<BirdMeat> ();
			
			play.name = "BirdMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerBirdMeat";
			example.GetComponentInChildren<Text>().text = "BirdMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat1");
			break;
		case 13:
			newItem.AddComponent<FrogMeat> ();
			
			play.name = "FrogMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerFrogMeat";
			example.GetComponentInChildren<Text>().text = "FrogMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat2");
			break;
		case 14:
			newItem.AddComponent<GoatMeat> ();
			
			play.name = "AnteaterMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerAnteaterMeat";
			example.GetComponentInChildren<Text>().text = "AnteaterMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat3");
			break;
		case 15:
			newItem.AddComponent<GoatMeat> ();
			
			play.name = "GiantAntMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerGiantAntMeat";
			example.GetComponentInChildren<Text>().text = "GiantAntMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat1");
			break;
		case 16:
			newItem.AddComponent<GoatMeat> ();
			
			play.name = "PorcupineMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerPorcupineMeat";
			example.GetComponentInChildren<Text>().text = "PorcupineMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			example.image.sprite = Resources.Load <Sprite>("Items/Meat2");
			break;
			
		}

		//Debug.Log (newItem+tempItem);
        newItem.transform.parent = gridLayout.transform;
        newItem.transform.localScale = Vector3.one ;
        newItem.SetActive(true);
    }
    #endregion

    #region PRIVATE_COROUTINES
    private IEnumerator MoveTowardsTarget(float time,float from,float target) {
        float i = 0;
        float rate = 1 / time;
        while(i<1)
		{
            i += rate * Time.deltaTime;
            scrollRect.verticalNormalizedPosition = Mathf.Lerp(from,target,i);
            yield return 0;
        }
    }
    #endregion

    #region DELEGATES_CALLBACKS
    #endregion

    #region UI_CALLBACKS
//    public void AddNewElement()
//    {
//        InitializeNewItem("" + (gridLayout.transform.childCount + 1));
//        SetContentHeight();
//        StartCoroutine(MoveTowardsTarget(0.2f, scrollRect.verticalNormalizedPosition, 0));
//    }
    #endregion

	public void useItem(Item selectedItem, ref ScrollItem selectedScrollItem)
	{

		Debug.Log ("Count of selected Scroll item :"+selectedScrollItem.count);
		Debug.Log ("Count of Item tool box :"+ItemToolBox.count);
		selectedScrollItem.count--;
		ItemToolBox.count--;


		characterAttributes.SetStrength(selectedItem.getStrength());
		characterAttributes.SetSpeed(selectedItem.getSpeed());
		characterAttributes.SetAccuracy(selectedItem.getAccuracy());
		characterAttributes.SetIntelligence(selectedItem.getIntelligence());
		characterAttributes.SetEnergy(selectedItem.getEnergy());
		characterAttributes.SetEnergyPoints(selectedItem.getEnergyHealed());
		characterAttributes.SetHitPoints(selectedItem.getHitPointsHealed());


		if (selectedScrollItem.count <= 0)
			selectedScrollItem.OnRemoveMe ();
		Debug.Log ("Count of selected Scroll item :"+selectedScrollItem.count);
		Debug.Log ("Count of Item tool box :"+ItemToolBox.count);
	}

}
