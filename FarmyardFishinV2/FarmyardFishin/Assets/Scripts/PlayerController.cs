using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f; // player movement speed
    public float xRange = 26; // range size of player movement border
    public float yRangeUpper = 18.5f; // range size of player movement border
    public float yRangeLower = 0.5f; // range size of player movement border
    private float fixedZAxis = -26; // fixed z axis for player movement (player should only be able to move in x and y directions)

    public float horizontalInput;
    public float verticalInput;

    public GameObject player;
    public GameObject enemy;
    public GameObject attachedFriend;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
            if (gameController == null)
            {
                gameController = FindObjectOfType<GameController>();
            }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        Vector3 positionZ = transform.position;
        positionZ.z = fixedZAxis;
        transform.position = positionZ;


        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y < yRangeLower)
        {
            transform.position = new Vector3(transform.position.x, yRangeLower, transform.position.z);
        }

        if (transform.position.y > yRangeUpper)
        {
            transform.position = new Vector3(transform.position.x, yRangeUpper, transform.position.z);
        }
        // these 4 if statements constrain the player within the level


        // logic to detach animal from player
        if (attachedFriend != null && Input.GetKeyDown(KeyCode.Space)) // spacebar key to detach animal (might remove this later, dont know if we really need it)
        {
            attachedFriend.transform.SetParent(null);
            Debug.Log("Friend detached!");
            attachedFriend = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Lose a life and destroy the enemy
            gameController.LoseLife();
            Destroy(collision.gameObject);

            Debug.Log($"Lives Remaining: {gameController.lives}");

        }
        else if (collision.gameObject.CompareTag("Friend") && attachedFriend == null)
        { // checks if an animal is already attached or not as only one animal can be attached at a time
            attachedFriend = collision.gameObject;

            // attach animal to player
            attachedFriend.transform.SetParent(player.transform);
            attachedFriend.GetComponent<NPCMovement>().speed = 0f; // sets animal speed to zero after being attached

            Rigidbody friendRigidbody = attachedFriend.GetComponent<Rigidbody>();
            if (friendRigidbody != null) Destroy(friendRigidbody);
    
            Collider friendCollider = attachedFriend.GetComponent<Collider>(); // removing the collider and rigidbody from the attached animal here to prevent movement from messing up on the player
            if (friendCollider != null) friendCollider.enabled = false;

            Debug.Log("Friend attached!");
        }
    }
}