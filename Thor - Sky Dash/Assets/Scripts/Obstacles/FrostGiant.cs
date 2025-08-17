using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FrostGiant : Obstacle
{
    public float zigZagRate;
    private int direction;
    private void Start()
    {
        direction = transform.position.x > 3f ? -1 : 1;
        StartCoroutine(ZigZagRoutine());
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
    private IEnumerator ZigZagRoutine()
    {
        while (true)
        {
            direction = -direction;
            yield return new WaitForSeconds(zigZagRate);
        }
    }
}