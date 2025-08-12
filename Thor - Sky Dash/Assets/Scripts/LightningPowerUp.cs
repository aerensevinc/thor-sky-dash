using System.Collections;
using UnityEngine;

public class LightningPowerUp : Interactable
{
    public float spawnDuration = 20f;
    public float spawnRate = 1f;
    public override void Interact()
    {
        GameManager.instance.Thor.GetComponent<ThorScript>().ThrowLightning(spawnDuration, spawnRate);
        Destroy(gameObject);
    }
}
