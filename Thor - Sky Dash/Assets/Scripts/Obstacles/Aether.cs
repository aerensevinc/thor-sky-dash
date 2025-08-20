using System;
using UnityEngine;

public class Aether : Obstacle
{
    private static float previousSpawnPosition;
    private float currentSpawnPosition;

    private void Awake()
    {
        do
        {
            currentSpawnPosition = UnityEngine.Random.Range(-2.5f, 2.5f);
        }
        while (Mathf.Abs(previousSpawnPosition - currentSpawnPosition) < 1.4f);
        previousSpawnPosition = currentSpawnPosition;
    }

    public override void Move()
    {
        if (transform.position.y > 2.4f)
        {
            transform.position += Vector3.up * DeltaY();
        }
        else if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += new Vector3(DeltaX(), DeltaY(), 0);
        }
    }

    public override float DeltaX(float constant = 1)
    {
        if (Mathf.Abs(currentSpawnPosition - transform.position.x) < 0.1f)
        {
            horizontalDirection = 0;
            return 0f;
        }
        else
        {
            horizontalDirection = currentSpawnPosition > transform.position.x ? 1 : -1;
            return constant * gameSpeed * horizontalSpeed * horizontalDirection * Time.deltaTime;
        }
    }
}