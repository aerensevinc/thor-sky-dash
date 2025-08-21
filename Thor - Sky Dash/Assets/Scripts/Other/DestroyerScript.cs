using System.Diagnostics;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        Obstacle obstacle = other.GetComponentInParent<Obstacle>();
        if (obstacle != null)
        {
            GameManager.instance.points += obstacle.pointsOnceDestroyed;
        }
        Destroy(other);
    }
}