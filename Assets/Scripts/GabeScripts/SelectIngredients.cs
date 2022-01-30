using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectIngredients : MonoBehaviour
{
    public static SelectIngredients instance;


    public List<Recipies> Recipies;
    List<int> currentRecipie;

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
        if (SelectedItems.Length >= 2)
        {
            List<int> newIngredientList = new List<int>();
            foreach (Ingredients I in SelectedItems)
            {
                newIngredientList.Add(I.IngredientType);
            }
            newIngredientList.Sort((I1, I2) => I1.CompareTo(I2));


            for (int i = 0; i < currentRecipie.Count; i++)
            {
                if (currentRecipie[i] != newIngredientList[i])
                    return;
            }
            //ChangePhase(currentPhase++);
            GameManager.instance.MinigameCompleted();   
            GameManager1.completed("minigame0");
        }

    }

    void ChangePhase(int NextPhase)
    {
        currentPhase = NextPhase;

        List<int> RequiredRecipie = Recipies[currentPhase].IngredientList;
        RequiredRecipie.Sort((I1, I2) => I1.CompareTo(I2));
        currentRecipie = RequiredRecipie;

        switch (currentPhase)
        {
            case 0:
                //play dialogue between each scene        
                PlaySound.OneShot(gameObject,null, 0);
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
                GameManager.instance.MinigameCompleted();
                break;
        }
    }
}
