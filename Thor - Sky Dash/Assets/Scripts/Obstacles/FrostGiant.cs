using System.Collections;
using TMPro;
using UnityEngine;

public class FrostGiant : Obstacle
{
    public float horizontalSpeed = 1f;
    public float horizontalTime = 2f;
    private bool isMovingLeft = true;
    void Start()
    {
        StartCoroutine(ZigZagRoutine());
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
        
    }
    private IEnumerator ZigZagRoutine()
    {
        while (true)
        {
        isMovingLeft = !isMovingLeft;
        yield return new WaitForSeconds(horizontalTime);
        }
    }
}