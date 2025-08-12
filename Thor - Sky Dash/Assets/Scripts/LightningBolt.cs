using System.Collections;
using UnityEngine;

public class LightningBolt : Interactable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Obstacle>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    public override void Interact()
    {
    }
}