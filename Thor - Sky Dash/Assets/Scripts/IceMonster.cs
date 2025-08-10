using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class IceMonster : Obstacle
{
    public GameObject IceSpike;
    public float spawnRate = 2f;
    public float y_position = 3f;
    public float horizontalSpeed = 1f;
    public float x_limit = 3f;
    public float spawnDuration = 10f;
    private bool isSpawning = false;
    private bool spawningOver = false;
    private int direction = 1;

    public override void Move()
    {
        if (x_limit - Mathf.Abs(transform.position.x) < 0.2f)
        {
            direction = -direction;
        }
        if (!isSpawning && !spawningOver && transform.position.y <= y_position)
        {
            StartCoroutine(SpawnRoutine(spawnDuration));
            isSpawning = true;
        }
        float changeY = isSpawning ? 0 : GameManager.instance.gameSpeed * speedConstant * Time.deltaTime;
        float changeX = horizontalSpeed * direction * Time.deltaTime;
        transform.position += new Vector3(changeX, -changeY, 0);
    }

    private IEnumerator SpawnRoutine(float spawnDuration)
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