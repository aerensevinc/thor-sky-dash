using System.Collections;
using UnityEngine;

public class InvinciblePowerUp : Interactable
{
    public float powerUpDuration = 2f;
    public override void Interact()
    {
        GameManager.instance.MakeThorInvincible(powerUpDuration);
        Destroy(gameObject);
    }
}