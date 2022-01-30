using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AirFishLab.ScrollingList;

public class SelectAndAddIngredients : MonoBehaviour
{
    [SerializeField]
    private int _maxItems;

    [SerializeField]
    private GameObject _ingredientListContent;

    [SerializeField]
    private CircularScrollingList _list;

    private int counter;

    public void GetSelectedContentID(int selectedContentID)
    {
        var data = (DataWrapper)_list.listBank.GetListContent(selectedContentID);
        Image content = (Image)data.value;
        //Debug.Log("Selected content ID: " + selectedContentID + ", Content: " + content);
        

        //GameObject listViewpoint = _ingredientlist.transform.Find("Viewpoint").gameObject;
        //GameObject listContent = listViewpoint.transform.Find("Content").gameObject;
        //Image newImage = _ingredientListContent.AddComponent<Image>() as Image;

        // reset the counter if there are no child objects on the ingredient list content object
        if (_ingredientListContent.transform.childCount == 0)
        {
            counter = 0;
        }
        // add more ingredients to the selected ingredient list until the max items has been reached
        if (counter < _maxItems)
        {
            Instantiate(content, _ingredientListContent.transform);
            counter ++;
        }
        PlaySound.OneShot(gameObject, null, 1);
        SelectIngredients.instance.CheckRecipie(_ingredientListContent.transform.GetComponentsInChildren<Ingredients>());
    }
}
