using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlot : MonoBehaviour
{
    public DraggableObject.ObjectType SlotType;
    public bool isFilled = false;
    DraggableObject ObjectToSet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isFilled)
        {
            ObjectToSet = collision.gameObject.GetComponent<DraggableObject>();
            if (ObjectToSet.Type == SlotType)
                ObjectToSet.SlotToSet = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!isFilled)
        {
            ObjectToSet.SlotToSet = null;
            ObjectToSet = null;
        }
    }
}
