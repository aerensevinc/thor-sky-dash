using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;

public class LightningBolt : Interactable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        Obstacle obstacle = other.GetComponentInParent<Obstacle>();
        if (obstacle != null)
        {
            if (--obstacle.health <= 0)
            {
                GameManager.instance.points += obstacle.pointsOnceDestroyed;
                Destroy(other);
            }
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
    }
}