using System.Collections;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class FrostGoblin : Obstacle
{
    private int direction;
    private void Start()
    {
        direction = transform.position.x > 3f ? -1 : 1;
    }
    public override void Move()
    {
        float changeX = gameSpeed * horizontalSpeed * direction * Time.deltaTime;
        float changeY = -gameSpeed * verticalSpeed * Time.deltaTime;
        transform.position += new Vector3(changeX, changeY, 0);
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            direction = -direction;
        }
    }
}
