using UnityEngine;

public class Coin : Interactable
{
    public override void Interact()
    {
        Destroy(gameObject);
        GameManager.instance.coinCount += 1;
        Debug.Log($"Current Coin Count : {GameManager.instance.coinCount}");
    }
}
