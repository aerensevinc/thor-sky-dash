using System;
using System.Collections;
using UnityEngine;

public class FlyingSkeleton : Obstacle
{
    private int direction = 1;
    public override void Move()
    {
        GameManager gameManager = GameManager.instance;
        float thor_x = gameManager.Thor.transform.position.x;
        float gameSpeed = gameManager.gameSpeed;
        if (Mathf.Abs(transform.position.x - thor_x) < 0.1f)
        {
            direction = 0;
        }
        else
        {
            direction = thor_x > transform.position.x ? 1 : -1;
        }
        float changeX = gameSpeed * horizontalSpeed * direction * Time.deltaTime;
        float changeY = gameSpeed * verticalSpeed * Time.deltaTime;
        transform.position += new Vector3(changeX, -changeY, 0);
    }
}
