using System.Collections;
using UnityEngine;

public class LightningPowerUp : Interactable
{
    public float spawnDuration;
    public float spawnRate;

    public override void Interact()
    {
        AudioManager.instance.PlaySound(interactSound, true);
        GameManager.instance.Thor.GetComponent<ThorScript>().ThrowLightning(spawnDuration, spawnRate);
        Destroy(gameObject);
    }
}