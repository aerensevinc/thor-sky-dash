using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [HideInInspector]
    public static SpawnManager instance;
    public float bossSpawnRate;
    public float obstacleSpawnRate;
    public float powerUpSpawnRate;
    public List<SpawnableEntry> obstacleList, powerUpList, bossList;
    [HideInInspector]
    public bool isSpawningBoss;
    private float lastSpawnPosition;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        lastSpawnPosition = 0;
        isSpawningBoss = false;
        StartCoroutine(SpawnRoutine(obstacleList, obstacleSpawnRate));
        StartCoroutine(SpawnRoutine(powerUpList, powerUpSpawnRate));
        StartCoroutine(BossSpawnRoutine());
    }

    private IEnumerator SpawnRoutine(List<SpawnableEntry> list, float spawnRate)
    {
        yield return new WaitUntil(() => GameManager.instance.IsGameActive());
        while (GameManager.instance.IsGameActive())
        {
            yield return new WaitUntil(() => !isSpawningBoss);
            float xPosition;
            while (true)
            {
                xPosition = UnityEngine.Random.Range(-3f, 3f);
                if (Mathf.Abs(xPosition - lastSpawnPosition) > 1f) break;
            }
            lastSpawnPosition = xPosition;
            GameObject currentObject = GetRandomInList(list);
            UnityEngine.Vector3 spawnPosition = new UnityEngine.Vector3(xPosition, 10, 0);
            Instantiate(currentObject, spawnPosition, quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator BossSpawnRoutine()
    {
        yield return new WaitUntil(() => GameManager.instance.IsGameActive());
        while (GameManager.instance.IsGameActive())
        {
            yield return new WaitUntil(() => !isSpawningBoss);
            yield return new WaitForSeconds(bossSpawnRate);
            GameObject currentBoss = GetRandomInList(bossList);
            Instantiate(currentBoss, UnityEngine.Vector3.up * 10.5f, quaternion.identity);
        }
    }

    private GameObject GetRandomInList(List<SpawnableEntry> list)
    {
        float counter = 0f;
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