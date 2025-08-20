using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Surtur : SpawnerBoss
{
    private static float previousFireball_X;
    private float surturX;
    private void Start()
    {
        isSpawning = false;
        spawningOver = false;
        surturX = UnityEngine.Random.Range(-2f, 2f);
        Debug.Log($"surturs position is: {surturX}");
    }

    public override void MoveWhileExit()
    {
        float currentX = transform.position.x;
        if (Mathf.Abs(currentX - surturX) < 0.2f)
        {
            horizontalDirection = 0;
        }
        else
        {
            horizontalDirection = surturX > currentX ? 1 : -1;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }

    protected override Vector3 SpawnPosition()
    {
        float currentFireball_X;
        do
        {
            currentFireball_X = UnityEngine.Random.Range(-3.2f, 3.2f);
        }
        while (Mathf.Abs(currentFireball_X - previousFireball_X) < 1.8f);
        previousFireball_X = currentFireball_X;
        return new Vector3(currentFireball_X, 8.5f, 0);
    }
}