using UnityEngine;
using UnityEngine.UIElements;

public abstract class Obstacle : Interactable
{
    public int pointsOnceDestroyed = 5;
    public int maxHealth;
    [HideInInspector]
    public int health;
    public override void Interact()
    {
        if (GameManager.instance.isThorInvincible)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.instance.gameOver = true;
        }
    }
    private void Awake()
    {
        health = maxHealth;
    }
}