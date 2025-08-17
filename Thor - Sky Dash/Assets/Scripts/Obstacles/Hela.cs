using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.Android.Gradle;
using Unity.Mathematics;
using UnityEngine;

public class Hela : Boss
{
    public GameObject blackSword;
    public float spawnDuration;
    public float spawnRate;
    public float yPosition;
    private bool isSpawning;
    private bool spawningOver;
    private int direction;
    private void Start()
    {
        isSpawning = false;
        spawningOver = false;
        direction = UnityEngine.Random.value > 0.5f ? 1 : -1;
        StartCoroutine(SpawnRoutine());
    }
    public override void Move()
    {
        float changeY = -gameSpeed * verticalSpeed * Time.deltaTime;
        if (transform.position.y > yPosition)
        {
            transform.position += Vector3.up * changeY;
        }
        else if (spawningOver)
        {
            direction = Mathf.Abs(transform.position.x) > 1.8f ? -direction : direction;
            float changeX = gameSpeed * direction * horizontalSpeed * Time.deltaTime;
            transform.position += new Vector3(changeX, changeY, 0);
        }
        else
        {
            isSpawning = true;
        }
    }
    private IEnumerator SpawnRoutine()
    {
        float timer = 0f;
        yield return new WaitUntil(() => isSpawning);
        while (timer < spawnDuration)
        {
            Instantiate(blackSword, transform.position + Vector3.down, RotateTowardsThor());
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