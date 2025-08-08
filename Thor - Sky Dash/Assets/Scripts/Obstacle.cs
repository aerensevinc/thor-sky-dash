using UnityEngine;

public abstract class Obstacle : Interactable
{
    public override void Interact()
    {
        if (GameManager.instance.isThorInvincible)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Game Over!");
        }
    }
}