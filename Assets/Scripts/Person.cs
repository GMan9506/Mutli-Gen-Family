using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    // NPC Class
    public List<Transform> waypoints; 
    public float speed;
    private Transform next_pos;
    private int currentPos;

    // Start is called before the first frame update
    void Start()
    {
        next_pos = waypoints[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waypoints.Count != 0) {
            moveToNextPoint();
        }
    }

    private void moveToNextPoint() {
        if(Vector2.Distance(transform.position,next_pos.position) > 0.5f) {
            transform.position = Vector2.Lerp(transform.position, next_pos.position, speed);
            Debug.Log("moving");
        }
        else
            {
            currentPos = ((currentPos + 1) == waypoints.Count) ? 0 : currentPos + 1;
            next_pos = waypoints[currentPos];
            }
    }
}
