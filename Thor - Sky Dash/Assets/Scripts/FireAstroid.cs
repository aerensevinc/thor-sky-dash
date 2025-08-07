using Unity.VisualScripting;
using UnityEngine;

public class FireAstroid : Interactable
{
    public override void Interact()
    {
        Debug.Log("Game Over!");
    }
    public void Start()
    {
        fallSpeed *= 2;
    }
}
