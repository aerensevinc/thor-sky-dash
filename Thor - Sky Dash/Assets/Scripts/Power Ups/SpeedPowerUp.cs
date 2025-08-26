using UnityEngine;

public class SpeedPowerUp : Interactable
{
    public float intensity;
    public float duration;
    
    public override void Interact()
    {
        GameManager.instance.Thor.GetComponent<MoveScript>().MakeThorFaster(intensity, duration);
        Destroy(gameObject);
    }
}
