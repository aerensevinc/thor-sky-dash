using UnityEngine;

public class SpeedPowerUp : Interactable
{
    public float intensity;
    public float duration;
    
    public override void Interact()
    {
        AudioManager.instance.PlaySound(interactSound, true);
        GameManager.instance.Thor.GetComponent<MoveScript>().MakeThorFaster(intensity, duration);
        Destroy(gameObject);
    }
}
