using System;
using System.Collections;
using UnityEngine;

public class FlyingSkeleton : Obstacle
{
    public override void Move()
    {
        float thor_x = GameManager.instance.Thor.transform.position.x;
        if (Mathf.Abs(transform.position.x - thor_x) < 0.1f)
        {
            horizontalDirection = 0;
        }
        else
        {
            horizontalDirection = thor_x > transform.position.x ? 1 : -1;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
    }
}