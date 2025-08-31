using System.Collections;
using UnityEngine;

public class InvinciblePowerUp : Interactable
{
    public float powerUpDuration;
    public override void Interact()
    {
        AudioManager.instance.PlaySound(interactSound, true);
        GameManager.instance.MakeThorInvincible(powerUpDuration);
        Destroy(gameObject);
    }
}