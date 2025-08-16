using System;
using System.Collections;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class IceMonster : Boss
{
    public GameObject IceSpike;
    public float y_position;
    public float spawnRate;
    public float spawnDuration;
    private bool isSpawning;
    private bool spawningOver;
    private int direction;
    private void Start()
    {
        isSpawning = false;
        spawningOver = false;
        direction = transform.position.x > 3f ? -1 : 1;
    }

    public override void Move()
    {
        float gameSpeed = GameManager.instance.gameSpeed;
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            direction = -direction;
        }
        if (!isSpawning && !spawningOver && transform.position.y <= y_position)
        {
            StartCoroutine(SpawnRoutine());
            isSpawning = true;
        }
        float changeX = gameSpeed * horizontalSpeed * direction * Time.deltaTime;
        float changeY = isSpawning ? 0 : gameSpeed * verticalSpeed * Time.deltaTime;
        transform.position += new Vector3(changeX, -changeY, 0);
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