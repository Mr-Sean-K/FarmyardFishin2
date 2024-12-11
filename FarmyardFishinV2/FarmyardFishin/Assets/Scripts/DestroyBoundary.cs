using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    public float xLimit = 28;
    public float yLimit = 17;
    GameController gameController;

    void Update()
    {
        // destroys animals and fish that go off screen
        if (transform.position.x < -xLimit){
            Destroy(gameObject);
        }
        else if (transform.position.x > xLimit){
            Destroy(gameObject);
        }

        if (transform.position.y > yLimit){ // when animals are hooked and brought to the top of the river, a point is added and the animal is removed
            Destroy(gameObject);
            GameController.score++;
            Debug.Log("score: " + GameController.score);
        }
    }
}