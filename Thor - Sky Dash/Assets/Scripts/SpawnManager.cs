using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnManager instance;
    public float obstacleSpawnRate;
    public float powerUpSpawnRate;
    public float x_limit = 3f;
    public List<SpawnableEntry> obstacleList, powerUpList;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnObstacleRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }
    private IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject currentObstacle = GetRandomInList(obstacleList);
            UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(UnityEngine.Random.Range(-x_limit, x_limit), 10, 0);
            Instantiate(currentObstacle, spawnPosition, quaternion.identity);
            yield return new WaitForSeconds(obstacleSpawnRate);
        }
    }
    private IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        { 
            GameObject currentPowerUp = GetRandomInList(powerUpList);
            UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(UnityEngine.Random.Range(-x_limit, x_limit), 10, 0);
            Instantiate(currentPowerUp, spawnPosition, quaternion.identity);
            yield return new WaitForSeconds(powerUpSpawnRate);
        }
    }
    private GameObject GetRandomInList(List<SpawnableEntry> list)
    {
        float counter = 0;
        float totalWeight = 0f;
        foreach (var entry in list)
        {
            totalWeight += entry.spawnWeight;
        }
        float randomValue = UnityEngine.Random.Range(0f, totalWeight);
        foreach (var entry in list)
        {
            counter += entry.spawnWeight;
            if (counter >= randomValue)
            {
                return entry.preFab;
            }
        }
        return null;
    }
}

[System.Serializable]
public class SpawnableEntry
{
    public GameObject preFab;
    public float spawnWeight;
}