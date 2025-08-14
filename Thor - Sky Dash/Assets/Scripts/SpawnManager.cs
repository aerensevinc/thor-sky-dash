using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public SpawnManager instance;
    [HideInInspector]
    public bool isSpawning;
    public float obstacleSpawnRate;
    public float powerUpSpawnRate;
    public float x_limit = 3f;
    public List<SpawnableEntry> obstacleList, powerUpList;
    private static float lastSpawnPosition;
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
        isSpawning = true;
        lastSpawnPosition = 0;
        StartSpawning();
    }
    public void StartSpawning()
    {
        StartCoroutine(SpawnRoutine(obstacleList, obstacleSpawnRate));
        StartCoroutine(SpawnRoutine(powerUpList, powerUpSpawnRate));
    }

    private IEnumerator SpawnRoutine(List<SpawnableEntry> list, float spawnRate)
    {
        while (isSpawning)
        {
            float xPosition;
            while (true)
            {
                xPosition = UnityEngine.Random.Range(-x_limit, x_limit);
                if (Mathf.Abs(xPosition - lastSpawnPosition) > 1f) break;
            }
            lastSpawnPosition = xPosition;
            GameObject currentObject = GetRandomInList(list);
            UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(xPosition, 10, 0);
            Instantiate(currentObject, spawnPosition, quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
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