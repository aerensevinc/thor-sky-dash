using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class FrostGoblin : Obstacle
{
    private int direction;
    private void Start()
    {
        direction = 1;
    }
    public override void Move()
    {
        float change = GameManager.instance.gameSpeed * speedConstant * Time.deltaTime;
        transform.position += new Vector3(direction, -1, 0) * change;
        if (Mathf.Abs(transform.position.x) > 2.95f)
        {
            direction = -direction;
        }
    }
}
