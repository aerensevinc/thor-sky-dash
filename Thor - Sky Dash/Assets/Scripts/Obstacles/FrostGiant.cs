using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FrostGiant : Obstacle
{
    public float horizontalSpeed = 1f;
    public float horizontalTime = 2f;
    private bool isMovingLeft = true;
    private void Start()
    {
        StartCoroutine(ZigZagRoutine(horizontalTime));
    }
    public override void Move()
    {
        float gameSpeed = GameManager.instance.gameSpeed;
        if (isMovingLeft)
        {
            transform.position += new Vector3(-horizontalSpeed, -1, 0) * gameSpeed * speedConstant * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(horizontalSpeed, -1, 0) * gameSpeed * speedConstant * Time.deltaTime;
        }
        if (3f - Mathf.Abs(transform.position.x) < 0.1f)
        {
            isMovingLeft = !isMovingLeft;
        }
    }
    private IEnumerator ZigZagRoutine(float duration)
    {
        while (true)
        {
        isMovingLeft = !isMovingLeft;
        yield return new WaitForSeconds(duration);
        }
    }
}