using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    [Header("Ingredients 0 - carrot")]
    [Header("Ingredients 1 - Cheese")]
    [Header("Ingredients 2 - Sausage")]
    [Header("Ingredients 3 - Salt")]
    [Header("Ingredients 4 - Pepper")]
    [Header("Ingredients 5 - Pasta")]

    [Range(0, 5)]
    public int IngredientType = 0;
}
