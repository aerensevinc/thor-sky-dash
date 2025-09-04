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
            AudioManager.instance.PlaySound("crush", true);
            GameManager.instance.score += obstacle.pointsOnceDestroyed;
            Destroy(other);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        gameSpeed = GameManager.instance.gameSpeed;
        if (transform.position.y > 9f)
        {
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
    }
}