using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;

public class LightningBolt : Interactable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        Obstacle obstacle = other.GetComponentInParent<Obstacle>();
        Boss boss = other.GetComponentInParent<Boss>();
        if (obstacle != null && boss == null)
        {
            GameManager.instance.score += obstacle.pointsOnceDestroyed;
            Destroy(other);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
    }
}