using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public enum ObjectType {SPOON, FORK, KNIFE, PLATE, GLASS }
    public ObjectType Type;
    public ObjectSlot SlotToSet;

    public bool isDragging = false;
    public bool isSet = false;

    private void OnMouseDrag()
    {
        if (!isSet)
        {
            isDragging = true;
            transform.position = GetMousePos();
        }
    }
    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            if (SlotToSet)
            {
                isSet = true;
                transform.position = SlotToSet.transform.position;
                SlotToSet.isFilled = true;
                Table.instance.CheckSlotsFilled();
            }
        }
        
    }

}
