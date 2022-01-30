using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlot : MonoBehaviour
{
    public DraggableObject.ObjectType SlotType;
    public DraggableObject.FamilyMember FamilySeat;
    public bool isFilled = false;
    public bool IsFilled
    {
        get { return isFilled; }
        set
        {
            if (value == isFilled)
                return;
            else
            {
                isFilled = value;
                if (isFilled == true)
                {
                    if (!ObjectToSet.isPortrait && ObjectToSet.Type == SlotType)
                        isCorrect = true;
                    else if (ObjectToSet.isPortrait && ObjectToSet.Member == FamilySeat)
                        isCorrect = true;
                }
                else
                    isCorrect = false;
            }
        }

    }

    public bool isCorrect = false;
    DraggableObject ObjectToSet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DraggableObject coll = collision.GetComponent<DraggableObject>();
        if (!ObjectToSet)
            ObjectToSet = coll;
        if(!isFilled)
        {
            if (ObjectToSet.Type == SlotType || ObjectToSet.isPortrait)
            {
                ObjectToSet = collision.gameObject.GetComponent<DraggableObject>();
                ObjectToSet.SlotToSet = this;             
            }                     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ObjectToSet == collision.gameObject.GetComponent<DraggableObject>())// != collision.gameObject.GetComponent<DraggableObject>())
        {
            ObjectToSet.SlotToSet = null;
            ObjectToSet = null;
            IsFilled = false;
        }
    }
}
