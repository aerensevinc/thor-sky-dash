using UnityEngine;

public class CollusionScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Interactable interactable = collision.collider.GetComponentInParent<Interactable>();
        Debug.Log($"collided with: {collision.gameObject.name}");
        if (interactable != null)
        {
            interactable.Interact();
        }
    }
}