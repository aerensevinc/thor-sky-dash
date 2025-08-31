using UnityEngine;

public class HeartPowerUp : Interactable
{
    public override void Interact()
    {
        GameManager.instance.health++;
        Destroy(gameObject);
        AudioManager.instance.PlaySound(interactSound, true);
    }
}