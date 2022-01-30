using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCannon : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    public int numObjectsSpawning = 20;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numObjectsSpawning; i++)
        {
            int spawnInt = Random.Range(0, ObjectPrefabs.Length);
            GameObject.Instantiate(ObjectPrefabs[spawnInt], transform.position, Quaternion.identity);
        }
    }
}
