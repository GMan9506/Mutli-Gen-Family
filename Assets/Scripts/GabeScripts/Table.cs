using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table instance;
    public bool RandSpawn = false;

    //slots and objects must be int he same order comparativey
    public List<GameObject> SlotPrefabs = new List<GameObject>();
    public List<GameObject> ObjectPrefabs = new List<GameObject>();

    public List<Transform> SlotSpawnpoints;
    public List<Transform> ObjectSpawnpoints;

    int maxSlots = 6;
    [SerializeField] List<ObjectSlot> SlotList = new List<ObjectSlot>();
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        if(RandSpawn)
        { SpawnPrefabs(); }
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            int spawnInt = Random.Range(0, SlotPrefabs.Count);
            SlotList.Add(GameObject.Instantiate(SlotPrefabs[spawnInt], SlotSpawnpoints[i].position,Quaternion.identity).GetComponent<ObjectSlot>());
            GameObject.Instantiate(ObjectPrefabs[spawnInt], ObjectSpawnpoints[i].position, Quaternion.identity);
        }
    }

   public void CheckSlotsCondition()
    {
        foreach(ObjectSlot fSlot in SlotList)
            if (!fSlot.isCorrect)
                return;
        
        Debug.Log("All spaces have been filled!");
    }
}
