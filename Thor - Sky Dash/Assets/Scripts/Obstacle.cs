using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Obstacle : Interactable
{
    public int pointsOnceDestroyed = 5;
    public override void Interact()
    {
        if (GameManager.instance.isThorInvincible)
        {
            GameManager.instance.points += pointsOnceDestroyed;
            Destroy(gameObject);
        }
        else
        {
            GameManager.instance.health--;
            Destroy(gameObject);
        }
    }
}