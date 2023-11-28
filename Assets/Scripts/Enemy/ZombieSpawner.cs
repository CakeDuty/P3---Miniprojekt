using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public int minZombies = 1;
    public int maxZombies = 5;
    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float minSpawnInterval = 7f;
    public float maxSpawnInterval = 15f;

    void Start()
    {
       
        InvokeRepeating("SpawnZombies", 0f, Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnZombies()
    {
        int numberOfZombies = Random.Range(minZombies, maxZombies + 1);

        for (int i = 0; i < numberOfZombies; i++)
        {
            Vector3 randomSpawnPoint = GetRandomSpawnPoint();
            Instantiate(zombiePrefab, randomSpawnPoint, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(minDistance, maxDistance);
        Vector3 randomSpawnPoint = new Vector3(randomCircle.x, 0f, randomCircle.y);
        return transform.position + randomSpawnPoint;
    }
}
