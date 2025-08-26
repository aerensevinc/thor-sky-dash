using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class IceMonster : Boss
{
    public GameObject IceSpike;
    public float spawnRate;
    public float spawnDuration;
    private bool isSpawning;
    private bool spawningOver;
    private void Start()
    {
        isSpawning = false;
        spawningOver = false;
        horizontalDirection = transform.position.x > 3f ? -1 : 1;
    }

    public override void Move()
    {
        if (Mathf.Abs(transform.position.x) > 2.8f)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        if (!isSpawning && !spawningOver && transform.position.y <= yPosition)
        {
            StartCoroutine(SpawnRoutine());
            isSpawning = true;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }
    public override float DeltaY()
    {
        return isSpawning ? 0 : -gameSpeed * verticalSpeed * Time.deltaTime;
    }

    private IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        while (timer < spawnDuration)
        {
            Instantiate(IceSpike, transform.position + Vector3.down, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        spawningOver = true;
        isSpawning = false;
    }
}