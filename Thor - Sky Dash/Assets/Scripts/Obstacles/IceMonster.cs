using System;
using System.Collections;
using JetBrains.Annotations;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class IceMonster : Obstacle
{
    public GameObject IceSpike;
    public float spawnRate;
    public float zigZagRate;

    private void Start()
    {
        horizontalDirection = transform.position.x > 3f ? -1 : 1;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(ZigZagRoutine(zigZagRate));
    }

    public override void Move()
    {
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            horizontalSpeed = -horizontalSpeed;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    private IEnumerator SpawnRoutine()
    {
        while (GameManager.instance.IsGameActive() && transform.position.y > -7f)
        {
            Instantiate(IceSpike, transform.position + 1.3f*Vector3.down, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}