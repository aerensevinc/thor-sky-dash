using System.Collections;
using UnityEngine;

public class LightningPowerUp : Interactable
{
    public float spawnDuration;
    public float spawnRate;

    public override void Interact()
    {
        GameManager.instance.Thor.GetComponent<ThorScript>().ThrowLightning(spawnDuration, spawnRate);
        Destroy(gameObject);
    }
}