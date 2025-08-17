using System;
using UnityEngine;

public class BlackSword : Obstacle
{
    private Vector2 direction;
    private void Start()
    {
        direction = -transform.up;
        direction = direction.normalized;
    }
    public override void Move()
    {
        Vector2 change = gameSpeed * verticalSpeed * Time.deltaTime * direction;
        transform.position += (Vector3)change;
    }
}