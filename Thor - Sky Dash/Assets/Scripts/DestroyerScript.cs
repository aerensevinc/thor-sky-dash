using System.Diagnostics;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obstacle = collision.gameObject;
        if (obstacle.GetComponentInParent<Obstacle>() != null)
        {
            GameManager.instance.points += obstacle.GetComponentInParent<Obstacle>().pointsOnceDestroyed;
        }
        Destroy(collision.gameObject);
    }
}