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
            AudioManager.instance.PlaySound("crush", true);
            gameManager.score += pointsOnceDestroyed;
            Destroy(gameObject);
        }
        else if (!gameManager.isOnCoolDown)
        {
            AudioManager.instance.PlaySound("damage", true);
            gameManager.health--;
            gameManager.StartCoolDown(1f);
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