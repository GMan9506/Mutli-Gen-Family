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
    [Header("Ingredients 6 - Suqash")]
    [Header("Ingredients 7 - Red Shroom")]
    [Header("Ingredients 8 - Yellow Shroom")]

    [Range(0, 8)]
    public int IngredientType = 0;
}
