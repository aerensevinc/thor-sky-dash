using System.Collections;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Obstacle : Interactable
{
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
    public virtual IEnumerator ZigZagRoutine(float zigZagRate)
    {
        while (true)
        {
            horizontalDirection = -horizontalDirection;
            yield return new WaitForSeconds(zigZagRate);
        }
    }
}