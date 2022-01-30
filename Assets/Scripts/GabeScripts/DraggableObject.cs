using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    public enum ObjectType {SPOON, FORK, KNIFE, PLATE, GLASS }
    public ObjectType Type;
    public enum FamilyMember {SON, DAUGHTER, MOM, DAD, GRANDMA, GRANDPA }
    public FamilyMember Member;

    public ObjectSlot SlotToSet;

    public bool isDragging = false; //used for mouse up function so only the one that is dragging will call the logic
    public bool isSet = false;
    public bool isPortrait = false;

    public AudioClip[] soundClips;

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
                //when an object is placed into the slot space, it will only lock in if it is correct,
                //however, for the seating minigame, they will all lock in, but are still changable until they are all correctly placed
                if (!isPortrait)
                    isSet = true;

                if (!SlotToSet.isFilled)
                {
                    transform.position = SlotToSet.transform.position;
                    SlotToSet.IsFilled = true;
                    if (soundClips.Length > 0)
                    {
                        if (!isPortrait)
                            PlaySound.OneShot(Camera.main.gameObject, (soundClips[Random.Range(0, soundClips.Length)]));
                        else
                            PlaySound.OneShot(Camera.main.gameObject, soundClips[0]);
                    }
                    Table.instance.CheckSlotsCondition();
                }
            }
        }
        
    }

}
