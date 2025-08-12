using System.Collections;
using UnityEngine;

public class TimePowerUp : Interactable
{
    public float powerUpIntensity = 10f;
    public float powerUpDuration = 20f;
    public override void Interact()
    {
        GameManager.instance.ChangeGameSpeed(1 / powerUpIntensity, powerUpDuration);
        Destroy(gameObject);
    }
}