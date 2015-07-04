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

		InitializeNewItem(0);
		InitializeNewItem(1);
		InitializeNewItem(2);
		InitializeNewItem(3);
		InitializeNewItem(4);

        SetContentHeight();
    }

    private void InitializeNewItem(int number)
    {
        GameObject newItem = Instantiate(item) as GameObject;
		ScrollItem play = newItem.GetComponent<ScrollItem>();
		Button example;

		switch (number)
		{
		case 0:

			newItem.AddComponent<Daffodil> ();
			play.name = "Daffodil";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerDaffodil";
			//Setting the button name
			example.GetComponentInChildren<Text>().text = "Daffodil";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
			break;
		case 1:
			newItem.AddComponent<BearMeat> ();

			play.name = "BearMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerBearMeat";
			example.GetComponentInChildren<Text>().text = "BearMeat";
			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));

			break;
		case 2:
			newItem.AddComponent<Chloroform> ();

			play.name = "Chloroform";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerChloroform";
			example.GetComponentInChildren<Text>().text = "Chloroform";

			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));

			break;
		case 3:
			newItem.AddComponent<RabbitMeat> ();

			play.name = "RabbitMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerRabbitMeat";
			example.GetComponentInChildren<Text>().text = "RabbitMeat";

			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));

			break;
		case 4:
			newItem.AddComponent<WolfMeat> ();
			play.name = "WolfMeat";
			example = play.GetComponentInChildren<Button>();
			example.name = "InnerWoldMeat";
			example.GetComponentInChildren<Text>().text = "WolfMeat";

			example.onClick.AddListener( ()=> useItem(newItem.GetComponent<Item>(), ref play));
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
		selectedScrollItem.count--;
		if (selectedScrollItem.count <= 0)
			selectedScrollItem.OnRemoveMe ();
		Debug.Log (selectedItem);
		characterAttributes.SetStrength(selectedItem.getStrength());
		characterAttributes.SetSpeed(selectedItem.getSpeed());
		characterAttributes.SetAccuracy(selectedItem.getAccuracy());
		characterAttributes.SetIntelligence(selectedItem.getIntelligence());
		characterAttributes.SetEnergy(selectedItem.getEnergy());
		characterAttributes.SetEnergyPoints(selectedItem.getEnergyHealed());
		characterAttributes.SetHitPoints(selectedItem.getHitPointsHealed());
	}

}
