using System;
using System.Collections;
using UnityEngine;

public class FlyingSkeleton : Obstacle
{
    public float horizontalSpeed = 2f;
    private int direction = 1;
    public override void Move()
    {
        float thor_x;
        float gameSpeed = GameManager.instance.gameSpeed;
        if (GameManager.instance.Thor != null)
        {
            thor_x = GameManager.instance.Thor.transform.position.x;
            if (Mathf.Abs(transform.position.x - thor_x) < 0.1f) direction = 0;
            else direction = thor_x > transform.position.x ? 1 : -1;
        }
        else
        {
            direction = 0;
        }
        float changeX = gameSpeed * horizontalSpeed * direction * Time.deltaTime;
        float changeY = gameSpeed * speedConstant * Time.deltaTime;
        transform.position += new Vector3(changeX, -changeY, 0);
    }
}
