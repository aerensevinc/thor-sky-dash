using System.Collections;
using UnityEngine;

public class FlyingSkeleton : Obstacle
{
    public float horizontalSpeed = 2f;
    private int direction = 1;
    public override void Move()
    {
        float thor_x = GameManager.instance.Thor.transform.position.x;
        if (Mathf.Abs(transform.position.x - thor_x) < 0.1f) direction = 0;
        else direction = thor_x > transform.position.x ? 1 : -1;
        float changeX = direction * horizontalSpeed * Time.deltaTime;
        float changeY = GameManager.instance.gameSpeed * speedConstant * Time.deltaTime;
        transform.position += new Vector3(changeX, -changeY, 0);
    }
}
