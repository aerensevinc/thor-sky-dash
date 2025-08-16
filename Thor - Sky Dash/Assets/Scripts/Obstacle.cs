using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Obstacle : Interactable
{
    public float horizontalSpeed = 0;
    public int pointsOnceDestroyed;
    public override void Interact()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager.isThorInvincible)
        {
            gameManager.points += pointsOnceDestroyed;
            Destroy(gameObject);
        }
        else
        {
            gameManager.health--;
            Destroy(gameObject);
        }
    }
}