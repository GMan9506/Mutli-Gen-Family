using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIngredients : MonoBehaviour
{
    public static SelectIngredients instance;

    public Recipies Recipie;

    int currentPhase = 0;
    public GameObject container1;
    public GameObject container2;
    public GameObject container3;

    private void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
        ChangePhase(0);
    }

    public void CheckRecipie(Ingredients[] SelectedItems)
    {
        List<Ingredients> CompareList = new List<Ingredients>(SelectedItems);
    }

    void ChangePhase(int NextPhase)
    {
        currentPhase = NextPhase;
        switch (currentPhase)
        {
            case 0:
                //play dialogue between each scene
                container1.SetActive(false);
                break;
            case 1:
                container1.SetActive(true);
                container2.SetActive(false);
                break;
            case 2:
                container2.SetActive(true);
                container3.SetActive(false);
                break;
            case 3:
                break;
        }
    }
}
