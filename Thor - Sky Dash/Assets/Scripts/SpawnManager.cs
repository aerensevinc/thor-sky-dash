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
    public float x_limit;
    public List<SpawnableEntry> obstacleList, powerUpList, bossList;
    private Coroutine obsRoutine, powRoutine;
    private float lastSpawnPosition;
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
        lastSpawnPosition = 0;
        StartSpawning();
        StartCoroutine(BossSpawnRoutine());
    }
    public void StartSpawning()
    {
        Debug.Log("starting spawning!");
        obsRoutine = StartCoroutine(SpawnRoutine(obstacleList, obstacleSpawnRate));
        powRoutine = StartCoroutine(SpawnRoutine(powerUpList, powerUpSpawnRate));
    }
    public void StopSpawning()
    {
        Debug.Log("stoping spawning");
        StopCoroutine(obsRoutine);
        StopCoroutine(powRoutine);
    }
    private IEnumerator SpawnRoutine(List<SpawnableEntry> list, float spawnRate)
    {
        while (true)
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
    private IEnumerator BossSpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(bossSpawnRate);
            GameObject currentBoss = GetRandomInList(bossList);
            Instantiate(currentBoss, transform.position, quaternion.identity);
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