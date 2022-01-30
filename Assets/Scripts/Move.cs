using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Top Down Movement, used for OUTSIDE of minigames. */

public class Move: MonoBehaviour {

    public bool canMove = true;
     public float speed = 15;
     private Vector2 velocity;
     private Rigidbody2D rb;
     private void Awake() {
          rb = GetComponent<Rigidbody2D>();
          velocity = Vector2.zero;
     }
     private void Update() {
        if (!canMove)
            return;
          velocity.x = Input.GetAxisRaw("Horizontal");
          velocity.y = Input.GetAxisRaw("Vertical");
     }
     private void FixedUpdate() {
           rb.MovePosition(rb.position + 
                (velocity.normalized * speed *
                 Time.fixedDeltaTime)); 
     }
}