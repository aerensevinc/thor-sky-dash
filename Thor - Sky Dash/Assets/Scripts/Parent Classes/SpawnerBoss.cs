using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public abstract class SpawnerBoss : Boss
{
    public GameObject spawnedObject;
    public float spawnDuration;
    public float spawnRate;
    protected bool isSpawning;
    protected bool spawningOver;

    private void Start()
    {
        isSpawning = false;
        spawningOver = false;
    }

    public override void Move()
    {
        if (transform.position.y > yPosition)
        {
            MoveWhileEntry();
        }
        else if (!isSpawning && !spawningOver)
        {
            StartCoroutine(SpawnRoutine());
            DoBeforeSpawn();
        }
        else if (isSpawning && !spawningOver)
        {
            MoveWhileSpawning();
        }
        else
        {
            MoveWhileExit();
        }
    }

    public virtual void MoveWhileEntry()
    {
        transform.position += Vector3.up * DeltaY();
    }

    public virtual void DoBeforeSpawn()
    {
    }

    public virtual void MoveWhileSpawning()
    {
    }

    public virtual void MoveWhileExit()
    {
        transform.position += Vector3.up * DeltaY();
    }

    protected virtual IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        isSpawning = true;
        while (timer < spawnDuration && !GameManager.instance.gameOver)
        {
            Instantiate(spawnedObject, SpawnPosition(), quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        isSpawning = false;
        spawningOver = true;
    }

    protected virtual Vector3 SpawnPosition()
    {
        return transform.position;
    }
}