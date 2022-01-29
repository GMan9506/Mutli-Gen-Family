using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public static Table instance;
    [SerializeField] List<ObjectSlot> SlotList = new List<ObjectSlot>();
    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }

   public void CheckSlotsFilled()
    {
        foreach(ObjectSlot fSlot in SlotList)
        {
            if (!fSlot.isFilled)
                return;
        }
        Debug.Log("All spaces have been filled!");
    }
}
