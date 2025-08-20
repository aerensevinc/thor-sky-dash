using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Loki : SpawnerBoss
{
    public override void DoBeforeSpawn()
    {
        GameManager.instance.Thor.GetComponent<MoveScript>().ReverseControls();
        SpriteManager.instance.currentSprite = SpriteManager.instance.spriteList[1];
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
        transform.position += new Vector3(DeltaX(0.4f), DeltaY(), 0);
    }

    protected override void WhenDestroyed()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null)
        {
            gameManager.Thor.GetComponent<MoveScript>().UnReverseControls();
            SpriteManager.instance.currentSprite = SpriteManager.instance.spriteList[0];
        }
    }
}