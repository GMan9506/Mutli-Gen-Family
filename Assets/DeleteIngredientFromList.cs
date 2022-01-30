using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIngredientFromList : MonoBehaviour
{
    [SerializeField]
    private GameObject _ingredientListContent;

    // delete all ingredients from the selected list
    public void DeleteAllIngredients()
    {
        PlaySound.OneShot(gameObject, null, 2);
        foreach (Transform child in _ingredientListContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
