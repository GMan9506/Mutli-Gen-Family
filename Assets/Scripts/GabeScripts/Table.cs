using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Table : MonoBehaviour
{
    public static Table instance;
    public bool RandSpawn = false;

    //slots and objects must be int he same order comparativey
    public List<GameObject> SlotPrefabs = new List<GameObject>();
    public List<GameObject> ObjectPrefabs = new List<GameObject>();

    public List<Transform> SlotSpawnpoints;
    public List<Transform> ObjectSpawnpoints;

    public List<GameObject> utensils;

    int maxSlots = 10;

    [SerializeField] List<ObjectSlot> SlotList = new List<ObjectSlot>();
    // Start is called before the first frame update
    void Start()
    {
        
        utensils = new List<GameObject>();
       
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
                        utensils.Add(GameObject.Instantiate(ObjectPrefabs[spawnInt], ObjectSpawnpoints[i].position, Quaternion.identity));
        }
    }

   public void CheckSlotsCondition()
    {
        foreach(ObjectSlot fSlot in SlotList)
            if (!fSlot.isCorrect)
                return;

        GameManager.instance.MinigameCompleted();

        Debug.Log("Gabe game done");
        if(!RandSpawn) {
        GameManager1.completed("minigame3");
                Debug.Log("Gabe game 3 done");

        }
        else {
        GameManager1.completed("minigame1");
                Debug.Log("Gabe game 1 done");

                for(int x = SlotList.Count-1; x >= 0; x--) {
                    Destroy(SlotList[x]);
                    SlotList.RemoveAt(x);
                }


                for(int x = utensils.Count-1; x >= 0; x--) {
                    Destroy(utensils[x]);
                    utensils.RemoveAt(x);
                }

        }
    }
}
