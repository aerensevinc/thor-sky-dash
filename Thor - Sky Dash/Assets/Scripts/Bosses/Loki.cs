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
        SpriteRenderer thorSprite = GameManager.instance.thorSprite;
        if (Mathf.Abs(transform.position.x) > 3f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += Vector3.right * DeltaX();
        if (thorSprite.color == Color.white)
        {
            thorSprite.color = Color.limeGreen;
        }
    }

    public override void MoveWhileExit()
    {
        SpriteRenderer thorSprite = GameManager.instance.thorSprite;
        if (Mathf.Abs(transform.position.x) > 2.9f)
        {
            horizontalDirection = -horizontalDirection;
        }
        transform.position += new Vector3(DeltaX(), DeltaY(), 0);
        if (thorSprite.color == Color.white)
        {
            thorSprite.color = Color.limeGreen;
        }
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