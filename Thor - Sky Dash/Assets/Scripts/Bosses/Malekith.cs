using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Malekith : SpawnerBoss
{
    public override void MoveWhileExit()
    {
        float thor_x = GameManager.instance.Thor.transform.position.x;
        if (Mathf.Abs(thor_x - transform.position.x) < 0.05f)
        {
            horizontalDirection = 0;
        }
        else
        {
            horizontalDirection = thor_x > transform.position.x ? 1 : -1;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    protected override IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        isSpawning = true;
        while (timer < spawnDuration)
        {
            Instantiate(spawnedObject, Vector3.up * 10, quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
            timer += spawnRate;
        }
        yield return new WaitForSeconds(3);
        isSpawning = false;
        spawningOver = true;
    }
}