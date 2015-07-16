using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollItem : MonoBehaviour
{
    #region PUBLIC_VARIABLES
    public Text indexText;
    public DynamicScrollView dynamicScrollView;
	UnityEngine.UI.Image itemImage;
    #endregion

    #region PRIVATE_VARIABLES
	[HideInInspector]public int count;

    #endregion

    #region UNITY_CALLBACKS

	void Start()
	{
//		itemImage = transform.FindChild("InventoryPanel/Panel - Content/Item/Item - Button").GetComponent<UnityEngine.UI.Image>();
	}

    void OnEnable()
    {
        indexText.text = transform.name;

			
		UnityEngine.UI.Image itemImage;
		
    }
    #endregion

    #region PUBLIC_METHODS
	public void setCount(int count)
	{
		count = count;
	}
	public int getCount()
	{
		return count;
	}
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region PRIVATE_COROUTINES
    #endregion

    #region DELEGATES_CALLBACKS
    #endregion

    #region UI_CALLBACKS
    public void OnRemoveMe()
    {
        DestroyImmediate(gameObject);
        dynamicScrollView.SetContentHeight();
    }
    #endregion


}
