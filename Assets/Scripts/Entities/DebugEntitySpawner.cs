using UnityEngine;

public class DebugEntitySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Enemy enemyToSpawn;
    public float timeBetweenSpawns;
    public float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeBetweenSpawns)
        {
            currentTime -= timeBetweenSpawns;
            Instantiate(enemyToSpawn, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
    }
}
