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
        foreach (Transform child in _ingredientListContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
