using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fishPrefabs;
    public GameObject[] animalPrefabs;

   //the limit on the X and Y axis in which the fish will spawn 
    public float spawnLimitXLeft = -27;
    public float spawnLimitXRight = 27;
    public float spawnLimitYDown = 7;
    public float spawnLimitYUp = 15;

    private Quaternion spawnRotationL = Quaternion.Euler(0, 90, 0);
    private Quaternion spawnRotationR = Quaternion.Euler(0, -90, 0);

    //speed and spawn rate
    public float startDelay = 1f;
    public float spawnInterval = 4f;
    public float spawnSpeed = 2f;    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFish", startDelay, spawnInterval);
        InvokeRepeating("SpawnAnimal", startDelay, spawnInterval); 

    }

void SpawnFish()
{
    // Generate a random fish in a random position
    int index = Random.Range(0, fishPrefabs.Length);
    float randomY = Random.Range(spawnLimitYDown, spawnLimitYUp);

    // X positions for left and right spawns
    Vector3 spawnPosLeft = new Vector3(spawnLimitXLeft, randomY, -26);
    Vector3 spawnPosRight = new Vector3(spawnLimitXRight, randomY, -26);

    // Spawn fish on the left moving right
    GameObject fishLeft = Instantiate(fishPrefabs[index], spawnPosLeft, spawnRotationL);
    NPCMovement fishMovementLeft = fishLeft.GetComponent<NPCMovement>();
    if (fishMovementLeft != null)
    {
        fishMovementLeft.SetDirection(true); // Move right
        fishMovementLeft.speed = Random.Range(8f, 15f); // Randomize speed
    }

    // Spawn fish on the right moving left
    GameObject fishRight = Instantiate(fishPrefabs[index], spawnPosRight, spawnRotationR);
    NPCMovement fishMovementRight = fishRight.GetComponent<NPCMovement>();
    if (fishMovementRight != null)
    {
        fishMovementRight.speed = Random.Range(8f, 15f); // Randomize speed
    }
}

void SpawnAnimal()
{
    int index = Random.Range(0, animalPrefabs.Length);

    // Positions for left and right spawns
    Vector3 spawnPosLeft = new Vector3(spawnLimitXLeft, 0.5f, -26);
    Vector3 spawnPosRight = new Vector3(spawnLimitXRight, 0.5f, -26);

    // Spawn animal on the left moving right
    GameObject animalLeft = Instantiate(animalPrefabs[index], spawnPosLeft, spawnRotationL);
    NPCMovement animalMovementLeft = animalLeft.GetComponent<NPCMovement>();
    if (animalMovementLeft != null)
    {
        animalMovementLeft.SetDirection(true); // Move right
        animalMovementLeft.speed = Random.Range(2f, 6f); // Randomize speed
    }

    // Spawn animal on the right moving left
    GameObject animalRight = Instantiate(animalPrefabs[index], spawnPosRight, spawnRotationR);
    NPCMovement animalMovementRight = animalRight.GetComponent<NPCMovement>();
    if (animalMovementRight != null)
    {
        animalMovementRight.speed = Random.Range(2f, 6f); // Randomize speed
    }
}

}