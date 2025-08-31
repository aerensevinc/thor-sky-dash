using UnityEngine;

public class Coin : Interactable
{
    public override void Interact()
    {
        GameManager.instance.coinCount++;
        Destroy(gameObject);
        AudioManager.instance.PlaySound(interactSound, true);
    }
}