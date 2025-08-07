using System.Collections;
using UnityEngine;

public class TimePowerUp : Interactable
{
    public float powerUpIntensity = 10f;
    public float powerUpDuration = 4f;
    public override void Interact()
    {
        Debug.Log("Slowing down time.");
        StartCoroutine(SlowGameSpeed());
        Destroy(gameObject);
    }
    private IEnumerator SlowGameSpeed()
    {
        GameManager.instance.gameSpeed /= powerUpIntensity;
        yield return new WaitForSeconds(powerUpDuration);
        GameManager.instance.gameSpeed *= powerUpIntensity;
    }
}