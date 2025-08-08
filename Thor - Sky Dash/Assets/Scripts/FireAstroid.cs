using Unity.VisualScripting;
using UnityEngine;

public class FireAstroid : Obstacle
{
    public float speedConstant = 2f;
    protected override void FixedUpdate()
    {
        fallSpeed = GameManager.instance.gameSpeed * speedConstant;
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}