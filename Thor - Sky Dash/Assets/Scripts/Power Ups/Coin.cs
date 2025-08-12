using UnityEngine;

public class Coin : Interactable
{
    public override void Interact()
    {
        Destroy(gameObject);
        GameManager.instance.coinCount += 1;
    }
}