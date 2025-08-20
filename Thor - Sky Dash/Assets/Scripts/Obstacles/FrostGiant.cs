using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FrostGiant : Obstacle
{
    public float zigZagRate;
    private void Start()
    {
        horizontalDirection = transform.position.x > 3f ? -1 : 1;
        StartCoroutine(ZigZagRoutine(zigZagRate));
    }
    public override void Move()
    {
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }
}