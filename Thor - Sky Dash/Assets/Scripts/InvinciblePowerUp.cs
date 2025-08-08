using System.Collections;
using UnityEngine;

public class InvinciblePowerUp : Interactable
{
    public float powerUpDuration = 2f;
    public int powerUpColor = 0xB0C2F0;
    public override void Interact()
    {
        GameManager.instance.MakeThorInvincible(powerUpDuration);
        Destroy(gameObject);
    }
}