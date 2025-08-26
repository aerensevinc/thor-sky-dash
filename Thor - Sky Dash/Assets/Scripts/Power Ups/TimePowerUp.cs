using System.Collections;
using UnityEngine;

public class TimePowerUp : Interactable
{
    public float powerUpIntensity;
    public float powerUpDuration;
    
    public override void Interact()
    {
        GameManager.instance.ChangeGameSpeed(1 / powerUpIntensity, powerUpDuration);
        Destroy(gameObject);
    }
}