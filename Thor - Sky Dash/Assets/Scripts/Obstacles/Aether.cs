using System;
using UnityEngine;

public class Aether : Obstacle
{
    private static float lastSpawnPosition;
    private float currentSpawnPosition;
    private int direction;

    private void Start()
    {
        do
        {
            currentSpawnPosition = UnityEngine.Random.Range(-3f, 3f);
        }
        while (Mathf.Abs(lastSpawnPosition - currentSpawnPosition) > 4.5f);
        lastSpawnPosition = currentSpawnPosition;
    }

    public override void Move()
    {
        float changeY = -gameSpeed * verticalSpeed * Time.deltaTime;
        if (transform.position.y > 4f)
        {
            transform.position += Vector3.up * changeY;
        }
        else
        {
            if (Mathf.Abs(currentSpawnPosition - transform.position.x) < 0.1f)
            {
                direction = 0;
            }
            else
            {
                direction = currentSpawnPosition > transform.position.x ? 1 : -1;
            }
            float changeX = gameSpeed * horizontalSpeed * direction * Time.deltaTime;
            transform.position += new Vector3(changeX, changeY, 0);
        }
    }
}
