using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Loki : SpawnerBoss
{
    public override void DoBeforeSpawn()
    {
        GameManager.instance.Thor.GetComponent<MoveScript>().ReverseControls();
        GameManager.instance.thorSprite.color = Color.limeGreen;
    }

    public override void MoveWhileSpawning()
    {
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += Vector3.right * DeltaX();
    }

    public override void MoveWhileExit()
    {
        if (Mathf.Abs(transform.position.x) > 2.8f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += new Vector3(0.5f * DeltaX(), DeltaY(), 0);
    }

    protected override void WhenDestroyed()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null)
        {
            gameManager.Thor.GetComponent<MoveScript>().UnReverseControls();
            gameManager.thorSprite.color = Color.white;
        }
    }
}