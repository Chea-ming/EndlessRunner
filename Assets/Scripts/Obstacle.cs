using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn, spawnObject; // The object to spawn
    public float minX, maxX; // Range for random X position
    public float minY, maxY; // Range for random Y position
    public float timeBetweenSpawn; // Time interval between spawns
    public float objectLifetime = 5f; // Time before the object is destroyed

    private float spawnTime; // Timer to track spawn time

    void Update()
    {
        if(Time.time > spawnTime) {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        // Generate random X and Y positions within the specified ranges
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Instantiate the object at the random position with no rotation
        spawnObject = Instantiate(objectToSpawn, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

        // Start the coroutine to destroy the object after a certain time
        StartCoroutine(DestroyAfterTime(spawnObject, objectLifetime));
    }

    private IEnumerator DestroyAfterTime(GameObject obj, float time)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Destroy the object
        Destroy(obj);
    }
}