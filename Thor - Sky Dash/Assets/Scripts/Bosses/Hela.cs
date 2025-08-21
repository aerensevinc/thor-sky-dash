using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Android.Gradle;
using Unity.Mathematics;
using UnityEngine;

public class Hela : SpawnerBoss
{
    public override void DoBeforeSpawn()
    {
        horizontalDirection = UnityEngine.Random.value > 0.5f ? 1 : -1;
    }
    
    public override void MoveWhileExit()
    {
        if (Mathf.Abs(transform.position.x) > 2f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    protected override IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        isSpawning = true;
        while (timer < spawnDuration)
        {
            Instantiate(spawnedObject, transform.position + Vector3.down, RotateTowardsThor());
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        spawningOver = true;
        isSpawning = false;
    }
    public Quaternion RotateTowardsThor()
    {
        Vector3 thorPosition = GameManager.instance.Thor.transform.position;
        float dX = transform.position.x - thorPosition.x;
        float dY = transform.position.y - thorPosition.y;
        float zAngle = Mathf.Atan2(dY, dX) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, zAngle - 90f);
    }
}