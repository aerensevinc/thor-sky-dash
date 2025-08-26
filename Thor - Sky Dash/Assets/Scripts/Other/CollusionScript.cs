using UnityEngine;

public class CollusionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Interactable interactable = collision.collider.GetComponentInParent<Interactable>();
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}