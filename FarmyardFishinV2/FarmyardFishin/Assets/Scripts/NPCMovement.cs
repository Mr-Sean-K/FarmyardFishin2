using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // this script controls npc movement speed and direction
    private bool isMovingRight = true;
    public float speed = 2f; // npc movement speed


    // This method will be called from the SpawnManager to tell the NPC which way to go
    public void SetDirection(bool movementDirection)
    {
        isMovingRight = movementDirection;  // if movement direction is true, set the NPC to move right, else set it to move left
    }

    void Update()
    {

        float direction = isMovingRight ? 1f : -1f;  // 1 means move right, -1 means move left

        // Move the NPC in the correct direction, based on the speed
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);
    }
}